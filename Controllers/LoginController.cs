using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Proyecto_Tokens.Models;
using Proyecto_Tokens.Data;
using Microsoft.AspNetCore.Identity;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly JwtService _jwtService;
    private readonly IPasswordHasher<UserModels> _passwordHasher;

    public LoginController(ApplicationDbContext context, JwtService jwtService, IPasswordHasher<UserModels> passwordHasher)
    {
        _context = context;
        _jwtService = jwtService;
        _passwordHasher = passwordHasher;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginUser model)
    {
        var usuario = _context.Usuarios.FirstOrDefault(u => u.Correo_Electronico == model.Correo_Electronico);

        if (usuario == null)
            return Unauthorized("Usuario no encontrado");

        var result = _passwordHasher.VerifyHashedPassword(usuario, usuario.Contraseña, model.Contraseña);

        if (result != PasswordVerificationResult.Success)
            return Unauthorized("Contraseña incorrecta");

        // Guardar el registro de login
        var loginRegistro = new LoginRegistro
        {
            Usuario = usuario,
           FechaHoraLogin = DateTime.UtcNow
        };

        _context.LoginRegistro.Add(loginRegistro);
        _context.SaveChanges();

        var token = _jwtService.GenerateToken(usuario.Correo_Electronico, usuario.Rol);
        return Ok(new { token });
    }

    [Authorize(Roles = "Administrador")]
    [HttpGet("admin")]
    public IActionResult AdminEndpoint()
    {
        return Ok("Solo administradores pueden ver esto.");
    }

    [Authorize(Roles = "Cliente")]
    [HttpGet("cliente")]
    public IActionResult ClienteEndpoint()
    {
        return Ok("Solo clientes pueden ver esto.");
    }

    [Authorize]
    [HttpGet("general")]
    public IActionResult CualquierUsuario()
    {
        return Ok("Cualquier usuario autenticado.");
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] UserModels newUser)
    {
        if (_context.Usuarios.Any(u => u.Correo_Electronico == newUser.Correo_Electronico))
            return BadRequest("El correo ya está registrado.");

        newUser.Contraseña = _passwordHasher.HashPassword(newUser, newUser.Contraseña);

        _context.Usuarios.Add(newUser);
        _context.SaveChanges();

        return Ok("Usuario registrado con éxito.");
    }

    [Authorize(Roles = "Administrador")]
    [HttpGet("usuarios-activos")]
    public IActionResult ObtenerUsuariosActivos()
    {
        var usuariosActivos = _context.Usuarios
            .Where(u => u.Activo)
            .Select(u => new
            {
                u.ID,
                u.Nombre_Usuario,
                u.Correo_Electronico,
                u.Rol
            })
            .ToList();

        return Ok(usuariosActivos);
    }

    [Authorize]
    [HttpGet("login-registros")]
    public IActionResult ObtenerRegistrosLogin()
    {
        var registros = _context.LoginRegistro
            .Select(r => new
            {
                r.Id,
                r.Usuario,
                r.FechaHoraLogin
            })
            .ToList();

        return Ok(registros);
    }
}
