using Newtonsoft.Json;

namespace TPC_EcoSupport.Models
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
    }

    public class Contrato
    {
        public int Id { get; set; }
        public Empresa Empresa { get; set; }
        public string TipoContrato { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public double Valor { get; set; }
        public string Status { get; set; }
        public string AssinaturaPendente { get; set; }
    }

    public class Transacao
    {
        public int Id { get; set; }
        public Contrato Contrato { get; set; }
        public DateTime Data { get; set; }
        public double Valor { get; set; }
        public string Descricao { get; set; }
    }

    public class Exibicao
    {
        public int Id { get; set; }
        public Transacao Transacao { get; set; }
        public double Valor { get; set; }
        public DateTime DataExibicao { get; set; }
        public string Descricao { get; set; }
    }

    public class Instituicao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
    }

    public class Embedded
    {
        public List<Exibicao> ExibicaoList { get; set; }
        public List<Instituicao> InstituicaoList { get; set; }
    }

    public class Links
    {
        public Self Self { get; set; }
    }

    public class Self
    {
        public string Href { get; set; }
    }

    public class Page
    {
        public int Size { get; set; }
        public int TotalElements { get; set; }
        public int TotalPages { get; set; }
        public int Number { get; set; }
    }

    public class ApiResponse
    {
        [JsonProperty("_embedded")]
        public Embedded Embedded { get; set; }
        [JsonProperty("_links")]
        public Links Links { get; set; }
        public Page Page { get; set; }
    }
}

