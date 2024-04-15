namespace Models{
public class CepModel
{
    public string? cep { get; set; }
    public string? logradouro { get; set; }
    public string? complemento { get; set; }
    public string? bairro { get; set; }
    public string? localidade { get; set; }
    public string? uf { get; set; }
    public string gia { get; set; }
    public string? ddd { get; set; }
    public string? siafi { get; set; }

    public CepModel (string cep, string logradouro, string complemento, string bairro, string localidade, string uf, string gia, string ddd, string siafi)
    {
        this.cep = cep;
        this.logradouro = logradouro;
        this.complemento = complemento;
        this.bairro = bairro;
        this.localidade = localidade;
        this.uf = uf;
        this.gia = gia;
        this.ddd = ddd;
        this.siafi = siafi;
    }

    public void MostrarDados()
    {
        Console.WriteLine($"CEP: {cep}");
        Console.WriteLine($"Logradouro: {logradouro}");
        Console.WriteLine($"Complemento: {complemento}");
        Console.WriteLine($"Bairro: {bairro}");
        Console.WriteLine($"Localidade: {localidade}");
        Console.WriteLine($"UF: {uf}");
        Console.WriteLine($"GIA: {gia}");
        Console.WriteLine($"DDD: {ddd}");
        Console.WriteLine($"SIAFI: {siafi}");
    }
    
    
}
}


