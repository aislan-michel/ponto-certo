namespace PontoCerto.WebApplication.Infrastructure.Extensions;

public static class StringExtensions
{
    /// <summary>
    /// Formatar uma string CNPJ
    /// </summary>
    /// <param name="cnpj">string CNPJ sem formatacao</param>
    /// <returns>string CNPJ formatada</returns>
    /// <example>Recebe '99999999999999' Devolve '99.999.999/9999-99'</example>
 
    public static string FormatarCnpj(this string cnpj)
    {
        return Convert.ToUInt64(cnpj).ToString(@"00\.000\.000\/0000\-00");
    }
}