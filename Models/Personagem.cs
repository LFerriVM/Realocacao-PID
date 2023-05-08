using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Personagem
{
    public static List<Personagem> lista = new List<Personagem>();

    [Key]
    public int IdPersonagem { get; set; }

    [StringLength(50)]
    public string Nome { get; set; }

    public string Tendencia { get; set; }

    public int? Iniciativa { get; set; }

    public int? Slots { get; set; }

    public int? Constituicao { get; set; }
    public bool ConstituicaoBool { get; set; }
    public int? ModificadorConstituicao { get; set; }

    public int? Forca { get; set; }
    public bool ForcaBool { get; set; }
    public int? ModificadorForca { get; set; }

    public int? Destreza { get; set; }
    public bool DestrezaBool { get; set; }
    public int? ModificadorDestreza { get; set; }

    public int? Inteligencia { get; set; }
    public bool InteligenciaBool { get; set; }
    public int? ModificadorInteligencia { get; set; }

    public int? Sabedoria { get; set; }
    public bool SabedoriaBool { get; set; }
    public int? ModificadorSabedoria { get; set; }

    public int? Carisma { get; set; }
    public bool CarismaBool { get; set; }
    public int? ModificadorCarisma { get; set; }

    public double? Tamanho { get; set; }

    public int? Idade { get; set; }

    public double? Peso { get; set; }

    public string Olhos { get; set; }

    public string Cabelos { get; set; }

    public string Pele { get; set; }

    // [Required(ErrorMessage = "Campo Obrigatório")]
    public string Traco { get; set; }

    // [Required(ErrorMessage = "Campo Obrigatório")]
    public string Ideal { get; set; }

    // [Required(ErrorMessage = "Campo Obrigatório")]
    public string Vinculo { get; set; }

    // [Required(ErrorMessage = "Campo Obrigatório")]
    public string Defeito { get; set; }

    // [Required(ErrorMessage = "Campo Obrigatório")]
    public string Bio { get; set; }
    public int? Nivel { get; set; }
    public int? BonusProficiencia { get; set; }

    public int? VidaAtual { get; set; }
    public int? VidaTotal { get; set; }

    public int? TestesBemSucedidos { get; set; }
    public int? TestesMalSucedidos { get; set; }
    public bool? Morto { get; set; }

    public int? PC { get; set; }
    public int? PP { get; set; }
    public int? PE { get; set; }
    public int? PO { get; set; }
    public int? PL { get; set; }


    public bool Acrobacia { get; set; }
    public int? AcrobaciaValor { get; set; }
    public bool Arcanismo { get; set; }
    public int? ArcanismoValor { get; set; }
    public bool Atletismo { get; set; }
    public int? AtletismoValor { get; set; }
    public bool Atuacao { get; set; }
    public int? AtuacaoValor { get; set; }
    public bool Enganacao { get; set; }
    public int? EnganacaoValor { get; set; }
    public bool Furtividade { get; set; }
    public int? FurtividadeValor { get; set; }
    public bool Historia { get; set; }
    public int? HistoriaValor { get; set; }
    public bool Intimidacao { get; set; }
    public int? IntimidacaoValor { get; set; }
    public bool Intuicao { get; set; }
    public int? IntuicaoValor { get; set; }
    public bool Investigacao { get; set; }
    public int? InvestigacaoValor { get; set; }
    public bool LidarcomAnimais { get; set; }
    public int? LidarcomAnimaisValor { get; set; }
    public bool Medicina { get; set; }
    public int? MedicinaValor { get; set; }
    public bool Natureza { get; set; }
    public int? NaturezaValor { get; set; }
    public bool Percepcao { get; set; }
    public int? PercepcaoValor { get; set; }
    public bool Persuasao { get; set; }
    public int? PersuasaoValor { get; set; }
    public bool Prestidigitacao { get; set; }
    public int? PrestidigitacaoValor { get; set; }
    public bool Religiao { get; set; }
    public int? ReligiaoValor { get; set; }
    public bool Sobrevivencia { get; set; }
    public int? SobrevivenciaValor { get; set; }

    public int EscolheuEquip { get; set; }
    public int EscolheuPericia { get; set; }


    [ForeignKey("Classe")]
    public int? IdClasse { get; set; }
    public Classe Classe { get; set; }


    [ForeignKey("Raca")]
    public int? IdRaca { get; set; }
    public Raca Raca { get; set; }

    [ForeignKey("SubRaca")]
    public int? IdSubRaca { get; set; }
    public SubRaca SubRaca { get; set; }


    [ForeignKey("Antecedente")]
    public int? IdAntecedente { get; set; }
    public Antecedente Antecedente { get; set; }


    [ForeignKey("Skin")]
    public int? IdSkin { get; set; }
    public Skin Skin { get; set; }

    [ForeignKey("Usuario")]
    public int? IdUsuario { get; set; }
    public Usuario Usuario { get; set; }


    [NotMapped]
    public ICollection<Personagem_Armadura> Personagens_Armaduras { get; set; }
    [NotMapped]
    public ICollection<Personagem_Arma> Personagens_Armas { get; set; }
    [NotMapped]
    public ICollection<Personagem_Item> Personagens_itens { get; set; }


    public Personagem()
    {
        this.Nome = "";
        this.Tendencia = "";
        this.Iniciativa = null;
        this.Slots = null;
        this.Tamanho = null;
        this.Idade = null;
        this.Peso = null;
        this.Olhos = "";
        this.Cabelos = "";
        this.Pele = "";
        this.Traco = "";
        this.Ideal = "";
        this.Vinculo = "";
        this.Defeito = "";
        this.Bio = "";
        this.Nivel = 1;
        this.BonusProficiencia = 2;
        this.PC = 0;
        this.PP = 0;
        this.PE = 0;
        this.PO = 0;
        this.PL = 0;
        this.Acrobacia = false;
        this.Arcanismo = false;
        this.Atletismo = false;
        this.Atuacao = false;
        this.Enganacao = false;
        this.Furtividade = false;
        this.Historia = false;
        this.Intimidacao = false;
        this.Intuicao = false;
        this.Investigacao = false;
        this.LidarcomAnimais = false;
        this.Medicina = false;
        this.Natureza = false;
        this.Percepcao = false;
        this.Persuasao = false;
        this.Prestidigitacao = false;
        this.Religiao = false;
        this.Sobrevivencia = false;
        this.Forca = 0;
        this.ModificadorForca = 0;
        this.ForcaBool = false;
        this.Destreza = 0;
        this.ModificadorDestreza = 0;
        this.DestrezaBool = false;
        this.Constituicao = 0;
        this.ModificadorConstituicao = 0;
        this.ConstituicaoBool = false;
        this.Inteligencia = 0;
        this.ModificadorInteligencia = 0;
        this.InteligenciaBool = false;
        this.Sabedoria = 0;
        this.ModificadorSabedoria = 0;
        this.SabedoriaBool = false;
        this.Carisma = 0;
        this.ModificadorCarisma = 0;
        this.CarismaBool = false;
        this.EscolheuEquip = 0;
        this.EscolheuPericia = 0;
        this.TestesBemSucedidos = 0;
        this.TestesMalSucedidos = 0;
    }
    public void DefinirModificadores()
    {
        {
            if (this.Forca == 1)
            {
                this.ModificadorForca = -5;
            }
            else if (this.Forca <= 3)
            {
                this.ModificadorForca = -4;
            }
            else if (this.Forca <= 5)
            {
                this.ModificadorForca = -3;
            }
            else if (this.Forca <= 7)
            {
                this.ModificadorForca = -2;
            }
            else if (this.Forca <= 9)
            {
                this.ModificadorForca = -1;
            }
            else if (this.Forca <= 11)
            {
                this.ModificadorForca = 0;
            }
            else if (this.Forca <= 13)
            {
                this.ModificadorForca = 1;
            }
            else if (this.Forca <= 15)
            {
                this.ModificadorForca = 2;
            }
            else if (this.Forca <= 17)
            {
                this.ModificadorForca = 3;
            }
            else if (this.Forca <= 19)
            {
                this.ModificadorForca = 4;
            }
            else if (this.Forca <= 21)
            {
                this.ModificadorForca = 5;
            }
            else if (this.Forca <= 23)
            {
                this.ModificadorForca = 6;
            }
            else if (this.Forca <= 25)
            {
                this.ModificadorForca = 7;
            }
            else if (this.Forca <= 27)
            {
                this.ModificadorForca = 8;
            }
            else if (this.Forca <= 29)
            {
                this.ModificadorForca = 9;
            }
            else if (this.Forca == 30)
            {
                this.ModificadorForca = 10;
            }
            else
            {

            }
        }

        {
            if (this.Destreza == 1)
            {
                this.ModificadorDestreza = -5;
            }
            else if (this.Destreza <= 3)
            {
                this.ModificadorDestreza = -4;
            }
            else if (this.Destreza <= 5)
            {
                this.ModificadorDestreza = -3;
            }
            else if (this.Destreza <= 7)
            {
                this.ModificadorDestreza = -2;
            }
            else if (this.Destreza <= 9)
            {
                this.ModificadorDestreza = -1;
            }
            else if (this.Destreza <= 11)
            {
                this.ModificadorDestreza = 0;
            }
            else if (this.Destreza <= 13)
            {
                this.ModificadorDestreza = 1;
            }
            else if (this.Destreza <= 15)
            {
                this.ModificadorDestreza = 2;
            }
            else if (this.Destreza <= 17)
            {
                this.ModificadorDestreza = 3;
            }
            else if (this.Destreza <= 19)
            {
                this.ModificadorDestreza = 4;
            }
            else if (this.Destreza <= 21)
            {
                this.ModificadorDestreza = 5;
            }
            else if (this.Destreza <= 23)
            {
                this.ModificadorDestreza = 6;
            }
            else if (this.Destreza <= 25)
            {
                this.ModificadorDestreza = 7;
            }
            else if (this.Destreza <= 27)
            {
                this.ModificadorDestreza = 8;
            }
            else if (this.Destreza <= 29)
            {
                this.ModificadorDestreza = 9;
            }
            else if (this.Destreza == 30)
            {
                this.ModificadorDestreza = 10;
            }
            else
            {

            }
        }

        {
            if (this.Constituicao == 1)
            {
                this.ModificadorConstituicao = -5;
            }
            else if (this.Constituicao <= 3)
            {
                this.ModificadorConstituicao = -4;
            }
            else if (this.Constituicao <= 5)
            {
                this.ModificadorConstituicao = -3;
            }
            else if (this.Constituicao <= 7)
            {
                this.ModificadorConstituicao = -2;
            }
            else if (this.Constituicao <= 9)
            {
                this.ModificadorConstituicao = -1;
            }
            else if (this.Constituicao <= 11)
            {
                this.ModificadorConstituicao = 0;
            }
            else if (this.Constituicao <= 13)
            {
                this.ModificadorConstituicao = 1;
            }
            else if (this.Constituicao <= 15)
            {
                this.ModificadorConstituicao = 2;
            }
            else if (this.Constituicao <= 17)
            {
                this.ModificadorConstituicao = 3;
            }
            else if (this.Constituicao <= 19)
            {
                this.ModificadorConstituicao = 4;
            }
            else if (this.Constituicao <= 21)
            {
                this.ModificadorConstituicao = 5;
            }
            else if (this.Constituicao <= 23)
            {
                this.ModificadorConstituicao = 6;
            }
            else if (this.Constituicao <= 25)
            {
                this.ModificadorConstituicao = 7;
            }
            else if (this.Constituicao <= 27)
            {
                this.ModificadorConstituicao = 8;
            }
            else if (this.Constituicao <= 29)
            {
                this.ModificadorConstituicao = 9;
            }
            else if (this.Constituicao == 30)
            {
                this.ModificadorConstituicao = 10;
            }
            else
            {

            }
        }

        {
            if (this.Inteligencia == 1)
            {
                this.ModificadorInteligencia = -5;
            }
            else if (this.Inteligencia <= 3)
            {
                this.ModificadorInteligencia = -4;
            }
            else if (this.Inteligencia <= 5)
            {
                this.ModificadorInteligencia = -3;
            }
            else if (this.Inteligencia <= 7)
            {
                this.ModificadorInteligencia = -2;
            }
            else if (this.Inteligencia <= 9)
            {
                this.ModificadorInteligencia = -1;
            }
            else if (this.Inteligencia <= 11)
            {
                this.ModificadorInteligencia = 0;
            }
            else if (this.Inteligencia <= 13)
            {
                this.ModificadorInteligencia = 1;
            }
            else if (this.Inteligencia <= 15)
            {
                this.ModificadorInteligencia = 2;
            }
            else if (this.Inteligencia <= 17)
            {
                this.ModificadorInteligencia = 3;
            }
            else if (this.Inteligencia <= 19)
            {
                this.ModificadorInteligencia = 4;
            }
            else if (this.Inteligencia <= 21)
            {
                this.ModificadorInteligencia = 5;
            }
            else if (this.Inteligencia <= 23)
            {
                this.ModificadorInteligencia = 6;
            }
            else if (this.Inteligencia <= 25)
            {
                this.ModificadorInteligencia = 7;
            }
            else if (this.Inteligencia <= 27)
            {
                this.ModificadorInteligencia = 8;
            }
            else if (this.Inteligencia <= 29)
            {
                this.ModificadorInteligencia = 9;
            }
            else if (this.Inteligencia == 30)
            {
                this.ModificadorInteligencia = 10;
            }
            else
            {

            }
        }

        {
            if (this.Sabedoria == 1)
            {
                this.ModificadorSabedoria = -5;
            }
            else if (this.Sabedoria <= 3)
            {
                this.ModificadorSabedoria = -4;
            }
            else if (this.Sabedoria <= 5)
            {
                this.ModificadorSabedoria = -3;
            }
            else if (this.Sabedoria <= 7)
            {
                this.ModificadorSabedoria = -2;
            }
            else if (this.Sabedoria <= 9)
            {
                this.ModificadorSabedoria = -1;
            }
            else if (this.Sabedoria <= 11)
            {
                this.ModificadorSabedoria = 0;
            }
            else if (this.Sabedoria <= 13)
            {
                this.ModificadorSabedoria = 1;
            }
            else if (this.Sabedoria <= 15)
            {
                this.ModificadorSabedoria = 2;
            }
            else if (this.Sabedoria <= 17)
            {
                this.ModificadorSabedoria = 3;
            }
            else if (this.Sabedoria <= 19)
            {
                this.ModificadorSabedoria = 4;
            }
            else if (this.Sabedoria <= 21)
            {
                this.ModificadorSabedoria = 5;
            }
            else if (this.Sabedoria <= 23)
            {
                this.ModificadorSabedoria = 6;
            }
            else if (this.Sabedoria <= 25)
            {
                this.ModificadorSabedoria = 7;
            }
            else if (this.Sabedoria <= 27)
            {
                this.ModificadorSabedoria = 8;
            }
            else if (this.Sabedoria <= 29)
            {
                this.ModificadorSabedoria = 9;
            }
            else if (this.Sabedoria == 30)
            {
                this.ModificadorSabedoria = 10;
            }
            else
            {

            }
        }

        {
            if (this.Carisma == 1)
            {
                this.ModificadorCarisma = -5;
            }
            else if (this.Carisma <= 3)
            {
                this.ModificadorCarisma = -4;
            }
            else if (this.Carisma <= 5)
            {
                this.ModificadorCarisma = -3;
            }
            else if (this.Carisma <= 7)
            {
                this.ModificadorCarisma = -2;
            }
            else if (this.Carisma <= 9)
            {
                this.ModificadorCarisma = -1;
            }
            else if (this.Carisma <= 11)
            {
                this.ModificadorCarisma = 0;
            }
            else if (this.Carisma <= 13)
            {
                this.ModificadorCarisma = 1;
            }
            else if (this.Carisma <= 15)
            {
                this.ModificadorCarisma = 2;
            }
            else if (this.Carisma <= 17)
            {
                this.ModificadorCarisma = 3;
            }
            else if (this.Carisma <= 19)
            {
                this.ModificadorCarisma = 4;
            }
            else if (this.Carisma <= 21)
            {
                this.ModificadorCarisma = 5;
            }
            else if (this.Carisma <= 23)
            {
                this.ModificadorCarisma = 6;
            }
            else if (this.Carisma <= 25)
            {
                this.ModificadorCarisma = 7;
            }
            else if (this.Carisma <= 27)
            {
                this.ModificadorCarisma = 8;
            }
            else if (this.Carisma <= 29)
            {
                this.ModificadorCarisma = 9;
            }
            else if (this.Carisma == 30)
            {
                this.ModificadorCarisma = 10;
            }
            else
            {

            }
        }
    }
    public void DefinirBonusdeProficiencia()
    {
        if (this.Nivel < 5)
        {
            this.BonusProficiencia = 2;
        }
        else if (this.Nivel < 9)
        {
            this.BonusProficiencia = 3;
        }
        else if (this.Nivel < 13)
        {
            this.BonusProficiencia = 4;
        }
        else if (this.Nivel < 17)
        {
            this.BonusProficiencia = 5;
        }
        else if (this.Nivel <= 20)
        {
            this.BonusProficiencia = 6;
        }
    }
    public void DefinirDinheiro(int? IdClasse)
    {
        if (IdClasse == 1)
        {
            this.PO = 40;
        }
        else if (IdClasse == 2)
        {
            this.PO = 100;
        }
        else if (IdClasse == 3)
        {
            this.PO = 80;
        }
        else if (IdClasse == 4)
        {
            this.PO = 100;
        }
        else if (IdClasse == 5)
        {
            this.PO = 40;
        }
        else if (IdClasse == 6)
        {
            this.PO = 60;
        }
        else if (IdClasse == 7)
        {
            this.PO = 100;
        }
        else if (IdClasse == 8)
        {
            this.PO = 80;
        }
        else if (IdClasse == 9)
        {
            this.PO = 80;
        }
        else if (IdClasse == 10)
        {
            this.PO = 10;
        }
        else if (IdClasse == 11)
        {
            this.PO = 100;
        }
        else if (IdClasse == 12)
        {
            this.PO = 100;
        }
    }
    public void AumentarDinheiro(int pc, int pp, int pe, int po, int pl)
    {
        this.PC = this.PC + pc;
        this.PP = this.PP + pp;
        this.PE = this.PE + pe;
        this.PO = this.PO + po;
        this.PL = this.PL + pl;
    }
    public void DefinirSalvaguarda(bool ForcaBool = false, bool DestrezaBool = false, bool ConstituicaoBool = false, bool InteligenciaBool = false, bool SabedoriaBool = false, bool CarismaBool = false)
    {
        this.ForcaBool = ForcaBool;
        this.DestrezaBool = DestrezaBool;
        this.ConstituicaoBool = ConstituicaoBool;
        this.InteligenciaBool = InteligenciaBool;
        this.SabedoriaBool = SabedoriaBool;
        this.CarismaBool = CarismaBool;
    }
    public void setVidaTotal(int DadoVida)
    {
        this.VidaTotal = (((DadoVida / 2)+1) * Convert.ToInt32(this.Nivel)) + Convert.ToInt32(this.ModificadorConstituicao);
        this.VidaAtual = VidaTotal;

    }
    public void setVidaAtual(int VidaAtual)
    {
        if(VidaAtual > this.VidaTotal)
        {
            this.VidaAtual = this.VidaTotal;
        }
        else if(this.VidaAtual < 0)
        {
            this.VidaAtual = 0;
        }
        else 
        {
            this.VidaAtual = VidaAtual;
        }
    }
    public void MudarTestesBemSucedidos(int TestesBemSucedidos){
        this.TestesBemSucedidos = TestesBemSucedidos;
        if(TestesBemSucedidos == 3){
            this.VidaAtual = 1;
            this.TestesBemSucedidos = 0;
            this.TestesMalSucedidos = 0;
        }
    }
    public void MudarTestesMalSucedidos(int TestesMalSucedidos){
        this.TestesMalSucedidos = TestesMalSucedidos;
        if(TestesMalSucedidos == 3){
            this.Morto = true;
        }
    }

}