﻿namespace PontoCerto.WebApplication.Models.Empresa;

public class ColaboradorVm
{
    public ColaboradorVm(string nome, string dataNascimento, string email, string userName)
    {
        Nome = nome;
        DataNascimento = dataNascimento;
        Email = email;
        UserName = userName;
    }
        
    public string Nome { get; set; }
    public string DataNascimento { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
}