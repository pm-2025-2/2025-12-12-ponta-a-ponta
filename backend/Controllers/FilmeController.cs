using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    // https://google.com/search?q=tads
    // virá um filme do frontend {titulo:..., genero:}
    // tratar os erros
    [HttpPost]
    public ActionResult Post([FromBody] Filme filme)
    {
        if (filme.Hype < 1 || filme.Hype > 5)
        {
            return BadRequest("Hype deve estar entre 1 e 5");
        }
        Console.WriteLine("Filme recebido:");
        Console.WriteLine(filme);

        // endereço e credenciais do PostgreSQL, =================
        var strconexao = "Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=tadsflix";
        // conecta ao banco
        using var conexao = new NpgsqlConnection(strconexao);

        // abrir a conexão
        conexao.Open();

        // SQL
        var sql = "INSERT INTO filmes (titulo, genero, hype, assistido) VALUES (@titulo, @genero, @hype, true)";
        // Comando do Banco
        var cmd = new NpgsqlCommand(sql, conexao);
        // preencher os dados do INSERT
        cmd.Parameters.AddWithValue("@titulo", filme.Titulo);
        cmd.Parameters.AddWithValue("@genero", filme.Genero);
        cmd.Parameters.AddWithValue("@hype", filme.Hype);
        // executar o comando no Banco
        cmd.ExecuteNonQuery();
        // ===== FIM DO BANCO

        // INSERT
        return Ok("Filme salvo com sucesso");
    }

    [HttpGet]
    public string Get()
    {
        return "Análise e Desenvolvimento de Sistemas!";
    }
}
