using Microsoft.EntityFrameworkCore;
using Models;
namespace Data;
public class DataContext : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<TipoArma> TiposArmas { get; set; }
    public DbSet<TipoIdioma> TiposIdiomas { get; set; }
    public DbSet<Idioma> Idiomas { get; set; }
    public DbSet<TipoMagia> TiposMagias { get; set; }
    public DbSet<Magia> Magias { get; set; }
    public DbSet<Item> Itens { get; set; }
    public DbSet<Arma> Armas { get; set; }
    public DbSet<TipoArmadura> TiposArmaduras { get; set; }
    public DbSet<Armadura> Armaduras { get; set; }
    public DbSet<Designer> Designers { get; set; }
    public DbSet<Skin> Skins { get; set; }
    public DbSet<Antecedente> Antecedentes { get; set; }
    public DbSet<Arquetipo> Arquetipos { get; set; }
    public DbSet<ListaMagia> ListasMagias { get; set; }
    public DbSet<HabilidadeRacial> HabilidadesRaciais { get; set; }
    public DbSet<Classe> Classes { get; set; }
    public DbSet<TracodeClasse> TracosdeClasse { get; set; }
    public DbSet<Raca> Racas { get; set; }
    public DbSet<SubRaca> SubRacas { get; set; }
    public DbSet<HabilidadeRacial_Raca> HabilidadesRaciais_Racas { get; set; }
    public DbSet<HabilidadeRacial_SubRaca> HabilidadesRaciais_SubRacas { get; set; }
    public DbSet<TracodeClasse_Arquetipo> TracosdeClasse_Arquetipos { get; set; }
    public DbSet<Magia_ListaMagia> Magias_ListasMagias { get; set; }
    public DbSet<Classe_TracodeClasse> Classes_TracosdeClasses { get; set; }
    public DbSet<Personagem> Personagens { get; set; }
    public DbSet<Idioma_Personagem> Idiomas_Personagens { get; set; }
    public DbSet<Personagem_Arma> Personagens_Armas { get; set; }
    public DbSet<Personagem_Armadura> Personagens_Armaduras { get; set; }
    public DbSet<Personagem_Item> Personagens_Itens { get; set; }
    public DbSet<Proficiencia_Arma> Proficiencias_Armas { get; set; }
    public DbSet<Proficiencia_Armadura> Proficiencias_Armaduras { get; set; }
    public DbSet<Proficiencia_Item> Proficiencias_Itens { get; set; }

    public DbSet<ASVTracao> ASVTracoes { get; set; }
    public DbSet<VeiculoTerrestre> VeiculosTerrestres { get; set; }
    public DbSet<VeiculoAquatico> VeiculosAquaticos { get; set; }

    public DbSet<Personagem_ASVTracao> Personagens_ASVTracoes { get; set; }
    public DbSet<Personagem_VeiculoTerrestre> Personagens_VeiculosTerrestres { get; set; }
    public DbSet<Personagem_VeiculoAquatico> Personagens_VeiculosAquaticos { get; set; }
    public DbSet<Proficiencia_VeiculoTerrestre> Proficiencias_VeiculosTerrestres { get; set; }
    public DbSet<Proficiencia_VeiculoAquatico> Proficiencias_VeiculosAquaticos { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TracodeClasse_Arquetipo>().HasKey(ta => new { ta.IdTracodeClasse, ta.IdArquetipo });
        modelBuilder.Entity<HabilidadeRacial_Raca>().HasKey(hr => new { hr.IdHabilidadeRacial, hr.IdRaca });
        modelBuilder.Entity<HabilidadeRacial_SubRaca>().HasKey(hs => new { hs.IdHabilidadeRacial, hs.IdSubRaca });
        modelBuilder.Entity<Classe_TracodeClasse>().HasKey(ct => new { ct.IdClasse, ct.IdTracodeClasse });
        modelBuilder.Entity<Personagem_Arma>().HasKey(pa => new { pa.IdPersonagem, pa.IdArma });
        modelBuilder.Entity<Personagem_Armadura>().HasKey(pa => new { pa.IdPersonagem, pa.IdArmadura });
        modelBuilder.Entity<Personagem_Item>().HasKey(pi => new { pi.IdPersonagem, pi.IdItem });
        modelBuilder.Entity<Proficiencia_Arma>().HasKey(pa => new { pa.IdPersonagem, pa.IdArma });
        modelBuilder.Entity<Proficiencia_Armadura>().HasKey(pa => new { pa.IdPersonagem, pa.IdArmadura });
        modelBuilder.Entity<Proficiencia_Item>().HasKey(pi => new { pi.IdPersonagem, pi.IdItem });
        modelBuilder.Entity<Proficiencia_ASVTracao>().HasKey(pa => new { pa.IdPersonagem, pa.IdASVTracao });
        modelBuilder.Entity<Proficiencia_VeiculoTerrestre>().HasKey(pv => new { pv.IdPersonagem, pv.IdVeiculoTerrestre });
        modelBuilder.Entity<Proficiencia_VeiculoAquatico>().HasKey(pv => new { pv.IdPersonagem, pv.IdVeiculoAquatico });
        modelBuilder.Entity<Personagem_ASVTracao>().HasKey(pa => new { pa.IdPersonagem, pa.IdASVTracao });
        modelBuilder.Entity<Personagem_VeiculoTerrestre>().HasKey(pv => new { pv.IdPersonagem, pv.IdVeiculoTerrestre });
        modelBuilder.Entity<Personagem_VeiculoAquatico>().HasKey(pv => new { pv.IdPersonagem, pv.IdVeiculoAquatico });
        modelBuilder.Entity<Idioma_Personagem>().HasKey(ip => new { ip.IdIdioma, ip.IdPersonagem });
        modelBuilder.Entity<Magia_ListaMagia>().HasKey(ml => new { ml.IdMagia, ml.IdListaMagia });

        #region Inserção de Dados
        modelBuilder.Entity<Antecedente>().HasData(
        new Antecedente
        {
            IdAntecedente = 1,
            Nome = "Acólito",
            Traco = "1 Eu idolatro um herói particular da minha fé, e constantemente me refiro a seus feitos e exemplos. \n2 Eu consigo encontrar semelhanças mesmo entre os inimigos mais violentos, com empatia e sempre trabalhando pela paz. \n3 Eu vejo presságios em cada evento e ação. Os deuses estão falando conosco, nós apenas temos de ouvi-los. \n4 Nada pode abalar minha atitude otimista. \n5 Eu cito (corretamente ou não) textos sagrados e provérbios em quase qualquer situação. \n6 Eu sou tolerante (ou intolerante) a qualquer outra fé, e respeito (ou condeno) a adoração a outros deuses. \n7 Eu aprecio comida requintada, bebidas e a elite entre o alto escalão de meu templo. Uma vida dura me irrita. \n8 Eu passei tanto tempo no templo que possuo pouca prática em lidar com as pessoas mundo a fora.",
            Ideal = "1 Tradição. As tradições ancestrais de adoração e sacrifício devem ser preservadas e perpetradas. (Leal) \n2 Caridade. Eu sempre tento ajudar aqueles em necessidade, não importando o custo pessoal. (Bom) \n3 Mudança. Nós devemos ajudar a conduzir as mudanças que os deuses estão constantemente trabalhando para o mundo. (Caótico) \n4 Poder. Eu espero que um dia eu consiga chegar ao topo na hierarquia da minha religião. (Leal) \n5 Fé. Eu acredito que minha divindade guia minhas ações. Eu tenho fé que, se eu trabalhar duro, coisas boas acontecerão. (Leal) \n6 Aspiração. Eu busco ser digno da graça do meu deus ao corresponder minhas ações aos seus ensinamentos. (Qualquer)",
            Vinculo = "1 Eu morreria para recuperar uma relíquia ancestral de minha fé, perdida há muito tempo. \n2 Eu ainda terei minha vingança contra o templo corrupto que me acusou de heresia. \n3 Eu devo minha vida ao sacerdote que me acolheu quando meus pais morreram. \n4 Tudo o que faço, faço pelo povo. \n5 Eu farei qualquer coisa para proteger o templo que sirvo. \n6 Eu busco guardar um texto sagrado que meus inimigos dizem ser herético e tentam destruí-lo.",
            Defeito = "1 Eu julgo os outros severamente, e a mim mesmo mais ainda. \n2 Eu deposito muita confiança naqueles que detêm o poder na hierarquia de meu templo. \n3 Minha devoção é muitas vezes me cega perante aqueles que professam a fé do meu deus. \n4 Meu pensamento é inflexível. \n5 Eu suspeito de estranhos e sempre espero o pior deles. \n6 Depois de escolher um objetivo, eu fico obcecado em cumpri-lo, até mesmo em detrimento de qualquer outra coisa em minha vida.",
            Habilidade = "CARACTERÍSTICA: ABRIGO DOS FIÉIS \nComo um acólito, você detém o respeito daqueles que compartilham de sua fé, e você pode realizar cerimônias de sua divindade. Você e seus companheiros de aventura podem até receber cura e caridade de um templo, santuário ou outro posto de sua fé, embora devam fornecer quaisquer componentes materiais necessários para as magias. Aqueles que compartilham de sua religião vão garantir a você (mas apenas você), custeando um estilo de vida modesto. Você também pode possuir laços com um templo específico devotado à sua divindade ou panteão, e fixar residência nele. Pode ser o templo que você está acostumado a servir, se ainda tiver boas relações com ele, ou um templo no qual você encontrou um novo lar. Enquanto frequentar as redondezas desse templo, você pode solicitar os sacerdotes para assisti-lo, desde que essa assistência não seja de alguma forma perigosa e que você sempre esteja em uma boa relação com seu templo.",
            Proficiencia = "Intuição, Religião",
            IdiomaQtd = 2,
            Equipamento = "Um símbolo sagrado (um presente dado quando você entrou no templo), um livro de preces ou uma conta de orações, 5 varetas de incenso, vestimentas, um conjunto de roupas comuns e uma algibeira contendo 15 po",
        },
        new Antecedente
        {
            IdAntecedente = 2,
            Nome = "Artesão de Guilda",
            Traco = "1 Eu acredito que tudo que valha a pena fazer, vale a pena ser feito direito. Eu não posso evitar – Eu sou perfeccionista. \n2 Eu sou um esnobe que olha de cima a baixo aqueles que não sabem apreciar artes requintadas. \n3 Eu sempre quero aprender como as coisas funcionam e o que deixa as pessoas motivadas. \n4 Eu sou cheio de aforismos espirituosos e tenho um proverbio para cada ocasião.\n5 Eu sou grosso com as pessoas que não tem o mesmo comprometimento que eu com o trabalho duro e honesto. \n6 Eu gosto de falar longamente sobre minha profissão. \n7 Eu não gasto meu dinheiro facilmente e vou barganhar incansavelmente para conseguir o melhor acordo possível. \n8 Eu sou bem conhecido pelo meu trabalho e quero ter certeza que todos o apreciam. Eu sempre fico surpreso quando conheço pessoas que não ouviram falar de mim.",
            Ideal = "1 Comunidade. É dever de todo cidadão civilizado fortalecer os elos da comunidade e a segurança da civilização. (Leal) \n2 Generosidade. Meus talentos me foram dados para que eu pudesse usá-los para beneficiar o mundo. (Bom) \n3 Liberdade. Todos deveriam ser livres para perseguir seus próprios meios de vida. (Caótico) \n4 Ganância. Eu só estou aqui pelo dinheiro. (Mau)\n5 Povo. Eu sou cometido com o povo com quem me importo, não com ideias. (Neutro) \n6 Aspiração. Eu trabalho duro para ser o melhor no meu ofício. (Qualquer)",
            Vinculo = "1 A oficina onde aprendi meu negócio é o local mais importante do mundo pra mim. \n2 Eu criei um trabalho incrível para alguém, mas descobri que ele não era merecedor de recebê-lo. Ainda estou à procura de alguém que seja merecedor. \n3 Eu tenho uma grande dívida para com minha guilda por fazer de mim a pessoa que sou hoje. \n4 Eu busco riqueza para conseguir o amor de alguém.\n5 Um dia eu voltarei para a minha guilda e provarei que sou o maior artesão dentre eles. \n6 Eu irem me vingar das forças malignas que destruíram meu local de negócios e arruinaram meu estilo de vida.",
            Defeito = "1 Eu farei de tudo para pôr minha mãos em algo raro ou inestimável. \n2 Eu rapidamente presumo que alguém está tentando me trapacear. \n3 Ninguém nunca poderá saber que eu, certa vez, roubei dinheiro dos cofres da guilda. \n4 Eu nunca estou satisfeito com o que tenho – eu sempre quero mais.\n5 Eu mataria para adquirir um título de nobreza. \n6 Eu sou terrivelmente invejoso com qualquer um que possa ofuscar meu ofício. Todo lugar que eu vou, estou cercado de rivais. ",
            Habilidade = "CARACTERÍSTICA: ASSOCIADOS DA GUILDA \nComo um membro cativo e respeitado da guilda, você pode contar com certos benefícios que a sociedade garante. Seus camaradas, membros da guilda, irão provêlo com hospedagem e comida, se necessário, e pagarão pelo seu funeral se preciso for. Em algumas cidades e vilas, um salão da guilda oferece um local central para conhecer outros membros de profissão, podendo ser um bom lugar para se conhecer patrões, aliados e empregados em potencial. Guildas, muitas vezes, detêm tremendos poderes políticos. Se você for acusado de um crime, sua guilda irá ampará-lo se uma boa defesa puder ser apresentada para provar sua inocência ou se o crime for justificável. Você pode, também, ter acesso a figuras políticas poderosas através da guilda, se você for um membro bem posicionado. Tais conexões devem exigir doações de dinheiro ou itens mágicos para os cofres da guilda. Você deve pagar cotas de 5 po por mês a guilda. Se você não pagar, você irá contrair uma dívida para permanecer nas boas graças da guilda.",
            Proficiencia = "Intuição, Persuasão. \nUm tipo de ferramenta de artesão",
            IdiomaQtd = 1,
            Equipamento = "Um conjunto de ferramentas de artesão (à sua escolha), uma carta de apresentação da sua guilda, um conjunto de roupas de viajante e uma algibeira com 15 po"
        },
        new Antecedente
        {
            IdAntecedente = 3,
            Nome = "Artista",
            Traco = "1 Eu conheço uma história relevante de praticamente todas as situações. \n2 Sempre que eu chego em um lugar novo, eu coleto os rumores locais e espalho fofocas. \n3 Eu sou um romântico incorrigível, sempre em busca daquele “alguém especial.” \n4 Ninguém fica com raiva de mim ou perto de mim por muito tempo, já que eu posso acabar com qualquer tipo de tensão. \n5 Eu amo um bom insulto, até os direcionados a mim. \n6 Eu fico sentido se eu não for o centro das atenções. \n7 Eu não vou me contentar com nada menos que a perfeição. \n8 Eu mudo de ânimo ou de pensamento tão rápido quando mudo eu mudo de nota em uma canção.",
            Ideal = "1 Beleza. Quando eu atuo, eu torno o mundo um lugar melhor. (Bom) \n2 Tradição. As histórias, lendas e canções do passado nunca devem ser esquecidas, pois elas nos ensinam quem nós somos. (Leal) \n3 Criatividade. O mundo precisa de novas ideias e ações ousadas. (Caótico) \n4 Ganância. Eu só estou aqui pelo dinheiro e pela fama. (Mau) \n5 Povo. Eu gosto de ver os sorrisos nos rostos das pessoas quando eu atuo. Isso é tudo que importa. (Neutro) \n6 Honestidade. A arte deve refletir a alma; ela deve vir de dentro e revelar quem realmente somos. (Qualquer)",
            Vinculo = "1 Meu instrumento é meu bem mais valioso e ele me lembra de alguém que eu amo. \n2 Alguém roubou meu precioso instrumento e, algum dia, eu vou pegá-lo de volta. \n3 Eu quero ser famoso, custe o que custar. \n4 Eu idolatro um herói dos contos antigos e mensuro meus feitos baseados nessa personalidade. \n5 Eu vou fazer tudo para provar que sou superior eu meu odiado rival. \n6 Eu faria qualquer coisa pelos membros da minha antiga trupe.",
            Defeito = "1 Eu farei de tudo para ganhar fama e renome. \n2 Eu viro um idiota quando vejo um rosto bonito. \n3 Um escândalo me impede de voltar para casa novamente. Esse tipo de problema parece me perseguir por ai. \n4 Eu, certa vez, satirizei um nobre que ainda quer minha cabeça. Foi um erro que eu adoraria repetir. \n5 Eu tenho problemas em esconder meus verdadeiros sentimentos. Minha língua afiada me mete em confusão. \n6 Apesar dos meus melhores esforços, meus amigos não me consideram confiável.",
            Habilidade = "CARACTERÍSTICA: PELA DEMANDA POPULAR \nVocê sempre encontra um lugar para atuar, geralmente em tavernas ou estalagens mas, possivelmente em circos, teatros ou até em cortes nobres. Em tais lugares, você recebe alojamento e comida modesta ou de patrões confortáveis, de graça (dependendo da qualidade do estabelecimento), contanto que você atue a cada noite. Além disso, sua atuação torna você um tipo de figura local. Quando estranhos reconhecerem você em uma cidade em que você já tenha atuado, eles geralmente gostaram de você.",
            Proficiencia = "Acrobacia, Atuação. \nKit de disfarce, um tipo de instrumento musical",
            IdiomaQtd = 0,
            Equipamento = "Um instrumento musical (à sua escolha), um presente de um admirador (carta de amor, mecha de cabelo ou uma bijuteria), um traje e uma algibeira contendo 15 peças de ouro "
        },
        new Antecedente
        {
            IdAntecedente = 4,
            Nome = "Charlatão",
            Traco = "1 Eu me apaixono e desapaixono facilmente, e estou sempre em busca de alguém. \n2 Eu tenho uma piada para cada ocasião, especialmente ocasiões em que o humor é inapropriado. \n3 Bajulação é meu truque predileto para conseguir o que eu quero. \n4 Eu sou um jogador nato que não consegue resistir a se arriscar por uma possível recompensa. \n5 Eu minto sobre quase tudo, mesmo quando não existe qualquer boa razão. \n6 Sarcasmo e insultos são minhas armas prediletas. \n7 Eu tenho vários símbolos sagrados comigo, e invoco a divindade que seja mais útil em cada dado momento. \n8 Eu furto qualquer coisa que eu vejo que possa ter algum valor.",
            Ideal = "1 Independência. Sou um espirito livre – ninguém me diz o que fazer. (Caótico) \n2 Justiça. Eu nunca roubo de pessoas que não podem perder algumas moedas. (Leal) \n3 Caridade. Eu distribuo o dinheiro que adquiro com as pessoas que realmente precisam. (Bom) \n4 Criatividade. Eu nunca faço a mesma trapaça duas vezes. (Caótico) \n5 Amizade. Bens materiais vem e vão. Os laços de amizade duram pra sempre. (Bom) \n6 Aspiração. Eu estou determinado a fazer algo por mim mesmo. (Qualquer)",
            Vinculo = "1 Independência. Sou um espirito livre – ninguém me diz o que fazer. (Caótico) \n2 Justiça. Eu nunca roubo de pessoas que não podem perder algumas moedas. (Leal) \n3 Caridade. Eu distribuo o dinheiro que adquiro com as pessoas que realmente precisam. (Bom) \n4 Criatividade. Eu nunca faço a mesma trapaça duas vezes. (Caótico) \n5 Amizade. Bens materiais vem e vão. Os laços de amizade duram pra sempre. (Bom) \n6 Aspiração. Eu estou determinado a fazer algo por mim mesmo. (Qualquer)",
            Defeito = "1 Não resisto um rostinho bonito. \n2 Estou sempre com dividas. Eu gasto meus lucros ilícitos com luxurias decadentes mais rápido do que os ganho... \n3 Estou convencido que ninguém pode me enganar da forma que eu engano os outros. \n4 Eu sou ganancioso demais pra meu próprio bem. Eu não consigo resistir a me arriscar se tiver dinheiro envolvido. \n5 Eu não resisto a enganar pessoas que são mais poderosas que eu. \n6 Eu odeio admitir e vou me odiar por isso, mas, eu vou correr e salvar minha própria pele se as coisas engrossarem.",
            Habilidade = "CARACTERÍSTICA: IDENTIDADE FALSA \nVocê criou uma segunda identidade que inclui documentos, conhecidos estabelecidos e disfarces que possibilitam que você assuma essa persona. Além disso, você pode forjar documentos, incluindo papeis oficiais e cartas pessoais, contanto que você tenha visto um exemplo desse tipo de documento ou a caligrafia de quem você está tentando copiar.",
            Proficiencia = "Enganação, Prestidigitação,  \nKit de disfarce, kit de falsificação ",
            IdiomaQtd = 0,
            Equipamento = "Um conjunto de roupas finas, um kit de disfarce, ferramentas de trapaça, à sua escolha (dez garrafas tampadas preenchidas com líquidos coloridos, um conjunto de dados viciados, um baralho de cartas marcadas ou um anel de sinete de um duque imaginário), e uma algibeira contendo 15 peças de ouro"
        },
        new Antecedente
        {
            IdAntecedente = 5,
            Nome = "Criminoso",
            Traco = "1 Eu sempre tenho um plano para quando as coisas dão errado. \n2 Eu estou sempre calmo, não importa a situação. Eu nunca levanto minha voz ou deixo minhas emoções me controlarem. \n3 A primeira coisa que faço ao chegar a um novo local é decorar a localização de coisas valiosas – ou onde essas coisas podem estar escondidas. \n4 Eu prefiro fazer um novo amigo a um novo inimigo. \n5 Eu sou incrivelmente receoso em confiar. Aqueles que parecem mais amigáveis geralmente têm mais a esconder. \n6 Eu não presto atenção aos riscos envolvidos em uma situação, nunca me alerte sobre as probabilidades de fracasso. \n7 A melhor maneira de me levar a fazer algo é dizendo que eu não posso fazer. \n8 Eu explodo ao menor insulto.",
            Ideal = "1 Honra. Eu não roubo de irmãos de profissão. (Leal) \n2 Liberdade. Correntes foram feitas para serem partidas, assim como aqueles que as forjaram. (Caótico) \n3 Caridade. Eu roubo dos ricos para dar aos que realmente precisam. (Bom) \n4 Ganância. Eu farei qualquer coisa para me tornar rico. (Mal) \n5 Povo. Eu sou leal aos meus amigos, não a qualquer ideal, e todos sabem que posso viajar até o Estige por aqueles que me importo. (Neutro) \n6 Redenção. Há uma centelha de bondade em todo mundo. (Bom)",
            Vinculo = "1 Eu estou tentando quitar uma dívida que tenho com um generoso benfeitor. \n2 Meus ganhos, honestos ou não, são para sustentar minha família. \n3 Algo importante foi roubado de mim, e eu vou recuperá-lo. \n4 Eu me tornarei o maior ladrão que já existiu. \n5 Eu sou culpado por um terrível crime, espero algum dia poder me redimir. \n6 Alguém que amo morreu por causa de um erro que cometi. Isso nunca acontecerá novamente.",
            Defeito = "1 Quando vejo algo valioso, não consigo pensar em mais nada, além de roubá-lo. \n2 Quando confrontado com uma escolha entre dinheiro e amigo, eu bem que escolho o dinheiro. \n3 Se há um plano, eu vou esquecê-lo. Se eu não esquecê-lo, vou ignorá-lo. \n4 Eu tenho um 'tique' que revela se estou mentindo. \n5 Eu viro as costas e corro quando as coisas começam a ficar ruins. \n6 Um inocente foi preso por um crime que eu cometi. Por mim tudo bem.",
            Habilidade = "CARACTERÍSTICA: CONTATO CRIMINAL \nVocê possui contatos de confiança que agem como seus informantes em uma rede criminosa. Você sabe como se comunicar com eles mesmo em grandes distâncias. Você conhece em especial os mensageiros locais, mestres de caravana corruptos, e marinheiros escusos que podem transmitir seus recados. ",
            Proficiencia = "Enganação, Furtividade, \nUm tipo de kit de jogo, ferramentas de ladrão",
            IdiomaQtd = 0,
            Equipamento = "Um pé de cabra, um conjunto de roupas escuras comuns com capuz e uma algibeira contendo 15 po "
        },
        new Antecedente
        {
            IdAntecedente = 6,
            Nome = "Eremita",
            Traco = "1 Eu fiquei tanto tempo isolado que raramente falo, preferindo gestos e grunhidos ocasionais. \n2 Eu sou absurdamente sereno, mesmo em face do desespero. \n3 O líder da minha comunidade tem algo sábio a dizer sobre cada tópico, eu estou ansioso para partilhar dessa sabedoria. \n4 Eu sinto uma empatia tremenda por todos que sofrem. \n5 Eu estou alheio a etiqueta e expectativas sociais. \n6 Eu relaciono tudo que acontece comigo a um grande plano cósmico. \n7 Eu, muitas vezes, me perco em meus pensamentos e contemplação me tornando alheio ao meu redor. \n8 Eu estou trabalhando em uma grande teoria filosófica e adoro partilhar minhas ideias.",
            Ideal = "1 Bem Maior. Meus dons devem ser partilhados com todos, não usados em benefício próprio (Bom) \n2 Lógica. Emoções não podem obscurecer meus sentidos do que é certo e verdade, ou meu pensamento lógico. (Leal) \n3 Pensamento Livre. Questionamentos e curiosidade são os pilares do progresso. (Caótico) \n4 Poder. Isolamento e contemplação são caminhos para poderes místicos e mágicos. (Mau) \n5 Viva e Deixe Viver. Se intrometer nos assuntos dos outros só traz problemas. (Neutro) \n6 Autoconhecimento. Se você conhece a si mesmo, não a mais nada para saber. (Qualquer)",
            Vinculo = "1 Nada é mais importante que os outros membros do eremitério, ordem ou associação. \n2 Eu entrei em reclusão para me esconder daqueles que ainda devem estar me caçando. Algum dia irei confrontálos. \n3 Eu ainda busco o esclarecimento que eu perseguia durante meu isolamento e continuo a me iludir. \n4 Eu entrei em reclusão porque eu amava alguém que eu não podia ter. \n5 Se minha descoberta vir à tona, ela poderá trazer destruição ao mundo. \n6 Meu isolamento me deu grande discernimento sobre um grande mal que apenas eu posso destruir.",
            Defeito = "1 Agora que voltei ao mundo, eu desfruto de seus prazeres um pouco demais. \n2 Eu escondo nas sombras, pensamentos sanguinários que meu isolamento e meditação não conseguiram apagar. \n3 Eu sou dogmático em meus pensamentos e filosofia. \n4 Eu deixo meu desejo de vencer discussões ofuscar amizades e harmonia. \n5 Eu me arrisco muito para descobrir um pouco de conhecimento perdido. \n6 Eu gosto de guardar segredos e não os partilho com ninguém.",
            Habilidade = "CARACTERÍSTICA: DESCOBERTA \nA calma reclusão da seu eremitério prolongado lhe deu acesso a descobertas únicas e poderosas. A natureza exata dessas revelações depende da natureza da sua reclusão. Poderia ser uma grande verdade sobre o cosmos, os deuses, os poderosos seres de outros planos ou as forças da natureza. Poderia ser um local nunca visto por mais ninguém. Você pode ter descoberto um fato que a muito foi esquecido, ou desenterrado uma relíquia do passado que poderia reescrever a história. Poderia ser uma informação que seria prejudicial para as pessoas responsáveis pelo seu exilio, consequentemente, a razão que fez você voltar para a sociedade. Converse com o Mestre para determinar os detalhes da sua descoberta e o impacto na campanha.",
            Proficiencia = "Medicina, Religião,  \nKit de herbalismo",
            IdiomaQtd = 1,
            Equipamento = "Um estojo de pergaminho cheio de notas dos seus estudos e orações, um cobertor de inverno, um conjunto de roupas comuns, um kit de herbalismo e 5 po. "
        },
        new Antecedente
        {
            IdAntecedente = 7,
            Nome = "Forasteiro",
            Traco = "1 Eu fui guiado por uma sede de viagens que me levou a abandonas meu lar. \n2 Eu cuido dos meus amigos como se eles fossem filhotes recém-nascidos. \n3 Certa vez, eu corri quarenta quilômetros sem parar alertar meu clã da aproximação de uma horda orc. Eu faria de novo se fosse necessário. \n4 Eu tenho uma lição pra cada situação, aprendida observando a natureza. \n5 Eu não vejo lugar para o povo rico e educado. Dinheiro e modos não vão salvá-lo de um urso-coruja faminto. \n6 Estou sempre pegando coisas, distraidamente brincando com elas e, às vezes, quebrando-as. \n7 Eu me sinto muito mais confortável entre animais que entre pessoas. \n8 Eu fui, de fato, criado por lobos.",
            Ideal = "1 Mudança. A vida é como as estações, em constante mudança, e nós devemos mudar com ela. (Caótico) \n2 Bem maior. É responsabilidade de todos trazer a maior felicidade para toda a tribo. (Bom) \n3 Honra. Se eu me desonrar, eu desonrarei todo o meu clã. (Leal) \n4 Força. O mais forte deve governar. (Mau) \n5 Natureza. O mundo natural é mais importante que todas as construções da civilização. (Neutro) \n6 Gloria. Eu devo adquirir gloria em batalha, para mim e para meu clã. (Qualquer)",
            Vinculo = "1 Minha família, clã ou tribo é a coisa mais importante na minha vida, mesmo quando eles estão longe. \n2 Uma ofensa a natureza intocada do meu lar é uma ofensa a mim. \n3 Eu trarei uma fúria terrível aos malfeitores que destruíram minha terra natal. \n4 Eu sou o último da minha tribo e cabe a mim garantir que seus nomes façam parte das lendas. \n5 Eu sofro de visões terríveis de um desastre vindouro, e farei qualquer coisa para impedi-lo. \n6 É meu dever prover filhos para sustentar minha tribo.",
            Defeito = "1 Sou muito apaixonado por cerveja, vinho e outras bebidas. \n2 Não existe lugar para precaução em uma vida vivida ao máximo. \n3 Eu lembro de cada insulto que sofri e nutro um ressentimento silencioso contra qualquer um que já tenha me insultado \n4 Eu tenho dificuldade em confiar em membros de outras raças, tribos ou sociedades. \n5 A violência é minha resposta para quase todos os obstáculos. \n6 Não espere que eu salve aqueles que não conseguem se virar sozinhos. É a lei da natureza que os fortes prosperem e os fracos pereçam.",
            Habilidade = "CARACTERÍSTICA: ANDARILHO Você tem uma memória excelente para mapas e geografia, e você sempre pode recobrar o plano geral de terrenos, assentamentos ou outras características ao seu redor. Além disso, você pode encontrar comida e água fresca para você a até cinco outras pessoas a cada dia, considerando que a terra ofereça bagas, pequenas frutas, água e similares.",
            Proficiencia = "Atletismo, Sobrevivência, \nUm tipo de instrumento musical",
            IdiomaQtd = 1,
            Equipamento = "Um bordão, uma armadilha de caça, um fetiche de um animal que você matou, um conjunto de roupas de viajante e uma algibeira contendo 10 po"
        },
        new Antecedente
        {
            IdAntecedente = 8,
            Nome = "Herói do Povo",
            Traco = "1 Eu julgo as pessoas por suas ações, não por suas palavras. \n2 Se alguém está em apuros, eu estou sempre pronto para ajudar. \n3 Quando eu fixo minha mente em algo, eu sigo esse caminho, não importa o que fique no caminho. \n4 Eu possuo um forte senso de justiça e sempre tento encontrar a solução mais equilibrada para as discussões. \n5 Eu confio em minhas habilidades e farei o que for necessário para que os outros confiem também. \n6 Pensar é para os outros, eu prefiro agir. \n7 Eu abuso de palavras longas na tentativa de soar inteligente. \n8 Eu me entedio fácil. Para onde devo ir para me encontrar com meu destino?",
            Ideal = "1 Respeito. As pessoas merecem ser tratadas com dignidade e respeito. (Bom) \n2 Justiça. Ninguém merece tratamento diferenciado perante a lei, muito menos estar acima dela. (Leal) \n3 Liberdade. Não pode haver permissão para tiranos oprimirem o povo. (Caótico) \n4 Força. Se eu ficar forte, eu posso pegar tudo o que eu quiser – o que eu desejar. (Mal) \n5 Sinceridade. Não há nada de bom em fingir ser algo que não sou. (Neutro) \n6 Destino. Nada, nem ninguém, pode me manter longe do meu chamado. (Qualquer)",
            Vinculo = "1 Eu tenho família, embora não faça a mínima ideia de onde eles estão, espero encontrá-los um dia. \n2 Eu trabalho a terra, eu amo a terra e eu vou defender a terra. \n3 Um nobre orgulhoso me deu uma bela surra, e eu vou ter minha vingança em qualquer valentão que encontrar. \n4 Minhas ferramentas são símbolo de minha vida passada, eu as carregarei para nunca me esquecer de minhas origens. \n5 Eu devo proteger aqueles que não podem se defender. \n6 Gostaria que meu amor viesse comigo para seguir meu destino.",
            Defeito = "1 O tirano que comanda minha terra não vai parar até ver meu cadáver. \n2 Eu estou convencido sobre o significado do meu destino, e cego aos riscos e falhas. \n3 As pessoas que me conhecem desde criança sabem de um vergonhoso segredo meu, eu não poderei voltar para casa nunca. \n4 Eu tenho uma fraqueza pelos vícios da cidade, especialmente a bebedeira. \n5 Secretamente, eu acredito que as coisas estariam melhores se algum tirano comandasse a região. \n6 Eu tenho dificuldades em confiar em meus aliados.",
            Habilidade = "CARACTERÍSTICA: HOSPITALIDADE RÚSTICA Já que você ascendeu da categoria de pessoas comuns até onde você está agora, é fácil se misturar a eles. Você pode encontrar lugar entre os camponeses para se esconder, descansar ou se recuperar, a menos que isso ofereça um risco direto a eles. Eles o esconderão da lei e de qualquer um que venha perguntando por você, desde que não tenham que arriscar suas vidas. ",
            Proficiencia = "Adestrar Animais, Sobrevivência, \nUm tipo de ferramenta de artesão, veículos (terrestre)",
            IdiomaQtd = 0,
            Equipamento = " Um conjunto de ferramentas de artesão (à sua escolha), uma pá, um pote de ferro, um conjunto de roupas comuns e uma algibeira contendo 10 po "
        },
        new Antecedente
        {
            IdAntecedente = 9,
            Nome = "Marinheiro",
            Traco = "1 Meus amigos sabem que podem contar comigo pro que der e vier. \n2 Eu trabalho duro para que possa me divertir muito quando o trabalho estiver pronto. \n3 Eu gosto de navegar para novos portos e fazer novas amizades acompanhado de uma jarra de cerveja. \n4 Eu modifico alguns fatos para o bem de uma boa história. \n5 Pra mim, uma briga de taverna é uma ótima forma de conhecer uma nova cidade. \n6 Eu nunca deixo passar uma aposta amigável. \n7 Meu vocabulário é tão sujo quanto o covil de um otyugh. \n8 Eu gosto de trabalhos bem feitos, especialmente se eu puder convencer alguém a fazê-los.",
            Ideal = "1 Respeito. A coisa que mantem um navio unido é o respeito mútuo entre o capitão e a tripulação. (Bem) \n2 Justiça. Todos nós fazemos o trabalho, portanto, todos partilhamos os espólios. (Leal) \n3 Liberdade. O mar é liberdade – a liberdade de ir aonde quiser. (Caótico) \n4 Domínio. Eu sou um predador e os outros navios no mar são minhas presas. (Mau) \n5 Povo. Eu sou apegado aos meus companheiros de tripulação, não a ideais. (Neutro) \n6 Aspiração. Algum dia eu serei dono do meu próprio navio e traçarei meu próprio destino. (Qualquer)",
            Vinculo = "1 Eu sou leal ao meu capitão, primeiramente, o resto vem em segundo. \n2 O navio é o mais importante – tripulantes e capitães vem e vão. \n3 Eu sempre me lembrarei do meu primeiro navio. \n4 Em uma cidade portuária, eu tenho uma amante que quase me roubou do mar. \n5 Eu fui enganado na divisão dos espólios e eu quero o que me é devido. \n6 Cruéis piratas mataram meu capitão e companheiros de tripulação, saquearam nosso navio e me deixaram para morrer. A vingança será minha.",
            Defeito = "1 Eu sigo ordens, mesmo que eu ache que estão erradas. \n2 Eu direi qualquer coisa para evitar trabalho extra. \n3 Certa vez, alguém duvidou da minha coragem, eu nunca recuo, não importa o quão perigosa seja a situação. \n4 Quando começo a beber, é difícil pra mim parar. \n5 Eu não resisto a uma sacolinha de moedas dando sopa ou outras bugigangas que encontro. \n6 Meu orgulho provavelmente levará a minha destruição.",
            Habilidade = "CARACTERÍSTICA: PASSAGEM DE NAVIO \nQuando você precisar, você pode conseguir passagem de graça em um navio para você e seus companheiros de aventura. Você precisa viajar no navio em que você trabalhou ou em outro navio com o qual você teve boas 139 relações (talvez um comandado por um ex-companheiro de tripulação). Por ser um favor, você não pode solicitar uma programação ou rota que atenda à todas as suas necessidades. Seu Mestre determina quanto tempo levará pra chegar aonde você quer ir. Em troca da passagem grátis, espera-se que você e seus companheiros ajudem a tripulação durante a viagem. ",
            Proficiencia = "Atletismo, Percepção, \nFerramentas de navegador, veículo (aquático)",
            IdiomaQtd = 0,
            Equipamento = "Uma malagueta (clava), 15 metros de corda de seda, uma amuleto da sorte como um pé de coelho ou uma pequena pedra com um furo no centro (ou você pode rolar uma bugiganga da tabela Bugigangas no capítulo 5), um conjunto de trajes comuns e uma algibeira contendo 10 po "
        },
        new Antecedente
        {
            IdAntecedente = 10,
            Nome = "Nobre",
            Traco = "1 Minha bajulação eloquente faz com que todos com quem eu converse se sintam a pessoa mais maravilhosa e importante do mundo. \n2 As pessoas comuns me amam por minha bondade e generosidade. \n3 Ninguém pode duvidar, olhando para o meu porte real, que estou acima das massas plebeias. \n4 Eu tenho grande cuidado de sempre estar no meu melhor e seguir as últimas modas. \n5 Eu não gosto de sujar minhas mãos, e eu não vou ser pego em acomodações inadequadas. \n6 Apesar da minha origem nobre, eu não estou acima dos outros. O sangue é um só. \n7 Meu apoio, uma vez perdido, não volta. \n8 Se você me ferir, eu irei esmagá-lo, arruinar seu nome, e salgar seus campos.",
            Ideal = "1 Respeito. O respeito a mim é devido por causa da minha posição, mas todas as pessoas, independentemente da posição merecem ser tratados com dignidade. (Bom) \n2 Responsabilidade. É o meu dever respeitar a autoridade daqueles acima de mim, assim como aqueles abaixo de mim devem me respeitar. (Leal) \n3 Independência. Devo provar que posso me cuidar sem os mimos da minha família. (Caótico) \n4 Poder. Se eu puder alcançar mais poder, ninguém vai me dizer o que fazer. (Mau) \n5 Família. O sangue corre mais grosso que a água. (Qualquer) \n6 Obrigação Nobre. É o meu dever proteger e cuidar das pessoas abaixo de mim. (Bom)",
            Vinculo = "1 Eu vou encarar qualquer desafio para ganhar a aprovação da minha família. \n2 A aliança da minha casa com outra família nobre deve ser mantida a todo custo. \n3 Nada é mais importante do que os outros membros da minha família. \n4 Eu sou apaixonado pela herdeira de uma família que a minha família despreza. \n5 Minha lealdade ao meu soberano é inabalável. \n6 As pessoas comuns devem me ver como um herói do povo.",
            Defeito = "\n1 Eu secretamente acredito que todos estão abaixo de mim. \n2 Eu escondo um segredo verdadeiramente escandaloso que poderia arruinar minha família para sempre. \n3 Muitas vezes eu ouço insultos e ameaças veladas em cada palavra dirigida a mim, e me irrito muito rápido. \n4 Eu tenho um desejo insaciável por prazeres carnais. \n5 Na verdade, o mundo gira ao meu redor. \n6 Pelas minhas palavras e ações, muitas vezes, envergonho minha família.",
            Habilidade = "CARACTERÍSTICA: POSIÇÃO PRIVILEGIADA \nGraças a sua origem nobre, as pessoas tendem a pensar o melhor de você. Você é bem-vindo na alta sociedade e as pessoas assumem que você tem o direito de estar onde está. As pessoas comuns fazem todos os esforços para acomodá-lo e evitar seu desprazer, e outros nobres o tratam como um membro da mesma classe social. Você pode conseguir uma audiência com um nobre local se precisar. ",
            Proficiencia = "História, Persuasão, \nUm tipo de kit de jogos ",
            IdiomaQtd = 1,
            Equipamento = "Um conjunto de trajes finos, um anel de sinete, um pergaminho de linhagem e uma algibeira contendo 25 po"
        },
        new Antecedente
        {
            IdAntecedente = 11,
            Nome = "Órfão",
            Traco = "1 Eu escondo pedaços de comida e bugigangas em meus bolsos. \n2 Eu pergunto um monte e coisas. \n3 Eu gosto de me espremer em locais pequenos onde ninguém possa me alcançar. \n4 Eu durmo encostado em um muro ou árvore, abraçado com todas as minhas posses. \n5 Eu como feito um porco e tenho maus modos. \n6 Eu acho que todos que são gentis comigo tem segundas intenções. \n7 Eu não gosto de tomar banho. \n8 Eu digo na cara o que as outras pessoas insinuam ou escondem.",
            Ideal = "1 Respeito. Todas as pessoas, ricas ou pobres, merecem respeito. (Bom) \n2 Comunidade. Nós temos que tomar conta uns dos outros, porque ninguém mais o fará. (Leal) \n3 Mudança. Os baixos se erguerão e os altos irão tombar. A mudança é a natureza das coisas. (Caótico) \n4 Retribuição. Os ricos precisam ver como a vida e morte é nas sarjetas. (Mau) \n5 Povo. Eu ajudo as pessoas que me ajudam – é isso que nos mantem vivos. (Neutro) \n6 Aspiração. Eu vou provar que sou merecedor de uma vida melhor. (Qualquer)",
            Vinculo = "1 Minha cidade ou vila é meu lar, e eu vou lutar para defendêlo. \n2 Eu patrocino um orfanato para que outros não passem pelo que fui forçado a passar. \n3 Eu devo minha sobrevivência a outros órfão que me ensinou a vida nas ruas. \n4 Eu tenho uma dívida que nunca poderei pagar com uma pessoa que teve pena de mim. \n5 Eu sai da minha vida de pobreza roubando uma pessoa importante, eu sou procurado por isso. \n6 Ninguém deveria ter suportar as dificuldades pelas quais passei.",
            Defeito = "1 Se eu estiver em desvantagem, eu vou fugir de uma briga. \n2 Ouro parece ser muito dinheiro pra mim, e eu faria praticamente qualquer coisa por mais dele. \n3 Eu nunca vou confiar em ninguém plenamente, além de mim mesmo. \n4 Eu prefiro matar alguém enquanto dorme que uma luta justa. \n5 Não é roubo se eu preciso mais que outra pessoa. \n6 As pessoas que não podem se virar sozinhas, tem o que merecem.",
            Habilidade = "CARACTERÍSTICA: SEGREDOS DA CIDADE \nVocê conhece os padrões secretos e o fluxo das cidades e pode encontrar passagens através da expansão urbana que os outros deixariam passar. Quando você não estiver em combate, você (e os companheiros que você guiar) podem viajar entre dois locais quaisquer na cidade com o dobro da velocidade normalmente permitida. ",
            Proficiencia = "Furtividade, Prestidigitação, \nKit de disfarce, ferramentas de ladrão ",
            IdiomaQtd = 0,
            Equipamento = "Uma faca pequena, um mapa da cidade em que você cresceu, um rato de estimação, um pequeno objeto para lembrar dos seus pais, um conjunto de roupas comuns e uma algibeira contendo 10 peças de ouro"
        },
        new Antecedente
        {
            IdAntecedente = 12,
            Nome = "Sábio",
            Traco = "1 Eu uso palavras polissilábicas para endossar minha impressão de grande erudição. \n2 Eu já li todos os livros das grandes bibliotecas – ou gosto de me vangloriar e dizer que li. \n3 Eu costumo ajudar os outros que não são tão inteligentes quanto eu, e pacientemente explico tudo quantas vezes forem necessárias. \n4 Nada para mim é melhor que um bom mistério. \n5 Eu voluntariamente escuto cada lado, e seus argumentos, antes de tomar uma decisão final. \n6 Eu...falo...lentamente...ao...conversar...com idiotas...que tentam...se comparar...comigo. \n7 E sou horrível e estranho em situações sociais. \n8 Estou convencido de que todos tentam roubar os meus segredos de mim.",
            Ideal = "1 Conhecimento. O caminho para o poder e o auto aperfeiçoamento é através do conhecimento. (Neutro) \n2 Beleza. O que é belo nos mostra o que está além disso perto do que é verdadeiro. (Bom) \n3 Logica. Emoções não devem nublar seu pensamento lógico. (Leal) \n4 Sem Limites. Nada pode apaziguar a possibilidade infinita de toda a existência. (Caótico) \n5 Poder. Conhecimento é o caminho para o poder e a dominação. (Mau) \n6 Auto Aperfeiçoamento. O objetivo de uma vida de estudos é a melhoria de si mesmo. (Qualquer)",
            Vinculo = "1 É meu dever proteger meus estudantes. \n2 Eu guardo um texto ancestral que contém terríveis segredos que não podem cair em mãos erradas. \n3 Eu trabalho para preservar uma biblioteca, universidade, arquivo de escribas ou monastério. \n4 O trabalho a da minha vida é uma série de tomos relatando um campo de conhecimento específico. \n5 Eu venho procurando a minha vida inteira pela resposta de certa questão. \n6 Eu vendi minha alma por conhecimento. Espero realizar grandes feitos para ganhá-la de volta.",
            Defeito = "1 Eu me distraio facilmente com a promessa de informação. \n2 Muitas pessoas gritam e correm quando veem um corruptor. Eu paro e tomo notas de sua anatomia. \n3 Desvendar um mistério ancestral pode muito bem valer o preço e uma civilização. \n4 E prefiro soluções óbvias a complicadas. \n5 Eu falo sem antes pensar em minhas palavras, invariavelmente insultando outros. \n6 Eu não consigo guardar um segredo para salvar minha vida. Ou a vida de qualquer outra pessoa.",
            Habilidade = "CARACTERÍSTICA: PESQUISADOR \nQuando tentar obter ou recuperar um fragmento de conhecimento que você não saiba, você descobre aonde e com quem pode obter essa informação. Normalmente ela será adquirida em bibliotecas, arquivos de escribas, universidade ou outros sábios e pessoas aptas. Seu Mestre pode decidir que o conhecimento que busca está escondido em algum lugar quase inacessível, ou é simplesmente impossível de se obter. Desvendar os 142 segredos mais profundos do multiverso pode requerer uma campanha inteira. ",
            Proficiencia = "Arcanismo, História",
            IdiomaQtd = 2,
            Equipamento = "Um vidro de tinta escura, uma pena, uma faca pequena, uma carta de um falecido colega perguntando a você algo que você nunca terá a chance de responder, um conjunto de roupas comuns e uma algibeira contendo 10 po "
        },
        new Antecedente
        {
            IdAntecedente = 13,
            Nome = "Soldado",
            Traco = "1 Eu sou sempre polido e respeitoso. \n2 Eu sou assombrado pelas memórias da guerra. Não consigo tirar aquelas imagens da minha cabeça. \n3 Eu perdi muitos amigos, e sou muito devagar para fazer novos. \n4 Eu tenho muitas histórias de inspiração e cautela da época de minha experiência militar que são relevantes em todas as situações de combate. \n5 Eu não consigo encarar um cão infernal sem vacilar. \n6 Eu gosto de ser forte e de quebrar coisas. \n7 Eu tenho um senso de humor grosseiro. \n8 Eu enfrento os problemas de frente. Uma solução direta é o melhor caminho para o sucesso.",
            Ideal = "1 Bem Maior. Nosso destino é dar nossas vidas em defesa de terceiros. (Bom) \n2 Responsabilidade. Eu faço o que tenho que fazer e obedeço apenas a autoridade. (Leal) \n3 Independência. Quando pessoas seguem ordens cegas elas apoiam um tipo de tirania. (Caótico) \n4 Força. A vida é como uma guerra, o mais forte vence. (Mau) \n5 Viva e Deixa Viver. Ideais não valem a pena se você matar, ou for à guerra por eles. (Neutro) \n6 Aspiração. Minha cidade, nação ou meu povo, são tudo o que importa para mim. (Qualquer)",
            Vinculo = "1 Eu ainda daria a minha vida pelas pessoas com quem servi. \n2 Alguém salvou minha vida no campo de batalha. Desde aquele dia eu nunca deixo nenhum amigo para trás. \n3 Minha honra é minha vida. \n4 Eu nunca esquecerei a destruidora derrota que minha companhia sofreu ou os inimigos que a causaram. \n5 Aqueles que lutam ao meu lado são aqueles por quem vale a pena morrer. \n6 Eu luto por aqueles que não podem lutar por si mesmos.",
            Defeito = "1 O inimigo monstruoso que enfrentei em uma batalha ainda me deixa tremendo de medo. \n2 Eu tenho pouco respeito por aqueles que não se provam bons combatentes. \n3 Eu cometi um terrível erro em batalha, o que custou muitas vidas – eu farei de tudo para manter esse erro em segredo. \n4 Meu ódio por meus inimigos é cego e irracional. \n5 Eu obedeço a lei, mesmo se a lei trouxer a angústia. \n6 Eu prefiro comer minha armadura a admitir que estou errado.",
            Habilidade = "CARACTERÍSTICA: PATENTE MILITAR \nVocê possui uma patente militar da sua época como soldado. Soldados leais à sua antiga organização reconhecem sua autoridade e influência, e o prestam deferência se forem de uma patente mais baixa. Você pode invocar sua patente para exercer influência sobre soldados, e requisitar equipamentos simples ou cavalos para uso temporário. Você também pode ganhar acesso a acampamentos militares aliados, e fortalezas onde usa patente é reconhecida. ",
            Proficiencia = "Atletismo, Intimidação ",
            IdiomaQtd = 0,
            Equipamento = "Uma insígnia de patente, um fetiche obtido de um inimigo caído (uma adaga, lâmina partida ou tira de estandarte), um conjunto de dados de osso ou baralho, um conjunto de roupas comuns e uma algibeira contendo 10 po "
        }
        );
        modelBuilder.Entity<TipoArma>().HasData(
        new TipoArma
        {
            IdTipoArma = 1,
            Tipo = "Arma Simples Corpo-a-Corpo"
        },
        new TipoArma
        {
            IdTipoArma = 2,
            Tipo = "Arma Simples à Distância"
        },
        new TipoArma
        {
            IdTipoArma = 3,
            Tipo = "Arma Marcial Corpo-a-Corpo"
        },
        new TipoArma
        {
            IdTipoArma = 4,
            Tipo = "Arma Marcial à Distância"
        }
        );
        modelBuilder.Entity<Arma>().HasData(
            new Arma
            {
                IdArma = 1,
                DadoDano = "1d4 perfurante",
                Propriedade = "Acuidade, leve, arremesso (distância 6/18)",
                Nome = "Adaga",
                Peso = "0.5 Kg",
                Preco = "2 Peças de Ouro",
                IdTipoArma = 1
            },
            new Arma
            {
                IdArma = 2,
                DadoDano = "1d6 perfurante",
                Propriedade = "Arremesso (distância 9/36)",
                Nome = "Azagaia",
                Peso = "1 Kg",
                Preco = "5 Peças de Prata",
                IdTipoArma = 1
            },
            new Arma
            {
                IdArma = 3,
                DadoDano = "1d6 concussão",
                Propriedade = "Versátil (1d8)",
                Nome = "Bordão",
                Peso = "2 Kg",
                Preco = "2 Peças de Prata",
                IdTipoArma = 1
            },
            new Arma
            {
                IdArma = 4,
                DadoDano = "1d8 concussão",
                Propriedade = "Pesada, duas mãos",
                Nome = "Clava Grande",
                Peso = "5 Kg",
                Preco = "2 Peças de Prata",
                IdTipoArma = 1
            },
            new Arma
            {
                IdArma = 5,
                DadoDano = "1d4 cortante",
                Propriedade = "Leve",
                Nome = "Foice Curta",
                Peso = "1 Kg",
                Preco = "1 Peça de Ouro",
                IdTipoArma = 1
            },
            new Arma
            {
                IdArma = 6,
                DadoDano = "1d6 perfurante",
                Propriedade = "Arremesso (distância 6/18), versãtil (1d8)",
                Nome = "Lança",
                Peso = "1.5 Kg",
                Preco = "1 Peça de Ouro",
                IdTipoArma = 1
            },
            new Arma
            {
                IdArma = 7,
                DadoDano = "1d6 concussão",
                Propriedade = "",
                Nome = "Maça",
                Peso = "2 Kg",
                Preco = "5 Peças de Ouro",
                IdTipoArma = 1
            },
            new Arma
            {
                IdArma = 8,
                DadoDano = "1d6 cortante",
                Propriedade = "Leve, arremesso (distância 6/18)",
                Nome = "Machadinha",
                Peso = "1 Kg",
                Preco = "5 Peças de Ouro",
                IdTipoArma = 1
            },
            new Arma
            {
                IdArma = 9,
                DadoDano = "1d4 concussão",
                Propriedade = "Leve, arremesso (distância 6/18)",
                Nome = "Martelo Leve",
                Peso = "1 Kg",
                Preco = "2 Peças de Ouro",
                IdTipoArma = 1
            },
            new Arma
            {
                IdArma = 10,
                DadoDano = "1d4 concussão",
                Propriedade = "Leve",
                Nome = "Porrete",
                Peso = "1 Kg",
                Preco = "1 Peça de Prata",
                IdTipoArma = 1
            },
            new Arma
            {
                IdArma = 11,
                DadoDano = "1d6 perfurante",
                Propriedade = "Munição (distância 24/96), duas mãos",
                Nome = "Arco Curto",
                Peso = "1 Kg",
                Preco = "25 Peças de Ouro",
                IdTipoArma = 2
            },
            new Arma
            {
                IdArma = 12,
                DadoDano = "1d8 perfurante",
                Propriedade = "Munição (distância 24/96), regarga, duas mãos",
                Nome = "Beste Leve",
                Peso = "2.5 Kg",
                Preco = "25 Peças de Ouro",
                IdTipoArma = 2
            },
            new Arma
            {
                IdArma = 13,
                DadoDano = "1d4 perfurante",
                Propriedade = "Acuidade, arremesso (distância 6/18)",
                Nome = "Dardo",
                Peso = "0.1 Kg",
                Preco = "5 Peças de Cobre",
                IdTipoArma = 2
            },
            new Arma
            {
                IdArma = 14,
                DadoDano = "1d4 concussão",
                Propriedade = "Munição (distância 9/36)",
                Nome = "Funda",
                Peso = "-",
                Preco = "1 Peça de Prata",
                IdTipoArma = 2
            },
            new Arma
            {
                IdArma = 15,
                DadoDano = "1d10 cortante",
                Propriedade = "Pesada, alcance, duas mãos",
                Nome = "Alabarda",
                Peso = "3 Kg",
                Preco = "20 Peças de Ouro",
                IdTipoArma = 3
            },
            new Arma
            {
                IdArma = 16,
                DadoDano = "1d6 cortante",
                Propriedade = "Acuidade, leve",
                Nome = "Cimitarra",
                Peso = "1.5 Kg",
                Preco = "25 Peças de Ouro",
                IdTipoArma = 3
            },
            new Arma
            {
                IdArma = 17,
                DadoDano = "1d4 cortante",
                Propriedade = "Acuidade, alcance",
                Nome = "Chicote",
                Peso = "1.5 Kg",
                Preco = "2 Peças de Ouro",
                IdTipoArma = 3
            },
            new Arma
            {
                IdArma = 18,
                DadoDano = "1d6 perfurante",
                Propriedade = "Acuidade, leve",
                Nome = "Espada Curta",
                Peso = "1 Kg",
                Preco = "10 Peças de Ouro",
                IdTipoArma = 3
            },
            new Arma
            {
                IdArma = 19,
                DadoDano = "2d6 cortante",
                Propriedade = "Pesada, duas mãos",
                Nome = "Espada Grande",
                Peso = "3 Kg",
                Preco = "50 Peças de Ouro",
                IdTipoArma = 3
            },
            new Arma
            {
                IdArma = 20,
                DadoDano = "1d8 cortante",
                Propriedade = "Versátil (1d10)",
                Nome = "Espada Longa",
                Peso = "1.5 Kg",
                Preco = "15 Peças de Ouro",
                IdTipoArma = 3
            },
            new Arma
            {
                IdArma = 21,
                DadoDano = "1d10 cortante",
                Propriedade = "Pesada, alcance, duas mãos",
                Nome = "Glaive",
                Peso = "3 Kg",
                Preco = "20 Peças de Ouro",
                IdTipoArma = 3
            },
            new Arma
            {
                IdArma = 22,
                DadoDano = "1d12 perfurante",
                Propriedade = "Alcance, especial",
                Nome = "Lança de Montaria",
                Peso = "3 Kg",
                Preco = "3 Kg",
                IdTipoArma = 3
            },
            new Arma
            {
                IdArma = 23,
                DadoDano = "1d8 perfurante",
                Propriedade = "",
                Nome = "Maça Estrela",
                Peso = "2 Kg",
                Preco = "15 Peças de Ouro",
                IdTipoArma = 3
            },
            new Arma
            {
                IdArma = 24,
                DadoDano = "1d12 cortante",
                Propriedade = "Pesada, duas mãos",
                Nome = "Machado Grande",
                Peso = "3.5 Kg",
                Preco = "30 Peças de Ouro",
                IdTipoArma = 3
            },
            new Arma
            {
                IdArma = 25,
                DadoDano = "1d8 cortante",
                Propriedade = "Versátil (1d10)",
                Nome = "Machado de Batalha",
                Peso = "2 Kg",
                Preco = "10 Peças de Ouro",
                IdTipoArma = 3
            },
            new Arma
            {
                IdArma = 26,
                DadoDano = "2d6 concussão",
                Propriedade = "Pesada, duas mãos",
                Nome = "Malho",
                Peso = "5 Kg",
                Preco = "10 Peças de Ouro",
                IdTipoArma = 3
            },
            new Arma
            {
                IdArma = 27,
                DadoDano = "1d8 concussão",
                Propriedade = "",
                Nome = "Mangual",
                Peso = "1 Kg",
                Preco = "10 Peças de Ouro",
                IdTipoArma = 3
            },
            new Arma
            {
                IdArma = 28,
                DadoDano = "1d8 concussão",
                Propriedade = "Versátil (1d10)",
                Nome = "Martelo de Guerra",
                Peso = "1 Kg",
                Preco = "15 Peças de Ouro",
                IdTipoArma = 3
            },
            new Arma
            {
                IdArma = 29,
                DadoDano = "1d8 perfurante",
                Propriedade = "",
                Nome = "Picareta de Guerra",
                Peso = "1 Kg",
                Preco = "5 Peças de Ouro",
                IdTipoArma = 3
            },
            new Arma
            {
                IdArma = 30,
                DadoDano = "1d8 perfurante",
                Propriedade = "Acuidade",
                Nome = "Rapieira",
                Peso = "1 Kg",
                Preco = "25 Peças de Ouro",
                IdTipoArma = 3
            },
            new Arma
            {
                IdArma = 31,
                DadoDano = "1d6 perfurante",
                Propriedade = "Arremesso (6/18), versátil(1d8)",
                Nome = "Tridente",
                Peso = "2 Kg",
                Preco = "5 Peças de Ouro",
                IdTipoArma = 3
            },
            new Arma
            {
                IdArma = 32,
                DadoDano = "1d8 perfurante",
                Propriedade = "Munição (distância 45/180), pesada, duas mãos",
                Nome = "Arco Longo",
                Peso = "1 Kg",
                Preco = "50 Peças de Ouro",
                IdTipoArma = 4
            },
            new Arma
            {
                IdArma = 33,
                DadoDano = "1d6 perfurante",
                Propriedade = "Munição (distância 9/36), leve, recarga",
                Nome = "Besta de Mão",
                Peso = "1.5 Kg",
                Preco = "75 Peças de Ouro",
                IdTipoArma = 4
            },
            new Arma
            {
                IdArma = 34,
                DadoDano = "1d10 perfurante",
                Propriedade = "Munição (distância 30/120), pesada, recarga, duas mãos",
                Nome = "Besta Pesada",
                Peso = "4.5 Kg",
                Preco = "50 Peças de Ouro",
                IdTipoArma = 4
            },
            new Arma
            {
                IdArma = 35,
                DadoDano = "",
                Propriedade = "Especial, arremesso (distância 1.4/4.5)",
                Nome = "Rede",
                Peso = "1.5 Kg",
                Preco = "1 Peça de Ouro",
                IdTipoArma = 4
            },
            new Arma
            {
                IdArma = 36,
                DadoDano = "1 perfurante",
                Propriedade = "Munição (distância 7.5/30), recarga",
                Nome = "Zarabatana",
                Peso = "0.5 Kg",
                Preco = "10 Peças de Ouro",
                IdTipoArma = 4
            }
        );
        modelBuilder.Entity<TipoArmadura>().HasData(
        new TipoArmadura
        {
            IdTipoArmadura = 1,
            Tipo = "Armadura Leve"
        },
        new TipoArmadura
        {
            IdTipoArmadura = 2,
            Tipo = "Armadura Média"
        },
        new TipoArmadura
        {
            IdTipoArmadura = 3,
            Tipo = "Armadura Pesada"
        },
        new TipoArmadura
        {
            IdTipoArmadura = 4,
            Tipo = "Escudo"
        }
        );
        modelBuilder.Entity<Armadura>().HasData(
        new Armadura
        {
            IdArmadura = 1,
            ClassedeArmadura = 11,
            ModificadorDestrezaMaximo = null,
            Forca = null,
            Furtividade = true,
            Nome = "Acolchoada",
            Peso = "4 Kg",
            Preco = "5 Peças de Ouro",
            IdTipoArmadura = 1
        },
        new Armadura
        {
            IdArmadura = 2,
            ClassedeArmadura = 11,
            ModificadorDestrezaMaximo = null,
            Forca = null,
            Furtividade = false,
            Nome = "Couro",
            Peso = "5 Kg",
            Preco = "10 Peças de Ouro",
            IdTipoArmadura = 1
        },
        new Armadura
        {
            IdArmadura = 3,
            ClassedeArmadura = 12,
            ModificadorDestrezaMaximo = null,
            Forca = null,
            Furtividade = false,
            Nome = "Couro Batido",
            Peso = "6.5 Kg",
            Preco = "45 Peças de Ouro",
            IdTipoArmadura = 1
        },
        new Armadura
        {
            IdArmadura = 4,
            ClassedeArmadura = 12,
            ModificadorDestrezaMaximo = 2,
            Forca = null,
            Furtividade = false,
            Nome = "Gibão de Peles",
            Peso = "6 Kg",
            Preco = "10 Peças de Ouro",
            IdTipoArmadura = 2
        },
        new Armadura
        {
            IdArmadura = 5,
            ClassedeArmadura = 13,
            ModificadorDestrezaMaximo = 2,
            Forca = null,
            Furtividade = false,
            Nome = "Camisão de Malha",
            Peso = "10 Kg",
            Preco = "30 Peças de Ouro",
            IdTipoArmadura = 2
        },
        new Armadura
        {
            IdArmadura = 6,
            ClassedeArmadura = 14,
            ModificadorDestrezaMaximo = 2,
            Forca = null,
            Furtividade = true,
            Nome = "Brunea",
            Peso = "22.5 Kg",
            Preco = "50 Peças de Ouro",
            IdTipoArmadura = 2
        },
        new Armadura
        {
            IdArmadura = 7,
            ClassedeArmadura = 14,
            ModificadorDestrezaMaximo = 2,
            Forca = null,
            Furtividade = true,
            Nome = "Peitoral",
            Peso = "10 Kg",
            Preco = "400 Peças de Ouro",
            IdTipoArmadura = 2
        },
        new Armadura
        {
            IdArmadura = 8,
            ClassedeArmadura = 15,
            ModificadorDestrezaMaximo = 2,
            Forca = null,
            Furtividade = true,
            Nome = "Meia-Armadura",
            Peso = "20 Kg",
            Preco = "750 Peças de Ouro",
            IdTipoArmadura = 2
        },
        new Armadura
        {
            IdArmadura = 9,
            ClassedeArmadura = 14,
            ModificadorDestrezaMaximo = 0,
            Forca = null,
            Furtividade = true,
            Nome = "Cota de Anéis",
            Peso = "20 Kg",
            Preco = "30 Peças de Ouro",
            IdTipoArmadura = 3
        },
        new Armadura
        {
            IdArmadura = 10,
            ClassedeArmadura = 16,
            ModificadorDestrezaMaximo = 0,
            Forca = 13,
            Furtividade = true,
            Nome = "Cota de Malha",
            Peso = "27.5 Kg",
            Preco = "75 Peças de Ouro",
            IdTipoArmadura = 3
        },
        new Armadura
        {
            IdArmadura = 11,
            ClassedeArmadura = 17,
            ModificadorDestrezaMaximo = 0,
            Forca = 15,
            Furtividade = true,
            Nome = "Cota de Talas",
            Peso = "30 Kg",
            Preco = "200 Peças de Ouro",
            IdTipoArmadura = 3
        },
        new Armadura
        {
            IdArmadura = 12,
            ClassedeArmadura = 18,
            ModificadorDestrezaMaximo = 0,
            Forca = 15,
            Furtividade = true,
            Nome = "Placas",
            Peso = "32.5 Kg",
            Preco = "1500 Peças de Ouro",
            IdTipoArmadura = 3
        },
        new Armadura
        {
            IdArmadura = 13,
            ClassedeArmadura = 2,
            ModificadorDestrezaMaximo = 0,
            Forca = null,
            Furtividade = true,
            Nome = "Escudo",
            Peso = "3 Kg",
            Preco = "10 Peças de Ouro",
            IdTipoArmadura = 4
        }
        );
        modelBuilder.Entity<ListaMagia>().HasData(
        new ListaMagia
        {
            IdListaMagia = 1,
            Nome = "Magias de Bardo"
        },
        new ListaMagia
        {
            IdListaMagia = 2,
            Nome = "Magias de Bruxo"
        },
        new ListaMagia
        {
            IdListaMagia = 3,
            Nome = "Magias de Clérigo"
        },
        new ListaMagia
        {
            IdListaMagia = 4,
            Nome = "Magias de Druida"
        },
        new ListaMagia
        {
            IdListaMagia = 5,
            Nome = "Magias de Feiticeiro"
        },
        new ListaMagia
        {
            IdListaMagia = 6,
            Nome = "Magias de Paladino"
        },
        new ListaMagia
        {
            IdListaMagia = 7,
            Nome = "Magias de Patrulheiro"
        },
        new ListaMagia
        {
            IdListaMagia = 8,
            Nome = "Magias de Mago"
        }
        );
        modelBuilder.Entity<Classe>().HasData(
        new Classe
        {
            IdClasse = 1,
            DadoVida = 12,
            Nome = "Bárbaro",
            Equipamento = "(a) um machado grande ou (b) qualquer arma marcial corpo-a-corpo  (a) dois machados de mão ou (b) qualquer arma simples  Um pacote de aventureiro e quatro azagaias",
            Proficiencia = "Armaduras: Armaduras leves, armaduras médias e escudos; Armas: Armas simples, armas marciais; Ferramentas: Nenhuma Testes de Resistência: Força, Constituição",
            IdListaMagia = null
        },
        new Classe
        {
            IdClasse = 2,
            DadoVida = 8,
            Nome = "Bardo",
            Equipamento = "(a) uma rapieira, (b) uma espada longa ou (c) qualquer arma simples  (a) um pacote de diplomata ou (b) um pacote de artista  (a) um lute ou (b) qualquer outro instrumento musical  Armadura de couro e uma adaga",
            Proficiencia = "Armaduras: Armaduras leves; Armas: Armas simples, bestas de mão, espadas longas, rapieiras, espadas curtas; Ferramentas: Três instrumentos musicais, à sua escolha; Testes de Resistência: Destreza, Carisma",
            IdListaMagia = 1
        },
        new Classe
        {
            IdClasse = 3,
            DadoVida = 8,
            Nome = "Bruxo",
            Equipamento = "(a) uma besta leve e 20 virotes ou (b) qualquer arma simples  (a) uma bolsa de componentes ou (b) um foco arcano  (a) um pacote de estudioso ou (b) um pacote de explorador  Armadura de couro, qualquer arma simples e duas adagas",
            Proficiencia = "Armaduras: Armaduras leves; Armas: Armas simples; Ferramentas: Nenhuma; Testes de Resistência: Sabedoria, Carisma",
            IdListaMagia = 2
        },
        new Classe
        {
            IdClasse = 4,
            DadoVida = 8,
            Nome = "Clérigo",
            Equipamento = "(a) uma maça ou (b) um martelo de guerra (se for proficiente)  (a) brunea, (b) armadura de couro ou (c) cota de malha (se for proficiente)  (a) um besta leve e 20 virotes ou (b) qualquer arma simples  (a) um pacote de sacerdote ou (b) um pacote de aventureiro  Um escudo e um símbolo sagrado",
            Proficiencia = "Armaduras: Armaduras leves, armaduras médias, escudos; Armas: Todas as armas simples; Testes de Resistência: Sabedoria, Carisma",
            IdListaMagia = 3
        },
        new Classe
        {
            IdClasse = 5,
            DadoVida = 8,
            Nome = "Druida",
            Equipamento = "(a) um escudo de madeira ou (b) qualquer arma simples (a) uma cimitarra ou (b) qualquer arma corpo-a-corpo simples (a) um pacote de estudioso ou (b) um pacote de explorador  Armadura de couro, um pacote de aventureiro e um foco druídico",
            Proficiencia = "Armaduras leves, armaduras médias, escudos (druidas não irão vestir armaduras ou usar escudos feitos de metal); Armas: Clavas, adagas, dardos, azagaias, maças, bordões, cimitarras, foices, fundas e lanças; Ferramentas: Kit de herbalismo; Testes de Resistência: Inteligência, Sabedoria",
            IdListaMagia = 4
        },
        new Classe
        {
            IdClasse = 6,
            DadoVida = 6,
            Nome = "Feiticeiro",
            Equipamento = "(a) uma besta leve e 20 virotes ou (b) qualquer arma simples  (a) uma bolsa de componentes ou (b) um foco arcano  (a) um pacote de explorador ou (b) um pacote de aventureiro",
            Proficiencia = "Armaduras: Nenhuma; Armas: Adagas, dardos, fundas, bordões e bestas leves; Ferramentas: Nenhuma; Testes de Resistência: Constituição, Carisma",
            IdListaMagia = 5
        },
        new Classe
        {
            IdClasse = 7,
            DadoVida = 10,
            Nome = "Guerreiro",
            Equipamento = "(a) cota de malha ou (b) gibão de peles, arco longo e 20 flechas  (a) uma arma marcial e um escudo ou (b) duas armas marciais  (a) uma besta leve e 20 virotes ou (b) dois machados de arremesso  (a) um pacote de aventureiro ou (b) um pacote de explorador",
            Proficiencia = "Armaduras: Todas as armaduras, escudos; Armas: Armas simples, armas marciais; Ferramentas: nenhum; Testes de Resistência: Força, Constituição",
            IdListaMagia = null
        },
        new Classe
        {
            IdClasse = 8,
            DadoVida = 8,
            Nome = "Ladino",
            Equipamento = "(a) uma rapieira ou (b) uma espada longa  (a) um arco curto e uma aljava com 20 flechas ou (b) uma espada curta  (a) um pacote de assaltante ou (b) um pacote de aventureiro ou (c) um pacote de explorador  Armadura de couro, duas adagas e ferramentas de ladrão",
            Proficiencia = "Armaduras: Armaduras leves; Armas: Armas simples, bestas de mão, espadas longas, rapieiras, espadas curtas; Ferramentas: Ferramentas de ladrão; Testes de Resistência: Destreza, Inteligência",
            IdListaMagia = null
        },
        new Classe
        {
            IdClasse = 9,
            DadoVida = 6,
            Nome = "Mago",
            Equipamento = "(a) uma arma marcial e um escudo ou (b) duas armas marciais  (a) cinco azagaias ou (b) qualquer arma simples corpoa-corpo  (a) um pacote de sacerdote ou (b) um pacote de aventureiro  Cota de malha e um símbolo sagrado",
            Proficiencia = "Armaduras: Nenhuma; Armas: Adagas, dardos, fundas, bordões, bestas leves; Ferramentas: Nenhuma; Testes de Resistência: Inteligência, Sabedoria",
            IdListaMagia = 8
        },
        new Classe
        {
            IdClasse = 10,
            DadoVida = 8,
            Nome = "Monge",
            Equipamento = "(a) uma arma marcial e um escudo ou (b) duas armas marciais  (a) cinco azagaias ou (b) qualquer arma simples corpoa-corpo  (a) um pacote de sacerdote ou (b) um pacote de aventureiro  Cota de malha e um símbolo sagrado",
            Proficiencia = "Armaduras: Todas as armaduras, escudos; Armas: Armas simples, armas marciais; Ferramentas: Nenhum; Testes de Resistência: Sabedoria, Carisma",
            IdListaMagia = null
        },
        new Classe
        {
            IdClasse = 11,
            DadoVida = 10,
            Nome = "Paladino",
            Equipamento = "(a) uma arma marcial e um escudo ou (b) duas armas marciais  (a) cinco azagaias ou (b) qualquer arma simples corpoa-corpo  (a) um pacote de sacerdote ou (b) um pacote de aventureiro  Cota de malha e um símbolo sagrado",
            Proficiencia = "Armaduras: Todas as armaduras, escudos; Armas: Armas simples, armas marciais; Ferramentas: Nenhum; Testes de Resistência: Sabedoria, Carisma",
            IdListaMagia = 6
        },
        new Classe
        {
            IdClasse = 12,
            DadoVida = 10,
            Nome = "Patrulheiro",
            Equipamento = "(a) brunea ou (b) armadura de couro  (a) duas espadas curtas ou (b) duas armas simples corpo-a-corpo  (a) um pacote de explorador ou (b) um pacote de aventureiro  Um arco longo e uma aljava com 20 flechas",
            Proficiencia = "Armaduras: Armaduras leves, armaduras médias, escudos; Armas: Armas simples, armas marciais; Ferramentas: Nenhuma; Testes de Resistência: Força, Destreza",
            IdListaMagia = 7
        }
        );
        modelBuilder.Entity<TracodeClasse>().HasData(
        new TracodeClasse
        {
            IdTracodeClasse = 1,
            Nome = "Fúria",
            HabilidadeTracodeClasse = "Em batalha, você luta com uma ferocidade primitiva. No seu turno, você pode entrar em fúria com uma ação bônus. \nEnquanto estiver em fúria, você recebe os seguintes benefícios se você não estiver vestindo uma armadura pesada: *Você tem vantagem em testes de Força e testes de resistência de Força. *Quando você desferir um ataque com arma corpo-acorpo usando Força, você recebe um bônus nas jogadas de dano que aumenta à medida que você adquire níveis de bárbaro, como mostrado na coluna Dano de Fúria na tabela O Bárbaro. *Você possui resistência contra dano de concussão, cortante e perfurante. Se você for capaz de conjurar magias, você não poderá conjurá-las ou se concentrar nelas enquanto estiver em fúria. Sua fúria dura por 1 minuto. Ela termina prematuramente se você cair inconsciente ou se seu turno acabar e você não tiver atacado nenhuma criatura hostil desde seu último turno ou não tiver sofrido dano nesse período. Você também pode terminar sua fúria no seu turno com uma ação bônus. Quando você tiver usado a quantidade de fúrias mostrada para o seu nível de bárbaro na coluna Fúrias da tabela O Bárbaro, você precisará terminar um descanso longo antes de poder entrar em fúria novamente. "
        },
        new TracodeClasse
        {
            IdTracodeClasse = 2,
            Nome = "Defesa sem Armadura",
            HabilidadeTracodeClasse = "Quando você não estiver vestindo qualquer armadura, sua Classe de Armadura será 10 + seu modificador de Destreza + seu modificador de Constituição. Você pode usar um escudo e continuar a receber esse benefício. "
        },
        new TracodeClasse
        {
            IdTracodeClasse = 3,
            Nome = "Ataque Descuidado",
            HabilidadeTracodeClasse = "A partir do 2° nível, você pode desistir de toda preocupação com sua defesa para atacar com um desespero feroz. Quando você fizer o seu primeiro ataque no turno, você pode decidir atacar descuidadamente. Fazer isso lhe concede vantagem nas jogadas de ataque com armas corpo-a-corpo usando Força durante seu turno, porém, as jogadas de ataques feitas contra você possuem vantagem até o início do seu próximo turno."
        },
        new TracodeClasse
        {
            IdTracodeClasse = 4,
            Nome = "Sentido de Perigo",
            HabilidadeTracodeClasse = "No 2° nível, você adquire um sentido sobrenatural de quando as coisas próximas não estão como deveriam, concedendo a você uma chance maior quando estiver evitando perigos. Você possui vantagem em testes de resistência de Destreza contra efeitos que você possa ver, como armadilhas e magias. Para receber esse benefício você não pode estar cego, surdo ou incapacitado. "
        },
        new TracodeClasse
        {
            IdTracodeClasse = 5,
            Nome = "Caminho Primitivo",
            HabilidadeTracodeClasse = "No 3° nível, você escolhe um caminho que molda a natureza da sua fúria. Escolha o Caminho do Furioso ou o Caminho do Guerreiro Totêmico, ambos detalhados no final da descrição de classe. Sua escolha lhe concederá características no 3° nível e novamente no 6°, 10° e 14° níveis. "
        },
        new TracodeClasse
        {
            IdTracodeClasse = 6,
            Nome = "Incremento no Valor de Habilidade",
            HabilidadeTracodeClasse = "Quando você atinge o 4° nível e novamente no 8°, 12°, 16° e 19° nível, você pode aumentar um valor de habilidade, à sua escolha, em 2 ou você pode aumentar dois valores de habilidade, à sua escolha em 1. Como padrão, você não pode elevar um valor de habilidade acima de 20 com essa característica."
        },
        new TracodeClasse
        {
            IdTracodeClasse = 7,
            Nome = "Ataque Extra",
            HabilidadeTracodeClasse = "A partir do 5° nível, você pode atacar duas vezes, ao invés de uma, sempre que você realizar a ação de Ataque no seu turno. "
        },
        new TracodeClasse
        {
            IdTracodeClasse = 8,
            Nome = "Movimento Rápido",
            HabilidadeTracodeClasse = "Começando no 5° nível, seu deslocamento aumenta em 3 metros enquanto você não estiver vestindo uma armadura pesada."
        },
        new TracodeClasse
        {
            IdTracodeClasse = 9,
            Nome = "Instinto Selvagem",
            HabilidadeTracodeClasse = "No 7° nível, seu instinto está tão apurado que você recebe vantagem nas jogadas de iniciativa. Além disso, se você estiver surpreso no começo de um combate e não estiver incapacitado, você pode agir normalmente no seu primeiro turno, mas apenas se você entrar em fúria antes de realizar qualquer outra coisa neste turno. "

        },
        new TracodeClasse
        {
            IdTracodeClasse = 10,
            Nome = "Crítico Brutal",
            HabilidadeTracodeClasse = "A partir do 9° nível, você pode rolar um dado de dano de arma adicional quando estiver determinando o dano extra de um acerto crítico com uma arma corpo-a-corpo. Isso aumenta para dois dados adicionais no 13° nível e três dados adicionais no 17° nível."
        },
        new TracodeClasse
        {
            IdTracodeClasse = 11,
            Nome = "Fúria Implacável",
            HabilidadeTracodeClasse = "A partir do 11° nível, sua fúria pode manter você lutando independente da gravidade dos seus ferimentos. Se você cair para 0 pontos de vida enquanto estiver em fúria e não morrer, você pode realizar um teste de resistência de Constituição CD 10. Se você for bem sucedido, você volta para 1 ponto de vida ao invés disso. Cada vez que você utilizar essa característica após a primeira, a CD aumenta em 5. Assim que você terminar um descanso curto ou longo a CD volta para 10"
        },
        new TracodeClasse
        {
            IdTracodeClasse = 12,
            Nome = "Fúria Persistente",
            HabilidadeTracodeClasse = "A partir do 15° nível, sua fúria é tão brutal que ela só termina prematuramente se você cair inconsciente ou se você decidir terminá-la. "
        },
        new TracodeClasse
        {
            IdTracodeClasse = 13,
            Nome = "Força Indomável",
            HabilidadeTracodeClasse = "A partir do 18° nível, se o total de um teste de Força seu for menor que o seu valor de Força, você pode usar esse valor no lugar do resultado. "
        },
        new TracodeClasse
        {
            IdTracodeClasse = 14,
            Nome = "Campeão Primitivo",
            HabilidadeTracodeClasse = "No 20° nível, você incorpora os poderes da natureza. Seus valores de Força e Constituição aumentam em 4. Seu máximo para esses valores agora é 24."
        },
        new TracodeClasse
        {
            IdTracodeClasse = 15,
            Nome = "Conjuração",
            HabilidadeTracodeClasse = "Você aprendeu a desembaraçar e remodelar o decido da realidade em harmonia com os seus desejos e música. Suas magias são parte do seu vasto repertório, magia que você pode entoar em diferentes situações. Veja o capítulo 10 para as regras gerais de conjuração e o capítulo 11 para a lista de magias de bardo. TRUQUES Você conhece dois truques, à sua escolha da lista de magias de bardo. Você aprende truques de bardo adicionais, à sua escolha em níveis mais altos, como mostrado na coluna Truques Conhecidos da tabela O Bardo. A tabela O Bardo mostra quantos espaços de magia de 1° nível e superiores você possui disponíveis para conjuração. Para conjurar uma dessas magias, você deve gastar uma espaço de magia do nível da magia ou superior. Você recobra todos os espaços de magia gastos quando você completa um descanso longo. Por exemplo, se você quiser conjurar a magia de 1° nível curar ferimentos e você tiver um espaço de magia de 1° nível e um de 2° nível disponíveis, você poderá conjurar curar ferimentos usando qualquer dos dois espaços. MAGIAS CONHECIDAS DE 1° NÍVEL E SUPERIORES Você conhece quatro magias de 1° nível, à sua escolha, da lista de magias de bardo. A coluna Magias Conhecidas na tabela O Bardo mostra quando você aprende mais magias de bardo, à sua escolha. Cada uma dessas magias deve ser de um nível a que você tenha acesso, como mostrado na tabela. Por exemplo, quando você alcança o 3° nível da classe, você pode aprender uma nova magia de 1° ou 2° nível. Além disso, quando você adquire um nível nessa classe, você pode escolher uma magia de bardo que você conheça e substituí-la por outra magia da lista de magias de bardo, que também deve ser de um nível ao qual você tenha espaços de magia. HABILIDADE DE CONJURAÇÃO Sua habilidade de conjuração é Carisma para suas magias de bardo, portanto, você usa seu Carisma sempre que alguma magia se referir à sua habilidade de conjurar magias. Além disso, você usa o seu modificador de Carisma para definir a CD dos testes de resistência para as magias de bardo que você conjura e quando você realiza uma jogada de ataque com uma magia. CD para suas magias = 8 + bônus de proficiência + seu modificador de Carisma Modificador de ataque de magia = seu bônus de proficiência + seu modificador de Carisma CONJURAÇÃO DE RITUAL Você pode conjurar qualquer magia de bardo que você conheça como um ritual se ela possuir o descritor ritual. FOCO DE CONJURAÇÃO Você pode usar um instrumento musical (encontrado no capítulo 5) como foco de conjuração das suas magias de bardo. "
        },
        new TracodeClasse
        {
            IdTracodeClasse = 16,
            Nome = "Inspiração de Bardo (d6)",
            HabilidadeTracodeClasse = "Você pode inspirar os outros através de palavras animadoras ou música. Para tanto, você usa uma ação bônus no seu turno para escolher uma outra criatura, que não seja você mesmo, a até 18 metros de você que possa ouvi-lo. Essa criatura ganha um dado de Inspiração de Bardo, um d6. Uma vez, nos próximos 10 minutos, a criatura poderá rolar o dado e adicionar o valor rolado a um teste de habilidade, jogada de ataque ou teste de resistência que ela fizer. A criatura pode esperar até rolar o d20 antes de decidir usar o dado de Inspiração de Bardo, mas deve decidir antes do Mestre dizer se a rolagem foi bem ou mal sucedida. Quando o dado de Inspiração de Bardo for rolado, ele é gasto. Uma criatura pode ter apenas um dado de Inspiração de Bardo por vez. Você pode usar essa característica um número de vezes igual ao seu modificador de Carisma (no mínimo uma vez). Você recupera todos os usos quando termina um descanso longo. Seu dado de Inspiração de Bardo muda quando você atinge certos níveis na classe. O dado se torna um d8 no 5° nível, um d10 no 10° nível e um d12 no 15° nível."
        },
        new TracodeClasse
        {
            IdTracodeClasse = 17,
            Nome = "Versatilidade",
            HabilidadeTracodeClasse = "A partir do 2° nível, você pode adicionar metade do seu bônus de proficiência, arredondado para baixo, em qualquer teste de habilidade que você fizer que ainda não possua seu bônus de proficiência. "
        },
        new TracodeClasse
        {
            IdTracodeClasse = 18,
            Nome = "Canção de Descanso",
            HabilidadeTracodeClasse = "A partir do 2° nível, você pode usar música ou oração calmantes para ajudar a revitalizar seus aliados feridos durante um descanso curto. Se você ou qualquer criatura amigável que puder ouvir sua atuação recuperar pontos de vida no fim do descanso curto ao gastar um ou mais Dados de Vida, cada uma dessas criaturas recupera 1d6 pontos de vida adicionais. Os pontos de vida adicionais aumentam quando você alcança determinados níveis na classe: para 1d8 no 9° nível, para 1d10 no 13° nível e para 1d12 no 17° nível. "
        },
        new TracodeClasse
        {
            IdTracodeClasse = 19,
            Nome = "Colégio de Bardo",
            HabilidadeTracodeClasse = "No 3° nível, você investiga as técnicas avançadas de um colégio de bardo, à sua escolha: o Colégio do Conhecimento ou o Colégio da Bravura, ambos detalhados no final da descrição da classe. Sua escolha lhe concede características no 3° nível e novamente no 6° e 14° nível."
        },
        new TracodeClasse
        {
            IdTracodeClasse = 20,
            Nome = "Aptidão",
            HabilidadeTracodeClasse = "No 3° nível, escolha duas das perícias em que você é proficiente. Seu bônus de proficiência é dobrado em teste de habilidade que você fizer que utilize qualquer das perícias escolhidas. No 10° nível, você escolhe mais duas perícias em que é proficiente para ganhar esse benefício. "
        },
        new TracodeClasse
        {
            IdTracodeClasse = 21,
            Nome = "Fonte de Inspiração",
            HabilidadeTracodeClasse = "Começando no momento em que você atinge o 5° nível, você recupera todas as utilizações gastas da sua Inspiração de Bardo quando você termina um descanso curto ou longo. "
        },
        new TracodeClasse
        {
            IdTracodeClasse = 22,
            Nome = "Canção de Proteção",
            HabilidadeTracodeClasse = "No 6° nível, você adquire a habilidade de usar notas musicais ou palavras de poder para interromper efeito de influência mental. Com uma ação, você pode começar uma atuação que dura até o fim do seu próximo turno. Durante esse tempo, você e qualquer criatura amigável a até 9 metros de você terá vantagem em testes de resistência para não ser amedrontado ou enfeitiçado. Uma criatura deve ser capaz de ouvir você para receber esse benefício. A atuação termina prematuramente se você for incapacitado ou silenciado ou se você terminá-la voluntariamente (não requer ação)"
        },
        new TracodeClasse
        {
            IdTracodeClasse = 23,
            Nome = "Segredos Mágicos",
            HabilidadeTracodeClasse = "No 10° nível, você usurpou conhecimento mágico de um vasto espectro de disciplinas. Escolha duas magias de qualquer classe, incluindo essa. A magia que você escolher deve ser de um nível que você possa conjurar, como mostrado na tabela O Bardo, ou um truque. As magias escolhidas contam como magias de bardo para você e já estão incluídas no número da coluna Magias Conhecidas da tabela O Bardo. Você aprende duas magias adicionais de qualquer classe no 14° nível e novamente no 18° nível."
        },
        new TracodeClasse
        {
            IdTracodeClasse = 24,
            Nome = "Inspiração Superior",
            HabilidadeTracodeClasse = "No 20° nível, quando você rolar iniciativa e não tiver nenhum uso restante de Inspiração de Bardo, você recupera um uso."
        },
        new TracodeClasse
        {
            IdTracodeClasse = 25,
            Nome = "Patrono Transcendental",
            HabilidadeTracodeClasse = "No 1° nível, você conclui uma barganha com um ser transcendental, à sua escolha: a Arquifada, o Corruptor ou o Grande Antigo, cada um deles é detalhado no final da descrição da classe. Sua escolha lhe confere traços no 1° nível e novamente no6°, 10° e 14° nível."
        },
        new TracodeClasse
        {
            IdTracodeClasse = 26,
            Nome = "Magia de Pacto",
            HabilidadeTracodeClasse = "Sua pesquisa arcana e a magia outorgada a você por seu patrono, lhe concedem uma gama de magias. Veja o capítulo 10 para as regras gerais de conjuração e o capítulo 11 para a lista de magias de bruxo. TRUQUES Você conhece dois truques, à sua escolha, da lista de magias de bruxo. Você aprende truques de bruxo adicionais, à sua escolha, em níveis mais altos, como mostrado na coluna Truques Conhecidos da tabela O Bruxo. ESPAÇOS DE MAGIA A tabela O Bruxo mostra quantos espaços de magia você possui. A tabela também mostra qual o nível desses espaços; todos os seus espaços de magia são do mesmo nível. Para conjurar uma magia de bruxo de 1° nível ou superior, você deve gastar uma espaço de magia. Você recobra todos os espaços de magia gastos quando você completa um descanso curto ou longo. Por exemplo, quando você atingir o 5° nível, você terá dois espaços de magia de 3° nível. Para conjurar a magia de 1° nível onda trovejante, você deve gastar um desses espaços e você a conjura como uma magia de 3° nível. MAGIAS CONHECIDAS DE 1° NÍVEL E SUPERIORES No 1° nível, você conhece duas magias de 1° nível, à sua escolha da lista de magias de bruxo. A coluna Magias Conhecidas na tabela O Bruxo mostra quando você aprende mais magias de bruxo, à sua escolha, de 1° nível ou superior. Cada uma dessas magias deve ser de um nível a que você tenha acesso, como mostrado na tabela na coluna de Nível de Magia para o seu nível. Quando você alcança o 6° nível, por exemplo, você aprende uma nova magia de bruxo, que pode ser de 1°, 2° ou 3° nível. Além disso, quando você adquire um nível nessa classe, você pode escolher uma magia de bruxo que você conheça e substituí-la por outra magia da lista de magias de bruxo, que também deve ser de um nível ao qual você tenha espaços de magia. HABILIDADE DE CONJURAÇÃO Sua habilidade de conjuração é Carisma para suas magias de bruxo, portanto, você usa seu Carisma sempre que alguma magia se referir à sua habilidade de conjurar magias. Além disso, você usa o seu modificador de Carisma para definir a CD dos testes de resistência para as magias de bruxo que você conjura e quando você realiza uma jogada de ataque com uma magia. CD para suas magias = 8 + bônus de proficiência + seu modificador de Carisma Modificador de ataque de magia = seu bônus de proficiência + seu modificador de Carisma FOCO DE CONJURAÇÃO Você pode usar um foco arcano (encontrado no capítulo 5) como foco de conjuração das suas magias de bruxo. "
        },
        new TracodeClasse
        {
            IdTracodeClasse = 27,
            Nome = "Invocações Místicas",
            HabilidadeTracodeClasse = "Durante seus estudos sobre conhecimento oculto, você descobriu as invocações místicas, fragmentos de conhecimento proibido que infundiram você com habilidade mágica permanente. No 2° nível, você ganha duas invocações místicas, à sua escolha. Suas opções de invocação estão detalhadas no final da descrição dessa classe. Quando você atinge certos nível de bruxo, você adquire novas invocações à sua escolha, como mostrado na coluna Invocações Conhecidas na tabela O Bruxo. Além disso, quando você adquire um novo nível nessa classe, você pode escolher uma invocação que você conheça e substituí-la por outra invocação que você possa aprender nesse nível. "
        },
        new TracodeClasse
        {
            IdTracodeClasse = 28,
            Nome = "Dádiva de Pacto",
            HabilidadeTracodeClasse = "No 3° nível, seu patrono transcendental lhe confere um dom por seus leais serviços. Você adquire uma das características a seguir, à sua escolha."
        },
        new TracodeClasse
        {
            IdTracodeClasse = 29,
            Nome = "Arcana Mística",
            HabilidadeTracodeClasse = "No 11° nível, seu patrono confere a você um segredo mágico conhecido como arcana. Escolha uma magia de 6° nível da lista de magias de bruxo como sua arcana. Você pode conjurar essa magia arcana uma vez sem gastar um espaço de magia. Você deve terminar um descanso longo antes de poder fazer isso novamente. Em nível altos, você adquire mais magias de bruxo de sua escolha que podem ser conjuradas dessa forma: uma magia de 7° nível no 13° nível, uma magia de 8° nível no 15° nível e uma magia de 9° nível no 17° nível. Você recupera todos os usos de sua Arcana Mística quando você termina um descanso longo."
        },
        new TracodeClasse
        {
            IdTracodeClasse = 30,
            Nome = "Mestre Místico",
            HabilidadeTracodeClasse = "No 20° nível, você pode recarregar sua reserva interior de poder místico quando suplicar ao seu patrono para recuperar espaços de magia gastos. Você pode gastar 1 minuto suplicando pela ajuda do seu patrono para recuperar todos os espaços de magia gastos da sua característica Magia de Pacto. Uma vez que você recuperou espaços de magia com essa característica, você deve terminar um descanso longo antes de fazê-lo novamente. "
        },
        new TracodeClasse
        {
            IdTracodeClasse = 31,
            Nome = "Conjuração",
            HabilidadeTracodeClasse = "CONJURAÇÃO Como um canalizador de poder divino, você pode conjurar magias de clérigo. Veja o capítulo 10 para as regras gerais de conjuração e o capítulo 11 para a lista de magias de clérigo. TRUQUES Você conhece três truques, à sua escolha, da lista de magias de clérigo. Você aprende truques de clérigo adicionais, à sua escolha, em níveis mais altos, como mostrado na coluna Truques Conhecidos da tabela O Clérigo. PREPARANDO E CONJURANDO MAGIAS A tabela O Clérigo mostra quantos espaços de magia você têm para conjurar suas magias de 1º nível e superiores. Para conjurar uma dessas magias, você precisa gastar um espaço do nível da magia ou superior. Você recupera todos os espaços gastos quando termina um descanso longo. Você prepara a lista de magias disponíveis selecionando-as da lista de magias de clérigo. Você seleciona um número de magias igual ao seu modificador de Sabedoria + seu nível de clérigo (mínimo de uma magia). Essas magias devem ser de níveis que você possua espaços de magia. Por exemplo, se você é um clérigo de 3º nível, você possui quatro espaços de magia de 1º nível e dois de 2º nível. Com Sabedoria 16, sua lista de magias preparadas pode incluir 6 magias, combinando as de 1º e 2º nível em qualquer ordem. Se você preparar a magia de 1º nível curar ferimentos, você pode conjurá-la com um espaço de magia de 1º ou de 2º nível. Ao conjurar a magia, você não a retira de sua lista de magias preparadas, podendo conjurá-la de novo se tiver espaços de magia disponíveis. Você pode modificar a sua lista de magias preparadas quando termina um descanso longo. Preparar uma nova lista de magias de clérigo requer tempo gasto em preces e meditação: no mínimo 1 minuto por nível de magia para cada magia preparada. HABILIDADE DE CONJURAÇÃO Sabedoria é a sua habilidade para você conjurar suas magias de clérigo. O poder de suas magias vem da devoção que você tem ao seu deus. Você usa sua Sabedoria sempre que alguma magia se referir a sua habilidade de conjurar magias. Além disso, você usa o seu modificador de Sabedoria para definir a CD dos testes de resistência para as magias de clérigo que você conjura e quando você realiza uma jogada de ataque com uma magia. CD para suas magias = 8 + bônus de proficiência + seu modificador de Sabedoria Modificador de ataque de magia = seu bônus de proficiência + seu modificador de Sabedoria CONJURAÇÃO DE RITUAL Você pode conjurar qualquer magia de clérigo que você conheça como um ritual se ela possuir o descritor ritual. FOCO DE CONJURAÇÃO Você pode usar um símbolo sagrado (encontrado no capítulo 5) como foco de conjuração das suas magias de clérigo. "
        },
        new TracodeClasse
        {
            IdTracodeClasse = 32,
            Nome = "Domínio Divino",
            HabilidadeTracodeClasse = "Escolha um domínio relacionado à sua divindade: Conhecimento, Enganação, Guerra, Luz, Natureza, Tempestade ou Vida. Cada domínio é detalhado ao final da descrição da classe e, cada um, fornece exemplos dos deuses associados a eles. Essa escolha, realizada no 1º nível, concede magias de domínio e outras características. Ela também concede a você outras formas de utilizar seu Canalizar Divindade quando você ganhá-lo no 2º nível, bem como outros benefícios no 6º, 8º e 17º níveis. MAGIAS DE DOMÍNIO Cada domínio tem uma lista de magias – as magias de domínio – que você adquire nos níveis especificados pelo seu domínio. Quando você ganha uma magia de domínio, você sempre a tem preparada, e essa magia não conta no número de magias que você pode preparar a cada dia. Se você tem uma magia de domínio que não aparece na lista de magias de clérigo, mesmo assim ela é uma magia de clérigo para você."
        },
        new TracodeClasse
        {
            IdTracodeClasse = 33,
            Nome = "Canalizar Divindade",
            HabilidadeTracodeClasse = "No 2º nível, você se torna capaz de canalizar energia diretamente de sua divindade, utilizando-a como combustível para efeitos mágicos. Você começa com dois efeitos: Expulsar Mortos-vivos e um efeito determinado pelo seu domínio. Alguns domínios conferem efeitos adicionais conforme você avança de nível, como consta na descrição de cada domínio. Quando você usar seu Canalizar Divindade, você escolhe qual efeito quer criar. Você precisa terminar um descanso curto ou longo para usar a característica de novo. 66 Alguns efeitos requerem teste de resistência. Quando você usar um desses efeitos, a CD é igual a das suas magias de clérigo. A partir do 6º nível, você pode Canalizar Divindade duas vezes entre descansos e a partir do 18º nível, três vezes. Você recupera os usos dessa característica quando termina um descanso curto ou longo. CANALIZAR DIVINDADE: EXPULSAR MORTOS-VIVOS Usando uma ação, você levanta seu símbolo sagrado e murmura uma prece repreendendo os mortos-vivos. Cada morto-vivo que puder ver ou ouvir você em um raio de 9 metros a partir de você, deve fazer um teste de resistência de Sabedoria. Se falhar, a criatura está expulsa por 1 minuto ou até sofrer algum dano. Uma criatura expulsa deve usar seu turno para fugir da melhor forma possível e de forma alguma pode aproximar-se a mais de 9 metros de você por vontade própria. Ela também não pode usar reações. Como uma ação, a criatura pode apenas realizar uma Disparada ou tentar escapar de um efeito que a impeça de se mover. Se não há lugar para ir, a criatura pode usar a ação Esquivar"
        },
        new TracodeClasse
        {
            IdTracodeClasse = 34,
            Nome = "Característica de Domínio Divino",
            HabilidadeTracodeClasse = "Escolha um domínio relacionado à sua divindade: Conhecimento, Enganação, Guerra, Luz, Natureza, Tempestade ou Vida. Cada domínio é detalhado ao final da descrição da classe e, cada um, fornece exemplos dos deuses associados a eles. Essa escolha, realizada no 1º nível, concede magias de domínio e outras características. Ela também concede a você outras formas de utilizar seu Canalizar Divindade quando você ganhá-lo no 2º nível, bem como outros benefícios no 6º, 8º e 17º níveis. MAGIAS DE DOMÍNIO Cada domínio tem uma lista de magias – as magias de domínio – que você adquire nos níveis especificados pelo seu domínio. Quando você ganha uma magia de domínio, você sempre a tem preparada, e essa magia não conta no número de magias que você pode preparar a cada dia. Se você tem uma magia de domínio que não aparece na lista de magias de clérigo, mesmo assim ela é uma magia de clérigo para você"
        },
        new TracodeClasse
        {
            IdTracodeClasse = 35,
            Nome = "Incremento no Valor de Habilidade",
            HabilidadeTracodeClasse = "Quando você atinge o 4° nível e novamente no 8°, 12°, 16° e 19° nível, você pode aumentar um valor de habilidade, à sua escolha, em 2 ou você pode aumentar dois valores de habilidade, à sua escolha, em 1. Como padrão, você não pode elevar um valor de habilidade acima de 20 com essa característica. "
        },
        new TracodeClasse
        {
            IdTracodeClasse = 36,
            Nome = "Destruir Mortos-Vivos",
            HabilidadeTracodeClasse = "A partir do 5º nível, quando um morto-vivo falhar no teste de resistência contra a sua característica Expulsar Mortos-vivos, ele é instantaneamente destruído se o Nível de Desafio dele for menor ou igual ao valor da tabela Destruir Mortos-vivos, de acordo com seu nível de clérigo. DESTRUIR MORTOS-VIVOS Nível de Clérigo Destrói Mortos-Vivos de ND 5° 1/2 ou menor 8° 1 ou menor 11° 2 ou menor 14° 3 ou menor 17° 4 ou menor"
        },
        new TracodeClasse
        {
            IdTracodeClasse = 37,
            Nome = "Intervenção Divina",
            HabilidadeTracodeClasse = "A partir do 10º nível, você pode rogar à sua divindade para que auxilie você em uma árdua tarefa. Implorar pelo auxílio requer uma ação. Você precisa descrever o que busca e realizar uma rolagem de dado de percentagem. Se o resultado for menor ou igual ao seu nível de clérigo, sua divindade intervém. O Mestre escolhe a natureza da intervenção. O efeito de qualquer magia de clérigo ou magia de domínio é apropriado como resultado. Se sua divindade intervir, você fica impedido de usar essa característica de novo por 7 dias. Do contrário, você pode usá-la de novo após terminar um descanso longo. No 20º nível, seus pedidos de intervenção funcionam automaticamente, sem necessidade de rolagem de dados"
        },
        new TracodeClasse
        {
            IdTracodeClasse = 38,
            Nome = "Druídico",
            HabilidadeTracodeClasse = "Você conhece o Druídico, o idioma secreto dos druidas. Você pode falar esse idioma e usá-lo para deixar mensagens escondidas. Você e outros que conheçam esse idioma automaticamente veem tais mensagens. Outros perceberão a presença da mensagem se passarem num teste de Sabedoria (Percepção) CD 15, mas não conseguirão decifrá-lo sem magia."
        },
        new TracodeClasse
        {
            IdTracodeClasse = 39,
            Nome = "Conjuração",
            HabilidadeTracodeClasse = "Baseado na essência divina da própria natureza, você pode conjurar magias para moldar sua essência a sua vontade. Veja o capítulo 10 para as regras gerais de conjuração e o capítulo 11 para a lista de magias de druida. TRUQUES Você conhece dois truques, à sua escolha, da lista de magias de druida. Você aprende truques de druida adicionais, à sua escolha, em níveis mais altos, como mostrado na coluna Truques Conhecidos da tabela O Druida. PREPARANDO E CONJURANDO MAGIAS A tabela O Druida mostra quantos espaços de magia você têm para conjurar suas magias de 1º nível e superiores. Para conjurar uma dessas magias, você precisa gastar um espaço do nível da magia ou superior. Você recupera todos os espaços gastos quando termina um descanso longo. PLANTAS E FLORESTAS SAGRADAS O druida tem certas plantas como sagradas, em particular o amieiro, freixo, bétula, elder, avelã, azevinho, zimbro, visco, carvalho, sorva, salgueiro e teixo. Druidas, muitas vezes, usam essas plantas como parte de seu foco de conjuração, incorporando lascas de carvalho ou teixo ou ramos de visco branco. Da mesma forma, um druida usa tais madeiras para fazer outros objetos, com armas e escudos. O teixo está associado a morte e renascimento, então, empunhaduras de cimitarras ou foices seriam feitas com esse material. O freixo está associado com a vida e o carvalho com a força. Essas madeiras fazem excelentes cabos ou armas inteiras, como clavas ou bordões, assim como escudos. O amieiro é associado ao ar e seria usado para armas de arremesso, como dardos e azagaias. Os druidas de regiões que não possuem as plantas descritas aqui, tem que escolher outras plantas para usos similares. Por exemplo, um druida de uma região desértica valorizaria a árvore da iúca e as plantas de cacto. Você prepara a lista de magias disponíveis selecionando-as da lista de magias de Druida. Você seleciona um número de magias igual ao seu modificador de Sabedoria + seu nível de druida (mínimo de uma magia). Essas magias devem ser de níveis que você possua espaços de magia. Por exemplo, se você é um druida de 3º nível, você possui quatro espaços de magia de 1º nível e dois de 2º nível. Com Sabedoria 16, sua lista de magias preparadas pode incluir 6 magias, combinando as de 1º e 2º nível em qualquer ordem. Se você preparar a magia de 1º nível curar ferimentos, você pode conjurá-la com um espaço de magia de 1º ou de 2º nível. Ao conjurar a magia, você não a retira de sua lista de magias preparadas, podendo conjurá-la de novo se tiver espaços de magia disponíveis. Você pode modificar a sua lista de magias preparadas quando termina um descanso longo. Preparar uma nova lista de magias de druida requer tempo gasto em preces e meditação: no mínimo 1 minuto por nível de magia para cada magia preparada. HABILIDADE DE CONJURAÇÃO Sabedoria é a sua habilidade para você conjurar suas magias de druida, já que sua magia vem da sua devoção e sintonia com a natureza. Você usa sua Sabedoria sempre que alguma magia se referir a sua habilidade de conjurar magias. Além disso, você usa o seu modificador de Sabedoria para definir a CD dos testes de resistência para as magias de druida que você conjura e quando você realiza uma jogada de ataque com uma magia. CD para suas magias = 8 + bônus de proficiência + seu modificador de Sabedoria Modificador de ataque de magia = seu bônus de proficiência + seu modificador de Sabedoria CONJURAÇÃO DE RITUAL Você pode conjurar qualquer magia de druida que você conheça como um ritual se ela possuir o descritor ritual. FOCO DE CONJURAÇÃO Você pode usar um foco druídico (encontrado no capítulo 5) como foco de conjuração das suas magias de druida. "
        },
        new TracodeClasse
        {
            IdTracodeClasse = 40,
            Nome = "Círculo Druídico",
            HabilidadeTracodeClasse = "No 2° nível, você escolhe se identificar com um círculo de druidas: o Círculo da Terra ou o Círculo da Lua, ambos detalhados no final da descrição da classe. Sua escolha lhe concede características no 2° nível e novamente no 6°, 10° e 14° nível."
        },
        new TracodeClasse
        {
            IdTracodeClasse = 41,
            Nome = "Forma Selvagem",
            HabilidadeTracodeClasse = "A partir do 2° nível, você pode usar sua ação para assumir magicamente a forma de uma besta que você já tenha visto antes. Você pode usar essa característica duas vezes. Você recupera os usos quando termina um descanso curto ou longo. Seu nível de druida determina as bestas em que você pode se transformar, como mostrado na tabela Formas de Besta. No 2° nível, por exemplo, você pode se transformar em qualquer besta que possui nível de desafio 1/4 ou inferior que não possua deslocamento de voo ou natação. FORMAS DE BESTA Nível ND Máx. Limitações Exemplo 2° 1/4 Sem deslocamento de voo ou natação Lobo 4° 1/2 Sem deslocamento de voo Crocodilo 8° 1 – Águia gigante Você pode continuar na forma de besta por um número de horas igual à metade do seu nível de druida (arredondado para baixo). Então, você volta a sua forma original, a não ser que você gaste outro uso dessa característica. Você pode reverter a sua forma normal 74 prematuramente usando uma ação bônus no seu turno. Você reverte automaticamente se cair inconsciente, cair a 0 pontos de vida ou morrer. Enquanto estiver transformado, as seguintes regras se aplicam:  Suas estatísticas de jogo são substituídas pelas estatísticas da besta, mas você mantem sua tendência, personalidade e valores de Inteligência, Sabedoria e Carisma. Você também mantem suas proficiências em todas as suas perícias e testes de resistência, além de receber as proficiências da criatura. Se a criatura possuir a mesma proficiência que você e o bônus no bloco de estatística dela for maior que o seu, você usará o bônus da criatura no lugar do seu. Se a criatura possuir qualquer ação lendária ou de covil, você não pode usá-las.  Quando você se transforma, você assume os pontos de vida e Dados de Vida da criatura. Quando você reverte a sua forma normal, você retorna ao número de pontos de vida que tinha antes de se transformar. Porém, se você reverter como resultado de ter caído a 0 pontos de vida, todo o dano excedente será transferido para a sua forma normal. Por exemplo, se você sofrer 10 pontos de dano em forma animal e tiver apenas 1 ponto de vida restante, você reverte e sofre 9 de dano. Contanto que o dano excedente não reduza você a 0 pontos de vida, você não cairá inconsciente.  Você não pode conjurar magias e sua capacidade de fala ou de realizar qualquer ação que requeira mãos são limitadas pelas capacidades da forma da besta que você assumiu. Transformar-se não interrompe sua concentração em uma magia que você já tenha conjurado, no entanto, nem previne você de realizar ações que são parte da conjuração, como convocar relâmpagos que você já tenha conjurado.  Você mantem os benefícios de todas as características de classe, raça ou outras fontes, e pode usá-las caso a nova forma seja fisicamente capaz de fazê-lo. No entanto, você não pode usar qualquer dos seus sentidos especiais, como visão no escuro, a não ser que a sua nova forma também tenha esse sentido.  Você pode escolher se o seu equipamento cai no chão no seu espaço, é assimilado a sua nova forma ou é usado por ela. Equipamentos vestidos e carregados funcionam normalmente, mas o Mestre decide qual equipamento é viável para a nova forma vestir ou usar, baseado na forma e tamanho da criatura. O seu equipamento não muda de forma ou tamanho para se adaptar à nova forma e, qualquer equipamento que a nova forma não possa vestir deve, ou cair no chão ou ser assimilado por ela. Equipamentos assimilados não terão efeito até você deixar a forma."
        },
        new TracodeClasse
        {
            IdTracodeClasse = 42,
            Nome = "Incremento no Valor de Habilidade",
            HabilidadeTracodeClasse = "Quando você atinge o 4° nível e novamente no 8°, 12°, 16° e 19° nível, você pode aumentar um valor de habilidade, à sua escolha, em 2 ou você pode aumentar dois valores de habilidade, à sua escolha, em 1. Como padrão, você não pode elevar um valor de habilidade acima de 20 com essa característica. "
        },
        new TracodeClasse
        {
            IdTracodeClasse = 43,
            Nome = "Corpo Atemporal",
            HabilidadeTracodeClasse = "Começando no 18° nível, a magia primordial que você controla faz com que você envelheça mais lentamente. Para cada 10 anos que passarem, seu corpo envelhece apenas 1."
        },
        new TracodeClasse
        {
            IdTracodeClasse = 44,
            Nome = "Magias da Besta",
            HabilidadeTracodeClasse = "A partir do 18° nível, você pode conjurar muitas das suas magias em qualquer forma que assumir usando a Forma Selvagem. Você pode realizar os componentes somáticos e verbais de uma magia de druida na forma de besta, mas você não é capaz de prover os componentes materiais."
        },
        new TracodeClasse
        {
            IdTracodeClasse = 45,
            Nome = "Arquidruida",
            HabilidadeTracodeClasse = "No 20° nível, você pode usar sua Forma Selvagem um número ilimitado de vezes. "
        },
        new TracodeClasse
        {
            IdTracodeClasse = 46,
            Nome = "Conjuração",
            HabilidadeTracodeClasse = "Um evento do seu passado ou na vida de um parente ou ancestral, deixou uma marca indelével em você, infundindo você com magia arcana. A fonte desse poder, independente da sua origem, flui em suas magias. Veja o capítulo 10 para as regras gerais de conjuração e o capítulo 11 para a lista de magias de feiticeiro. TRUQUES Você conhece quatro truques, à sua escolha, da lista de magias de feiticeiro. Você aprende truques de feiticeiro adicionais, à sua escolha, em níveis mais altos, como mostrado na coluna Truques Conhecidos da tabela O Feiticeiro. ESPAÇOS DE MAGIA A tabela O Feiticeiro mostra quantos espaços de magia de 1° nível e superiores você possui disponíveis para conjuração. Para conjurar uma dessas magias, você deve gastar uma espaço de magia do nível da magia ou superior. Você recobra todos os espaços de magia gastos quando você completa um descanso longo. Por exemplo, se você quiser conjurar a magia de 1° nível mãos flamejantes e você tiver um espaço de magia de 1° nível e um de 2° nível disponíveis, você poderá conjurar mãos flamejantes usando qualquer dos dois espaços. MAGIAS CONHECIDAS DE 1° NÍVEL E SUPERIORES Você conhece duas magias de 1° nível, à sua escolha, da lista de magias de feiticeiro. A coluna Magias Conhecidas na tabela O Feiticeiro mostra quando você aprende mais magias de feiticeiro, à sua escolha. Cada uma dessas magias deve ser de um nível a que você tenha acesso, como mostrado na tabela. Por exemplo, quando você alcança o 3° nível da classe, você pode aprender uma nova magia de 1° ou 2° nível. Além disso, quando você adquire um nível nessa classe, você pode escolher uma magia de feiticeiro que você conheça e substituí-la por outra magia da lista de magias de feiticeiro, que também deve ser de um nível ao qual você tenha espaços de magia. HABILIDADE DE CONJURAÇÃO Carisma é a sua habilidade de conjuração para suas magias de feiticeiro, já que o poder da sua magia depende da sua capacidade de projetar sua vontade no mundo. Use seu Carisma sempre que alguma magia se referir à sua habilidade de conjurar magias. Além disso, você usa o seu modificador de Carisma para definir a CD dos testes de resistência para as magias de feiticeiro que você conjura e quando você realiza uma jogada de ataque com uma magia. CD para suas magias = 8 + bônus de proficiência + seu modificador de Carisma Modificador de ataque de magia = seu bônus de proficiência + seu modificador de Carisma FOCO DE CONJURAÇÃO Você pode usar um foco arcano (encontrado no capítulo 5) como foco de conjuração das suas magias de feiticeiro. "
        },
        new TracodeClasse
        {
            IdTracodeClasse = 47,
            Nome = "Origem de Feitiçaria",
            HabilidadeTracodeClasse = "Escolha uma origem de feitiçaria, que descreve a fonte do seu poder mágico inato: Linhagem Dracônica ou Magia Selvagem, ambos detalhados no final da descrição da classe. Sua escolha lhe confere características quando você a escolhe, no 1° nível e novamente no 6°, 14° e 18° nível."
        },
        new TracodeClasse
        {
            IdTracodeClasse = 48,
            Nome = "Fonte de Magia",
            HabilidadeTracodeClasse = "No 2° nível, você alcança uma profunda fonte de magia dentro de você. Essa fonte é representada pelos pontos de feitiçaria, que permitem que você crie uma variedade de efeitos mágicos. PONTOS DE FEITIÇARIA Você tem 2 pontos de feitiçaria e ganha mais a medida que alcança níveis elevados, como mostrado na coluna Pontos de Feitiçaria da tabela O Feiticeiro. Você nunca poderá ter mais pontos de feitiçaria que os mostrados na tabela para o seu nível. Você recupera todos os pontos de feitiçaria gastos quando termina um descanso longo. CONJURAÇÃO FLEXÍVEL Você pode usar seus pontos de feitiçaria para ganhar novos espaços de magia ou sacrificar espaços de magia para ganhar pontos de magia adicionais. Você aprende novas formas de usar seus pontos de feitiçaria quando alcança níveis elevados. Os espaços de magia criados desaparecem ao final de um descanso longo. Criando Espaços de Magia. Você pode transformar pontos de fetiçaria disponíveis em um espaço de magia, com uma ação bônus, no seu turno. A tabela Criando Espaços de Magia mostra o custo para criar um espaço de magia de determinado nível. Você não pode criar espaços de magia acima do 5° nível. CRIANDO ESPAÇOS DE MAGIA Nível de Espaço de Magia Custo de Pontos de Feitiçaria 1° 2 2° 3 3° 5 4° 6 5° 7 Convertendo um Espaço de Magia em Pontos de Feitiçaria. Com uma ação bônus, no seu turno, você pode gastar um espaço de magia disponível e ganhar uma quantidade de pontos de feitiçaria igual ao nível do espaço."
        },
        new TracodeClasse
        {
            IdTracodeClasse = 49,
            Nome = "Metamágica",
            HabilidadeTracodeClasse = "No 3° nível, você adquire a habilidade de distorcer suas magias para se adequarem às suas necessidades. Você ganha duas das seguintes opções de Metamágica, à sua escolha. Você adquire outra no 10° e 17° nível. Você pode usar apenas uma opção de Metamágica em uma magia quando a conjura, a não ser que esteja descrito o contrário. MAGIA ACELERADA Quando você conjurar uma magia que tenha um tempo de conjuração de 1 ação, você pode gastar 2 pontos de feitiçaria para mudar o tempo de conjuração para 1 ação bônus para essa magia. MAGIA AUMENTADA Quando você conjura uma magia que obriga uma criatura a realizar um teste de resistência contra o seu efeito, você 80 pode gastar 3 pontos de feitiçaria para dar desvantagem a um alvo da magia no primeiro teste de resistência feito contra ela. MAGIA CUIDADOSA Quando você conjurar uma magia que obriga outras criaturas a realizarem um teste de resistência, você pode proteger algumas dessas criaturas da força total da magia. Para tanto, você gasta 1 ponto de feitiçaria e escolhe um número dessas criaturas até o seu modificador de Carisma (mínimo de uma criatura). Uma criatura escolhida passa automaticamente no teste de resistência contra a magia. MAGIA DISTANTE Quando você conjurar uma magia que tenha distância de 1,5 metro ou maior, você pode gastar 1 ponto de feitiçaria para dobrar o alcance da magia. Quando você conjura uma magia com alcance de toque, você pode gastar 1 ponto de feitiçaria para mudar o alcance da magia para 9 metros. MAGIA DUPLICADA Quando você conjurar uma magia que seja incapaz de ter mais de uma criatura como alvo no nível atual dela e não possua alcance pessoal, você pode gastar um número de pontos de feitiçaria igual ao nível da magia para ter uma segunda criatura, no alcance da magia, como alvo (1 ponto de feitiçaria se a magia for um truque). MAGIA ESTENDIDA Quando você conjurar uma magia que tenha duração de 1 minuto ou maior, você pode gastar 1 ponto de feitiçaria para dobrar sua duração, até uma duração máxima de 24 horas. MAGIA POTENCIALIZADA Quando você rola o dano de uma magia, você pode gastar 1 ponto de feitiçaria para jogar novamente um número de dados de dano, até seu modificador de Carisma (mínimo de um). Você deve usar a nova rolagem. Você pode usar Magia Potencializada mesmo que você já tenha usado uma opção diferente de Metamágica durante a conjuração da magia. MAGIA SUTIL Quando você conjurar uma magia, você pode gastar 1 ponto de feitiçaria para fazê-lo sem qualquer componente somático ou verbal."
        },
        new TracodeClasse
        {
            IdTracodeClasse = 50,
            Nome = "Incremento no Valor de Habilidade",
            HabilidadeTracodeClasse = "Quando você atinge o 4° nível e novamente no 8°, 12°, 16° e 19° nível, você pode aumentar um valor de habilidade, à sua escolha, em 2 ou você pode aumentar dois valores de habilidade, à sua escolha, em 1. Como padrão, você não pode elevar um valor de habilidade acima de 20 com essa característica."
        },
        new TracodeClasse
        {
            IdTracodeClasse = 51,
            Nome = "Restauração Mística",
            HabilidadeTracodeClasse = "No 20° nível, você recupera 4 pontos de feitiçaria gastos sempre que você terminar um descanso curto."
        },
        new TracodeClasse
        {
            IdTracodeClasse = 52,
            Nome = "Estilo de Luta",
            HabilidadeTracodeClasse = "Você adota um estilo de combate particular que será sua especialidade. Escolha uma das opções a seguir. Você não pode escolher o mesmo Estilo de Combate mais de uma vez, mesmo se puder escolher de novo. ARQUEARIA Você ganha +2 de bônus nas jogadas de ataque realizadas com uma arma de ataque à distância. COMBATE COM ARMAS GRANDES Quando você rolar um 1 ou um 2 num dado de dano de um ataque com arma corpo-a-corpo que você esteja empunhando com duas mãos, você pode rolar o dado novamente e usar a nova rolagem, mesmo que resulte em 1 ou 2. A arma deve ter a propriedade duas mãos ou versátil para ganhar esse benefício. COMBATE COM DUAS ARMAS Quando você estiver engajado em uma luta com duas armas, você pode adicionar o seu modificador de habilidade de dano na jogada de dano de seu segundo ataque. DEFESA Enquanto estiver usando armadura, você ganha +1 de bônus em sua CA. DUELISMO Quando você empunhar uma arma de ataque corpo-acorpo em uma mão e nenhuma outra arma, você ganha +2 de bônus nas jogadas de dano com essa arma. PROTEÇÃO Quando uma criatura que você possa ver atacar um alvo que esteja a até 1,5 metro de você, você pode usar sua reação para impor desvantagem na jogada de ataque da criatura. Você deve estar empunhando um escudo. "
        },
        new TracodeClasse
        {
            IdTracodeClasse = 53,
            Nome = "Retomar o Fôlego",
            HabilidadeTracodeClasse = "Você possui uma reserva de estamina e pode usá-la para proteger a si mesmo contra danos. No seu turno, você pode usar uma ação bônus para recuperar pontos de vida igual a 1d10 + seu nível de guerreiro. Uma vez que você use essa característica, você precisa terminar um descanso curto ou longo para usá-la de novo."
        },
        new TracodeClasse
        {
            IdTracodeClasse = 54,
            Nome = "Surto de Ação",
            HabilidadeTracodeClasse = "A partir do 2º nível, você pode forçar o seu limite para além do normal por um momento. Durante o seu turno, você pode realizar uma ação adicional juntamente com sua ação e possível ação bônus. Uma vez que você use essa característica, você precisa terminar um descanso curto ou longo para usá-la de novo. A partir do 17º nível, você pode usá-la duas vezes antes do descanso, porém somente uma vez por turno. "
        },
        new TracodeClasse
        {
            IdTracodeClasse = 55,
            Nome = "Arquétipo Marcial",
            HabilidadeTracodeClasse = "No 3º nível, você escolhe um arquétipo o qual se esforçará para seguir as técnicas e estilos de combate dele. Escolha Campeão, Cavaleiro Arcano ou Mestre de Batalha, todos detalhados no final da descrição da classe. O arquétipo confere a você características especiais no 3º nível e de novo no 7º, 10º, 15º e 18º nível. "
        },
        new TracodeClasse
        {
            IdTracodeClasse = 56,
            Nome = "Incremento no Valor de Habilidade",
            HabilidadeTracodeClasse = "Quando você atinge o 4° nível e novamente no 6°, 8°, 12°, 14°, 16° e 19° nível, você pode aumentar um valor de habilidade, à sua escolha, em 2 ou você pode aumentar dois valores de habilidade, à sua escolha, em 1. Como padrão, você não pode elevar um valor de habilidade acima de 20 com essa característica."
        },
        new TracodeClasse
        {
            IdTracodeClasse = 57,
            Nome = "Ataque Extra",
            HabilidadeTracodeClasse = "A partir do 5º nível, você pode atacar duas vezes, ao invés de uma, quando usar a ação de Ataque durante seu turno. O número de ataques aumenta para três quando você alcançar o 11º nível de guerreiro e para quatro quando alcançar o 20º nível de guerreiro. "
        },
        new TracodeClasse
        {
            IdTracodeClasse = 58,
            Nome = "Indomável",
            HabilidadeTracodeClasse = "A partir do 9º nível, você pode jogar de novo um teste de resistência que falhou. Se o fizer, você deve usar o novo valor e não pode usar essa característica de novo antes de terminar um descanso longo. Você pode usar esta característica duas vezes entre descansos longos quando chegar no 13º nível e três vezes entre descansos longos quando chegar no 17º nível."
        },
        new TracodeClasse
        {
            IdTracodeClasse = 59,
            Nome = "Especialização",
            HabilidadeTracodeClasse = "No 1º nível, você escolhe duas de suas perícias que seja proficiente, ou uma perícia que seja proficiente e ferramentas de ladrão. Seu bônus de proficiência é dobrado em qualquer teste de habilidade que fizer com elas. No 6º nível, você pode escolher outras duas de suas proficiências (em perícias ou ferramentas de ladrão) para ganhar esse benefício. "
        },
        new TracodeClasse
        {
            IdTracodeClasse = 60,
            Nome = "Ataque Furtivo",
            HabilidadeTracodeClasse = "A partir do 1º nível, você sabe como atacar sutilmente e explorar a distração de seus inimigos. Uma vez por turno, você pode adicionar 1d6 nas jogadas de dano contra qualquer criatura que acertar, desde que tenha vantagem nas jogadas de ataque. O ataque deve ser com uma arma de acuidade ou à distância. Você não precisa ter vantagem nas jogadas de ataque se outro inimigo do seu alvo estiver a 1,5 metro de distância dele, desde que este inimigo não esteja incapacitado e você não tenha desvantagem nas jogadas de ataque. A quantidade de dano extra aumenta conforme você ganha níveis nessa classe, como mostrado na coluna Ataque Furtivo da tabela O Ladino."
        },
        new TracodeClasse
        {
            IdTracodeClasse = 61,
            Nome = "Gíria de Ladrão",
            HabilidadeTracodeClasse = "Durante seu treinamento você aprendeu as gírias de ladrão, um misto de dialeto, jargão e códigos secretos que permitem você passar mensagens secretas durante uma conversa aparentemente normal. Somente outra criatura que conheça essas gírias de ladrão entende as mensagens. Leva-se quatro vezes mais tempo para transmitir essa mensagem do que falar a mesma ideia claramente. Além disso, você entende um conjunto de sinais secretos e símbolos usados para transmitir mensagens curtas e simples, como saber se uma área é perigosa ou se é território de uma guilda de ladrões, se o saque está próximo, se as pessoas na área são alvos fáceis ou até mesmo indicar lugares seguros para ladinos se esconderem. "
        },
        new TracodeClasse
        {
            IdTracodeClasse = 62,
            Nome = "Ação Ardilosa",
            HabilidadeTracodeClasse = "A partir do 2º nível, seu pensamento rápido e agilidade faz você se mover e agir rapidamente. Você pode usar uma ação bônus durante cada um de seus turnos em combate. Esta ação pode ser usada somente para Disparada, Desengajar ou Esconder. "
        },
        new TracodeClasse
        {
            IdTracodeClasse = 63,
            Nome = "Arquétipo de Ladino",
            HabilidadeTracodeClasse = "No 3º nível, você escolhe um arquétipo que se esforçará para se equiparar através de exercícios de suas habilidades de ladino: Assassino, Ladrão ou Trapaceiro Arcano, todos detalhados no final da descrição da classe. Sua escolha garante a você características no 3º nível e de novo no 9º, 13º e 17º nível. "
        },
        new TracodeClasse
        {
            IdTracodeClasse = 64,
            Nome = "Incremento no Valor de Habillidade",
            HabilidadeTracodeClasse = "Quando você atinge o 4° nível e novamente no 8°, 10°, 12°, 16° e 19° nível, você pode aumentar um valor de habilidade, à sua escolha, em 2 ou você pode aumentar dois valores de habilidade, à sua escolha, em 1. Como padrão, você não pode elevar um valor de habilidade acima de 20 com essa característica. "
        },
        new TracodeClasse
        {
            IdTracodeClasse = 65,
            Nome = "Esquiva Sobrenatural",
            HabilidadeTracodeClasse = "A partir do 5º nível, quando um inimigo que você possa ver o acerta com um ataque, você pode usar sua reação para reduzir pela metade o dano sofrido. "
        },
        new TracodeClasse
        {
            IdTracodeClasse = 66,
            Nome = "Evasão",
            HabilidadeTracodeClasse = "A partir do 7º nível, você pode esquivar-se agilmente de certos efeitos em área, como o sopro flamejante de um dragão vermelho ou uma magia tempestade de gelo. Quando você for alvo de um efeito que exige um teste de resistência de Destreza para sofrer metade do dano, você não sofre dano algum se passar, e somente metade do dano se falhar."
        },
        new TracodeClasse
        {
            IdTracodeClasse = 67,
            Nome = "Talento Confiável",
            HabilidadeTracodeClasse = "No 11º nível, você refinou suas perícias beirando à perfeição. Toda vez que você fizer um teste de habilidade no qual possa adicionar seu bônus de proficiência, você trata um resultado no d20 de 9 ou menor como um 10. "
        },
        new TracodeClasse
        {
            IdTracodeClasse = 68,
            Nome = "Sentido Cego",
            HabilidadeTracodeClasse = "No 14º nível, se você for capaz de ouvir, você está ciente da localização de qualquer criatura escondida ou invisível a até 3 metros de você. "
        },
        new TracodeClasse
        {
            IdTracodeClasse = 69,
            Nome = "Mente Escorregadia",
            HabilidadeTracodeClasse = "No 15º nível, você adquire uma grande força de vontade, adquirindo proficiência nos testes de resistência de Sabedoria."
        },
        new TracodeClasse
        {
            IdTracodeClasse = 70,
            Nome = "Elusivo",
            HabilidadeTracodeClasse = "A partir do 18º nível, você se torna tão sagaz que raramente alguém encosta a mão em você. Nenhuma jogada de ataque tem vantagem contra você, desde que você não esteja incapacitado."
        },
        new TracodeClasse
        {
            IdTracodeClasse = 71,
            Nome = "Golpe de Sorte",
            HabilidadeTracodeClasse = "No 20º nível, você adquire um dom incrível para ter sucesso nos momentos em que mais precisa. Se um ataque seu falhar contra um alvo ao seu alcance, você pode transformar essa falha em um acerto. Ou se falhar em um teste qualquer, você pode tratar a jogada desse mesmo teste como 20 natural. Uma vez que você use essa característica, você não pode fazê-lo de novo até terminar um descanso curto ou longo. "
        },
        new TracodeClasse
        {
            IdTracodeClasse = 72,
            Nome = "Conjuração",
            HabilidadeTracodeClasse = "Como um estudante da magia arcana, você possui um livro de magias (ou grimório) que revela os primeiros vislumbres de seu verdadeiro poder. Consulte o capítulo 10 para as regras gerais sobre conjuração de magias e o capítulo 11 para conferir a lista de magias de mago. TRUQUES A partir do 1º nível, você conhece três truques à sua escolha da lista de magias de mago. Você aprende truques adicionais conforme avança de nível, como mostra a coluna Truques Conhecidos na tabela O Mago. GRIMÓRIO No 1º nível, você possui um grimório contendo seis magias de mago de 1º nível, à sua escolha. Um grimório não contém truques. O SEU GRIMÓRIO As magias que você pode adicionar em seu grimório, à medida que sobe de nível, refletem suas próprias pesquisas arcanas, conduzidas à sua maneira, bem como as suas descobertas sobre a natureza do multiverso. Você pode encontrar outras magias durante suas aventuras, como um feitiço escrito em um pergaminho que estava no baú de um mago maligno, por exemplo, ou em um tomo empoeirado de uma biblioteca antiga. Copiar uma Magia para o Grimório. Quando você encontrar uma magia de mago de 1° nível ou superior, você pode adicioná-la em seu grimório, desde que seja de um nível que você possua espaços de magia, além de dispor de tempo para decifrá-la e copiá-la. A magia copiada deve ser de um nível de magia que o mago possa preparar. Copiar uma magia para seu grimório envolve reproduzir suas formas básicas e então precisa decifrar a notação singular utilizada pelo mago que a escreveu. Você deve praticar a magia até entender os sons e gestos exigidos, para então transcrevê-la em seu grimório com sua própria notação. Para cada nível da magia a ser copiada, gasta-se 2 horas e 50 po. O custo representa os componentes materiais que você gasta para experimentar a magia até dominá-la, bem como as finas tintas utilizadas para escrevê-la. Uma vez gasto o tempo e o dinheiro, você pode preparar a magia copiada como as suas outras magias. Substituir o Grimório. Você pode copiar uma magia de seu grimório em outro livro – por exemplo, se você quiser fazer uma cópia reserva de seu grimório. O processo é igual ao de copiar uma nova magia em seu grimório, só que mais rápido e fácil, pois o mago entende suas próprias notações e sabe como conjurar a magia. Você precisa gastar somente 1 hora e 10 po para cada nível de magia copiada. Se perder o seu grimório, você pode usar o mesmo procedimento para transcrever suas magias preparadas em um novo grimório. Preencher o restante do grimório exigirá que você encontre novas magias, como normalmente se faz. Por essa razão, muitos magos mantêm seus grimórios reservas em lugares seguros. A Aparência do Grimório. Seu grimório é uma compilação de magias, com sua própria decoração e anotações de rodapé. Pode ser um livro de couro simples e funcional, recebido como presente de seu mestre, ou um tomo finamente encadernado com bordas douradas que você encontrou em uma antiga biblioteca, ou mesmo um conjunto de folhas soltas amontoadas após você perder seu grimório anterior em um acidente. PREPARANDO E CONJURANDO MAGIAS A tabela O Mago mostra quantos espaços de magia você possui para conjurar suas magias de 1º nível e superiores. Para conjurar uma dessas magias, você precisa usar um espaço do nível da magia ou superior. Você recupera todos os espaços gastos quando termina um descanso longo. Você prepara a lista de magias de mago que estarão disponíveis para serem conjuradas. Para tanto, você escolhe um número de magias de mago de seu grimório igual ao seu modificador de Inteligência + seu nível de mago (mínimo de uma magia). As magias precisam ser de um nível que você tenha espaços de magia. Por exemplo, se você é um mago de 3º nível, você possui 4 espaços de magia de 1º nível e 2 espaços de magia de 2º nível. Com Inteligência 16, sua lista de magias preparadas pode incluir seis magias de 1º e 2º nível de seu grimório, em qualquer combinação. Se você preparar a magia de 1º nível mísseis mágicos, você poderá conjurá-la utilizando um espaço de 1º ou 2º nível de magia. Conjurar a magia não a remove de sua lista de magias preparadas. Você pode mudar sua lista de magias preparadas quando terminar um descanso longo. Preparar uma nova lista de magias de mago requer que você gaste um tempo estudando seu grimório e memorizando as palavras e gestos, para efetivamente conjurar a magia: ao menos 1 minuto por nível de magia para cada magia da sua lista. HABILIDADE DE CONJURAÇÃO Inteligência é a sua habilidade para você conjurar suas magias de mago, pois os magos aprendem novas magias através de estudo e memorização. Você usa sua Inteligência sempre que alguma magia se referir a sua habilidade de conjurar magias. Além disso, você usa o seu modificador de Inteligência para definir a CD dos testes de resistência para as magias de mago que você conjura e quando você realiza uma jogada de ataque com uma magia. CD para suas magias = 8 + bônus de proficiência + seu modificador de Inteligência Modificador de ataque de magia = seu bônus de proficiência + seu modificador de Inteligência CONJURAÇÃO DE RITUAL Você pode conjurar qualquer magia de mago como um ritual se ela possuir o descritor ritual, desde que a possua em seu grimório. Você não precisa ter essa magia preparada. FOCO DE CONJURAÇÃO Você pode usar um foco arcano (encontrado no capítulo 5) como foco de conjuração das suas magias de mago. APRENDENDO MAGIAS DE 1° NÍVEL OU SUPERIOR A cada nível de mago adquirido, você pode adicionar duas magias de mago à sua escolha em seu grimório. Cada uma dessas magias deve ser de um nível que você possua espaços de magia, conforme mostra a tabela O Mago. Em suas aventuras, você pode encontrar outras magias e adicioná-las em seu grimório (consulte a caixa de texto O Seu Grimório)."
        },
        new TracodeClasse
        {
            IdTracodeClasse = 73,
            Nome = "Recuperação Arcana",
            HabilidadeTracodeClasse = "Você aprendeu como recuperar um pouco de sua energia mágica estudando seu grimório. Uma vez por dia, quando você terminar um descanso curto, você pode escolher espaços de magia gastos para recuperá-los. Os espaços gastos a serem recuperados podem ser de qualquer combinação de níveis de magia, desde que sejam iguais ou inferiores a metade de seu nível de mago (arredondado para cima) e nenhum deles seja de 6º ou superior. Por exemplo, se você é um mago de 4º nível, você pode recuperar até 2 espaços de magia gastos. Você pode recuperar o espaço de uma magia de 2º nível ou os espaços de duas magias de 1º nível."
        },
        new TracodeClasse
        {
            IdTracodeClasse = 74,
            Nome = "Tradição Arcana",
            HabilidadeTracodeClasse = "Você aprendeu como recuperar um pouco de sua energia mágica estudando seu grimório. Uma vez por dia, quando você terminar um descanso curto, você pode escolher espaços de magia gastos para recuperá-los. Os espaços gastos a serem recuperados podem ser de qualquer combinação de níveis de magia, desde que sejam iguais ou inferiores a metade de seu nível de mago (arredondado para cima) e nenhum deles seja de 6º ou superior. Por exemplo, se você é um mago de 4º nível, você pode recuperar até 2 espaços de magia gastos. Você pode recuperar o espaço de uma magia de 2º nível ou os espaços de duas magias de 1º nível."
        },
        new TracodeClasse
        {
            IdTracodeClasse = 75,
            Nome = "Incremento no Valor de Habilidade",
            HabilidadeTracodeClasse = "Quando você atinge o 4° nível e novamente no 8°, 12°, 16° e 19° nível, você pode aumentar um valor de habilidade, à sua escolha, em 2 ou você pode aumentar dois valores de habilidade, à sua escolha, em 1. Como padrão, você não pode elevar um valor de habilidade acima de 20 com essa característica. "
        },
        new TracodeClasse
        {
            IdTracodeClasse = 76,
            Nome = "Dominar Magia",
            HabilidadeTracodeClasse = "No 18º nível, você alcança tamanha maestria em determinadas magias que pode conjurá-las à vontade. Você escolhe uma magia de mago de 1º nível e uma magia de mago de 2º nível de seu grimório. Você as conjura em seu nível mínimo, sem gastar espaços de magia quando as tiver preparadas. Caso queira, você pode conjurá-las com um espaço de nível superior, porém gastará espaços de magia, como normalmente se faz."
        },
        new TracodeClasse
        {
            IdTracodeClasse = 77,
            Nome = "Assinatura Mágica",
            HabilidadeTracodeClasse = "Quando alcançar o 20º nível, você adquire domínio completo de duas poderosas magias e pode conjurá-las sem muito esforço. Escolha duas magias de mago de 3º nível em seu grimório como sua assinatura mágica. Você sempre tem essas magias preparadas e elas não contam como magias preparadas em sua lista, além de você poder conjurar cada uma das magias escolhidas, uma vez ao dia, como magias de 3º nível, sem gastar nenhum espaço. Quando o fizer, você não poderá fazê-lo de novo antes de terminar um descanso curto ou longo. Se você quiser conjurar essas magias com espaços de níveis superiores, a magia gastará espaços de magia, como normalmente se faz."
        },
        new TracodeClasse
        {
            IdTracodeClasse = 78,
            Nome = "Defesa sem Armadura",
            HabilidadeTracodeClasse = "A partir do 1° nível, quando você não estiver vestindo nenhuma armadura nem empunhando um escudo, sua Classe de Armadura será 10 + seu modificador de Destreza + seu modificador de Sabedoria. ",
        },
        new TracodeClasse
        {
            IdTracodeClasse = 79,
            Nome = "Artes Marciais",
            HabilidadeTracodeClasse = "No 1° nível, sua prática nas artes marciais concede a você maestria nos estilos de combate que utilizam golpes desarmados e armas de monge, que são as espadas curtas e quaisquer armas simples corpo-a-corpo que não tenham a propriedade duas mãos ou pesada. Você ganha os seguintes benefícios enquanto estiver desarmado ou empunhando uma arma de monge e não estiver vestindo nenhuma armadura ou empunhando um escudo:  Você pode usar Destreza ao invés de Força para as jogadas de ataque e dano dos seus golpes desarmados e de suas armas de monge.  Você pode rolar um d4 no lugar do dano normal dos seus golpes desarmados e armas de monge. Esse dado muda à medida que você adquire níveis de monge, como mostrado na coluna Artes Marciais na tabela O Monge.  Quando você usa a ação de Ataque com um golpe desarmado ou uma arma de monge no seu turno, você pode realizar um golpe desarmado com uma ação bônus. Por exemplo, se você realizar a ação de Ataque com um bordão, você também poderá realizar um golpe desarmado com uma ação bônus, assumindo que você ainda não realizou uma ação bônus nesse turno. Determinados monastérios usam formas especializadas de armas de monge. Por exemplo, você pode usar uma clava feita por dois pedaços de madeira conectados por uma pequena corrente (chamado de nunchaku) ou uma foice com uma estranha lâmina fina (chamada de kama). Qualquer que seja o nome que você use para uma arma de monge, você pode usar as estatísticas de jogo mostradas para as armas no capítulo 5. ",
        },
        new TracodeClasse
        {
            IdTracodeClasse = 80,
            Nome = "Chi",
            HabilidadeTracodeClasse = "A partir do 2° nível, seu treinamento permitiu que você controlasse a energia mística do chi. Seu acesso a essa energia é representado por um número de pontos de chi. Seu nível de monge determina o número de pontos que você tem, como mostrado na coluna Pontos de Chi da tabela O Monge. Você pode gastar esses pontos para abastecer várias características de chi. Você começa conhecendo três dessas características: Rajada de Golpes, Defesa Paciente e Passo do Vento. Você aprende mais características de chi à medida que adquire níveis nessa classe. Quando você gasta um ponto de chi, ele se torna indisponível até você terminar um descanso curto ou longo, no fim deste, todos os pontos de chi gastos volta para você. Você deve gastar, pelo menos, 30 minutos do descanso meditando para recuperar seus pontos de chi. Algumas das características de chi requerem que seu alvo realize um teste de resistência para resistir ao efeito da característica. A CD do teste de resistência é calculada a segui: CD de resistência de Chi = 8 + bônus de proficiência + seu modificador de Sabedoria RAJADA DE GOLPES Imediatamente após você realizar a ação de Ataque no seu turno, você pode gastar 1 ponto de chi para realizar dois golpes desarmados com uma ação bônus. DEFESA PACIENTE Você pode gastar 1 ponto de chi para realizar a ação de Esquivar, com uma ação bônus, no seu turno. PASSO DO VENTO Você pode gastar 1 ponto de chi para realizar a Ação de Desengajar ou Disparada, com uma ação bônus, no seu turno, e sua distância de salto é dobrada nesse turno. ",
        },
        new TracodeClasse
        {
            IdTracodeClasse = 81,
            Nome = "Movimento sem Armadura",
            HabilidadeTracodeClasse = "A partir do 2° nível, seu deslocamento aumenta em 3 metros enquanto você não estiver usando armadura nem empunhando um escudo. Esse bônus aumenta quando você alcança determinados níveis, como mostrado na tabela O Monge. No 9° nível, você ganha a habilidade de se mover através de superfícies verticais e sobre líquidos, no seu turno, sem cair durante o movimento.",
        },
        new TracodeClasse
        {
            IdTracodeClasse = 82,
            Nome = "Tradição Monástica",
            HabilidadeTracodeClasse = "Quando você alcança o 3° nível, você ingressa numa tradição monástica: o Caminho da Mão Aberta, o Caminho Sombrio e o Caminho dos Quatro Elementos, todas detalhadas no final da descrição dessa classe. Sua tradição concede a você características no 3° nível e novamente no 6°, 11° e 17° nível.",
        },
        new TracodeClasse
        {
            IdTracodeClasse = 83,
            Nome = "Defletir Projéteis",
            HabilidadeTracodeClasse = "A partir do 3° nível, você pode usar sua reação para defletir ou apanhar o projétil quando você é atingido por um ataque de arma à distância. Quando o fizer, o dano que você sofrer do ataque é reduzido em 1d10 + seu modificador de Destreza + seu nível de monge. Se o dano for reduzido a 0, você pode apanhar o projétil se ele for pequeno o suficiente para ser segurando em uma mão e você tenha, pelo menos, uma mão livre. Se você apanhar um projétil dessa forma, você pode gastar 1 ponto de chi para realizar uma ataque à distância com a arma ou munição que você acabou de pegar, como parte da mesma reação. Você realiza esse ataque com proficiência, independentemente das armas em que você é proficiente, e o projétil conta como uma arma de monge para o ataque. A distância do ataque do monge é de 6/18 metros."
        },
        new TracodeClasse
        {
            IdTracodeClasse = 84,
            Nome = "Incremento no Valor de Habilidade",
            HabilidadeTracodeClasse = "Quando você atinge o 4° nível e novamente no 8°, 12°, 16° e 19° nível, você pode aumentar um valor de habilidade, à sua escolha, em 2 ou você pode aumentar dois valores de habilidade, à sua escolha, em 1. Como padrão, você não pode elevar um valor de habilidade acima de 20 com essa característica. "
        },
        new TracodeClasse
        {
            IdTracodeClasse = 85,
            Nome = "Queda Lenta",
            HabilidadeTracodeClasse = "Começando no 4° nível, você pode usar sua reação, quando você cai, para reduzir o dano de queda sofrido por um valor igual a cinco vezes seu nível de monge. ",
        },
        new TracodeClasse
        {
            IdTracodeClasse = 86,
            Nome = "Ataque Extra",
            HabilidadeTracodeClasse = "A partir do 5° nível, você pode atacar duas vezes, ao invés de uma, sempre que você realizar a ação de Ataque no seu turno."
        },
        new TracodeClasse
        {
            IdTracodeClasse = 87,
            Nome = "Ataque Atordoante",
            HabilidadeTracodeClasse = "A partir do 5° nível, você pode interferir no fluxo de chi do corpo de um oponente. Quando você atingir outra criatura com um ataque corpo-a-corpo com arma, você pode gastar 1 ponto de chi para tentar um ataque atordoante. O alvo deve ser bem sucedido num teste de resistência de Constituição ou ficará atordoado até o final do seu próximo turno. "
        },
        new TracodeClasse
        {
            IdTracodeClasse = 88,
            Nome = "Golpes de Chi",
            HabilidadeTracodeClasse = "A partir do 6° nível, seus golpes desarmados contam como armas mágicas com o propósito de ultrapassar a resistência ou imunidade a ataques e danos não-mágicos. "
        },
        new TracodeClasse
        {
            IdTracodeClasse = 89,
            Nome = "Evasão",
            HabilidadeTracodeClasse = "A partir do 7º nível, você pode esquivar-se agilmente de certos efeitos em área, como o sopro elétrico de um dragão azul ou uma magia bola de fogo. Quando você for alvo de um efeito que exige um teste de resistência de Destreza para sofrer metade do dano, você não sofre dano algum se passar, e somente metade do dano se falhar."
        },
        new TracodeClasse
        {
            IdTracodeClasse = 90,
            Nome = "Mente Tranquila",
            HabilidadeTracodeClasse = "A partir do 7° nível, você pode usar sua ação para terminar um efeito em si mesmo, que esteja lhe enfeitiçando ou amedrontando",
        },
        new TracodeClasse
        {
            IdTracodeClasse = 91,
            Nome = "Pureza Corporal",
            HabilidadeTracodeClasse = "No 10° nível, sua maestria do chi flui através de você, tornando-o imune a doenças e venenos.",
        },
        new TracodeClasse
        {
            IdTracodeClasse = 92,
            Nome = "Idiomas do Sol e da Lua",
            HabilidadeTracodeClasse = "A partir do 13° nível, você aprende a tocar o chi de outras mentes fazendo com que você compreenda todos os idiomas falados. Além do mais, qualquer criatura que possa entender um idioma poderá entender o que você fala.",
        },
        new TracodeClasse
        {
            IdTracodeClasse = 93,
            Nome = "Alma de Diamante",
            HabilidadeTracodeClasse = "A partir do 14° nível, sua maestria do chi concede a você proficiência em todos os testes de resistência. Além disso, toda vez que você realizar um teste de resistência e falha, você pode gastar 1 ponto de chi para jogar novamente e ficar com o segundo resultado. ",
        },
        new TracodeClasse
        {
            IdTracodeClasse = 94,
            Nome = "Corpo Atemporal",
            HabilidadeTracodeClasse = "No 15° nível, seu chi sustenta você tanto que você não sofre os efeitos da velhice e não pode envelhecer magicamente. Você ainda morrerá de velhice, no entanto. Além disso, você não precisa mais de comida ou água.",
        },
        new TracodeClasse
        {
            IdTracodeClasse = 95,
            Nome = "Corpo Vazio",
            HabilidadeTracodeClasse = "A partir do 18° nível, você pode usar sua ação para gastar 4 pontos de chi e ficar invisível por 1 minuto. Durante esse tempo, você também adquire resistência a todos os danos, exceto dano de energia. Além disso, você pode gastar 8 pontos de chi para conjurar a magia projeção astral, sem precisar de componentes materiais. Quando o fizer, você não pode levar qualquer outra criatura com você.",
        },
        new TracodeClasse
        {
            IdTracodeClasse = 96,
            Nome = "Auto Aperfeiçoamento",
            HabilidadeTracodeClasse = "No 20° nível, quando você rolar iniciativa e não tiver nenhum ponto de chi restante, você recupera 4 pontos de chi.",
        },
        new TracodeClasse
        {
            IdTracodeClasse = 97,
            Nome = "Sentido Divino",
            HabilidadeTracodeClasse = "A presença de um mal poderoso é registrada nos seus sentidos como um odor nocivo e o bem poderoso badala como música celestial nos seus ouvidos. Com uma ação, você pode expandir sua consciência para detectar tais forças. Até o final do seu próximo turno, você sabe a localização de qualquer celestial, corruptor ou morto-vivo a 18 metros de você que não esteja com cobertura total. Você sabe o tipo (celestial, corruptor ou morto-vivo) de qualquer ser cuja presença você sentiu, mas não sua identidade (o vampiro Conde Strahd von Zarovish, por exemplo). Dentro do mesmo raio, você também detecta a presença de qualquer lugar ou objeto que tenha sido consagrado ou conspurcado, como pela magia consagrar. Você pode usar essa característica um número de vezes igual a 1 + seu modificador de Carisma. Quando você concluir um descanso longo, você recupera todos os usos gastos. "
        },
        new TracodeClasse
        {
            IdTracodeClasse = 98,
            Nome = "Cura pelas Mãos",
            HabilidadeTracodeClasse = "Seu toque abençoado pode curar ferimentos. Você tem um poço de poder curativo que se enche quando você realiza um descanso longo. Com esse poço, você pode restaurar um número total de pontos de vida igual ao seu nível de paladino x 5. Com uma ação, você pode tocar uma criatura e sugar poder do seu poço para restaurar um número de pontos de vida da criatura, até o máximo de pontos restantes no poço. Alternativamente, você pode gastar 5 pontos de cura do seu poço de cura para curar o alvo de uma doença ou neutralizar um veneno que o esteja afetando. Você pode curar múltiplas doenças e neutralizar múltiplos venenos com um único uso de Cura pelas Mãos, gastando pontos de vida separadamente para cada um. Essa característica não gera nenhum efeito em mortos-vivos e constructos."
        },
        new TracodeClasse
        {
            IdTracodeClasse = 99,
            Nome = "Estilo de Luta",
            HabilidadeTracodeClasse = "No 2° nível, você adota um estilo de combate particular que será sua especialidade. Escolha uma das opções a seguir. Você não pode escolher o mesmo Estilo de Combate mais de uma vez, mesmo se puder escolher de novo. COMBATE COM ARMAS GRANDES Quando você rolar um 1 ou um 2 num dado de dano de um ataque com arma corpo-a-corpo que você esteja empunhando com duas mãos, você pode rolar o dado novamente e usar a nova rolagem, mesmo que resulte em 1 ou 2. A arma deve ter a propriedade duas mãos ou versátil para ganhar esse benefício. DEFESA Enquanto estiver usando armadura, você ganha +1 de bônus em sua CA. DUELISMO Quando você empunhar uma arma de ataque corpo-acorpo em uma mão e nenhuma outra arma, você ganha +2 de bônus nas jogadas de dano com essa arma. PROTEÇÃO Quando uma criatura que você possa ver atacar um alvo que esteja a até 1,5 metro de você, você pode usar sua reação para impor desvantagem nas jogadas de ataque da criatura. Você deve estar empunhando um escudo."
        },
        new TracodeClasse
        {
            IdTracodeClasse = 100,
            Nome = "Conjuração",
            HabilidadeTracodeClasse = "No 2° nível, você aprende a extrair magia divina através de meditação e oração para conjurar magias, como um clérigo faz. Veja o capítulo 10 para as regras gerais de conjuração e o capítulo 11 para a lista de magias de paladino. PREPARANDO E CONJURANDO MAGIAS A tabela O Paladino mostra quantos espaços de magia você têm para conjurar suas magias de 1º nível e superiores. Para conjurar uma dessas magias, você precisa gastar um espaço do nível da magia ou superior. Você recupera todos os espaços gastos quando termina um descanso longo. Você prepara a lista de magias disponíveis selecionando-as da lista de magias de paladino. Você seleciona um número de magias igual ao seu modificador de Carisma + metade do seu nível de paladino, arredondado para baixo (mínimo de uma magia). Essas magias devem ser de níveis que você possua espaços de magia. Por exemplo, se você é um paladino de 5º nível, você possui quatro espaços de magia de 1º nível e dois de 2º nível. Com Carisma de 14, sua lista de magias preparadas pode incluir quatro magias, combinando as de 1º e 2º nível em qualquer ordem. Se você preparar a magia de 1º nível curar ferimentos, você pode conjurá-la com um espaço de magia de 1º ou de 2º nível. Ao conjurar a magia, você não a retira de sua lista de magias preparadas, podendo conjurá-la de novo se tiver espaços de magia disponíveis. Você pode modificar a sua lista de magias preparadas quando termina um descanso longo. Preparar uma nova lista de magias de paladino requer tempo gasto em preces e meditação: no mínimo 1 minuto por nível de magia para cada magia preparada. HABILIDADE DE CONJURAÇÃO Carisma é a sua habilidade para você conjurar suas magias de paladino, já que seu poder deriva da força das suas convicções. Você usa seu Carisma sempre que alguma magia se referir a sua habilidade de conjurar 111 magias. Além disso, você usa o seu modificador de Carisma para definir a CD dos testes de resistência para as magias de paladino que você conjura e quando você realiza uma jogada de ataque com uma magia. CD para suas magias = 8 + bônus de proficiência + seu modificador de Carisma Modificador de ataque de magia = seu bônus de proficiência + seu modificador de Carisma FOCO DE CONJURAÇÃO Você pode usar um símbolo sagrado (encontrado no capítulo 5) como foco de conjuração das suas magias de paladino. "
        },
        new TracodeClasse
        {
            IdTracodeClasse = 101,
            Nome = "Destruição Divina",
            HabilidadeTracodeClasse = "A partir do 2° nível, quando você atingir uma criatura com um ataque corpo-a-corpo com arma, você pode gastar um espaço de magia de qualquer classe para causar dano radiante no alvo, além do dano normal da arma. O dano extra é de 2d8 para um espaço de magia de 1° nível, mais 1d8 para cada espaço de magia acima do 1°, até o máximo de 5d8. O dano aumenta em 1d8 se o alvo for um corruptor ou um morto-vivo. "
        },
        new TracodeClasse
        {
            IdTracodeClasse = 102,
            Nome = "Saúde Divina",
            HabilidadeTracodeClasse = "No 3° nível, a magia divina flui através de você tornando você imune a doenças."
        },
        new TracodeClasse
        {
            IdTracodeClasse = 103,
            Nome = "Juramento Sagrado",
            HabilidadeTracodeClasse = "Quando você alcança o 3° nível, você faz um juramento que torna-o um paladino para sempre. Até então, você estava em um estágio preparatório, guiado pelo caminho, mas ainda não jurado a ele. Agora você escolhe o Juramento de Devoção, o Juramento dos Anciões ou o Juramento de Vingança, todos detalhados no final da descrição da classe. Sua escolha lhe confere características no 3° nível e novamente no 7°, 15° e 20° nível. Tais características incluem as magias de juramento e a característica Canalizar Divindade. MAGIAS DE JURAMENTO Cada juramento possui uma lista de magias associada a ele. Você ganha acesso a essas magias nos níveis especificados na descrição do juramento. Uma vez que você tenha ganhado acesso a uma magia de juramento, você sempre a terá preparada. Magias de juramento não contam no número de magias que você pode preparar a cada dia. Se você ganhar uma magia de juramento que não apareça na lista de magias de paladino, a magia será, no entanto, uma magia de paladino para você. CANALIZAR DIVINDADE Seu juramento permite que você canalize energia divina para abastecer efeitos mágicos. Cada opção de Canalizar Divindade concedida por um juramento explica como usála. Quando você usa o seu Canalizar Divindade, você escolhe qual opção usar. Você deve terminar um descanso curto ou longo para pode usar seu Canalizar Divindade novamente. Alguns efeitos de Canalizar Divindade requerem um teste de resistência. Quando você usar tais efeitos dessa classe, a CD será igual a CD das suas magias de paladino. "
        },
        new TracodeClasse
        {
            IdTracodeClasse = 104,
            Nome = "Incremento no Valor de Habilidade",
            HabilidadeTracodeClasse = "Quando você atinge o 4° nível e novamente no 8°, 12°, 16° e 19° nível, você pode aumentar um valor de habilidade, à sua escolha, em 2 ou você pode aumentar dois valores de habilidade, à sua escolha, em 1. Como padrão, você não pode elevar um valor de habilidade acima de 20 com essa característica. "
        },
        new TracodeClasse
        {
            IdTracodeClasse = 105,
            Nome = "Ataque Extra",
            HabilidadeTracodeClasse = "A partir do 5° nível, você pode atacar duas vezes, ao invés de uma, sempre que você realizar a ação de Ataque no seu turno."
        },
        new TracodeClasse
        {
            IdTracodeClasse = 106,
            Nome = "Aura de Proteção",
            HabilidadeTracodeClasse = "A partir do 6° nível, sempre que você ou uma criatura amigável a até 3 metros de você tiver que fazer um teste de resistência, aquela criatura ganha um bônus no seu teste de proteção igual a seu modificador de Carisma (com um bônus mínimo de +1). Você deve estar consciente para garantir esse bônus. No 18° nível, o alcance dessa aura aumenta para 9 metros."
        },
        new TracodeClasse
        {
            IdTracodeClasse = 107,
            Nome = "Aura de Coragem",
            HabilidadeTracodeClasse = "Começando no 10° nível, você e as criaturas amigáveis dentro de um raio de 3 metros de você não podem ser amedrontadas enquanto você estiver consciente. No 18° nível, o alcance dessa aura aumenta para 9 metros. "
        },
        new TracodeClasse
        {
            IdTracodeClasse = 108,
            Nome = "Destruição Divina Aprimorada",
            HabilidadeTracodeClasse = "No 11° nível, você fica tão infundido com o poder da justiça que todos os seus ataques corpo-a-corpo com arma carregam poder divino neles. Sempre que você atingir uma criatura com um ataque corpo-a-corpo, a criatura sofre 1d8 de dano radiante extra. Se você também usar sua Destruição Divina em um ataque, você adiciona esse dano ao dano extra da sua Destruição Divina."
        },
        new TracodeClasse
        {
            IdTracodeClasse = 109,
            Nome = "Toque Purificador",
            HabilidadeTracodeClasse = "A partir do 14° nível, você pode usar sua ação para terminar uma magia em si mesmo ou em uma criatura voluntária que você tocar. Você pode usar essa característica um número de vezes igual a seu modificador de Carisma (mínimo uma vez). Você recupera os usos gastos quando termina um descanso longo. "
        },
        new TracodeClasse
        {
            IdTracodeClasse = 110,
            Nome = "Inimigo Favorito",
            HabilidadeTracodeClasse = "A partir do 1° nível, você tem experiência significativa estudando, rastreando, caçando e, até mesmo, falando com certos tipos de inimigos. Escolha um tipo de inimigo favorito: bestas, fadas, humanoide, monstruosidades ou mortos-vivos. Você recebe um bônus de +2 nas jogadas de dano com ataques com arma contra criaturas do tipo escolhido. Além disso, você tem vantagem em testes de Sabedoria (Sobrevivência) para rastrear seus inimigos favoritos, assim como em testes de Inteligência para lembrar informações sobre eles. Quando você adquire essa característica, você também aprende um idioma, à sua escolha, que seja falado pelos seus inimigos favoritos, se eles falarem algum."
        },
        new TracodeClasse
        {
            IdTracodeClasse = 111,
            Nome = "Explorador Natural",
            HabilidadeTracodeClasse = "Você é um mestre na navegação pelo mundo natural e você reage de forma rápida e decisiva quando é atacado. Isso fornece a você os seguintes benefícios:  Você ignora terreno difícil.  Você tem vantagem em rolagens de iniciativa.  No seu primeiro turno de combate, você tem vantagem nas jogadas de ataque contra criaturas que ainda não tenham agido. Além disso, você é perito em navegar pelo ambiente selvagem. Você ganha os seguintes benefícios quando estiver viajando por uma hora ou mais:  Terreno difícil não atrasa a viagem do seu grupo.  Seu grupo não pode se perder, exceto por meios mágicos.  Mesmo quando você está engajado em outra atividade além de viajar (como forragear, navegar ou rastrear), você permanece alerta ao perigo.  Se você estiver viajando sozinho, você pode se mover furtividamente com um ritmo de viagem normal.  Quando você forrageia, você encontra o dobro de comida que normalmente encontraria.  Enquanto estiver rastreando outras criaturas, você também descobre o número exato delas, seus tamanhos e há quanto tempo elas passaram pela área."
        },
        new TracodeClasse
        {
            IdTracodeClasse = 112,
            Nome = "Estilo de Luta",
            HabilidadeTracodeClasse = "No 2° nível, você adota um estilo de combate particular que será sua especialidade. Escolha uma das opções a seguir. Você não pode escolher o mesmo Estilo de Combate mais de uma vez, mesmo se puder escolher de novo. ARQUEARIA Você ganha +2 de bônus nas jogadas de ataque realizadas com uma arma de ataque à distância. COMBATE COM DUAS ARMAS Quando você estiver engajado em uma luta com duas armas, você pode adicionar o seu modificador de habilidade na jogada de dano do seu segundo ataque. DEFESA Enquanto estiver usando armadura, você ganha +1 de bônus em sua CA. DUELISMO Quando você empunhar uma arma de ataque corpo-acorpo em uma mão e nenhuma outra arma, você ganha +2 de bônus nas jogadas de dano com essa arma. "
        },
        new TracodeClasse
        {
            IdTracodeClasse = 113,
            Nome = "Conjuração",
            HabilidadeTracodeClasse = "Quando você alcança o 2° nível, você aprende a usar a essência mágica da natureza para conjurar magias, como um druida faz. Veja o capítulo 10 para as regras gerais de conjuração e o capítulo 11 para a lista de magias de patrulheiro. ESPAÇOS DE MAGIA A tabela O Patrulheiro mostra quantos espaços de magia você tem para conjurar suas magias de 1° nível e superiores. Para conjurar uma dessas magias, você deve gastar uma espaço de magia do nível da magia ou superior. Você recobra todos os espaços de magia gastos quando você completa um descanso longo. Por exemplo, se você quiser conjurar a magia de 1° nível amizade animal e você tiver um espaço de magia de 1° nível e um de 2° nível disponíveis, você poderá conjurar amizade animal usando qualquer dos dois espaços. MAGIAS CONHECIDAS DE 1° NÍVEL E SUPERIORES Você conhece duas magias de 1° nível, à sua escolha, da lista de magias de patrulheiro. A coluna Magias Conhecidas na tabela O Patrulheiro mostra quando você aprende mais magias de patrulheiro, 118 à sua escolha. Cada uma dessas magias deve ser de um nível a que você tenha acesso, como mostrado na tabela. Por exemplo, quando você alcança o 5° nível da classe, você pode aprender uma nova magia de 1° ou 2° nível. Além disso, quando você adquire um nível nessa classe, você pode escolher uma magia de patrulheiro que você conheça e substituí-la por outra magia da lista de magias de patrulheiro, que também deve ser de um nível ao qual você tenha espaços de magia. HABILIDADE DE CONJURAÇÃO Sabedoria é a sua habilidade para conjurar suas magias de patrulheiro, já que sua magia vem da sua sintonia com a natureza. Você usa sua Sabedoria sempre que alguma magia se referir a sua habilidade de conjurar magias. Além disso, você usa o seu modificador de Sabedoria para definir a CD dos testes de resistência para as magias de patrulheiro que você conjura e quando você realiza uma jogada de ataque com uma magia. CD para suas magias = 8 + bônus de proficiência + seu modificador de Sabedoria Modificador de ataque de magia = seu bônus de proficiência + seu modificador de Sabedoria "
        },
        new TracodeClasse
        {
            IdTracodeClasse = 114,
            Nome = "Conclave de Patrulheiro",
            HabilidadeTracodeClasse = "No 3° nível, você escolhe emular os ideais de treinamento de um conclave de patrulheiro: o Conclave da Besta, o Conclave do Caçador ou o Conclave do Rastreador Subterrâneo, todos detalhados no final da descrição da classe. Sua escolha lhe concede características no 3° nível e novamente no 5°, 7°, 11° e 15° nível. "
        },
        new TracodeClasse
        {
            IdTracodeClasse = 115,
            Nome = "Consciência Primitiva",
            HabilidadeTracodeClasse = "A partir do 3° nível, sua maestria do conhecimento de patrulheiro permite que você estabeleça um poderoso elo com bestas e com a terra ao seu redor. Você possui uma habilidade inata de se comunicar com bestas e elas consideram você como um espírito semelhante. Através de sons e gestos, você pode comunicar ideias simples a bestas como uma ação e pode compreender seu ânimo e intenção básicos. Você aprende o estado emocional dela, suas necessidades imediatas (como comida e abrigo) e ações que você pode tomar (se aplicável) para persuadi-la a não atacar. Você não pode usar essa habilidade contra uma criatura que você tenha atacado nos últimos 10 minutos. Além disso, você pode sintonizar seus sentidos para determinar se algum dos seus inimigos favoritos está espreitando nas redondezas. Ao passar 1 minuto ininterrupto em concentração (como se estivesse se concentrando em uma magia), você pode sentir se algum dos seus inimigos favoritos está presente a até 8 quilometros de você. Essa característica revela qual dos seus inimigos favoritos está presente, a quantidade deles e a direção e distância aproximadas dessas criaturas (em quilometros) de você. Se houverem múltiplos grupos de seus inimigos favoritos no alcance, você descobre essas informações de cada grupo."
        },
        new TracodeClasse
        {
            IdTracodeClasse = 116,
            Nome = "Inimigo Favorito Maior",
            HabilidadeTracodeClasse = "A partir do 6° nível, você está pronto para caçar mesmo as presas mais mortais. Escolha um tipo de inimigo favorito maior: aberrações, celestiais, constructos, corruptores, dragões, elementais ou gigantes. Você ganha todos os benefícios contra o inimigo escolhido que você normalmente ganha contra seu inimigo favorito, além do idioma adicional. Seu bônus nas jogadas de dano contra todos os seus inimigos favoritos aumenta para +4. Além disso, você tem vantagem em testes de resistência contra magias e habilidades usadas por um inimigo favorito maior. "
        },
        new TracodeClasse
        {
            IdTracodeClasse = 117,
            Nome = "Pés Rápidos",
            HabilidadeTracodeClasse = "Começando no 8° nível, você pode usar a ação de Disparada como uma ação bônus no seu turno. "
        },
        new TracodeClasse
        {
            IdTracodeClasse = 118,
            Nome = "Mimetismo",
            HabilidadeTracodeClasse = "A partir do 10° nível, você pode permanecer perfeitamente imóvel por longos períodos de tempo para preparar uma emboscada. Quando você tentar se esconder no seu turno, você pode optar por não se mover nesse turno. Se você evitar se mover, criaturas que tentarem detectar você sofrem –10 de penalidade em testes de Sabedoria (Percepção) até o começo do seu próximo turno. Você perde esse benefício caso se mova ou caia no chão, voluntariamente ou por um efeito externo. Você ainda será automaticamente detectado caso algum efeito ou ação faça com que você não esteja mais escondido. 119 Se você ainda estiver escondido no seu turno, você pode continuar imóvel e ganhar esse benefício até ser detectado."
        },
        new TracodeClasse
        {
            IdTracodeClasse = 119,
            Nome = "Desaparecer",
            HabilidadeTracodeClasse = "Começando no 14° nível, você pode usar a ação de Esconder, com uma ação bônus, no seu turno. Além disso, você não pode ser rastreado por meios não-mágicos, a não ser que você decida deixar um rastro."
        },
        new TracodeClasse
        {
            IdTracodeClasse = 120,
            Nome = "Sentidos Selvagens",
            HabilidadeTracodeClasse = "No 18° nível, você ganha sentidos preternaturais que o ajudam a lutar contra criaturas que você não pode ver. Quando você atacar uma criatura que você não possa ver, sua incapacidade em vê-la não impõem desvantagem nas suas jogadas de ataque contra ela. Você também está ciente da localização de qualquer criatura invisível a até 9 metros de você, considerando que a criatura não esteja se escondendo de você e você não esteja cego ou surdo. "
        },
        new TracodeClasse
        {
            IdTracodeClasse = 121,
            Nome = "Matador de Inimigos",
            HabilidadeTracodeClasse = "No 20° nível, você se torna um caçador incomparável. Uma vez em cada um dos seus turnos, você pode adicionar seu modificador de Sabedoria na jogada de ataque ou jogada de dano de um ataque que você fizer. Você pode escolher usar essa característica antes ou depois da rolagem, mas antes de qualquer efeito da jogada ser aplicado."
        }
    );
        modelBuilder.Entity<Arquetipo>().HasData(
            new Arquetipo
            {
                IdArquetipo = 1,
                Nome = "Caminho do Furioso",
                HabilidadeArquetipo = "CAMINHO DO FURIOSO Para alguns bárbaros, a fúria é um meio para um fim – esse fim é a violência. O Caminho do Furioso é um caminho de fúria livre, entumecido em sangue. A medida que você entra na fúria de um furioso, você vibra no caos da batalha, despreocupado com a sua própria saúde ou bem-estar. FRENESI Começando no momento que você escolhe esse caminho no 3° nível, você pode entrar num frenesi quando estiver em fúria. Se você desejar, pela duração da sua fúria, você pode realizar um único ataque corpo-a-corpo com arma, com uma ação bônus, em cada um de seus turnos após esse. Quando sua fúria acabar, você sofrerá um nível de exaustão (como descrito no apêndice A). FÚRIA INCONSCIENTE A partir do 6° nível, você não pode ser enfeitiçado ou amedrontado enquanto estiver em fúria. Se você estava enfeitiçado ou amedrontado quando entrou em fúria, o efeito é suspenso pela duração da fúria. PRESENÇA INTIMIDANTE A partir do 10° nível, você pode usar sua ação para amedrontar alguém com sua presença intimidante. Quando o fizer, escolha uma criatura que você possa ver a 9 metros. Se a criatura puder ver ou ouvir você, ela deve ser bem sucedida num teste de resistência de Sabedoria (CD igual a 8 + seu bônus de proficiência + seu modificador de Carisma) ou ficara com medo de você até o fim do seu próximo turno. Nos turnos seguintes, você pode usar sua ação para estender a duração desse efeito na criatura amedrontada até o início do seu próximo turno. Esse efeito termina se a criatura terminar seu turno fora da sua linha de visão ao a mais de 18 metros de você. Se a criatura for bem sucedida no teste de resistência, você não poderá usar essa característica nessa criatura novamente por 24 horas. RETALIAÇÃO A partir do 14° nível, quando você sofrer dano de uma criatura que esteja a até 1,5 metro de você, você pode usar sua reação para realizar um ataque corpo-a-corpo com arma contra essa criatura. "
            },
            new Arquetipo
            {
                IdArquetipo = 2,
                Nome = "Caminho do Guerreiro Totêmico",
                HabilidadeArquetipo = "O Caminho do Guerreiro Totêmico é uma jornada espiritual, à partir do momento que o bárbaro aceita um espirito animal como seu guia, protetor e inspiração. Em batalha, seu espirito totêmico preenche você com força sobrenatural, adicionando combustível mágico a sua fúria bárbara. A maioria das tribos bárbaras consideram que um animal totêmico possui parentesco a um clã em particular. Em tais casos, é incomum a um indivíduo possuir mais de um espirito animal totêmico, apesar de existirem exceções. CONSELHEIRO ESPIRITUAL Seu caminho é buscar a sintonia com o mundo natural, concedendo a você uma afinidade com as bestas. A partir do 3° nível, quando você toma esse caminho, você recebe a habilidade de conjurar as magias sentido bestial e falar com animais, mas apenas na forma de rituais, como descrito no capítulo 10. TOTEM ESPIRITUAL A partir do 3° nível, quando você adota esse caminho, você escolhe um totem espiritual e ganha suas características. Você deve fazer ou adquirir um objeto físico como totem – um amuleto ou adorno similar – que incorpora o pelo ou penas, garras, dente ou ossos do animal totêmico. Se você quiser, você também adquire pequenos atributos físicos que o assemelham ao seu totem espiritual. Por exemplo, se você tiver o totem espiritual do urso, você seria incomumente peludo e de pele grossa, ou se o seu totem for a águia, seu olhos teriam um brilho amarelado. Seu totem animal deve ser um animal relacionado aos listados aqui, mas pode ser um mais apropriado a sua terra natal. Por exemplo, você poderia escolher falcão ou abutre ao invés de águia. Águia. Quando estiver em fúria e não estiver vestindo uma armadura pesada, as outras criaturas terão desvantagem nas jogadas de ataque de oportunidade contra você e você pode usar a ação de Disparada como uma ação bônus no seu turno. O espirito da águia torna você um predador que pode vagar pelo meio da briga com facilidade. Lobo. Quando estiver em fúria, seus amigos tem vantagem nas jogadas de ataque corpo-a-corpo realizadas contra qualquer criatura a 1,5 metro de você que seja hostil a você. O espirito do lobo transforma você em um líder de caça. Urso. Quando em fúria, você adquire resistência a todos os tipos de dano, exceto dano psíquico. O espirito do urso torna você vigoroso o suficiente para permanecer de pé diante de qualquer castigo. ASPECTO DA BESTA No 6° nível, você adquire um benefício místico baseado no totem que você escolheu. Você pode escolher o mesmo animal que selecionou no 3° nível ou um diferente. Águia. Você ganha a visão aguçada de uma águia. Você pode ver a até 1,6 km sem dificuldade, sendo capaz de discernir até os menores detalhes quando estiver olhando para algo a menos de 30 metros de você. Além disso, penumbra não impõem desvantagem nos seus testes de Sabedoria (Percepção). Lobo. Você ganha a sensibilidade predatória de um lobo. Você pode rastrear outras criaturas quando estiver viajando a passo rápido e você pode se mover furtivamente quando estiver viajando a passo normal (veja o capítulo 8 para as regras de passo de viagem). Urso. Você ganha a força de um urso. Sua capacidade de carga (incluindo carga máxima e capacidade de erguer) é dobrada e você tem vantagem em testes de Força realizados para empurrar, puxar, erguer ou quebrar objetos. ANDARILHO ESPIRITUAL No 10° nível, você pode conjurar a magia comunhão com a natureza, mas apenas como um ritual. Quando o fizer, uma versão espiritual de um dos animais que você escolheu como Totem Espiritual ou Aspecto da Besta aparece para você para transmitir a informação que você busca. SINTONIA TOTÊMICA No 14° nível, você ganha um benefício magico baseado em um totem animal, à sua escolha. Você pode escolher o mesmo animal que selecionou anteriormente ou um diferente. Águia. Quando estiver em fúria, você adquire um deslocamento de voo igual ao seu deslocamento de caminhada. Esse benefício funciona apenas em pequenos explosões: você cai se terminar seu turno no ar e não tiver nada em que possa se agarrar. Lobo. Quando estiver em fúria, você pode usar uma ação bônus no seu turno para derrubar uma criatura Grande ou menor no chão quando você atingi-la com um ataque corpo-a-corpo com arma. Urso. Quando estiver em fúria, qualquer criatura a até 1,5 metro de você que for hostil a você terá desvantagem nas jogadas de ataque contra outros alvos além de você ou outro personagem com essa característica. Um inimigo é imune a esse efeito se ele não puder ver ou ouvir você ou caso ele não possa ser amedrontado. "
            },
            new Arquetipo
            {
                IdArquetipo = 3,
                Nome = "Colégio do Conhecimento",
                HabilidadeArquetipo = "Bardos do Colégio do Conhecimento conhecem algo sobre a maioria das coisas, coletando pedaços de conhecimento de fontes tão diversas quanto tomos eruditos ou contos de camponeses. Quer seja cantando baladas populares em taverna, quer seja elaborando composições para cortes reais, esses bardos usam seus dons para manter a audiência enfeitiçada. Quando os aplausos acabam, os membros da audiência vão estar se questionando se tudo que eles creem é verdade, desde sua crença no sacerdócio do templo local até sua lealdade ao rei. A fidelidade desses bardos reside na busca pela beleza e verdade, não na lealdade a um monarca ou em seguir os dogmas de uma divindade. Um nobre que mantem um bardo desses como seu arauto ou conselheiro, sabe que o bardo prefere ser honesto que político. Os membros do colégio se reúnem em bibliotecas e, as vezes, em faculdades de verdade, completas com salas de aula e dormitórios, para partilhar seu conhecimento uns com os outros. Eles também se encontram em festivais ou em assuntos de estado, onde eles podem expor corrupção, desvendar mentiras e zombar da superestima de figuras de autoridade. PROFICIÊNCIA ADICIONAL Quando você se junta ao Colégio do Conhecimento no 3° nível, você ganha proficiência em três perícias, à sua escolha. PALAVRAS DE INTERRUPÇÃO Também no 3° nível, você aprende como usar sua perspicácia para distrair, confundir e, de outras formas, atrapalhar a confiança e competência de outros. Quando uma criatura que você pode ver a até 18 metros de você realizar uma jogada de ataque, um teste de habilidade ou uma jogada de dano, você pode usar sua reação para gastar um uso de Inspiração de Bardo, rolando o dado de Inspiração de Bardo e subtraindo o número rolado da rolagem da criatura. Você escolhe usar essa característica depois da criatura fazer a rolagem, mas antes do Mestre determinar se a jogada de ataque ou teste de habilidade foi bem ou mal sucedido, ou antes da criatura causar dano. A criatura será imune se não puder ouvir ou se não puder ser enfeitiçada. SEGREDOS MÁGICOS ADICIONAIS No 6° nível, você aprende duas magias, à sua escolha, de qualquer classe. As magias que você escolher devem ser de um nível que você possa conjurar, como mostrado na tabela O Bardo, ou um truque. As magias escolhidas contam como magias de bardo pra você, mas não contam no número de magias de bardo que você conhece. PERÍCIA INIGUALÁVEL A partir do 14° nível, quando você fizer um teste de habilidade, você pode gastar um uso de Inspiração de Bardo. Role o dado de Inspiração de Bardo e adicione o número rolado ao seu teste de habilidade. Você pode escolher fazer isso depois de rolar o dado do teste de habilidade, mas antes do Mestre dizer se foi bem ou mal sucedido. "
            },
            new Arquetipo
            {
                IdArquetipo = 4,
                Nome = "Colégio da Bravura",
                HabilidadeArquetipo = "Os bardos do Colégio da Bravura são escaldos destemidos de quem os contos mantem viva a memória dos grandes heróis do passado, dessa forma inspirando uma nova geração de heróis. Esses bardos se reúnem em salões de hidromel ou ao redor de fogueiras para cantar os feitos dos grandiosos, tanto do passado quanto do presente. Eles viajam pelos lugares para testemunhar grandes eventos em primeira mão e para garantir que a memória desses eventos não se perca nesse mundo. Com suas canções, eles inspiram outros a alcançar o mesmo patamar de realizações dos antigos heróis. PROFICIÊNCIA ADICIONAL Quando você se junta ao Colégio da Bravura no 3° nível, você adquire proficiência com armadura médias, escudos e armas marciais. INSPIRAÇÃO EM COMBATE Também no 3° nível, você aprende a inspirar os outros em batalha. Uma criatura que possuir um dado de Inspiração de Bardo seu, pode rolar esse dado e adicionar o número rolado a uma jogada de dano que ele tenha acabado de fazer. Alternativamente, quando uma jogada de ataque for realizada contra essa criatura, ela pode usar sua reação para rolar o dado de Inspiração de Bardo e adicionar o número rolado a sua CA contra esse ataque, depois da rolagem ser feita, mas antes de saber se errou ou acertou. ATAQUE EXTRA A partir do 6° nível, você pode atacar duas vezes, ao invés de uma, sempre que você realizar a ação de Ataque no seu turno. MAGIA DE BATALHA No 14° nível, você dominou a arte de tecer a conjuração e usar armas em um ato harmonioso. Quando você usar sua ação para conjurar uma magia de bardo, você pode realizar um ataque com arma com uma ação bônus."
            },
            new Arquetipo
            {
                IdArquetipo = 5,
                Nome = "Pacto da Corrente",
                HabilidadeArquetipo = "PACTO DA CORRENTE Você aprende a magia convocar familiar e pode conjurá-la como um ritual. Essa magia não conta no número de magias que você conhece. Quando você conjura essa magia, você pode escolher uma das formas convencionais para o seu familiar ou uma das seguintes formas especiais: diabrete, pseudodragão, quasit ou sprite. Além disso, quando você realiza a ação de Ataque, você pode renunciar s um dos seus ataques para permitir que seu familiar realize um ataque, com a reação dele"
            },
            new Arquetipo
            {
                IdArquetipo = 6,
                Nome = "Pacto da Lâmina",
                HabilidadeArquetipo = "Você pode usar sua ação para criar uma arma de pactom em sua mão vazia. Você escolhe a forma que essa arma corpo-a-corpo tem a cada vez que você a cria (veja as opções de arma no capítulo 5). Você é proficiente com ela enquanto a empunhar. Essa arma conta como sendo mágica com os propósitos de ultrapassar resistência e imunidade a ataques e danos não-mágicos. Sua arma de pacto desaparece se ela estiver a mais de 1,5 metro de você por 1 minuto ou mais. Ela também desaparece se você usar essa característica novamente, se você dissipar a arma (não requer ação) ou se você morrer. Você pode transformar uma arma mágica em sua arma de pacto ao realizar um ritual especial enquanto empunha a arma. Você precisa de 1 hora para concluir o ritual, que pode ser realizado durante um descanso curto. Você pode dissipar a arma, guardando-a em um espaço extradimensional, e ela reaparece toda vez que você criar sua arma de pacto. A arma deixa de ser sua arma de pacto se você morrer, se você realizar um ritual de 1 hora com outra arma diferente ou se você realizar um ritual de 1 hora para romper seu elo com ela. A arma aparece aos seus pés se ela estiver no espaço extradimensional quando o elo for quebrado."
            },
            new Arquetipo
            {
                IdArquetipo = 7,
                Nome = "Pacto do Tomo",
                HabilidadeArquetipo = "Seu patrono lhe deu um grimório chamado Livro das Sombras. Quando você adquire essa característica, escolha três truques da lista de magias de qualquer classe. Enquanto o livro estiver com você, você poderá conjurar esses truques à vontade. Eles não contam no número de truques que você conhece. Esses truques são considerados magias de bruxo para você e não precisam ser da mesma lista de magia. Se você perder seu Livro das Sombras, você pode realizar uma cerimônia de 1 hora para receber um substituto do seu patrono. Essa cerimônia pode ser realizada durante um descanso curto ou longo e destrói o livro anterior. O livro se torna cinzas quando você morre"
            },
            new Arquetipo
            {
                IdArquetipo = 8,
                Nome = "A Arquifada",
                HabilidadeArquetipo = "Seu patrono é um senhor ou senhora das fadas, uma criatura lendária que detém segredos que foram esquecidos antes das raças mortais nascerem. As motivações desses seres são, muitas vezes, inescrutáveis e, as vezes, excêntricas e podem envolver esforços para adquirir grandes poderes mágicos ou resolução de desavenças antigas. Incluem-se dentre esses seres o Príncipe do Frio; a Rainha do Ar e Trevas, regente da Corte do Crepúsculo; Titania da Corte do Verão; seu cônjuge, Oberon, o Senhor Verdejante; Hyrsam, o Príncipe dos Tolos; e bruxas antigas. LISTA DE MAGIA EXPANDIDA A Arquifada permite que você escolha magias de uma lista expandida quando você for aprender magias de bruxo. As seguintes magias são adicionadas a sua lista de magias de bruxo. MAGIAS EXPANDIDAS DA ARQUIFADA Nível de Magia Magias 1° fogo das fadas, sono 2° acalmar emoções, força fantasmagórica 3° piscar, ampliar plantas 4° dominar besta, invisibilidade maior 5° dominar pessoa, similaridade PRESENÇA FEÉRICA A partir do 1° nível, seu patrono concede a você a habilidade de projetar a sedução e temeridade da presença da fada. Com uma ação, você pode fazer com que cada criatura num cubo de 3 metros centrado em você, faça um teste de resistência de Sabedoria com uma CD igual a de sua magia de bruxo. As criaturas que falharem no teste ficaram enfeitiçadas ou amedrontadas por você (à sua escolha) até o início do seu próximo turno. Quando você usar essa característica, você não poderá utilizá-la novamente antes de realizar um descanso curto ou longo. NÉVOA DE FUGA A partir do 6° nível, você pode desaparecer em uma lufada de névoa em resposta a alguma ofensa. Quando você sofrer dano, você pode usar sua reação para ficar invisível e se teletransportar a até 18 metros para um espaço desocupado que você possa ver. Você permanece invisível até o início do seu próximo turno ou até realizar um ataque ou conjurar uma magia. Após usar essa características, você não poderá utilizá-la novamente até terminar um descanso curto ou longo. DEFESA SEDUTORA A partir do 10° nível, seu patrono ensina você como voltar as magias de efeito mental dos seus inimigos contra eles. Você não pode ser enfeitiçado e, quando outra criatura tenta enfeitiçá-lo, você pode usar sua reação para tentar reverter o encanto de volta aquela criatura. A criatura deve ser bem sucedida num teste de resistência de Sabedoria contra a CD da sua magia de bruxo ou ficara enfeitiçado por 1 minuto ou até a criatura sofrer dano. DELÍRIO SOMBRIO Começando no 14° nível, você pode imergir uma criatura num reino ilusório. Com um ação, escolha uma criatura que você possa ver a até 18 metros de você. Ela deve ser bem sucedida num teste de resistência de Sabedoria contra a CD da sua magia de bruxo. Se ela falhar, ela ficará enfeitiçada ou amedrontada por você (à sua escolha) por 1 minuto ou até você quebrar sua concentração (como se você estivesse se concentrando em uma magia). Esse efeito termina prematuramente se a criatura sofrer dano. Até que essa ilusão termine, a criatura acredita que está perdida num reino enevoado, a aparência desse reino fica a seu critério. A criatura só pode ver e ouvir a si mesma, a você e a sua ilusão. Você deve terminar um descanso curto ou longo antes de poder usar essa característica novamente. "
            },
            new Arquetipo
            {
                IdArquetipo = 9,
                Nome = "O Corruptor",
                HabilidadeArquetipo = "Você realizou um pacto com um corruptor dos planos de existência inferiores, um ser cujos objetivos são o mal, mesmo se você se opor a esses objetivos. Tais seres desejam corromper ou destruir todas as coisas, em última análise, até mesmo você. Corruptores poderosos o bastante para forjar pactos incluem lordes demônios como Demogorgon, Orcus, Fraz’Urb-luu e Bafomé; arquidiabos como Asmodeus, Dispater, Mefistófeles e Belial; senhores das profundezas e balors que sejam excepcionalmente poderosos; e ultraloths e outros senhores dos yugoloths. LISTA DE MAGIA EXPANDIDA O Corruptor permite que você escolha magias de uma lista expandida quando você for aprender magias de bruxo. As seguintes magias são adicionadas a sua lista de magias de bruxo. MAGIAS EXPANDIDAS DO CORRUPTOR Nível de Magia Magias 1° mãos flamejantes, comando 2° cegueira/surdez, raio ardente 3° bola de fogo, névoa fétida 4° escudo de fogo, muralha de fogo 5° coluna de chamas, consagrar BÊNÇÃO DO OBSCURO A partir do 1° nível, quando você reduzir uma criatura hostil a 0 pontos de vida, você ganha uma quantidade de pontos de vida temporários igual ao seu modificador de Carisma + seu nível de bruxo (mínimo 1). SORTE DO PRÓPRIO OBSCURO A partir do 6° nível, você pode pedir ao seu patrono para alterar o destino em seu favor. Quando você realizar um teste de habilidade ou um teste de resistência, você pode usar essa característica para adicionar 1d10 a sua jogada. Você pode fazer isso após ver sua jogada inicial, mas antes que qualquer efeito da jogada ocorra. Após usar essa características, você não poderá utilizá-la novamente até terminar um descanso curto ou longo. RESISTÊNCIA DEMONÍACA A partir do 10° nível, você pode escolher um tipo de dano quando você terminar um descanso curto ou longo. Você adquire resistência contra esse tipo de dano até você escolher um tipo de dano diferente com essa característica. Dano causado por armas mágicas ou armas de prata ignoram essa resistência. LANÇAR NO INFERNO A partir do 14° nível, quando você atingir uma criatura com um ataque, você pode usar essa característica para, instantaneamente, transportar o alvo para os planos inferiores. A criatura desaparece e é jogada para um lugar similar a um pesadelo. No final do seu turno, o alvo retorna ao lugar que ela ocupava anteriormente, ou para o espaço desocupado mais próximo. Se o alvo não for um corruptor, ele sofre 10d10 de dano psíquico à medida que toma conta da experiência traumática. Após usar essa características, você não poderá utilizá-la novamente até terminar um descanso curto ou longo. "
            },
            new Arquetipo
            {
                IdArquetipo = 10,
                Nome = "O Grande Antigo",
                HabilidadeArquetipo = "Seu patrono é uma entidade misteriosa cuja natureza é profundamente alheia ao tecido da realidade. Ela deve ter vindo do Reino Distante, o espaço além da realidade, ou ela pode ser um dos deuses anciãos conhecido apenas nas lendas. Seus motivos são incompreensíveis para os mortais e seu conhecimento é tão imenso e antigo que, até mesmo, as mais grandiosas bibliotecas desbotam em comparação com os vastos segredos que ele detém. O Grande Antigo pode desconhecer a sua existência ou ser totalmente indiferente a você, mas os segredos que você desvendou permitem que você obtenha suas magias dele. Entidades desse tipo incluem Ghaunadar, conhecido como Aquele que Espreita; Tharizdun, o Deus Acorrentado; Dendar, a Serpente da Noite; Zargon, o Retornado; Grande Cthulhu; entre outros seres insondáveis. LISTA DE MAGIA EXPANDIDAO Grande Antigo permite que você escolha magias de uma lista expandida quando você for aprender magias de bruxo. As seguintes magias são adicionadas a sua lista de magias de bruxo. MAGIAS EXPANDIDAS DO GRANDE ANTIGO Nível de Magia Magias 1° sussurros dissonantes, riso histérico de Tasha 2° detectar pensamentos, força fantasmagórica 3° clarividência, enviar mensagem 4° dominar besta, tentáculos negros de Evard 5° dominar pessoa, telecinésia DESPERTAR A MENTE A partir do 1° nível, seu conhecimento alienígena concede a você a habilidade de tocar a mente de outras criaturas. Você pode se comunicar telepaticamente com qualquer criatura que você possa ver a até 18 metros de você. Você não precisa partilhar um idioma com a criatura para compreender suas expressões telepáticas, mas a criatura deve ser capaz de compreender pelo menos um idioma. PROTEÇÃO ENTRÓPICA A partir do 6° nível, você aprende a se proteger magicamente contra ataques e a transformar os ataques mal sucedidos de seus inimigos em boa sorte pra você. Quando uma criatura realizar uma jogada de ataque contra você, você pode usar sua reação para impor desvantagem nesse jogada. Se o ataque errar você, sua próxima jogada de ataque contra essa criatura recebevantagem se você o fizer antes do final do seu próximo turno. Após usar essa características, você não poderá utilizá-la novamente até terminar um descanso curto ou longo. ESCUDO DE PENSAMENTOS A partir do 10° nível, seus pensamentos não podem ser lidos através de telepatia ou outros meios, a não ser que você permita. Você também adquire resistência a dano psíquico e, toda vez que uma criatura causar dano psíquico a você, essa criatura sofre a mesma quantidade de dano que você sofreu. CRIAR LACAIO No 14° nível, você adquire a habilidade de infectar a mente de um humanoide com a magia alienígena do seu patrono. Você pode usar sua ação para tocar um humanoide incapacitado. Essa criatura então, ficará enfeitiçada por você até que a magia remover maldição seja conjurada sobre ela, a condição enfeitiçado seja removida dela ou você use essa característica novamente. Você pode se comunicar telepaticamente com a criatura enfeitiçada contanto que ambos estejam no mesmo plano de existência. "
            },
            new Arquetipo
            {
                IdArquetipo = 11,
                Nome = "Invocações Místicas",
                HabilidadeArquetipo = "Se uma invocação mística tiver pré-requisitos, você deve possuí-los para que possa aprendê-la. Você pode aprender a invocação ao mesmo tempo que adquire os prérequisitos dela. O pré-requisito de nível nas invocações se refere ao nível de bruxo, não ao nível de personagem. ARMADURA DE SOMBRAS Você pode conjurar armadura arcana em si mesmo, à vontade, sem precisar gastar um espaço de magia ou componentes materiais. CORRENTES DE CÁRCERI Pré-requisito: 15° nível, característica Corrente de Cárceri Você pode conjurar imobilizar monstro, à vontade – tendo como alvo um celestial, corruptor ou elemental – sem precisar gastar um espaço de magia ou componentes materiais. Você deve terminar um descanso longo antes de poder usar essa invocação na mesma criatura novamente. ENCHARCAR A MENTE Pré-requisito: 5° nível Você pode conjurar lentidão, uma vez, usando um espaço de magia de bruxo. Você não pode fazer isso novamente até terminar um descanso longo. ESCULTOR DE CARNE Pré-requisito: 7° nível Você pode conjurar metamorfose, uma vez, usando um espaço de magia de bruxo. Você não pode fazer isso novamente até terminar um descanso longo. EXPLOSÃO AGONIZANTE Pré-requisito: truque rajada mística Quando você conjura rajada mística, adicione seu modificador de Carisma ao dano causado quando atingir. EXPLOSÃO REPULSIVA Pré-requisito: truque rajada mística Quando você atingir uma criatura com uma rajada mística, você pode empurrar a criatura até 3 metros para longe de você em linha reta. IDIOMA BESTIAL Você pode conjurar falar com animais, à vontade, sem precisar gastar um espaço de magia. INFLUÊNCIA ENGANADORA Você ganha proficiência nas perícias Enganação e Persuasão. LACAIOS DO CAOS Pré-requisito: 9° nível Você pode lançar conjurar elemental, uma vez, usando um espaço de magia de bruxo. Você não pode fazer isso novamente até terminar um descanso longo. LÂMINA SEDENTA Pré-requisito: 5° nível, característica Pacto da Lâmina Você pode atacar com sua arma do pacto duas vezes, ao invés de apenas uma, quando você usa a ação de Ataque no seu turno. LANÇA MÍSTICA Pré-requisito: truque rajada mística Quando você conjura rajada mística, seu alcance será de 90 metros. LARÁPIO DOS CINCO DESTINOS Você pode conjurar perdição, uma vez, usando um espaço de magia de bruxo. Você não pode fazer isso novamente até terminar um descanso longo. LIVRO DE SEGREDOS ANTIGOS Pré-requisito: Característica Pacto do Tomo Você pode agora, registrar rituais mágicos no seu Livro das Sombras. Escolha duas magias de 1° nível que 62 possuam o descritor ritual da lista de magias de qualquer classe. A magia aparece no livro e não conta no número de magias que você conhece. Com o seu Livro das Sombras em mãos, você pode conjurar as magias escolhidas como rituais. Você não pode conjurar essas magias, exceto na forma de rituais, a não ser que você tenha aprendido elas através de outros meios. Você também pode conjurar uma magia de bruxo que você conheça como ritual se ela possuir o descritor ritual. Os rituais não precisam ser da mesma lista de magias. Durante suas aventuras, você pode adicionar outras magias de ritual ao seu Livro das Sombras. Quando você encontrar tais magias, você pode adicioná-la ao livro se o nível da magia for igual ou inferior à metade do seu nível de bruxo (arredondado para baixo) e se você tiver tempo para gastar transcrevendo a magia. Para cada nível da magia, o processo de transcrição levará 2 horas e custará 50 po, devido às tintas raras necessárias para inscrevê-la. MÁSCARA DAS MUITAS FACES Você pode conjurar disfarçar-se, à vontade, sem precisar gastar um espaço de magia. MESTRE DAS INFINDÁVEIS FORMAS Pré-requisito: 15° nível Você pode conjurar alterar-se, à vontade, sem precisar gastar um espaço de magia. OLHAR DE DUAS MENTES Você pode usar sua ação para tocar um humanoide voluntário e perceber através do seus sentidos até o final do seu próximo turno. Conquanto que a criatura esteja no mesmo plano de existência que você, você pode usar sua ação nas rodadas subsequentes para manter a conexão, estendendo a duração até o início do seu próximo turno. Enquanto estiver percebendo através dos sentidos de outra criatura, você aproveita os benefícios de todos os sentidos especiais possuídos pela criatura e você fica cego e surdo ao que está a sua volta. OLHOS DO GUARDIÃO DAS RUNAS Você pode ler todas as escritas. PALAVRA TERRÍVEL Pré-requisito: 7° nível Você pode conjurar confusão, uma vez, usando um espaço de magia de bruxo. Você não pode fazer isso novamente até terminar um descanso longo. PASSO ASCENDENTE Pré-requisito: 9° nível Você pode conjurar levitação em si mesmo, à vontade, sem precisar gastar um espaço de magia ou componentes materiais. SALTO TRANSCENDENTAL Pré-requisito: 9° nível Você pode conjurar salto em si mesmo, à vontade, sem precisar gastar um espaço de magia ou componentes materiais. SINAL DE MAU AGOURO Pré-requisito: 5° nível Você pode conjurar rogar maldição, uma vez, usando um espaço de magia de bruxo. Você não pode fazer isso novamente até terminar um descanso longo. SORVEDOR DE VIDA Pré-requisito: 12° nível, característica Pacto da Lâmina Quando você atingir uma criatura com sua arma do pacto, a criatura sofre uma quantidade de dano necrótico adicional igual ao seu modificador de Carisma (mínimo 1). SUSSURROS DA SEPULTURA Pré-requisito: 9° nível Você pode conjurar falar com os mortos, à vontade, sem precisar gastar um espaço de magia. SUSSURROS SEDUTORES Pré-requisito: 7° nível Você pode conjurar compulsão, uma vez, usando um espaço de magia de bruxo. Você não pode fazer isso novamente até terminar um descanso longo. UNO COM AS SOMBRAS Pré-requisito: 5° nível Quando você estiver em uma área de penumbra ou escuridão, você pode usar sua ação para ficar invisível até se mover ou realizar uma ação ou reação. VIGOR ABISSAL Você pode conjurar vitalidade falsa em si mesmo, à vontade, como uma magia de 1° nível, sem precisar gastar um espaço de magia ou componentes materiais. VISÃO DA BRUXA Pré-requisito: 15° nível Você pode ver a verdadeira forma de qualquer metamorfo ou criatura oculta através de magias de ilusão ou transmutação contanto que a criatura esteja a até 9 metros de você e você tenha linha de visão. VISÃO DIABÓLICA Você pode ver normalmente na escuridão, tanto mágica quanto normal, com um alcance de 36 metros. VISÃO MÍSTICA Você pode conjurar detectar magia, à vontade, sem precisar gastar um espaço de magia. VISÕES DE REINOS DISTANTES Pré-requisito: 15° nível Você pode conjurar olho arcano, à vontade, sem precisar gastar um espaço de magia. VISÕES NAS BRUMAS Você pode conjurar imagem silenciosa, à vontade, sem precisar gastar um espaço de magia ou componentes materiais. VOZ DO MESTRE DAS CORRENTES Pré-requisito: Característica Pacto da Corrente Você pode se comunicar telepaticamente com seu familiar e perceber através dos sentidos do seu familiar enquanto ambos estiverem no mesmo plano de existência. Além disso, enquanto estiver percebendo através dos sentidos do seu familiar, você também poderá falar através dele com a sua voz, mesmo que seu familiar, normalmente, seja incapaz de falar"
            },
            new Arquetipo
            {
                IdArquetipo = 12,
                Nome = "Domínio do Conhecimento",
                HabilidadeArquetipo = "Os deuses do conhecimento – como Oghma, Boccob, Gilean, Aureon e Thoth – valorizam o estudo e compreensão acima de tudo. Alguns ensinam que o conhecimento deve ser coletado e partilhado em bibliotecas e universidades ou promovem o conhecimento prático do artesanato e da invenção. Algumas divindades escondem conhecimentos e os mantem em segredo para si mesmos. E outros prometem a seus seguidores que eles ganharão poderes tremendos se desvendarem os segredos do multiverso. Os seguidores desses deuses estudam conhecimento exotérico, coletam tomos antigos, escavam locais secretos da terra e aprendem tudo que podem. Alguns deuses do conhecimento que promovem a prática de ofícios e criação incluem deuses da forja como Gond, Reorx, Onatar, Moradin, Hefesto e Goibhniu. MAGIAS DO DOMÍNIO DO CONHECIMENTO Nível de Clérigo Magias 1° comando, identificação 3° augúrio, sugestão 5° dificultar detecção, falar com os mortos 7° olho arcano, confusão 9° conhecimento lendário, vidência BÊNÇÃOS DO CONHECIMENTO No 1° nível, você aprende dois idiomas, à sua escolha. Você também se torna proficiente em duas perícias, à sua escolha, dentre as seguintes: Arcanismo, História, Natureza ou Religião. Seu bônus de proficiência é dobrado em qualquer teste de habilidade que você fizer usando qualquer dessas perícias. CANALIZAR DIVINDADE: CONHECIMENTO DAS ERAS A partir do 2° nível, você pode usar seu Canalizar Divindade para beber da fonte divina do conhecimento. Com uma ação, você escolhe uma perícia ou ferramenta. Por 10 minutos, você terá proficiência com a perícia ou ferramenta escolhida. 67 CANALIZAR DIVINDADE: LER PENSAMENTOS No 6° nível, você pode usar seu Canalizar Divindade para ler a mente de uma criatura. Você pode, então, usar seu acesso a mente da criatura para comandá-la. Com uma ação, escolha uma criatura que você possa ver que esteja a até 18 metros de você. Essa criatura deve realizar um teste de resistência de Sabedoria, se for bem sucedida nesse teste, você não poderá usar essa característica contra ela novamente até terminar um descanso longo. Se a criatura falhar no teste, você pode ler seus pensamentos superficiais (aqueles mais atuais, que refletem suas emoções e no que você está pensando constantemente) quando estiver a até 18 metros de você. Esse efeito dura por 1 minuto. Durante esse tempo, você pode usar sua ação para terminar esse efeito e conjurar a magia sugestão na criatura sem gastar um espaço de magia. O alvo falha automaticamente no teste de resistência contra essa magia. CONJURAÇÃO PODEROSA A partir do 8° nível, você adiciona seu modificador de Sabedoria no dano causado por qualquer truque de clérigo. VISÕES DO PASSADO A partir do 17° nível, você pode convocar visões do passado relacionadas a um objeto que você esteja segurando ou sobre o ambiente ao seu redor. Você gasta pelo menos 1 minuto meditando e rezando, então, recebe oníricos vislumbres turvos dos eventos recentes. Você pode meditar dessa maneira por um número de minutos igual ao seu valor de Sabedoria e deve manter a concentração durante esse tempo, como se você estivesse conjurando uma magia. Quando você usa essa característica, você não pode usá-la novamente até terminar um descanso curto ou longo. Leitura de Objeto. Ao segurar um objeto enquanto medita, você pode ter visões do dono anterior do objeto. Depois de meditar por 1 minuto, você descobre como o antigo dono adquiriu e perdeu o objeto, assim como o evento recente mais significativo envolvendo o objeto e seu dono. Se o objeto foi portado por outra criatura num passado recente (dentro de um número de dias igual ao seu valor de Sabedoria), você pode gastar 1 minuto adicional, por cada dono, para descobrir as mesmas informações sobre essa criatura. Leitura Local. À medida que você medita, você tem visões dos eventos recentes nas suas vizinhanças próximas (uma sala, rua, túnel, clareira, ou similar, de até 15 metros cúbicos), voltando um número de dias igual ao seu valor de Sabedoria. Para cada minuto que você meditar, você descobre sobre um evento significativo, a partir dos mais recentes. Eventos significativos, normalmente envolvem emoções fortes, como batalhas e traições, casamentos e assassinatos, nascimentos e funerais. No entanto, também podem incluir eventos mais mundanos, que podem ser, no entanto, relevantes na sua"
            },
            new Arquetipo
            {
                IdArquetipo = 13,
                Nome = "Domínio da Enganação",
                HabilidadeArquetipo = "Deuses da enganação – como Tymora, Beshaba, Olidammara, o Viajante, Garl Glittergold e Loki – são causadores de travessuras e instigadores que se mantem como um desafio constante para a aceitação das ordens tanto de mortais quanto dos deuses. Eles são patronos dos ladrões, trapaceiros, apostadores, rebeldes e libertadores. Seus clérigos são uma força intrometida no mundo, ferindo orgulhos, zombando de tiranos, roubando dos ricos, libertando cativos e desrespeitando tradições vazias. Eles preferem subterfúgio, trapaças, enganação e rouba no lugar do confronto direto. MAGIAS DO DOMÍNIO DA ENGANAÇÃO Nível de Clérigo Magias 1° enfeitiçar pessoa, disfarçar-se 3° reflexos, passos sem pegadas 5° piscar, dissipar magia 7° porta dimensional, metamorfose 9° dominar pessoa, modificar memória BÊNÇÃO DO TRAPACEIRO A partir do momento em que você escolhe esse domínio, no 1° nível, você pode usar sua ação para tocar uma criatura voluntária além de você mesmo para conceder vantagem em testes de Destreza (Furtividade). Essa bênção dura por 1 hora ou até você usar essa característica novamente. 68 CANALIZAR DIVINDADE: INVOCAR DUPLICIDADE A partir do 2° nível, você pode usar seu Canalizar Divindade para criar uma duplicada ilusória de si mesmo. Com uma ação, você cria uma ilusão perfeita de si mesmo que dura por 1 minuto ou até você perder sua concentração (como se você estivesse se concentrando em uma magia). A ilusão aparece em um espaço desocupado que você possa ver a até 9 metros de você. Com uma ação bônus, no seu turno, você pode mover a ilusão até 9 metros para um espaço que você possa ver, mas ela deve permanecer a até 36 metros de você. Pela duração, você pode conjurar magias como se você estivesse no espaço ocupado pela ilusão, mas você deve usar seus próprios sentidos. Além disso, quando ambos você e sua ilusão estiverem a 1,5 metro de uma criatura que possa ver a ilusão, você tem vantagem nas jogadas de ataque contra essa criatura, devido a distração causada no alvo pela ilusão. CANALIZAR DIVINDADE: MANTO DE SOMBRAS No 6° nível, você pode usar seu Canalizar Divindade para desaparecer. Com uma ação, você se torna invisível até o final do seu próximo turno. Você se torna visível se atacar ou conjurar uma magia. GOLPE DIVINO No 8º nível, você ganha a habilidade de imbuir seus ataques com arma com veneno – uma dádiva da sua divindade. Uma vez em cada um de seus turnos, quando você acertar uma criatura com um ataque com arma, você pode fazer o ataque causar 1d8 de dano de veneno extra ao alvo. Quando alcançar o 14º nível, o dano extra aumenta para 2d8. DUPLICIDADE APRIMORADA A partir do 17° nível, você pode criar até quatro duplicatas de você, ao invés de uma, quando usar Invocar Duplicidade. Com uma ação bônus, no seu turno, você pode mover quantas duplicadas quiser até 9 metros, até no máximo de 36 metros de distância."
            },
            new Arquetipo
            {
                IdArquetipo = 14,
                Nome = "Domínio da Guerra",
                HabilidadeArquetipo = "A guerra tem muitas manifestações. Ela pode tornar pessoas comuns em heróis. Ela pode ser desesperadora e horripilante, com atos de crueldade e covardia obscurecendo momentos de bravura e coragem. Em ambos os casos, os deuses da guerra zelam pelos guerreiros e os recompensa pelos seus grandes feitos. Os clérigos de tais deuses se sobressaem em batalha, inspirando os outros a lutar o bom combate ou oferecendo atos de violência como suas orações. Entre os deuses da guerra estão inclusos campeões da honra e bravura (como Torm, Heironeous e Kir-Jolith) assim como deuses da destruição e pilhagem (como Erythnul, a Fúria, Gruumsh e Ares) e deuses da conquista e dominação (como Bane, Hextor e Maglubiyet). Outros deuses da guerra (como Tempus, Nike e Nuada) tomam uma postura mais neutra, promovendo a guerra em todas as suas manifestações e apoiando os guerreiros em qualquer circunstância. MAGIAS DO DOMÍNIO DA GUERRA Nível de Clérigo Magias 1° auxílio divino, escudo da fé 3° arma mágica, arma espiritual 5° manto do cruzado, espíritos guardiões 7° movimentação livre, pele de pedra 9° coluna de chamas, imobilizar monstro PROFICIÊNCIA ADICIONAL No 1° nível, você adquire proficiência em armas marciais e em armaduras pesadas. SACERDOTE DA GUERRA A partir do 1° nível, seu deus envia rajadas de inspiração a você quando você está engajado em combate. Quando você usa a ação de Ataque, você pode realizar um ataque com arma, com uma ação bônus. Você pode usar essa característica um número de vezes igual ao seu modificador de Sabedoria (mínimo uma vez). Você recupera todos os usos gastos após terminar um descanso longo. CANALIZAR DIVINDADE: ATAQUE DIRIGIDO A partir do 2° nível, você pode usar seu Canalizar Divindade para golpear com precisão sobrenatural. Quando você realiza uma jogada de ataque, você pode usar seu Canalizar Divindade para recebe +10 de bônus na jogada. Você realiza essa escolha depois de ver a rolagem, mas antes do Mestre dizer se o ataque atingiu ou errou. CANALIZAR DIVINDADE: BÊNÇÃO DO DEUS DA GUERRA No 6° nível, quando uma criatura a até 9 metros de você realizar uma jogada de ataque, você pode usar sua reação para conceder a criatura +10 de bônus nessa jogada, usando seu Canalizar Divindade. Você realiza essa escolha depois de ver a rolagem, mas antes do Mestre dizer se o ataque atingiu ou errou. GOLPE DIVINO No 8º nível, você ganha a habilidade de imbuir seus ataques com energia divina. Uma vez em cada um de seus turnos, quando você acertar uma criatura com um ataque com arma, você pode fazer o ataque causar 1d8 de dano extra de mesmo tipo do dano da arma ao alvo. Quando alcançar o 14º nível, o dano extra aumenta para 2d8. AVATAR DA BATALHA A partir do 17° nível, você ganha resistência a dano de concussão, cortante e perfurante de ataques não-mágicos"
            },
            new Arquetipo
            {
                IdArquetipo = 15,
                Nome = "Domínio da Luz",
                HabilidadeArquetipo = "Deuses da luz – como Helm, Lathander, Pholtus, Branchala, a Chama Prateada, Belenus, Apolo e ReHorakhty – promovem os ideias do renascimento e renovação, verdade, vigilância e beleza, muitas vezes usando o símbolo do sol. Alguns desses deuses são retratados como o próprio sol ou como um cocheiro que carrega o sol através do céu. Outros são sentinelas incansáveis cujos olhos penetram cada sombra e veem através de cada enganação. Alguns são divindades da beleza e arte que ensinam que a arte é o veículo para o aprimoramento da alma. Clérigos de um deus da luz são almas esclarecidas infundidas com radiação e o poder divino da visão do discernimento, conhecidos por afastar as mentiras e incineras a escuridão. MAGIAS DO DOMÍNIO DA LUZ Nível de Clérigo Magias 1° mãos flamejantes, fogo das fadas 3° esfera flamejante, raio ardente 5° luz do dia, bola de fogo 7° guardião da fé, muralha de fogo 9° coluna de chamas, vidência 69 TRUQUE ADICIONAL Quando você escolhe esse domínio no 1° nível, você ganha o truque luz se você ainda não o conhecia. LABAREDA PROTETORA Também a partir do 1° nível, você pode interpor luz divina entre você e uma criatura atacante. Quando você for atacado por uma criatura a até 9 metros de você que você pode ver, você pode usar sua reação para impor desvantagem na jogada de ataque, causando labaredas de luz na frente do atacante antes dele atingir ou errar. Um atacante que não puder ser cegado é imune a essa característica. Você pode usar essa característica um número de vezes igual ao seu modificador de Sabedoria (mínimo uma vez). Você recupera todos os usos gastos após terminar um descanso longo. CANALIZAR DIVINDADE: RADIAÇÃO DO AMANHECER A partir do 2° nível, você pode usar seu Canalizar Divindade para criar uma explosão de luz solar, banindo a escuridão e causando dano radiante aos inimigos. Com uma ação, você ergue seu símbolo sagrado e qualquer escuridão mágica num raio de 9 metros de você é dissipada. Além disso, cada criatura hostil a até 9 metros deve realizar um teste de resistência de Constituição. Uma criatura sofre dano radiante igual a 2d10 + seu nível de clérigo se falhar no teste e metade desse dano caso seja bem sucedida. Uma criatura que tenha cobertura total contra você não é afetada. LABAREDA APRIMORADA No 6° nível, você também pode utilizar sua característica Labareda Protetora quando uma criatura que você possa ver a até 9 metros atacar outra criatura diferente de você. CONJURAÇÃO PODEROSA A partir do 8° nível, você adiciona seu modificador de Sabedoria no dano causado por qualquer truque de clérigo. COROA DE LUZ A partir do 17° nível, você pode usar sua ação para ativar uma aura de luz solar que dura por 1 minuto ou até você dissipá-la usando outra ação. Você emite luz plena num raio de 18 metros e penumbra a até 9 metros além disso. Os seus inimigos na área de luz plena tem desvantagem nos testes de resistência contra suas magias que causam dano de fogo ou dano radiante."
            },
            new Arquetipo
            {
                IdArquetipo = 16,
                Nome = "Domínio da Natureza",
                HabilidadeArquetipo = "Os deuses da natureza são tão variados como a própria natureza do mundo, desde deuses inescrutáveis de profundas florestas (como Silvanus, Obad-Hai, Chislev, Balinor e Pã) até divindades amigáveis associadas a alguma fonte ou bosque em particular (como Eldath). Druidas reverenciam a natureza como um todo e podem vir a servir essas divindades, praticando ritos misteriosos e recitando orações a muito esquecidas em sua própria língua secreta. Porém, muitos desses deuses também possuem clérigos, campeões que tem um papel mais ativo em promover os interesses particulares de um deus da natureza. Esses clérigos devem caçar monstruosidades malignas que usurpam dos bosques, abençoar a colheita dos fieis ou murchar a cultura dos que irritarem seus deuses. MAGIAS DO DOMÍNIO DA NATUREZA Nível de Clérigo Magias 1° amizade animal, falar com animais 3° pele de árvore, crescer espinhos 5° ampliar plantas, muralha de vento 7° dominar besta, vinha esmagadora 9° praga de insetos, caminhar em árvores ACÓLITO DA NATUREZA No 1° nível, você aprende um truque de druida, à sua escolha. Você também ganha proficiência em uma das seguintes perícias, à sua escolha: Adestrar Animais, Natureza ou Sobrevivência. PROFICIÊNCIA ADICIONAL Também a partir do 1° nível, você adquire proficiência com armaduras pesadas. CANALIZAR DIVINDADE: ENFEITIÇAR ANIMAIS E PLANTAS A partir do 2° nível, você pode usar seu Canalizar Divindade para enfeitiçar animais e plantas. Com uma ação, você ergue seu símbolo sagrado e invoca o nome do seu deus. Cada besta ou criatura-planta que puder ver você num raio de 9 metros, deve realizar um teste de resistência de Sabedoria. Se a criatura falhar, ela estará enfeitiçada por você durante 1 minuto ou até sofrer dano. Enquanto estiver enfeitiçada por você, ela será amistosa a você a as criaturas que você designar. AMORTECER ELEMENTOS No 6° nível, quando você ou uma criatura a até 9 metros de você sofrer dano de ácido, frio, fogo, elétrico ou trovão, você pode usar sua reação para conceder resistência a criatura contra aquele tipo de dano. GOLPE DIVINO No 8º nível, você ganha a habilidade de imbuir seus ataques com energia divina. Uma vez em cada um de seus turnos, quando você acertar uma criatura com um ataque com arma, você pode fazer o atque causar 1d8 de dano de frio, fogo ou elétrico (à sua escolha) extra ao alvo. Quando alcançar o 14º nível, o dano extra aumenta para 2d8. SENHOR DA NATUREZA A partir do 17° nível, você ganha a habilidade de comandar animais e criaturas-planta. Enquanto a criatura estiver enfeitiçada pela sua característica Enfeitiçar Animais e Plantas, você pode usar uma ação bônus no seu turno para dizer verbalmente o que cada uma dessas criaturas devem fazer no próximo turno delas."
            },
            new Arquetipo
            {
                IdArquetipo = 17,
                Nome = "Domínio da Tempestade",
                HabilidadeArquetipo = "Deuses cujo portfólio contenha o domínio da Tempestade – como Talos, Umberlee, Kord, Zeboim, o Devorador, Zeus e Thor – governam tormentas, mares e céus. Estão inclusos deuses dos relâmpagos e trovões, deuses dos terremotos, alguns deuses do fogo e certos deuses da violência, força física e coragem. Em alguns panteões, um deus com esse domínio comanda os outros deuses e é conhecido pela justiça rápida levada através de relâmpagos. Nos panteões de povos marítimos e 70 navegantes, deuses com esse domínio são divindades do oceano e patrono dos marinheiros. Deuses da tempestade enviam seus clérigos para inspirar pavor no povo comum, tanto para mantê-los no caminho da justiça e coragem quanto para oferecer sacrifícios de propiciação para afastar a ira divina. MAGIAS DO DOMÍNIO DA TEMPESTADE Nível de Clérigo Magias 1° névoa obscurecente, onda trovejante 3° lufada de vento, despedaçar 5° convocar relâmpagos, nevasca 7° controlar a água, tempestade de gelo 9° onda destrutiva, praga de insetos PROFICIÊNCIA ADICIONAL A partir do 1° nível, você adquire proficiência em armas marciais e armaduras pesadas. IRA DA TORMENTA Também a partir do 1° nível, você pode repreender ataques violentamente. Quando uma criatura a 1,5 metro de você que você possa ver, atingir você com um ataque, você pode usar sua reação para forçar a criatura a realizar um teste de resistência de Destreza. A criatura sofre 2d8 de dano elétrico ou de trovão (à sua escolha) caso falhe no teste, e metade desse dano caso seja bem sucedido. Você pode usar essa característica um número de vezes igual ao seu modificador de Sabedoria (mínimo uma vez). Você recupera todos os usos gastos após terminar um descanso longo. CANALIZAR DIVINDADE: IRA DESTRUIDORA A partir do 2° nível, você pode usar seu Canalizar Divindade para empunhar o poder da tormenta com ferocidade desmedida. Quando você rolar dano elétrico ou trovejante, você pode usar seu Canalizar Divindade para causar o máximo de dano, ao invés de rolá-lo. GOLPE DE RELÂMPAGO No 6° nível, quando você causa dano elétrico a uma criatura Grande ou menor, você também pode empurrá-la para até 3 metros de distância de você. GOLPE DIVINO No 8º nível, você ganha a habilidade de imbuir seus ataques com energia divina. Uma vez em cada um de seus turnos, quando você acertar uma criatura com um ataque com arma, você pode fazer o ataque causar 1d8 de dano trovejante extra ao alvo. Quando alcançar o 14º nível, o dano extra aumenta para 2d8. FILHO DA TORMENTA A partir do 17° nível, você adquire deslocamento de voo igual a seu deslocamento de caminhada contanto que você não esteja no subterrâneo ou em local fechado."
            },
            new Arquetipo
            {
                IdArquetipo = 18,
                Nome = "Domínio da Vida",
                HabilidadeArquetipo = "O domínio da vida foca na vívida energia positiva – uma das forças fundamentais do universo – que sustenta toda a vida. Os deuses da vida promovem a vitalidade e a saúde, curando os doentes e feridos, cuidando dos necessitados, além de afastar as forças da morte e hordas de mortos-vivos. Quase toda divindade não maligna pode alegar influência sobre esse domínio. Em particular divindades da agricultura (como Chauntea, Arawai e Demeter), do sol (como Lathander, Pelor e Re-Horakhty), da cura ou resistência (como Ilmater, Mishakal, Apolo e Diancecht), e do lar e comunidade (como Hestia, Hathor e Boldrei). MAGIAS DO DOMÍNIO DA VIDA Nível de Clérigo Magias 1° bênção, curar ferimentos 3° restauração menor, arma espiritual 5° sinal de esperança, revivificar 7° proteção contra a morte, guardião da fé 9° curar ferimentos em massa, reviver os mortos PROFICIÊNCIA ADICIONAL Quando você escolhe este domínio no 1º nível, você ganha proficiência com armaduras pesadas. DISCÍPULO DA VIDA Também no 1º nível, suas magias de cura são mais efetivas. Sempre que você conjurar uma magia de cura para recuperar pontos de vida, o alvo daquela magia recupera pontos de vida adicionais iguais a 2 + nível da magia. CANALIZAR DIVINDADE: PRESERVAR A VIDA A partir do 2º nível, você pode usar seu Canalizar Divindade para curar os feridos. Como uma ação, você usa seu símbolo sagrado para invocar energia que pode recuperar um total de 5 vezes seu nível de clérigo em pontos de vida. Você escolhe quaisquer criaturas a até 9 metros de você e divide esses pontos entre elas. Essa característica só pode curar as criaturas a até metade de seu máximo de pontos de vida. Você não pode usar essa característica em um morto-vivo ou constructo. CURANDEIRO ABENÇOADO A partir do 6º nível, as magias que você conjurar para curar os outros também curam você. Quando conjurar uma magia de cura em outra criatura, você também recupera pontos de vida, em um total de 2 + nível da magia. GOLPE DIVINO No 8º nível, você ganha a habilidade de imbuir seus ataques com poder divino. Uma vez em cada um de seus turnos, quando você acertar uma criatura com um ataque com arma, você pode fazer o ataque causar 1d8 de dano radiante extra ao alvo. Quando alcançar o 14º nível, o dano extra aumenta para 2d8. CURA SUPREMA A partir do 17º nível, quando você jogaria normalmente um ou mais dados para recuperar pontos de vida com uma magia, você usa o maior resultado possível nos dados. Por exemplo, ao invés de recuperar 2d6 pontos de vida, você recupera 12."
            },
            new Arquetipo
            {
                IdArquetipo = 19,
                Nome = "Círculo da Terra",
                HabilidadeArquetipo = "O Círculo da Terra é constituído por místicos e sábios que salvaguardam conhecimento e ritos antigos através de uma vasta tradição oral. Esses druidas se encontram em círculos sagrados de árvores ou monólitos para sussurrar segredos primordiais em Druídico. Os membros mais sábios do círculo presidem como os sacerdotes-dirigentes de comunidades que creem na Crença Antiga, e servem como conselheiros para os governantes desses povos. Como membro desse círculo, sua magia é influenciada pela terra onde você é iniciado nos ritos misteriosos do círculo. TRUQUE ADICIONAL Quando você escolhe esse círculo no 2° nível, você aprende um truque de druida adicional, à sua escolha. RECUPERAÇÃO NATURAL A partir do 2° nível, você pode recuperar parte da sua energia mágica parando para fazer uma meditação e comunhão com a natureza. Durante um descanso curto, você escolhe espaços de magia gastos para recuperar. O espaço de magia pode ter um nível combinado igual ou menor que metade do seu nível de druida (arredondado para baixo) e, nenhum dos espaços pode ser de uma magia de 6° nível ou superior. Você não pode usar essa característica novamente até terminar um descanso longo. Por exemplo, quando você for um druida de 4° nível, você pode recuperar até dois níveis em espaços de magia. Você pode recuperar, tanto uma magia de 2° nível, quanto duas magias de 1° nível. MAGIAS DE CÍRCULO Sua conexão mística com a terra infunde você com a habilidade de conjurar certas magias. No 3°, 5°, 7° e 9° nível, você ganha acesso a magias de círculo ligadas ao terreno em que você se tornou druida. Escolha o terreno – ártico, costa, deserto, floresta, montanha, pântano, planície ou subterrâneo – e consulte a lista de magias associada. Uma vez que você tenha acesso a uma magia de círculo, você sempre poderá prepará-la e ela não conta no número de magias que você pode preparar a cada dia. Se você tiver acesso a uma magia que não aparece na lista de magias de druida, a magia, no entanto, será uma magia de druida para você. ÁRTICO Nível de Druida Magias de Círculo 3° imobilizar pessoa, crescer espinho 5° nevasca, lentidão 7° movimentação livre, tempestade de gelo 9° comunhão com a natureza, cone de frio COSTA Nível de Druida Magias 3° passo nebuloso, reflexos 5° andar na água, respirar água 7° movimentação livre, controlar água 9° vidência, conjurar elemental DESERTO Nível de Druida Magias 3° nublar, silêncio 5° criar alimentos, proteção contra energia 7° praga, terreno alucinógeno 9° muralha de pedra, praga de insetos FLORESTA Nível de Druida Magias 3° patas de aranha, pele de árvore 5° convocar relâmpagos, crescer plantas 7° adivinhação, movimentação livre 9° comunhão com a natureza, passo de árvore MONTANHA Nível de Druida Magias 3° crescer espinho, patas de aranha 5° mesclar-se às rochas, relâmpago 7° moldar rochas, pele de pedra 9° criar passagem, muralha de pedra PÂNTANO Nível de Druida Magias 3° escuridão, flecha ácida 5° andar na água, névoa fétida 7° localizar criatura, movimentação livre 9° vidência, praga de insetos PLANÍCIE Nível de Druida Magias 3° invisibilidade, passos sem pegadas 5° luz do dia, velocidade 7° adivinhação, movimentação livre 9° praga de insetos, sonho SUBTERRÂNEO Nível de Druida Magias 3° patas de aranha, teia 5° forma gasosa, névoa fétida 7° invisibilidade maior, moldar rochas 9° praga de insetos, névoa mortal 76 CAMINHO DA FLORESTA A partir do 6° nível, mover-se através de terreno difícil não-mágico não te custará nenhum movimento extra. Você também pode passar através de plantas não-mágicas sem ser atrasado por elas e sem sofrer dano delas se elas tiverem espinhos, espinhas ou perigos similares. Além disso, você tem vantagem em testes de resistência contra plantas criadas magicamente ou manipuladas para impedir movimentação, como as criadas pela magia constrição. PROTEÇÃO NATURAL Quando você atingir o 10° nível, você não pode ser enfeitiçado ou amedrontado por elementais ou fadas e você se torna imune a venenos e doenças. SANTUÁRIO NATURAL A partir do 14° nível, as criaturas do mundo natural sentem sua ligação com a natureza e hesitarão em atacar você. Quando uma besta ou plantar atacar você, essa criatura deverá fazer um teste de resistência de Sabedoria contra uma CD igual a das suas magias de druida. Em uma falha, a criatura deve escolher um alvo diferente ou o ataque erra automaticamente. Em um sucesso, a criatura se torna imune a esse efeito por 24 horas. A criatura está ciente deste efeito antes de resolver atacar você."
            },
            new Arquetipo
            {
                IdArquetipo = 20,
                Nome = "Círculo da Lua",
                HabilidadeArquetipo = "Os druidas do Círculo da Lua são ferrenhos guardiões na natureza. Sua ordem se reuni nas noites de lua cheia para partilhar notícias e trocar informações. Eles assombram as partes mais profundas das florestas, onde eles podia ir por semanas a fio antes de cruzar o caminho de outro humanoide e, muito menos outro druida. Tão mutável quanto a lua, um druida desse círculo poderia espreitar como um grande felino, voar sobre a copa das árvores como uma águia no dia seguinte e mergulhar pela vegetação rasteira como um urso para expulsar um monstro invasor. A selvageria está no sangue do druida. FORMA SELVAGEM DE COMBATE Quando você escolhe esse círculo, no 2° nível, você recebe a habilidade de usar sua Forma Selvagem no seu turno com uma ação bônus, ao invés de com uma ação. Além disso, enquanto você estiver transformando pela sua Forma Selvagem, você pode usar uma ação bônus para gastar uma espaço de magia e ganhar 1d8 pontos de vida por nível do espaço de magia gasto. FORMAS DE CÍRCULO Os ritos do seu círculo garantem a você a habilidade de se transformar em formas animais mais poderosas. A partir do 2° nível, você pode usar sua Forma Selvagem para se transformar em uma besta com nível de desafio até 1 (você ignora a coluna ND Max da tabela Formas de Besta, mas ainda deve acatar as limitações descritas lá). A partir do 6° nível, você pode se transformar em uma besta com nível de desafio tão alto quanto seu nível de druida dividido por 3, arredondado para baixo. ATAQUE PRIMORDIAL A partir do 6° nível, seus ataques na forma de besta contam como mágicos com os propósitos de ultrapassar resistência e imunidade a ataques e danos não-mágicos. FORMA SELVAGEM DE ELEMENTAL No 10° nível, você pode gastar dois usos da sua Forma Selvagem, ao mesmo tempo, para se transformar em um elemental da água, elemental do ar, elemental do fogo ou elemental da terra. MIL FORMAS No 14° nível, você aprende a usar magia para alterar sua forma física de formas mais sutis. Você pode conjurar a magia alterar-se à vontade. O DRUIDA E OS DEUSES Alguns druidas veneram as próprias forças da natureza, mas, a maioria dos druidas são devotados de uma das muitas divindades da natureza adoradas no multiverso (a lista de deuses encontrada no apêndice B inclui muitos desses deuses). A adoração desses deuses é, muitas vezes, considerada uma tradição mais antiga que as crenças de clérigos e pessoas urbanizadas. De fato, no mundo de Greyhawk, a doutrina druídica é chamada de Crença Antiga, e ela reivindica muitos adoradores dentre os agricultores, silvicultores, pescadores e outros que vivem perto da natureza. Essa tradição inclui a adoração da Natureza como força primordial acima de personificação, mas também engloba a adoração de Beory, a Mãe Oerth, assim como a devoção a Obad-Hai, Ehlonna e Ulaa. Nos mundos de Greyhawk e dos Reinos Esquecidos, os círculos druídicos não estão normalmente conectados a fé de uma única divindade da natureza. Cada círculo dos Reinos Esquecidos, por exemplo, pode incluir druidas que reverenciam Silvanus, Mielikki, Eldath, Chauntea ou, até mesmo os ferozes Deuses da Fúria: Talos, Malar, Auril e Umberlee. Esses deuses da natureza são, muitas vezes, chamados de Primeiro Círculo, o primeiro entre os druidas, e muitos druidas consideram todos (até os mais violentos) como merecedores de veneração. Os druidas de Eberron possuem crenças animistas, completamente desconectados do Soberano Anfitrião, dos Seis Sombrios ou de qualquer outra religião do mundo. Eles acreditam que cada coisa viva e cada fenômeno natural – sol, lua, vento, fogo e o próprio mundo – tem um espirito. Suas magias, portanto, são um meio de se comunicar e de comandar esses espíritos. Diferentes seitas druídicas, no entanto, possuem diferentes filosofias sobre o relacionamento mais adequado com esses espíritos entre si e com as forças da civilização. O Ashbound, por exemplo, acredita que a magia arcana é uma abominação contra a natureza, as Crianças do Inverno veneram as forças da morte e os Guardiões do Portal preservam tradições antigas destinadas a proteger o mundo da incursão de aberrações."
            },
            new Arquetipo
            {
                IdArquetipo = 21,
                Nome = "Linhagem Dracônica",
                HabilidadeArquetipo = "Sua magia inata vem de magia dracônica que foi misturada ao seu sangue ou ao sangue dos seus ancestrais. Geralmente, os feiticeiros com essa origem traçam sua descendência de poderosos feiticeiros da antiguidade que fizeram uma barganha com um dragão ou que tenham um dragão como parente. Algumas dessas linhagens estão bem definidas no mundo, mas a maioria é obscura. Qualquer feiticeiro pode ser o primeiro de uma nova linhagem, como resultado de um pacto ou de outra circunstância excepcional. ANCESTRAL DRACÔNICO No 1° nível, você escolhe um tipo de dragão como seu ancestral. O tipo de dano associado a cada dragão será usado por características que você ganhará posteriormente. ANCESTRAL DRACÔNICO Dragão Tipo de Dano Azul Elétrico Branco Frio Bronze Elétrico Cobre Acido Latão Fogo Negro Acido Ouro Fogo Prata Frio Verde Veneno Vermelho Fogo Você pode falar, ler e escrever em Dracônico. Além disso, sempre que você fizer um teste de Carisma quando estiver interagindo com dragões, seu bônus de proficiência será dobrado se ele se aplicar a esse teste. RESILIÊNCIA DRACÔNICA A medida que a magia flui pelo seu corpo, ela faz com que os traços físicos do seu ancestral dracônico surjam. No 1° nível, seu máximo de pontos de vida aumenta em 1 e aumenta em mais 1 sempre que você ganhar um nível na classe. Além disso, partes da sua pele são cobertas com minúsculas escamas lustrosas de dragão. Quando você não estiver utilizando armadura, sua CA será igual a 13 + seu modificador de Destreza. AFINIDADE ELEMENTAL A partir do 6° nível, quando você conjurar uma magia que cause dano do tipo associado ao seu ancestral dracônico, adicione seu modificador de Carisma ao dano. Ao mesmo tempo, você pode gastar 1 ponto de feitiçaria para ganhar resistência a esse tipo de dano por 1 hora. O bônus de dano se aplica a uma única rolagem de dano da magia, não à diversas rolagens. 81 ASAS DE DRAGÃO No 14° nível, você adquire a habilidade de brotar um par de asas de dragão das suas costas, ganhando deslocamento de voo igual ao seu deslocamento atual. Você pode criar essas asas com uma ação bônus, no seu turno. Elas duram até que você as dissipe, com uma ação bônus no seu turno. Você não pode manifestar suas asas quando estiver vestindo uma armadura, a não ser que a armadura seja feita para acomodá-las, e roupas que não forem feitas para se acomodar às suas asas devem ser destruídas quando você manifestá-las. PRESENÇA DRACÔNICA A partir do 18° nível, você pode canalizar a assustadora presença do seu ancestral dracônico, fazendo com que aqueles que o rodeiam fiquem impressionados ou amedrontados. Com uma ação, você pode gastar 5 pontos de feitiçaria para recorrer a esse poder e exalar uma aura de admiração ou medo (à sua escolha) a uma distância de 18 metros. Por 1 minuto ou até você perder sua concentração (como se você tivesse conjurado uma magia de concentração), cada criatura hostil que começar seu turno nessa aura, deve ser bem sucedido num teste de resistência de Sabedoria ou ficará enfeitiçada (se você escolheu admiração) ou amedrontada (se você escolheu medo) até a aura terminar. Uma criatura que seja bem sucedida no teste de resistência ficará imune a sua aura por 24 horas. "
            },
            new Arquetipo
            {
                IdArquetipo = 22,
                Nome = "Magia Selvagem",
                HabilidadeArquetipo = "Sua magia inata vem das forças selvagens do caos que constituem a base da ordem da criação. Você deve ter sido exposto a algum tipo de magia bruta, talvez de um portal planar que levava ao Limbo, a Planos Elementais ou ao misterioso Reino Distante. Talvez você tenha sido abençoado por uma poderosa criatura feérica ou marcado por um corruptor. Ou sua magia pode ser uma casualidade do seu nascimento, sem qualquer razão aparente. No entanto, ela existe, essa magia caótica fervilha dentro de você, esperando por qualquer brecha. SURTO DE MAGIA SELVAGEM A partir do momento que você escolhe essa origem, no 1° nível, sua conjuração pode liberar surtos de magia selvagem. Imediatamente após você conjurar uma magia de feiticeiro de 1° nível ou superior, o Mestre pode solicitar que você role um d20. Se você rolar um 1, role na tabela Surto de Magia Selvagem para criar um efeito mágico aleatório. Um surto só pode ocorrer uma vez por turno. Se o efeito de um surto for uma magia, ela é muito selvagem para ser afetada por Metamagia. Se ela normalmente exige concentração, nesse caso não será necessário; a magia permanece por sua duração total. MARÉS DE CAOS A partir do 1° nível, você pode manipular as forças do acaso e do caos para ganhar vantagem em uma jogada de ataque, teste de habilidade ou teste de resistência. Quando o fizer, você deve finalizar um descanso longo antes de poder usar essa característica novamente. A qualquer momento, antes de recuperar o uso dessa característica, o Mestre pode rolar na tabela Surto de Magia Selvagem, imediatamente após você conjurar uma magia de feiticeiro de 1° nível ou superior. Após isso, você recupera o uso dessa característica. DOBRAR A SORTE A partir do 6° nível, você adquire a habilidade de mudar o destino usando sua magia selvagem. Quando outra criatura que você possa ver realizar uma jogada de ataque, um teste de habilidade ou um teste de resistência, você pode usar sua reação para gastar 2 pontos de feitiçaria para rolar 1d4 e aplicar o número rolado como um bônus ou uma penalidade (à sua escolha) na jogada da criatura. Você pode fazer isso depois da criatura fazer a jogada, mas antes do efeito ocorrer. CAOS CONTROLADO No 14° nível, você ganha um controle modico sobre seus surtos de magia selvagem. Sempre que você rolar a tabela Surto de Magia Selvagem, você pode rolar duas vezes e usar qualquer resultado. BOMBARDEIO DE MAGIA A partir do 18° nível, a energia nociva das suas magias se intensifica. Quando você rolar o dano de uma magia e rolar o maior dano possível em qualquer dado, escolha um desses dados, role ele novamente e adicione o valor rolado ao dano. Você pode usar essa característica apenas uma vez por rodada."
            },
            new Arquetipo
            {
                IdArquetipo = 23,
                Nome = "Campeão",
                HabilidadeArquetipo = "O arquétipo Campeão foca no desenvolvimento da pura força física acompanhada por uma perfeição mortal. Aqueles que trilham o caminho desse arquétipo combinam rigorosos treinamentos com excelência física para desferir golpes devastadores. CRÍTICO APRIMORADO A partir do 3º nível, seus ataques com armas adquirem uma margem de acerto crítico de 19 a 20 nas jogadas de ataque. ATLETISMO EXTRAORDINÁRIO A partir do 7º nível, você adiciona metade de seu bônus de proficiência (arredondado para cima) em qualquer teste de Força, Destreza ou Constituição que você já não aplique seu bônus de proficiência. Além disso, quando você fizer um salto longo com corrida, o alcance em metros que poderá saltar aumenta em 0,3 vezes o seu modificador de Força. 86 ESTILO DE LUTA ADICIONAL No 10º nível, você pode escolher um segundo Estilo de Combate da sua característica de classe. CRÍTICO SUPERIOR A partir do 15º nível, seus ataques com armas adquirem uma margem de acerto crítico de 18 a 20 nas jogadas de ataque. SOBREVIVENTE No 18º nível, você alcança o topo da resiliência em batalha. No começo de cada um de seus turnos, você recupera uma quantidade de pontos de vida igual a 5 + seu modificador de Constituição se não estiver com mais que metade de seus pontos de vida. Você não recebe esse benefício se estiver com 0 pontos de vida. "
            },
            new Arquetipo
            {
                IdArquetipo = 24,
                Nome = "Cavaleiro Arcano",
                HabilidadeArquetipo = "O arquétipo de Cavaleiro Arcano combina a maestria marcial comum a todos os guerreiros, com um cuidadoso estudo de magia. Os cavaleiros arcanos usam técnicas mágicas similares as praticadas pelos magos. Eles focam seu estudo em duas das oito escolas: abjuração e evocação. As magia de abjuração concedem proteção adicional em batalha ao Cavaleiro Arcano, e as magias de evocação causam dano a vários oponentes de uma vez, estendendo o alcance do guerreiro em combate. Esses cavaleiros aprendem, comparativamente, um pequeno número de magias, guardando-as na memória ao invés de mantê-las em um grimório. CONJURAÇÃO Quando você alcançar o 3° nível, você amplia o seu poderio marcial com a habilidade de conjurar magias. Veja o capítulo 10 para as regras gerais de conjuração e o capítulo 11 para a lista de magias de mago. Truques. Você aprende dois truques, à sua escolha, da lista de magias de mago. Você aprende um truque de mago adicional, à sua escolha, no 10° nível. Espaços de Magia. A tabela Conjuração de Cavaleiro Arcano mostra quantos espaços de magia de 1° nível e superiores você possui disponíveis para conjuração. Para conjurar uma dessas magias, você deve gastar uma espaço de magia do nível da magia ou superior. Você recobra todos os espaços de magia gastos quando você completa um descanso longo. Por exemplo, se você quiser conjurar a magia de 1° nível escudo arcano e você tiver um espaço de magia de 1° nível e um de 2° nível disponíveis, você poderá conjurar escudo arcano usando qualquer dos dois espaços. Magias Conhecidas de 1° Nível e Superiores. Você conhece três magias de 1° nível, à sua escolha, as quais duas delas você deve escolher das magias de abjuração e evocação da lista de magias de mago. A coluna Magias Conhecidas na tabela Conjuração do Cavaleiro Arcano mostra quando você aprende mais magias de mago, de 1° nível ou superior. Cada uma dessas magias deve ser uma magia de abjuração ou evocação, à sua escolha, de um nível a que você tenha acesso, como mostrado na tabela. Por exemplo, quando você alcança o 7° nível da classe, você pode aprender uma nova magia de 1° ou 2° nível. As magias que você aprende no 8°, 14° e 20° nível podem vir de qualquer escola de magia. CONJURAÇÃO DE CAVALEIRO ARCANO Nível de Guerreiro Truques Conhecidos Magias Conhecidas Espaços de Magia por Nível 1° 2° 3° 4° 3° 2 3 2 – – – 4° 2 4 3 – – – 5° 2 4 3 – – – 6° 2 4 3 – – – 7° 2 5 4 2 – – 8° 2 6 4 2 – – 9° 2 6 4 2 – – 10° 3 7 4 3 – – 11° 3 8 4 3 – – 12° 3 8 4 3 – – 13° 3 9 4 3 2 – 14° 3 10 4 3 2 – 15° 3 10 4 3 2 – 16° 3 11 4 3 3 – 17° 3 11 4 3 3 – 18° 3 11 4 3 3 – 19° 3 12 4 3 3 1 20° 3 13 4 3 3 1 Além disso, quando você adquire um nível nessa classe, você pode escolher uma magia de mago que você conheça e substituí-la por outra magia da lista de magias de mago, que também deve ser de um nível ao qual você tenha espaços de magia e deve ser uma magia de abjuração ou evocação, exceto as magias substituídas no 8°, 14° e 20º nível. Habilidade de Conjuração. Sua habilidade de conjuração é Inteligência para suas magias de mago, portanto, você usa sua Inteligência sempre que alguma magia se referir à sua habilidade de conjurar magias. Além disso, você usa o seu modificador de Inteligência para definir a CD dos testes de resistência para as magias de mago que você conjura e quando você realiza uma jogada de ataque com uma magia. CD para suas magias = 8 + bônus de proficiência + seu modificador de Inteligência Modificador de ataque de magia = seu bônus de proficiência + seu modificador de Inteligência VÍNCULO COM ARMA No 3° nível, você aprende um ritual que cria um vínculo mágico entre você e uma arma. Você realiza esse ritual no curso de 1 hora, que pode ser realizada durante um descanso curto. A arma deve estar ao seu alcance ao decorrer do ritual, ao concluí-lo, você toca a arma e forja o elo. Uma vez que você tenha vinculado uma arma a você, você não pode ser desarmado dessa arma, a menos que você esteja incapacitado. Se ela estiver no mesmo plano de existência, você pode invocar essa arma com uma ação bônus, no seu turno, fazendo-a se teletransportar instantaneamente para a sua mão. Você pode ter até duas armas vinculadas, mas só pode invocar uma por vez com sua ação bônus. Se você quiser criar um elo com uma terceira arma, você deve quebrar o vínculo com um das outras duas. MAGIA DE GUERRA A partir do 7° nível, quando você usar sua ação para conjurar um truque, você pode realizar um ataque com arma, com uma ação bônus. 87 GOLPE MÍSTICO No 10° nível, você aprende como fazer com que os seus golpes com arma penetrem a resistência de uma criatura às suas magias. Quando você atingir uma criatura com um ataque com arma, aquela criatura terá desvantagem no próximo teste de resistência que ela fizer contra uma magia que você conjurar antes do final do seu próximo turno. INVESTIDA ARCANA No 15° nível, você ganha a capacidade de se teletransportar até 9 metros para um espaço desocupado que você possa ver, quando você usar seu Surto de Ação. Você pode se teletransportar antes ou depois da ação adicional. MAGIA DE GUERRA APRIMORADA A partir do 18° nível, quando você usar sua ação para conjurar uma magia, você pode realizar um ataque com arma, com uma ação bônus. "
            },
            new Arquetipo
            {
                IdArquetipo = 25,
                Nome = "Mestre de Batalha",
                HabilidadeArquetipo = "Aqueles que emulam o arquétipo de Mestre de Batalhaempregam técnicas marciais passadas de geração emgeração. Para um Mestre de Batalha, o combate é umcampo acadêmico, as vezes, incluindo assuntos além dabatalha, como forjaria e caligrafia. Nem todo guerreiroabsorve as lições de história, teoria e arte que sãorefletidas no arquétipo de Mestre de Batalha, masaqueles que conseguem, tornam-se guerreiros bemsupridos de grande perícia e conhecimento. SUPERIORIDADE EM COMBATEQuando você escolhe esse arquétipo, no 3° nível, vocêaprende manobras que são abastecidas com dadosespeciais chamados dados de superioridade.Manobras. Você aprende três manobras, à suaescolha, que são detalhadas em “Manobras”, a seguir.Muitas manobras aprimoram um ataque de váriasformas. Você só pode usar uma manobra por ataque.Você aprende duas manobras adicionais, à suaescolha, no 7°, 10° e 15° nível. A cada vez que vocêaprende uma nova manobra, você pode substituir umamanobra conhecida por uma diferente.Dados de Superioridade. Você tem quatro dados desuperioridade, que são d8s. Um dado de superioridade égasto quando você usa-o. Você recupera todos os dados desuperioridade gastos quando terminar um descanso curtoou longo.Você adquire outro dado de superioridade no 7° nível emais um no 15° nível.Teste de Resistência. Algumas das suas manobrasexigem que o alvo realize um teste de resistência contra oefeito da manobra. A CD do teste de resistência écalculada a seguir:CD para suas manobras = 8 + bônus de proficiência +seu modificador de Força ou Destreza (à sua escolha)ESTUDIOSO DAGUERRANo 3° nível, você ganha proficiência com um tipo deferramenta de artesão, à sua escolha.88CONHEÇA SEU INIMIGOA partir do 7° nível, se você gastar, pelo menos, 1 minutoobservando ou interagindo com outra criatura fora decombate, você pode aprender certas informações sobre ascapacidades dela comparadas as suas. O Mestre conta avocê se a criatura é igual, superior ou inferior a você arespeito de duas das seguintes características, à suaescolha: Valor de Força Valor de Destreza Valor de Constituição Classe de Armadura Pontos de Vida atuais Nível total de classe (se possuir) Níveis da classe guerreiro (se possuir)SUPERIORIDADE EM COMBATE APRIMORADANo 10° nível, seus dados de superioridade se tornam d10s.No 18° nível, eles se tornam d12s.IMPLACÁVELNo 15° nível, quando você rolar iniciativa e não tivernenhum dado de superioridade restante, você recuperaum dado de superioridade.MANOBRASAs manobras são apresentadas em ordem alfabética.Aparar. Quando outra criatura causar dano a vocêcom um ataque corpo-a-corpo, você pode usar sua reação egastar um dado de superioridade para reduzir o dano pelonúmero rolado no dado de superioridade + seumodificador de Destreza.Ataque Ameaçador. Quando você atingir umacriatura com um ataque com arma, você pode gastar umdado de superioridade para tentar amedrontar o alvo.Você adiciona seu dado de superioridade a jogada de danodo ataque e o alvo deve realizar um teste de resistência deSabedoria. Se falhar, ele ficará com medo de você até ofinal do seu próximo turno.Ataque de Encontrão. Quando você atingir umacriatura com um ataque com arma, você pode gastar umdado de superioridade para tentar empurrar o alvo paratrás. Você adiciona seu dado de superioridade a jogada dedano do ataque e, se o alvo for Grande ou menor, ele deverealizar um teste de resistência de Força. Se falhar, vocêempurra o alvo para até 4,5 metros de você.Ataque de Finta. Você pode gastar um dado desuperioridade e usar uma ação bônus, no seu turno, parafintar, escolhendo uma criatura a 1,5 metro de você comoalvo. Você tem vantagem na sua próxima jogada deataque contra essa criatura, nesse turno. Se o ataqueatingir, você adiciona seu dado de superioridade ao danodo ataque.Ataque de Manobra. Quando você atingir umacriatura com um ataque com arma, você pode gastar umdado de superioridade para tentar manobrar um de seuscompanheiros para uma posição mais vantajosa. Vocêadiciona seu dado de superioridade a jogada de dano doataque e escolhe uma criatura amigável que possa ver ououvir você. Aquela criatura pode usar sua reação para semover até metade do seu deslocamento, sem provocarataques de oportunidade do alvo do seu ataque.Ataque de Precisão. Quando você realizar umajogada de ataque com arma contra uma criatura, vocêpode gastar um dado de superioridade para adicioná-lo ajogada. Você pode usar essa manobra antes ou depois derealizar a jogada de ataque, mas deve usá-la antes dequalquer efeito do ataque ser aplicado.Ataque Desarmante. Quando você atingir umacriatura com um ataque com arma, você pode gastar umdado de superioridade para tentar desarmar o alvo,forçando-o a derrubar um item, à sua escolha, que eleesteja empunhando. Você adiciona o dado desuperioridade a jogada de dano do ataque e o alvo deverealizar um teste de resistência de Força. Se fracassar,ele derrubará o objeto escolhido. O objeto cai aos pés dele.Ataque Estendido. Quando você atingir uma criaturacom um ataque corpo-a-corpo com arma, você pode gastarum dado de superioridade para aumentar o alcance doseu ataque em 1,5 metro. Se você atingir, você adiciona oseu dado de superioridade ao dano causado pelo ataque.Ataque Provocante. Quando você atingir umacriatura com um ataque com arma, você pode gastar umdado de superioridade para tentar incitar a alvo a atacarvocê. Você adiciona seu dado de superioridade a jogada dedano do ataque e o alvo deve realizar um teste deresistência de Sabedoria. Se falhar, o alvo terádesvantagem em todas as jogadas de ataque contra alvosdiferentes de você, até o fim do seu próximo turno.Ataque Trespassante. Quando você atingir umacriatura com um ataque corpo-a-corpo com arma, vocêpode gastar um dado de superioridade para tentar causardano a outra criatura com o mesmo ataque. Escolha umacriatura a 1,5 metro do alvo original e que esteja no seualcance. Se a jogada de ataque original atingiria asegunda criatura, ela sofre dano igual ao número roladono dado de superioridade. O dano é do mesmo tipo que ocausado pelo ataque original.Contra-Atacar. Quando uma criatura atacar vocêcom um ataque corpo-a-corpo e errar, você pode usar suareação e gastar um dado de superioridade para realizarum ataque corpo-a-corpo com arma contra essa criatura.Se você atingir, você adiciona seu dado de superioridade ajogada de dano do ataque.Derrubar. Quando você atingir uma criatura com umataque com arma, você pode gastar um dado desuperioridade para tentar derrubar o alvo no chão. Vocêadiciona seu dado de superioridade a jogada de dano doataque e, se o alvo for Grande ou menor, ele deve realizarum teste de resistência de Força. Se falhar, o alvo ficarácaído no chão.Golpe Distrativo. Quando você atingir uma criaturacom um ataque com arma, você pode gastar um dado desuperioridade para tentar distrair a criatura, abrindouma brecha para um de seus aliados. Você adiciona seudado de superioridade a jogada de dano do ataque. Apróxima jogada de ataque realizada contra o alvo por umacriatura diferente de você, tem vantagem, se o ataque forrealizado antes do começo do seu próximo turno.Golpe do Comandante. Quando você realiza a açãode Ataque, no seu turno, você pode desistir de um dosseus ataques e usar uma ação bônus para direcionar oataque de um dos seus companheiros. Quando você fazisso, escolha uma criatura amigável que possa ver ououvir você e gaste um dado de superioridade. Essacriatura pode, imediatamente, usar sua reação pararealizar um ataque com arma, adicionando seu dado desuperioridade a jogada de dano do ataque.Inspirar. No seu turno, você pode usar uma açãobônus e gastar um dado de superioridade para reforçar adeterminação dos seus companheiros. Quando o fizer,escolha uma criatura amigável que possa ver ou ouvirvocê. Essa criatura ganha uma quantidade de pontos devida temporários igual a sua rolagem de dado desuperioridade + seu modificador de Carisma.Passo Evasivo. Quando você se mover, você podegastar um dado de superioridade, role o dado e adicione onúmero rolado a sua CA até você terminar seudeslocamento. "
            },
            new Arquetipo
            {
                IdArquetipo = 26,
                Nome = "Assassino",
                HabilidadeArquetipo = "Você focou seu treinamento na macabra arte da morte. Aqueles que devotam-se a esse arquétipo são diversos: assassinos de aluguel, espiões, caçadores de recompensa e, até mesmo, padres especialmente treinados em exterminar os inimigos das suas divindades. Subterfúgio, veneno e disfarces ajudam você a eliminar seus oponentes com eficiência mortífera. PROFICIÊNCIA ADICIONAL Quando você escolhe esse arquétipo, no 3° nível, você ganha proficiência com kit de disfarce e kit de venenos. ASSASSINAR A partir do 3° nível, você fica mais mortal quando pega seus oponentes desprevenidos. Você tem vantagem nas jogadas de ataque contra qualquer criatura que ainda não tenha chegado ao turno dela no combate. Além disso, qualquer ataque que você fizer contra essa criatura que está surpresa, será um ataque crítico. ESPECIALIZAÇÃO EM INFILTRAÇÃO A partir do 9° nível, você pode infalivelmente, criar identidades falsas para si mesmo. Você deve gastar sete dias e 25 po para estabelecer o histórico, profissão e filiações para uma identidade. Você não pode estabelecer uma identidade que pertença a alguém. Por exemplo, você deveria adquirir roupas apropriadas, cartas de introdução e um certificado, aparentemente oficial, para estabelecerse como um membro da casa de comércio de uma cidade remota, assim, você poderia introduzir-se na companhia de outros comerciantes abastados. Posteriormente, se você adotar a nova identidade como disfarce, outras criaturas acreditarão que você é aquela pessoa, até terem algum motivo obvio para pensarem o contrário. IMPOSTOR No 13° nível, você adquire a habilidade de imitar a fala, escrita e comportamento de outra pessoa, infalivelmente. Você deve gastar pelo menos três horas estudando esses três componentes do comportamento de uma pessoa, ouvindo sua articulação, examinando sua escrita e observando seus maneirismos. Seu ardil é imperceptível para um observador casual. Se uma criatura desconfiada suspeitar que algo está errado, você tem vantagem em qualquer teste de Carisma (Enganação) que você fizer para evitar ser detectado. GOLPE LETAL No 17° nível, você se torna um mestre da morte instantânea. Quando você atacar e atingir uma criatura que esteja surpresa, ela deve realizar um teste de resistência de Constituição (CD 8 + seu modificador de Destreza + seu bônus de proficiência). Se ela falhar, dobre o dano do seu ataque contra a criatura."
            },
            new Arquetipo
            {
                IdArquetipo = 27,
                Nome = "Ladrão",
                HabilidadeArquetipo = "Você aprimorou suas habilidades na arte do furto de pequenos itens. Gatunos, bandidos, batedores de carteira e outros criminosos geralmente seguem esse arquétipo, mas também aqueles ladinos que preferem se ver como caçadores de tesouro profissionais, exploradores de masmorras e investigadores. Além de aprimorar sua agilidade e furtividade, você aprende perícias úteis para desbravar ruínas antigas, ler idiomas incomuns e usar itens mágicos que normalmente não poderia. MÃOS RÁPIDAS A partir do 3º nível, você pode usar a sua ação bônus concedida pela Ação Ardilosa para fazer um teste de Destreza (Prestidigitação), usar suas ferramentas de ladrão para desarmar uma armadilha ou abrir uma fechadura, ou realizar a ação de Usar um Objeto. ANDARILHO DE TELHADOS No 3º nível, você adquire a habilidade de escalar mais rápido que o normal. Escalar agora não possui custo adicional de movimento para você. Além disso, quando você fizer um salto com corrida, o alcance que pode saltar aumenta um número de metros igual a 0,3 vezes o seu modificador de Destreza. FURTIVIDADE SUPREMA A partir do 9º nível, você tem vantagem no teste de Destreza (Furtividade) se você não mover-se mais do que a metade de seu deslocamento em um turno. USAR INSTRUMENTO MÁGICO No 13º nível, você aprende o suficiente sobre como a magia funciona e pode improvisar o uso de itens que nem mesmo foram destinados a você. Você ignora todos os requisitos de classes, raças e níveis para uso de qualquer item mágico. REFLEXOS DE LADRÃO Quando atinge o 17º nível, você se torna adepto em fazer emboscadas e fugas rápidas de situações perigosas. Você pode realizar dois turnos durante o primeiro turno de cada combate. Você realiza seu primeiro turno na sua iniciativa e o segundo na ordem de sua iniciativa menos 10. Você não pode usar essa característica quando está surpreso. "
            },
            new Arquetipo
            {
                IdArquetipo = 28,
                Nome = "Trapaceiro Arcano",
                HabilidadeArquetipo = "Alguns ladinos aprimoram suas finas perícias de furtividade e agilidade com magia, aprendendo truques de encantamento e ilusão. Esses ladinos incluem não somente batedores de carteira e assaltantes, mas também 93 trapaceiros, enganadores e um número significativo de aventureiros. CONJURAÇÃO Quando você alcançar o 3° nível, você adquire a habilidade de conjurar magias. Veja o capítulo 10 para as regras gerais de conjuração e o capítulo 11 para a lista de magias de mago. Truques. Você aprende três truques: mãos mágicas e outros dois truques, à sua escolha, da lista de magias de mago. Você aprende um truque de mago adicional, à sua escolha, no 10° nível. Espaços de Magia. A tabela Conjuração de Trapaceiro Arcano mostra quantos espaços de magia de 1° nível e superiores você possui disponíveis para conjuração. Para conjurar uma dessas magias, você deve gastar uma espaço de magia do nível da magia ou superior. Você recobra todos os espaços de magia gastos quando você completa um descanso longo. Por exemplo, se você quiser conjurar a magia de 1° nível enfeitiçar pessoa e você tiver um espaço de magia de 1° nível e um de 2° nível disponíveis, você poderá conjurar enfeitiçar pessoa usando qualquer dos dois espaços. Magias Conhecidas de 1° Nível e Superiores. Você conhece três magias de 1° nível, à sua escolha, as quais duas delas você deve escolher das magias de encantamento e ilusão da lista de magias de mago. A coluna Magias Conhecidas na tabela Conjuração do Trapaceiro Arcano mostra quando você aprende mais magias de mago, de 1° nível ou superior. Cada uma dessas magias deve ser uma magia de encantamento ou ilusão, à sua escolha, de um nível a que você tenha acesso, como mostrado na tabela. Por exemplo, quando você alcança o 7° nível da classe, você pode aprender uma nova magia de 1° ou 2° nível. As magias que você aprende no 8°, 14° e 20° nível podem vir de qualquer escola de magia. Além disso, quando você adquire um nível nessa classe, você pode escolher uma magia de mago que você conheça e substituí-la por outra magia da lista de magias de mago, que também deve ser de um nível ao qual você tenha espaços de magia e deve ser uma magia de encantamento ou ilusão, exceto as magias substituídas no 8°, 14° e 20º nível. CONJURAÇÃO DE TRAPACEIRO ARCANO Nível de Ladino Truques Conhecidos Magias Conhecidas Espaços de Magia por Nível 1° 2° 3° 4° 3° 3 3 2 – – – 4° 3 4 3 – – – 5° 3 4 3 – – – 6° 3 4 3 – – – 7° 3 5 4 2 – – 8° 3 6 4 2 – – 9° 3 6 4 2 – – 10° 4 7 4 3 – – 11° 4 8 4 3 – – 12° 4 8 4 3 – – 13° 4 9 4 3 2 – 14° 4 10 4 3 2 – 15° 4 10 4 3 2 – 16° 4 11 4 3 3 – 17° 4 11 4 3 3 – 18° 4 11 4 3 3 – 19° 4 12 4 3 3 1 20° 4 13 4 3 3 1 Habilidade de Conjuração. Sua habilidade de conjuração é Inteligência para suas magias de mago, portanto, você usa sua Inteligência sempre que alguma magia se referir à sua habilidade de conjurar magias. Além disso, você usa o seu modificador de Inteligência para definir a CD dos testes de resistência para as magias de mago que você conjura e quando você realiza uma jogada de ataque com uma magia. CD para suas magias = 8 + bônus de proficiência + seu modificador de Inteligência Modificador de ataque de magia = seu bônus de proficiência + seu modificador de Inteligência MÃOS MÁGICAS MALABARISTAS A partir do 3° nível, quando você conjurar mãos mágicas, você pode fazer a mão espectral ficar invisível e poderá realizar as seguintes tarefas adicionais:  Você pode guardar um objeto que a mão estiver segurando em um recipiente vestido ou carregado por outra criatura.  Você pode recuperar um objeto guardado em um recipiente vestido ou carregado por outra criatura.  Você pode usar ferramentas de ladrão para abrir fechaduras ou desarmar armadilhas à distância. Você pode realizar qualquer dessas tarefas sem ser notado por uma criatura se for bem sucedido num teste de Destreza (Prestidigitação) resistido por um teste de Sabedoria (Percepção) da criatura. Além disso, você pode usar a ação bônus concedida por sua Ação Ardilosa para controlar a mão. EMBOSCADA MÁGICA A partir do 9° nível, se você estiver escondido de uma criatura quando conjurar uma magia nela, a criatura terá desvantagem em qualquer teste de resistência que ela fizer contra a magia nesse turno. TRAPACEIRO VERSÁTIL No 13° nível, você ganha a habilidade de distrair alvos com suas mãos mágicas. Com uma ação bônus, no seu turno, você pode designar uma criatura a até 1,5 metro da mão espectral criada por essa magia. Fazer isso, lhe concede vantagem nas jogadas de ataque contra essa criatura até o final do turno. LADRÃO DE MAGIA No 17° nível, você ganha a habilidade de, magicamente, roubar o conhecimento de como conjurar uma magia de outro conjurador. Imediatamente depois de uma criatura conjurar uma magia que tenha você como alvo ou inclua você na sua área de efeito, você pode usar sua reação para forçar a criatura a realizar um teste de resistência com o modificador de habilidade de conjuração dele. A CD é igual a CD das suas magias. Numa falha, você ignora o efeito da magia sobre você e rouba o conhecimento da magia, se ela for de, pelo menos, 1° nível e de um nível que você possa conjurar (não precisa ser uma magia de mago). Pelas próximas 8 horas, você conhece a magia e pode conjurá-la usando seus espaços de magia. A criatura não pode conjurar a magia até que 8 horas tenham se passado. Uma vez que você tenha usado essa característica, você não pode usá-la novamente até ter terminado um descanso longo. "
            },
            new Arquetipo
            {
                IdArquetipo = 29,
                Nome = "Escola de Abjuração",
                HabilidadeArquetipo = "A Escola de Abjuração enfatiza magias que bloqueiam, expulsão ou protegem. Detratores dessa escola dizem que sua tradição trata de contradição, negação, ao invés de asserções positivas. Você compreende, no entanto, que terminar efeitos nocivos, proteger os fracos e banir influências malignas é tudo, menos um vazio filosófico. É uma vocação de orgulho e respeito. Chamados de abjuradores, membros dessa escola são procurados quando espíritos sinistros precisam ser exorcizados, quando locais importantes devem ser guardados contra espionagem mágica e quando portais para outros planos de existência precisam ser selados. ABJURAÇÃO INSTRUÍDA Quando você escolhe essa escola no 2º nível, o ouro e o tempo que você precisa gastar para copiar uma magia da escola de abjuração em seu grimório é reduzido à metade. PROTEÇÃO ARCANA A partir do 2° nível, você pode tecer a magia a sua volta para proteção. Quando você conjura uma magia de abjuração de 1° nível ou superior, você pode, simultaneamente, usar uma vertente do poder da magia para criar uma proteção mágica em si mesmo, que dura até você terminar um descanso longo. A proteção tem pontos de vida iguais ao dobro do seu nível de mago + seu modificador de Inteligência. Sempre que você sofrer dano, a proteção sofrerá o dano no lugar. Se o dano reduzir a proteção a 0 pontos de vida, você sofre qualquer dano remanescente. Quando a proteção estiver com 0 pontos de vida, ela não poderá mais absorver dano, mas a mágica permanece. Toda vez que você conjurar uma magia de abjuração de 1° nível ou superior, a proteção recupera um número de pontos de vida igual ao dobro do nível da magia. Uma vez que você tenha criado a proteção, você não pode criá-la novamente até terminar um descanso longo. PROTEÇÃO PROJETADA A partir do 6° nível, quando uma criatura que você possa ver a até 9 metros sofrer dano, você pode usar sua reação para fazer com que sua Proteção Arcana absorva aquele dano. Se esse dano reduzir a proteção a 0 pontos de vida, a criatura protegida sofrerá qualquer dano remanescente. ABJURAÇÃO APRIMORADA A partir do 10° nível, quando você conjurar uma magia de abjuração que requeira que você realize um teste de habilidade como parte da conjuração da magia (como em contramágica e dissipar magia), você adiciona seu bônus de proficiência a esse teste de habilidade. "
            },
            new Arquetipo
            {
                IdArquetipo = 30,
                Nome = "Escola de Adivinhação",
                HabilidadeArquetipo = "Os conselhos de um adivinho são procurados tanto pela realeza quanto pelos plebeus comuns, por todos que buscam uma compreensão mais clara do passado, presente e futuro. Como um adivinho, você se esforça para separar os véus do espaço, tempo e da consciência, de modo que você possa ver claramente. Você trabalha para dominar magias de discernimento, visão remota, conhecimento sobrenatural e previsão. ADIVINHAÇÃO INSTRUÍDA Quando você escolhe essa escola no 2º nível, o ouro e o tempo que você precisa gastar para copiar uma magia da escola de adivinhação em seu grimório é reduzido à metade. PRODÍGIO Começando no 2° nível, quando você escolhe essa escola, vislumbres do futuro começam a aparecer em sua consciência. Quando você termina um descanso longo, role dois d20s e anote os números rolados. Você pode substituir qualquer jogada de ataque, teste de resistência ou teste de habilidade feito por você ou por outra criatura que você possa ver por uma das rolagens de premunição. Você deve escolher fazer isso antes da rolagem e você pode substituir uma rolagem dessa forma apenas uma vez por rodada. Cada rolagem de premonição pode ser usada apenas uma vez. Quando você termina um descanso longo, você perde qualquer rolagem de premonição que não tenha sido usada. ESPECIALISTA EM ADIVINHAÇÃO A partir do 6° nível, conjurar magias de adivinhação se tornou tão fácil pra você que isso requer apenas uma fração do seu esforço de conjuração. Quando você conjura uma magia de adivinhação de 2° nível ou superior usando um espaço de magia, você recupera um espaço de magia gasto. O espaço de magia que você recupera deve ser de um nível inferior ao da magia conjurada e não pode ser maior que 5° nível. O TERCEIRO OLHO A partir do 10° nível, você pode usar sua ação para aumentar seus poderes de percepção. Quando o fizer, escolha um dos benefícios a seguir, que dura até você ficar incapacitado ou realizar um descanso curto ou longo. Você não pode usar essa característica novamente até ter terminado um descanso longo. Visão no Escuro. Você adquire visão no escuro com alcance de 18 metros, como descrito no capítulo 8. Visão Etérea. Você pode ver no Plano Etéreo com alcance de 18 metros. Compreensão Maior. Você pode ler qualquer idioma. Ver Invisibilidade. Você pode ver criaturas e objetos invisíveis a até 3 metros de você aos quais você tenha linha de visão. PRODÍGIO MAIOR A partir do 14° nível, as visões em seus sonhos se intensificam e pintam um quadro mais preciso na sua mente do que está para acontecer. Você rola três d20s para a sua característica Prodígio, ao invés de dois."
            },
            new Arquetipo
            {
                IdArquetipo = 31,
                Nome = "Escola de Conjuração",
                HabilidadeArquetipo = "Como um conjurador, você prefere magias que produzam objetos e criaturas do nada. Você pode conjurar nuvens esvoaçantes de gás mortal ou invocar criaturas de outros lugares para lutar por você. À medida que seu domínio cresce, você aprende magias de teletransportação e pode se teletransportar por vastas distâncias, até mesmo para outros planos de existência, em um instante. CONJURAÇÃO INSTRUÍDA Quando você escolhe essa escola no 2º nível, o ouro e o tempo que você precisa gastar para copiar uma magia da escola de conjuração em seu grimório é reduzido à metade. CONJURAÇÃO MENOR A partir do 2° nível, quando você escolhe essa escola, você pode usar sua ação para conjurar até um objeto inanimado em sua mão ou no chão, em um espaço desocupado que você possa ver, a até 3 metros de você. Esse objeto não pode ter mais de 90 centímetros de largura nem pesar mais de 5 quilos e sua forma deve ser de um objeto não-mágico que você tenha visto. O objeto é visivelmente mágico, emanando penumbra a 1,5 metro. O objeto desaparece depois de 1 hora, quando você usa essa característica novamente ou se ele sofrer qualquer dano. "
            },
            new Arquetipo
            {
                IdArquetipo = 32,
                Nome = "Escola de Encantamento",
                HabilidadeArquetipo = "Como um membro da Escola de Encantamento, você afiou sua habilidade de entrar magicamente e seduzir outras pessoas e monstros. Alguns encantadores são pacifistas que fascinam os violentos para que larguem suas armas e enfeitiçam os cruéis para mostrar misericórdia. Outros são tiranos que dominam magicamente os involuntários, obrigando-os a servi-lo. A maioria dos encantadores está em algum lugar entre esses extremos. ENCANTAMENTO INSTRUÍDO Quando você escolhe essa escola no 2º nível, o ouro e o tempo que você precisa gastar para copiar uma magia da escola de encantamento em seu grimório é reduzido à metade. OLHAR HIPNOTIZANTE A partir do 2° nível, quando você escolhe essa escola, suas palavras suaves e olhar encantador podem escravizar magicamente outra criatura. Com uma ação, escolha uma criatura que você possa ver a até 1,5 metro. Se o alvo puder ver ou ouvir você, ele deve ser bem sucedido num teste de resistência de Sabedoria contra uma CD igual das suas magias de mago, ou ficará enfeitiçado por você até o final do seu próximo turno. O deslocamento da criatura enfeitiçada cai para 0 e a criatura está incapacitada e visivelmente aturdida. Nos turnos subsequentes, você pode usar sua ação para manter esse efeito, estendendo sua duração até o final do seu próximo turno. No entanto, o efeito termina se você se afastar mais de 1,5 metro da criatura, se a criatura não puder nem ver nem ouvir você ou se a criatura sofrer dano. Assim que o efeito terminar, ou se a criatura for bem sucedida no teste de resistência inicial contra esse efeito, você não poderá usar essa característica nessa criatura novamente até terminar um descanso longo. ENCANTO INSTINTIVO Começando no 6° nível, quando uma criatura que você puder ver a até 9 metros, realizar uma jogada de ataque contra você, você pode usar sua reação para desviar o ataque, contanto que exista outra criatura no alcance do ataque. O atacante deve realizar um teste de resistência de Sabedoria contra uma CD igual das suas magias de mago. Caso falhe, o atacante deve atacar a criatura mais próxima dele, excluindo você ou ele mesmo. Se existirem diversas criaturas próximas, o atacante escolhe qual deseja atacar. Em um sucesso, você não poderá usar essa característica contra o atacante novamente até terminar um descanso longo. Você deve escolher usar essa característica antes de saber se o ataque atingiu ou errou. Criaturas que não podem ser enfeitiçadas são imunes a esse efeito. DIVIDIR ENCANTAMENTO A partir do 10° nível, quando você conjurar uma magia de encantamento de 1° nível ou superior que tenha uma única criatura como alvo, você pode fazer com que ela afete uma segunda criatura. ALTERAR MEMÓRIAS No 14° nível, você ganha a habilidade de tornar uma criatura inconsciente da sua influência mágica sobre ela. Quando você conjura uma magia de encantamento para enfeitiçar uma ou mais criaturas, você pode alterar a compreensão de uma criatura para que ela continue sem saber que está sendo enfeitiçada. Além disso, assim que a magia expirar, você pode usar sua ação para tentar fazer com que a criatura escolhida esqueça parte do tempo que permaneceu enfeitiçada. A criatura deve ser bem sucedida num teste de resistência de Inteligência contra uma CD igual das suas magias de mago ou perderá uma quantidade de horas da sua memória igual a 1 + seu modificador de Carisma (mínimo 1). Você pode fazer com que a criatura esqueça menos tempo e o total de tempo não pode exceder a duração da sua magia de encantamento."
            },
            new Arquetipo
            {
                IdArquetipo = 33,
                Nome = "Escola de Evocação",
                HabilidadeArquetipo = "Você foca seu estudo para criar poderosos efeitos elementais, como um frio cortante, uma chama intensa, um trovão estrondoso, um relâmpago devastador e ácido ardente. Alguns evocadores encontram emprego nas forças militares, servindo como artilharia para explodir fileiras inimigas de longe. Outros usam seu poder espetacular para proteger os fracos, enquanto alguns buscam o ganho próprio como bandidos, aventureiros ou aspirantes de tiranos. EVOCAÇÃO INSTRUÍDA Quando você escolhe essa escola no 2º nível, o ouro e o tempo que você precisa gastar para copiar uma magia da escola de evocação em seu grimório é reduzido à metade. ESCULPIR MAGIAS A partir do 2º nível, você pode criar bolsões de segurança relativa contra os efeitos de suas magias de evocação. Quando você conjurar uma magia de evocação que afeta outras criaturas que você possa ver, você pode escolher um número delas igual a 1 + o nível da magia. As criaturas escolhidas passam automaticamente em seus testes de resistência contra a magia conjurada e elas não sofrem dano se normalmente sofreriam metade em um sucesso no teste de resistência. TRUQUE POTENTE A partir do 6º nível, seus truques de dano afetam até mesmo as criaturas que evitariam a força daquele efeito. Quando uma criatura passa em um teste de resistência de seus truques, ela sofre metade do dano (se existir), mas não sofre nenhum efeito adicional. "
            },
            new Arquetipo
            {
                IdArquetipo = 34,
                Nome = "Escola de Ilusão",
                HabilidadeArquetipo = "Você focou seus estudos em magias que ofuscam os sentidos, confundem a mente e enganam até mesmo os povos mais sábios. Sua mágica é sutil, mas as ilusões criadas pela sua mente afiada fazem o impossível parecer real. Alguns ilusionistas – incluindo muitos magos gnomos – são vigaristas benignos que usam suas magias para entreter. Outros são mestres mais sinistros da enganação, usando suas ilusões para apavorar e iludir os outros para ganhos pessoais. ILUSÃO INSTRUÍDA Quando você escolhe essa escola no 2º nível, o ouro e o tempo que você precisa gastar para copiar uma magia da escola de ilusão em seu grimório é reduzido à metade. ILUSÃO MENOR APRIMORADA A partir do 2° nível, quando você escolhe essa escola, você aprende o truque ilusão menor. Se você já conhece esse truque, você aprende um truque de mago diferente, à sua escolha. O truque não conta no número de truque que você conhece. Quando você conjurar ilusão menor, você pode criar tanto um som quanto uma imagem com uma única conjuração da magia. ILUSÕES MOLDÁVEIS A partir do 6° nível, quando você conjura uma magia de ilusão que tenha duração de 1 minuto ou maior, você pode usar sua ação para mudar a natureza da ilusão (usando os parâmetros normais da magia para a ilusão), considerando que você pode ver a ilusão. EU ILUSÓRIO Começando no 10° nível, você pode criar uma duplicata ilusória de si mesmo em um instante, como uma reação instintiva ao perigo. Quando uma criatura realizar uma jogada de ataque contra você, você pode usar sua reação para interpor a duplicata ilusória entre o atacante e você. O ataque erra você automaticamente, e então, a ilusão se dissipa. Uma vez que você usa essa característica, não pode usá-la novamente até terminar um descanso longo. REALIDADE ILUSÓRIA A partir do 14° nível, você aprendeu o segredo de como tecer magia sombria em suas ilusões para torná-las semirreais. Quando você conjura uma magia de ilusão de 1° nível ou superior, você pode escolher um objeto inanimado e não-mágico que é parte da ilusão e tornar esse objeto real. Você pode fazer isso no seu turno, com uma ação bônus, enquanto a magia estiver em efeito. O objeto permanece real por 1 minuto. Por exemplo, você pode criar uma ilusão de uma ponte sobre um abismo e depois torná-la real tempo suficiente para que seus aliados a atravessem. O objeto não pode causar dano ou qualquer tipo de ferimento direto a ninguém. "
            },
            new Arquetipo
            {
                IdArquetipo = 35,
                Nome = "Escola de Necromancia",
                HabilidadeArquetipo = "A Escola de Necromancia explora as forças cósmicas da vida, morte e morte-vida. À medida que você foca seus estudos nessa tradição, você aprende a manipular a energia que anima todas as coisas vivas. Enquanto progride, você aprende a retirar a força vital de uma criatura enquanto sua magia destrói seu corpo, transformando a energia vital em poder mágico que você pode manipular. A maioria das pessoas veem necromantes como ameaças, ou até mesmo vilões, devido a sua associação intima com a morte. Nem todos os necromantes são malignos, mas as forças que eles manipulam são consideradas tabu por diversas sociedades. NECROMANCIA INSTRUÍDA Quando você escolhe essa escola no 2º nível, o ouro e o tempo que você precisa gastar para copiar uma magia da escola de necromancia em seu grimório é reduzido à metade. COLHEITA SINISTRA A partir do 2° nível, você ganha a habilidade de ceifar a energia vital das criaturas que você mata com suas magias. Uma vez por turno, quando você matar uma ou mais criaturas com uma magia de 1° nível ou superior, você recupera uma quantidade de pontos de vida igual ao dobro do nível da magia ou o triplo do seu nível, se a magia pertencer a Escola de Necromancia. Você não recebe esse benefício por matar constructos ou mortosvivos. "
            },
            new Arquetipo
            {
                IdArquetipo = 36,
                Nome = "Escola de Transmutação",
                HabilidadeArquetipo = "ESCOLA DE TRANSMUTAÇÃO Você é um estudante de magias que modificam energia e matéria. Para você, o mundo não é uma coisa fixa, mas sim eminentemente mutável e você se deleita em ser um agente da mudança. Você empunha a matéria-prima da criação e aprendeu tanto formas físicas quanto qualidades mentais. Sua magia lhe dá as ferramentas para se tornar o ferreiro na forja da realidade. Alguns transmutadores são vigaristas ou brincalhões, transformando pessoas em sapos e transformando cobre em prata por diversão e lucro ocasional. Outros perseguem seus estudos mágicos com uma seriedade mórbida, buscando o poder dos deuses de criar e destruir mundos. TRANSMUTAÇÃO INSTRUÍDA Quando você escolhe essa escola no 2º nível, o ouro e o tempo que você precisa gastar para copiar uma magia da escola de transmutação em seu grimório é reduzido à metade. ALQUIMIA MENOR A partir do 2° nível, quando você escolhe essa escola, você pode alterar temporariamente as propriedades físicas de um objeto não-mágico, alterando-o de uma substancia para outra. Você realiza um procedimento alquímico especial em um objeto composto inteiramente de madeira, pedra (mas não uma pedra preciosa), ferro, cobre ou prata, transformando-o em um material diferente dentre esses. Para cada 10 minutos que você gastar realizando esse procedimento, você pode transformar 30 centímetros cúbicos de material. Após 1 hora, ou até você perder sua concentração (como es estivesse se concentrando em uma magia) o material reverte à sua substancia original. PEDRA DE TRANSMUTADOR A partir do 6° nível, você pode gastar 8 horas criando uma pedra de transmutador que armazena magia de transmutação. Você pode se beneficiar da pedra ou dá-la para outra criatura. Uma criatura ganha um benefício, à sua escolha, enquanto a pedra estiver em sua posse. Quando você cria a pedra, escolha um benefício dentre as opções a seguir:  Visão no escuro com alcance de 18 metros, como descrito no capítulo 8  Um aumento de 3 metros no deslocamento enquanto a criatura não estiver sobrecarregada  Proficiência em testes de resistência de Constituição  Resistência a dano de ácido, frio, fogo, elétrico ou trovejante (escolhido por você quando escolhe esse benefício) Cada vez que você conjurar uma magia de conjuração de 1° nível ou superior, você pode mudar o efeito da sua pedra, se ela estiver em sua posse. Se você criar uma nova pedra de transmutador, a anterior para de funcionar. METAMORFO No 10° nível, você adiciona a magia metamorfose ao seu grimório, se você ainda não a possuir. Você pode conjurar metamorfose sem gastar um espaço de magia. Quando o fizer, você só pode escolher a si mesmo como alvo e se transforma em uma besta com nível de desafio 1 ou menor. Quando você conjurar metamorfose dessa forma, você não poderá fazê-lo novamente até terminar um descanso curto ou longo, apesar de ainda poder conjurá-la normalmente usando espaços de magia disponíveis. MESTRE TRANSMUTADOR A partir do 14° nível, você pode usar sua ação para consumir a reserva de magia de transmutação armazenada dentro da sua pedra de transmutador em uma única explosão. Quando o fizer, escolha um dos seguintes efeitos. Sua pedra de transmutador é destruída e não pode ser refeita até você terminar um descanso longo. Transformação Maior. Você pode transmutar um objeto não-mágico – não maior que 1,5 metro cubico – em outro objeto não-mágico de tamanho e massa similares e de valor igual ou inferior. Você deve gastar 10 minutos manipulando o objeto para transformá-lo. Panaceia. Você remove todas as maldições, doenças e venenos afetando uma criatura que você tocar com sua pedra de transmutador. A criatura também recupera todos os seu pontos de vida. Restaurar Vida. Você pode conjurar reviver mortos em uma criatura que você tocar com sua pedra de transmutador, sem gastar espaço de magia ou precisar ter a magia no seu grimório. Restaurar Juventude. Você toca a pedra de transmutador em uma criatura voluntária e a idade aparente da criatura é reduzida em 3d10 anos, para o mínimo de 13 anos. Esse efeito não estende a vida útil da criatura. "
            },
            new Arquetipo
            {
                IdArquetipo = 37,
                Nome = "Caminho da Mão Aberta",
                HabilidadeArquetipo = "Monges do Caminho da Mão Aberta são os mestres supremos das artes de combate marcial, tanto armado quanto desarmado. Eles aprendem técnicas para empurrar e derrubar seus oponentes, manipulando o chi para curar os ferimentos dos seus corpos e praticando uma meditação avançada que os protege de mazelas. TÉCNICA DA MÃO ABERTA Começando quando você escolhe essa tradição, no 3° nível, você pode manipular o chi do seu inimigo quando você controla o seu. Toda vez que você atingir uma criatura com um dos seus ataques garantidos por sua Rajada de Golpes, você pode impor um dos seguintes efeitos no alvo:  Ele deve ser bem sucedido num teste de resistência de Destreza ou cairá no chão.  Ele deve realizar um teste de resistência de Força. Se falhar, você pode empurrá-lo 4,5 metros para longe de você.  Ele não pode realizar reações até o final do seu próximo turno. INTEGRIDADE CORPORAL No 6° nível, você ganha a habilidade de se curar. Com uma ação, você recupera uma quantidade de pontos de vida igual a três vezes seu nível de monge. Você deve terminar um descanso longo antes de poder usar essa característica novamente. 106 TRANQUILIDADE A partir do 11° nível, você pode entrar num estado especial de meditação que rodeia você com uma aura pacifica. No final de um descanso longo, você ganha o efeito da magia santuário que dura até o começo do seu próximo descanso longo (a magia pode terminar prematuramente, como normal). A CD do teste de resistência para a magia é 8 + seu modificador de Sabedoria + seu bônus de proficiência. PALMA VIBRANTE No 17° nível, você ganha a habilidade de criar vibrações letais no corpo de alguém. Quando você atingir uma criatura com um golpe desarmado, você pode gastar 3 pontos de chi para começar essas vibrações imperceptíveis, que duram por um número de dias igual ao seu nível de monge. As vibrações são inofensivas, a não ser que você use sua ação para terminá-las. Para tanto, você e o alvo devem estar no mesmo plano de existência. Quando você usa essa ação, a criatura deve realizar um teste de resistência de Constituição. Se ela falhar, ela será reduzida a 0 pontos de vida. Se ela passar, ela sofrerá 10d10 de dano necrótico. Você pode ter apenas uma criatura sob o efeito dessa característica por vez. Você pode escolher terminar as vibrações inofensivamente, sem usar uma ação. "
            },
            new Arquetipo
            {
                IdArquetipo = 38,
                Nome = "Caminho da Sombra",
                HabilidadeArquetipo = "Monges do Caminho da Sombra seguem uma tradição que valoriza furtividade e subterfugio. Esses monges devem ser chamados de ninjas ou dançarinos das sombras e eles servem como espiões e assassinos. Às vezes, os membros de um monastério ninja são membros da mesma família, formando um clã que jurou sigilo sobre suas artes e missões. Outros monastérios parecem mais com guildas de ladrões, oferecendo seus serviços a nobres, mercadores ricos ou qualquer um que possa pagar suas taxas. Independente dos seus métodos, os líderes desses monastérios esperam obediência inquestionável de seus estudantes. ARTES SOMBRIAS Começando quando você escolhe essa tradição, no 3° nível, você pode usar seu chi para simular o efeito de certas magias. Com uma ação, você pode gastar 2 pontos de chi para conjurar escuridão, visão no escuro, passos sem pegadas ou silêncio, sem precisar de componentes materiais. Além disso, você ganha o truque ilusão menor, se você ainda não o conhecia. PASSO DAS SOMBRAS No 6° nível, você ganha a habilidade de entrar em uma sombra e sair em outra. Quando você estiver sob penumbra ou na escuridão, com uma ação bônus, você pode se teletransportar a até 18 metros para um espaço desocupado que você possa ver que também esteja sob penumbra ou escuridão. Você, então, terá vantagem no primeiro ataque corpo-a-corpo que você fizer antes do final do seu turno. MANTO DE SOMBRAS No 11° nível, você aprendeu a se tornar uno com as sombras. Quando você estiver em uma área de penumbra ou escuridão, você pode usar sua ação para se tornar invisível. Você permanece invisível até realizar um ataque, conjurar uma magia ou se for para uma área de luz plena. OPORTUNISTA No 17° nível, você pode explorar um momento de distração de uma criatura quando ela é atingida por um ataque. Toda vez que uma criatura a até 1,5 metro de você for atingida por um ataque realizar por outra criatura diferente de você, você pode usar sua reação para realizar um ataque corpo-a-corpo contra essa criatura. "
            },
            new Arquetipo
            {
                IdArquetipo = 39,
                Nome = "Caminho dos Quatro Elementos",
                HabilidadeArquetipo = "Você segue uma tradição monástica que ensina você a dominar os elementos. Quando você foca seu chi, você pode se alinhar com as forças da criação e moldar os elementos a sua vontade, usando-os como uma extensão do seu corpo. Alguns membros dessa tradição se dedicam a um único elemento, mas outros tecem os elementos juntos. Muitos monges dessa tradição tatuam seus corpos com representações dos seus poderes de chi, normalmente representadas através de dragões enrolados, mas também como fênix, peixes, plantas, montanhas e ondas coroantes. DISCÍPULO DOS ELEMENTOS Quando você escolhe essa tradição, no 3° nível, você aprende disciplinas mágicas que manipulam o poder dos quatro elementos. Uma disciplina requer que você gaste pontos de chi cada vez que você a usa. Você conhece a disciplina Sintonia Elemental e uma outra disciplina, à sua escolha, que são detalhadas na seção “Disciplinas Elementais” abaixo. Você aprende uma disciplina adicional, à sua escolha, no 6°, 11° e 17° nível. Toda vez que você aprende uma nova disciplina elemental, você pode substituir uma disciplina elemental que você já conhecia por uma disciplina diferente. Conjurando Magias Elementais. Algumas disciplinas elementais permitem que você conjure magias. Veja o capítulo 10 para as regras gerais de conjuração. Para conjurar uma dessas magias, você usa o tempo de conjuração da mesma e suas outra regras, mas você não precisa fornecer os componentes materiais dela. Quando você alcança o 5° nível nessa classe, você pode gastar pontos de chi adicionais para aumentar o nível da magia de disciplina elemental que você conjurar, considerando que a magia tenha um efeito de aprimoramento para um nível superior, como mãos flamejantes, por exemplo. O nível da magia aumenta em 1 para cada ponto de chi adicional que você gastar. Por exemplo, se você for um monge de 5° nível e usar Golpe de Varredura Cauterizante para conjurar mãos flamejantes, você pode gastar 3 pontos de chi para conjurá-la como uma magia de 2° nível (o custo base da disciplina de 2 pontos mais 1). O número máximo de pontos de chi que você pode gastar para conjurar uma magia dessa forma (incluindo seu custo de chi base e quaisquer pontos de chi adicionais que você gastar para elevar seu nível) é determinado pelo seu nível de monge, como mostrado na tabela Magias e Pontos de Chi. MAGIAS E PONTOS DE CHI Nível de Monge Pontos de Chi Máximos para uma Magia 5°–8° 3 9°–12° 4 13°–16° 5 17°–20° 6 107 DISCIPLINAS ELEMENTAIS As disciplinas elementais serão apresentadas em ordem alfabética. Se a disciplina tiver um nível como prérequisito, você deve ter aquele nível na classe para aprendê-la. Cavalgar o Vento (11° nível Requerido). Você pode gastar 4 pontos de chi para conjurar voo em si mesmo. Chamas da Fénix (11° nível Requerido). Você pode gastar 4 pontos de chi para conjurar bola de fogo. Chicote de Água. Você pode gastar 2 pontos de chi, com uma ação, para criar um chicote de água que empurra e puxa uma criatura para desequilibrá-la. Uma criatura que você possa ver a até 9 metros deve realizar um teste de resistência de Destreza. Se falhar, a criatura sofre 3d10 de dano de concussão, mais 1d10 de dano de concussão extra para cada ponto de chi adicional que você gastar e você pode tanto derrubar a criatura no chão, quanto puxá-la 7,5 metros para perto de você. Em um sucesso, a criatura sofre metade do dano e você não a puxa ou derruba. Defesa Eterna da Montanha (17° nível Requerido). Você pode gastar 5 pontos de chi para conjurar pele de pedra em si mesmo. Golpe de Varredura Cauterizante Você pode gastar 2 pontos de chi para conjurar mãos flamejantes. Gongo do Pico (6° nível Requerido). Você pode gastar 3 pontos de chi para conjurar despedaçar. Investida dos Espíritos da Ventania. Você pode gastar 2 pontos de chi para conjurar lufada de vento. Moldar o Rio Corrente. Com uma ação, você pode gastar 1 ponto de chi para escolher uma área de gelo ou água, não maior que 9 metros quadrados a até 36 metros de você. Você pode transformar água em gelo dentro da área, e vice-versa e pode remodelar o gelo na área da maneira que desejar. Você pode levantar ou baixar a elevação do gelo, criar encher uma vala, erguer ou achatar uma parede ou formar um pilar. A extensão dessas mudanças não podem exceder metade da maior dimensão da área. Por exemplo, se você afetou 9 metros quadrados, você pode criar um pilar de até 4,5 metros de altura, erguer ou rebaixar a elevação do quadrado em 4,5 metros, escavar uma vala de 4,5 metros de profundidade e assim por diante. Você não pode moldar o gelo para aprisionar ou ferir uma criatura na área. Onda de Pedras Rolantes (17° nível Requerido). Você pode gastar 6 pontos de chi para conjurar muralha de pedra. Postura da Neblina (11° nível Requerido). Você pode gastar 4 pontos de chi para conjurar forma gasosa. Presas da Serpente de Fogo. Quando você usa a ação de Ataque no seu turno, você pode gastar 1 ponto de chi para fazer com que gavinhas de chamas estiquem-se dos seus punho e pés. Seu alcance com seus ataques desarmados aumenta em 3 metros durante essa ação e também pelo resto do seu turno. Um acerto com tal ataque causa dano de fogo, ao invés de dano de concussão e, se você gastar 1 ponto de chi quando atingir o ataque, ele também causará 1d10 de fogo adicional. Punho do Ar Continuo. Você pode criar uma explosão de ar comprimido que atinge como um poderoso soco. Com uma ação, você pode gastar 2 pontos de chi e escolher uma criatura a até 9 metros. A criatura deve realizar um teste de resistência de Força. Se falhar, a criatura sofrerá 3d10 de dano de concussão, mais 1d10 de dano de concussão extra para cada ponto de chi adicional que você gastar e você pode empurrar a criatura para até 6 metros longe de você e derrubá-la no chão. Em um sucesso, a criatura sofre metade do dano e você não a empurra ou derruba. Punho dos Quatro Trovões. Você pode gastar 2 pontos de chi para conjurar onda trovejante. Rio de Chamas Famintas (17° nível Requerido). Você pode gastar 5 pontos de chi para conjurar muralha de fogo. Serragem do Vento do Norte (6° nível Requerido). Você pode gastar 3 pontos de chi para conjurar imobilizar pessoa. Sintonia Elemental. Você pode usar sua ação para, momentaneamente, controlar as forças elementais próximas, causando um dos seguintes efeitos, à sua escolha:  Criar, instantaneamente, um efeito sensorial inofensivo relacionado à água, ar, fogo ou terra, como uma chuva de faíscas, um sopro de vento, uma leve rajada de névoa ou um suave estrondo de pedra.  Acender ou apagar, instantaneamente, uma vela, tocha ou pequena fogueira.  Esfriar ou esquentar 0,5 quilo de material inorgânico por até 1 hora.  Fazer com que terra, fogo, ar ou névoa que possa caber dentro de 30 centímetros cúbicos se molde em uma forma bruta que você esculpiu por 1 minuto. Sopro do Inverno (17° nível Requerido). Você pode gastar 6 pontos de chi para conjurar cone de frio. ORDENS MONÁSTICAS Os mundos de D&D contém uma multidão de monastérios e tradições monásticas. Em terras com um toque de cultura asiática, como em Shou Lung no oriente dos Reinos Esquecidos, esses monastérios são associados a tradições filosóficas e a pratica de artes marciais. A Escola da Mão de Ferro, a Escola das Cinco Estrelas, a Escola do Punho Setentrional e a Escola da Estrela do Sul de Shou Lung, ensinam diferentes abordagens das disciplinas física, mental e espiritual do monge. Alguns desses monastérios se espalharam para terras ocidentais de Faerûn, especialmente para terras com grandes comunidades de imigrantes de Shou, como em Thesk e Portão Ocidental. Outras tradições monásticas são associadas com divindades que ensinam o valor do aperfeiçoamento físico e disciplina mental. Nos Reinos Esquecidos, a ordem da Lua Negra é formada por monges dedicados a Shar (deusa das sombras), que mantem comunidades secretas em colinas remotas, atrás dos aliados, e em esconderijos subterrâneos. Monastérios de Ilmater (deus dos flagelados) recebem nomes de flores e suas ordens carregam nomes de grandes heróis da crença; os Discípulos de Santo Sollars, o Duas Vezes Martirizado, residem no Monastério da Rosa Amarela perto de Damara. Os monastérios de Eberron combinam os estudos de artes marciais com uma vida de estudos. A maioria é devoto das divindades do Soberano Anfitrião. No mundo de Dragonlance, a maioria dos monges são devotados a Majere, deus da meditação e pensamento. Em Greyhawk, muitos monastérios são dedicados a Xan Yae, a deusa do crepúsculo e da superioridade da mente sobre matéria, ou a Zuoken, deus da maestria mental e física. Os monges malignos da Irmandade Escarlate no mundo de Greyhawk derivam seu fanatismo não de devoção a um deus, mas de dedicação a princípios de sua nação e raça – a crença de que"
            },
            new Arquetipo
            {
                IdArquetipo = 40,
                Nome = "Juramento de Devoção",
                HabilidadeArquetipo = "O Juramento de Devoção vincula um paladino aos mais sublimes ideias de justiça, virtude e ordem. Algumas vezes chamados de campeões, cavaleiros brancos ou guerreiros sagrados, esses paladinos atendem o ideal do cavaleiro na armadura brilhante, agindo com honra em busca de justiça e do bem maior. Eles se agarram aos mais altos padrões de conduta, e alguns, para o melhor ou para o pior, consideram que o resto do mundo deve ter os mesmos padrões. Muitos dos que fazem esse juramento são devotados aos deuses da lei e do bem e usam os dogmas de seus deuses como medida de sua devoção. Eles consideram os anjos – os perfeitos servos do bem – como seus ideais e incorporam imagens de asas angelicais em seus elmos ou brasões. DOGMAS DE DEVOÇÃO Embora as palavras exatas e restrições do Juramento de Devoção variem, os paladinos que fazem esse juramento partilha desses dogmas. Honestidade. Não minta nem trapaceie. Deixe sua palavra ser sua garantia. Coragem. Nunca tenha medo de agir, apesar de a cautela ser sensata. Compaixão. Ajude os outros, proteja os fracos, puna aqueles que os ameaçarem. Mostre misericórdia aos seus adversários, mas tempere isso com sabedoria. Honra. Trate os outros com equidade e deixe seus feitos honoráveis serem exemplos para eles. Faça o máximo de bem possível causando a menor quantidade de mazelas. Dever. Seja responsável pelos seus atos e por suas consequências, proteja aqueles confiados aos vossos cuidados e obedeça aqueles que tiverem autoridade sobre você. MAGIAS DE JURAMENTO Você ganha magias de juramento nos níveis de paladino descritos. MAGIAS DE JURAMENTO DE DEVOÇÃO Nível de Paladino Magias 3° proteção contra o bem e mal, santuário 5° restauração menor, zona da verdade 9° sinal de esperança, dissipar magia 13° movimentação livre, guardião da fé 17° comunhão, coluna de chamas CANALIZAR DIVINDADE Quando você faz esse juramento, no 3° nível, você ganha as duas opções seguintes de Canalizar Divindade. Arma Sagrada. Com uma ação, você pode imbuir uma arma que você esteja empunhando com energia positiva, usando seu Canalizar Divindade. Por 1 minuto, você adiciona seu modificador de Carisma as jogadas de ataque feitas com essa arma (bônus mínimo de +1). A arma também emite luz plena num raio de 6 metros e penumbra mais 6 metros além. Se a arma ainda não for mágica, ela se torna mágica por essa duração. Você pode terminar o efeito no seu turno, como parte de qualquer ação. Se você não estiver mais segurando ou portando a arma, ou estiver inconsciente, esse efeito termina. QUEBRANDO SEU JURAMENTO Um paladino tenta se manter nos mais altos padrões de conduta, mas, até mesmo o mais virtuoso paladino é falível. Algumas vezes, o caminho certo se mostra muito exigente, algumas vezes, uma situação requer o menor dentre dois males e, as vezes, o calor da emoção faz com que um paladino transgrida seu juramento. Um paladino que tenha quebrado um voto, geralmente buscará absolvição de um clérigo que partilhe sua crença ou de outro paladino da mesma ordem. O paladino deveria gastar toda uma noite em vigília, orando, como sinal de penitência, ou realizar um ato rápido similar de abnegação. Depois de um rito de confissão e perdão, o paladino se sente renovado. Se um paladino, por vontade própria, violar seu juramento e não demonstrar sinal de arrependimento, as consequências podem ser mais severas. A critério do Mestre, um paladino impenitente deveria ser forçado a abandonar essa classe e adotar outra, ou ainda pegar a opção Paladino Quebrador de Juramento, que aparece no Guia do Mestre. Expulsar o Profano. Com uma ação, você apresenta seu símbolo sagrado e faz uma oração censurando corruptores e mortos-vivos, usando seu Canalizar Divindade. Cada corruptor ou morto-vivo que puder ver ou ouvir você e esteja a até 9 metros, deve realizar um teste de resistência de Sabedoria. Se a criatura falhar no teste de resistência, ela será expulsa por 1 minuto ou até sofrer dano. Uma criatura expulsa deve gastar seu turno tentando se mover para longe de você da melhor forma possível e não pode, voluntariamente, se mover para um espaço a menos de 9 metros de você. Ela também não pode realizar reações. Nas ações delas, elas só poderão realizar a ação de Disparada ou tentar escapar de um efeito que as impeça de se mover. Se não houver lugar para se mover, a criatura pode usar a ação de Esquivar. AURA DE DEVOÇÃO A partir do 7° nível, você e as criaturas amistosas a até 3 metros não podem ser enfeitiçadas enquanto você estiver consciente. No 18° nível, o alcance dessa aura aumenta para 9 metros. PUREZA DE ESPÍRITO A partir do 15° nível, você estará sempre sob efeito da magia proteção contra o bem e mal. HALO SAGRADO No 20° nível, com uma ação, você pode emanar uma aura de luz solar. Por 1 minuto, luz plena emana de você num raio de 9 metros, penumbra brilha mais 9 metros além. Sempre que uma criatura inimiga começar seu turno na luz plena, a criatura sofrerá 10 de dano radiante. Além disso, por essa duração, você tem vantagem em testes de resistência contra magias conjuradas por corruptores ou mortos-vivos. Uma vez que você use essa característica, não poderá fazê-lo novamente até ter terminado um descanso longo. "
            },
            new Arquetipo
            {
                IdArquetipo = 41,
                Nome = "Juramento dos Anciões",
                HabilidadeArquetipo = "O Juramento dos Anciões é tão antigo quanto a raça dos elfos e os rituais dos druidas. Algumas vezes chamados de cavaleiros feéricos, cavaleiros verdejantes ou cavaleiros dos chifres, paladinos que fazem esse juramento lançam 113 sua sorte com o lado da luz na batalha cósmica contra as trevas, porque eles amam as coisas belas e vivificantes do mundo, não necessariamente porque eles acreditam em princípios de honra, coragem e justiça. Eles adornam suas armaduras e roupas com imagens de coisas que crescem – folhas, galhadas ou flores – para refletir seu comprometimento em preservar a vida e a luz no mundo. DOGMAS DOS ANCIÕES Os dogmas do Juramento dos Anciões tem sido preservados por incontáveis séculos. Esse juramento enfatiza os princípios do bem acima de qualquer interesse de ordem ou caos. Seus quatro princípios centrais são simples. Acenda a Luz. Através dos seus atos de misericórdia, gentileza e piedade, acenda a luz da esperança no mundo, afastando o desespero. Abrigue a Luz. Onde houver bem, beleza, amor e riso no mundo, mantenha-se contra a maldade que pode engolir isso. Onde a vida floresce, mantenha-se contra as forças que podem torná-la estéril. Preserve Sua Própria Luz. Deleite-se com música e risadas, beleza e arte. Se você permitir que a luz morra em seu coração, você não poderá preservá-la no mundo. Seja a Luz. Seja uma glorioso guia para todos que vivem em desespero. Deixe a luz da sua alegria e coragem brilhar através de todos os seus feitos. MAGIAS DE JURAMENTO Você ganha magias de juramento nos níveis de paladino descritos. MAGIAS DE JURAMENTO DOS ANCIÕES Nível de Paladino Magias 3° golpe constritor, falar com animais 5° raio lunar, passo nebuloso 9° ampliar plantas, proteção contra energia 13° tempestade de gelo, pele de pedra 17° comunhão com a natureza, caminhar em árvores CANALIZAR DIVINDADE Quando você faz esse juramento, no 3° nível, você ganha as duas opções seguintes de Canalizar Divindade. Fúria da Natureza. Você pode usar seu Canalizar Divindade para invocar forças primitivas para enredar um oponente. Com uma ação, você pode fazer com que vinhas espectrais cresçam e alcancem uma criatura a até 3 metros de você, que você possa ver. A criatura deve ser bem sucedida num teste de resistência de Força ou Destreza (a escolha dela) ou ficará impedida. Enquanto estiver impedida pelas vinhas, a criatura repete o teste de resistência no final de cada turno dela. Se obtiver sucesso, ela se liberta e as vinhas desaparecem. Expulsar os Infiéis. Você pode usar seu Canalizar Divindade para pronunciar palavras antigas que são dolorosas para fadas e corruptores que as ouvem. Com uma ação, você ergue seu símbolo sagrado e cada fada ou corruptor que puder ver ou ouvir você e esteja a até 9 metros, deve realizar um teste de resistência de Sabedoria. Se a criatura falhar no teste de resistência, ela será expulsa por 1 minuto ou até sofrer dano. Uma criatura expulsa deve gastar seu turno tentando se mover para longe de você da melhor forma possível e não pode, voluntariamente, se mover para um espaço a menos de 9 metros de você. Ela também não pode realizar reações. Nas ações delas, elas só poderão realizar a ação de Disparada ou tentar escapar de um efeito que as impeça de se mover. Se não houver lugar para se mover, a criatura pode usar a ação de Esquivar. AURA DE VIGILÂNCIA A partir do 7° nível, a magia antiga fica tão profunda em você que ela forma uma proteção mística. Você e as criaturas amistosas a até 3 metros tem resistência ao dano de magias. No 18° nível, o alcance dessa aura aumenta para 9 metros. SENTINELA IMORTAL A partir do 15° nível, quando você for reduzido a 0 pontos de vida, mas não morrer totalmente, você pode escolher cair para 1 ponto de vida no lugar. Uma vez que você use essa característica, não poderá fazê-lo novamente até ter terminado um descanso longo. Além disso, você não sofre nenhum efeito colateral por envelhecer e você não pode envelhecer magicamente. CAMPEÃO DOS ANCIÕES No 20° nível, você pode assumir a forma de uma antiga força da natureza, tomando a aparência que desejar. Por exemplo, sua pele poderia ficar verde ou adquirir uma textura de casca de árvore, seu cabelo poderia ficar com aparência de folhas ou musgo ou poderia crescer galhadas ou uma juba como a de um leão. Usando sua ação, você sofre uma transformação. Por 1 minuto, você ganha os seguintes benefícios:  No início de cada um dos seus turnos, você recupera 10 pontos de vida.  Sempre que você for conjurar uma magia de paladino que tiver um tempo de conjuração de 1 ação, você pode conjurá-la usando uma ação bônus, ao invés.  Criaturas inimigas a até 3 metros de você tem desvantagem em testes de resistência contra suas magias de paladino e as opções de Canalizar Divindade. Uma vez que você use essa característica, não poderá fazê-lo novamente até ter terminado um descanso longo. "
            },
            new Arquetipo
            {
                IdArquetipo = 42,
                Nome = "Juramento de Vingança",
                HabilidadeArquetipo = "O Juramento de Vingança é um comprometimento solene de punir aqueles que cometeram pecados graves. Quando forças malignas chacinam camponeses indefesos, quando todo um povo se volta contra a vontade dos deuses, quando uma guilda de ladrões cresce e se torna violenta e poderosa, quando um dragão investe através da zona rural – em momentos como esses, paladinos surgem e fazem o Juramento de Vingança para tornar certo o que já foi errado. Para esses paladinos – algumas vezes chamados de vingadores ou de cavaleiros negros – sua própria pureza não é tão importante quando trazer justiça. DOGMAS DE VINGANÇA Os dogmas do Juramento de Vingança variam de paladino para paladino, mas todos os dogmas giram em torno de punir malfeitores a qualquer custo. Paladinos que defendem esses dogmas estão dispostos a sacrificar, até mesmo sua própria integridade para fazer justiça sobre aqueles que praticaram o mal, de modo que, muitas vezes, os paladinos são neutros ou leais e neutros em alinhamento. Os princípios fundamentais dos dogmas são brutalmente simples. Combater o Mal Maior. Entre escolher lutar contra meus inimigos jurados ou combater um mal menor. Eu escolho o mal maior. Sem Misericórdia para os Malignos. Inimigos comuns podem ter minha misericórdia, mas meus inimigos jurados não. A Todo Custo. Meus escrúpulos não podem ficar no caminho do extermínio dos meus inimigos. Restituição. Se meus inimigos causaram ruina no mundo, é porque eu falhei em detê-los. Devo ajudar aqueles prejudicados pelos delitos. MAGIAS DE JURAMENTO Você ganha magias de juramento nos níveis de paladino descritos. MAGIAS DE JURAMENTO DE VINGANÇA Nível de Paladino Magias 3° perdição, marca do caçador 5° imobilizar pessoa, passo nebuloso 9° velocidade, proteção contra energia 13° banimento, porta dimensional 17° imobilizar monstro, vidência CANALIZAR DIVINDADE Quando você faz esse juramento, no 3° nível, você ganha as duas opções seguintes de Canalizar Divindade. Abjurar Inimigo. Com uma ação, você ergue seu símbolo sagrado e faz uma prece de condenação, usando seu Canalizar Divindade. Escolha uma criatura a até 18 metros de você que você possa ver. A criatura deve realizar um teste de resistência de Sabedoria, a não ser que seja imune a ser amedrontada. Corruptores e mortosvivos tem desvantagem nesse teste de resistência. Num fracasso no teste de resistência, a criatura ficará amedrontada por 1 minuto ou até sofrer qualquer dano. Enquanto estiver amedrontada, o deslocamento da criatura será 0 e ela não pode receber qualquer bônus de deslocamento. Em um sucesso, o deslocamento da criatura é reduzido à metade por 1 minuto ou até que ela sofra qualquer dano. Voto de Inimizade. Com uma ação bônus, você pode pronunciar um voto de inimizade contra uma criatura que você possa ver a até 3 metros, usando seu Canalizar Divindade. Você ganha vantagem nas jogadas de ataque contra a criatura por 1 minuto ou até ela cair a 0 pontos de vida ou cair inconsciente. VINGADOR IMPLACÁVEL No 7° nível, seu foco sobrenatural ajuda você a impedir a fuga de um inimigo. Quando você atinge uma criatura com um ataque de oportunidade, você pode se mover até metade do seu deslocamento, imediatamente depois do ataque e como parte da mesma reação. Esse movimento não provoca ataques de oportunidade. ALMA DE VINGANÇA A partir do 15° nível, a autoridade com a qual você fala seu Voto de Inimizade lhe dá maior poder sobre seu inimigo. Quando uma criatura sob efeito do seu Voto de Inimizade realizar um ataque, você pode usar sua reação para realizar um ataque corpo-a-corpo com arma contra essa criatura, se ela estiver ao seu alcance. ANJO VINGADOR No 20° nível, você pode assumir a forma de um anjo vingador. Usando sua ação, você sofre uma transformação. Por 1 hora, você ganha os seguintes benefícios:  Asas crescem nas suas costas e lhe concedem deslocamento de voo de 18 metros.  Você emana uma aura de ameaça num raio de 9 metros. A primeira vez que qualquer criatura inimiga entrar na aura ou começar seu turno nela, durante uma batalha, a criatura deve ser bem sucedida num teste de resistência de Sabedoria ou ficará amedrontada em relação a você por 1 minuto ou até sofrer qualquer dano. Jogadas de ataque contra a criatura amedrontada tem vantagem. Uma vez que você use essa característica, não poderá fazê-lo novamente até ter terminado um descanso longo. "
            },
            new Arquetipo
            {
                IdArquetipo = 43,
                Nome = "Conclave da Besta",
                HabilidadeArquetipo = "Muitos patrulheiros sentem-se mais a vontade no ambiente selvagem que na civilização, ao ponto de animais consideram-nos como semelhantes. Patrulheiros do Conclave da Besta desenvolvem um vínculo poderoso com uma besta, posteriormente fortalecendo esse vínculo com o uso de magia. COMPANHEIRO ANIMAL No 3° nível, você aprende a usar sua magia para criar um poderoso vínculo com uma criatura do mundo natural. Com 8 horas de trabalho e o gasto de 50 po em ervas raras e comida boa, você invoca um animal do ambiente selvagem para servir como um companheiro leal. Você geralmente escolhe seu companheiro dentre os seguintes animais: um arminho gigante, um javali, um gorila, um lobo, uma mula, uma pantera, um texugo gigante ou urso negro. Porém, seu Mestre pode escolher um desses animais para você baseado nos terrenos ao redor e em que tipos de criaturas logicamente poderiam estar presentes na área. Ao final das 8 horas, seu companheiro animal aparece e adquire todos os benefícios da sua habilidade Vínculo com o Companheiro. Você só pode ter um companheiro animal por vez. MONITORANDO A PROFICIÊNCIA Quando você adquire seu companheiro animal no 3° nível, o bônus de proficiência dele se equipara ao seu em +2. Conforme você ganha níveis e aumenta seu bônus de proficiência, lembre-se que o bônus de proficiência do seu companheiro também aumenta e é aplicado às seguintes áreas: Classe de Armadura, perícias, testes de resistência, bônus de ataque e jogadas de dano. Se o seu companheiro animal for morto, o vínculo mágico que vocês compartilham permite que você o traga de volta à vida. Com 8 horas de trabalho e o gasto de 25 po em ervas raras e comida boa, você pode invocar o espírito do seu companheiro e usar sua mágica para criar um novo corpo para ele. Você pode trazer um companheiro animal de volta à vida dessa forma mesmo que você não possua qualquer parte do corpo dele. Se você usar essa habilidade para trazer um companheiro animal antigo de volta à vida enquanto você já tiver outro companheiro animal, seu companheiro animal atual abandona você e é substituido pelo companheiro animal ressuscitado. VÍNCULO COM O COMPANHEIRO Seu companheiro animal ganha uma variedade de benefícios enquanto estiver vinculado a você. O companheiro animal perde a ação Ataques Múltiplos, caso ele possua. O companheiro obedece seus comandos da melhor forma possível. Ele rola iniciativa como qualquer outra criatura, mas você determina suas ações, decisões, atitudes e afins. Se você estiver incapacitado ou ausente, seu companheiro age por conta própria. Quando estiver usando sua característica Explorador Natural, você e seu companheiro animal podem se mover furtivamente com ritmo normal. Seu companheiro animal tem habilidades e estatísticas de jogo em parte determinadas pelo seu nível. Seu companheiro usa seu bônus de proficiência ao invés do próprio. Além das áreas onde ele normalmente aplicaria o bônus de proficiência dele, um companheiro animal também adiciona o bônus de proficiência a CA e jogadas de dano dele. Seu companheiro animal ganha proficiência em duas perícias de sua escolha. Ele também se torna proficiente em todos os testes de resistência. Para cada nível que você adquirir após o 3°, seu companheiro animal ganha um dado de vida adicional e aumenta os pontos de vida dele apropriadamente. ATAQUES MÚLTIPLOS, POR QUE NÃO? Ataques Múltiplos é um ferramenta conceitual útil para manter os monstros simples para o Mestre. Ela fornece um incremento ofensivo, mas esse incremento é pensado para tornar uma besta desafiadora para uma única batalha – uma noção que não se encaixa bem com uma besta que tem pretenções de lutar com o grupo, ao invés de contra ele. Projete os Ataques Múltiplos por uma aventura inteira e um companheiro animal corre o risco de superar os guerreiros e bárbaros do grupo. Por isso, em termos de história, seu companheiro animal trocou uma parte de sua ferocidade (na forma de Ataques Múltiplos) por consciência apurada e a habilidade de lutar com mais eficiência junto com você."
            },
            new Arquetipo
            {
                IdArquetipo = 44,
                Nome = "Conclave do Caçador",
                HabilidadeArquetipo = "Alguns patrulheiros buscam dominar armas para proteger melhor a civilização dos terrores do ambiente selvagem. Membros do Conclave do Caçador aprendem técnicas especializadas de luta usadas contra as mais terríveis ameaças, desde ogros enfurecidos e hordas de orcs até enormes gigantes e dragões aterradores. PRESA DO CAÇADOR No 3° nível, você ganha uma das seguintes características, à sua escolha. Assassino de Colossos. Sua tenacidade pode derrubar os mais poderosos oponentes. Quando você atinge uma criatura com um ataque com arma, a criatura sofre 1d8 de dano extra, se ela estiver abaixo do máximo de pontos de vida dela. Você só pode causar esse dano extra uma vez por turno. Matador de Gigantes. Quando uma criatura Grande ou maior a até 1,5 metro de você atingir ou errar um ataque contra você, você pode usar sua reação para atacar a criatura, imediatamente após o ataque dela, considerando que você possa ver a criatura. Destruidor de Hordas. Uma vez em cada um dos seus turnos, quando você fizer um ataque com arma, você pode realizar outro ataque com a mesma arma contra uma criatura diferente que esteja a até 1,5 metro do alvo original e esteja no alcance da sua arma. ATAQUE EXTRA A partir do 5° nível, você pode atacar duas vezes, ao invés de uma, sempre que você realizar a ação de Ataque no seu turno. TÁTICAS DEFENSIVAS No 7° nível, você ganha uma das seguintes características, à sua escolha. Escapar da Horda. Ataques de oportunidade contra você são feitos com desvantagem. Defesa Contra Múltiplos Ataques. Quando uma criatura atinge você com um ataque, você recebe +4 de bônus na CA contra todos os ataques subsequentes feitos por essa criatura no resto do turno."
            },
            new Arquetipo
            {
                IdArquetipo = 45,
                Nome = "Conclave do Rastreador Subterrâneo",
                HabilidadeArquetipo = "Muitos povos descem para as profundezas do Subterrâneo apenas sob as condições mais urgentes, empreendendo alguma busca desesperada ou seguindo promesas de vastas riquezas. Com demasiada frequência, males antigos ocultos abaixo da terra e patrulheiros do Conclave dos Rastreadores Subterrâneos se esforçam para descobrir e derrotar tais ameaças antes que elas possam alcançar a superfície. BATEDOR DO SUBTERRÂNEO No 3° nível, você domina a arte da emboscada. No seu primeiro turno durante o combate, você ganha +3 metros de bônus no seu deslocamento e, se você usar a ação de Ataque nesse turno, você pode realizar um ataque adicional. Você também é especialista em evitar criaturas que contam com visão no escuro. Tais criaturas não ganham qualquer benefício quando tentarem detectar você em condições de escuridão ou penumbra. Além disso, quando o Mestre determina se você pode se esconder de uma criatura, tal criatura não ganham qualquer benefício devido a visão no escuro dela. MAGIA DO RASTREADOR SUBTERRÂNEO A partir do 3° nível, você ganha visão no escuro com um alcance de 27 metros. Você também ganha acesso a magias adicionais no 3°, 5°, 9°, 13° e 17° níveis. Uma vez que tenha adquirido uma magia de rastreador subterrâneo, ela conta como uma magia de patrulheiro para você, mas não conta na quantidade de magias de patrulheiro que você conhece. MAGIAS DO RASTREADOR SUBTERRÂNEO Nível de Patrulheiro Magias 3° disfarçar-se 5° truque de corda 9° glifo de vigilância 13° invisibilidade maior 17° similaridade ATAQUE EXTRA A partir do 5° nível, você pode atacar duas vezes, ao invés de uma, sempre que você realizar a ação de Ataque no seu turno. MENTE DE AÇO No 7° nível, você ganha proficiência em testes de resistência de Sabedoria. RAJADA DO RASTREADOR A partir do 11° nível, uma vez em cada um dos seus turnos quando você errar um ataque, você pode realizar outro ataque. ESQUIVA DO RASTREADOR No 15° nível, sempre que uma criatura atacar você e não tiver vantagem, você pode usar sua reação para impor desvantagem na jogada de ataque da criatura contra você. Você pode usar essa característica antes ou depois da jogada de ataque ser feita, mas deve ser usada antes do resultado da jogada ser determinado. "
            }
        );
        modelBuilder.Entity<HabilidadeRacial>().HasData(
        new HabilidadeRacial
        {
            IdHabilidadeRacial = 1,
            Nome = "Visão no Escuro",
            Descricao = "Acostumado à vida subterrânea ou às florestas crepusculares e ao céu noturno, você tem uma visão superior no escuro e na penumbra. Você enxerga na penumbra a até 18 metros como se fosse luz plena, e no escuro como se fosse na penumbra. Você não pode discernir cores no escuro, apenas tons de cinza."
        },
        new HabilidadeRacial
        {
            IdHabilidadeRacial = 2,
            Nome = "Resiliência Anã",
            Descricao = "Você possui vantagem em testes de resistência contra venenos e resistência contra dano de veneno"
        },
        new HabilidadeRacial
        {
            IdHabilidadeRacial = 3,
            Nome = "Treinamento Anão em Combate",
            Descricao = "Você tem proficiência com machados de batalha, machadinhas,martelos leves e martelos de guerra."
        },
        new HabilidadeRacial
        {
            IdHabilidadeRacial = 4,
            Nome = "Proficiência com Ferramentas",
            Descricao = "Você tem proficiência em uma ferramenta de artesão à sua escolha entre: ferramentas de ferreiro, suprimentos de cervejeiro ou ferramentas de pedreiro. "
        },
        new HabilidadeRacial
        {
            IdHabilidadeRacial = 5,
            Nome = "Especialização em Rochas",
            Descricao = "Sempre que você realizar um teste de Inteligência (História) relacionado à origem de um trabalho em pedra, você é considerado proficiente na perícia História e adiciona o dobro do seu bônus de proficiência ao teste, ao invés do seu bônus de proficiência normal."
        },
        new HabilidadeRacial
        {
            IdHabilidadeRacial = 6,
            Nome = "Tenacidade Anã",
            Descricao = "Seu máximo de pontos de vida aumentam em 1, e cada vez que o anão da colina sobe um nível, ele recebe 1 ponto de vida adicional."
        },
        new HabilidadeRacial
        {
            IdHabilidadeRacial = 7,
            Nome = "Treinamento Anão com Armaduras",
            Descricao = "Você adquire proficiência em armaduras leves e médias. "
        },
        new HabilidadeRacial
        {
            IdHabilidadeRacial = 8,
            Nome = "Sentidos Aguçados",
            Descricao = "Você tem proficiência na perícia Percepção."
        },
        new HabilidadeRacial
        {
            IdHabilidadeRacial = 9,
            Nome = "Ancestral Feérico",
            Descricao = "Você tem vantagem nos testes de resistência para resistir a ser enfeitiçado e magias não podem colocá-lo para dormir. "
        },
        new HabilidadeRacial
        {
            IdHabilidadeRacial = 10,
            Nome = "Transe",
            Descricao = "Elfos não precisam dormir. Ao invés disso, eles meditam profundamente, permanecendo semiconscientes, durante 4 horas por dia. (A palavra em idioma comum para tal meditação é 'transe'.) Enquanto medita, um elfo é capaz de sonhar de certo modo. Esses sonhos na verdade são exercícios mentais que se tornam reflexos através de anos de prática. Depois de descansar dessa forma, você ganha os mesmos benefícios que um humano depois de 8 horas de sono."
        },
        new HabilidadeRacial
        {
            IdHabilidadeRacial = 11,
            Nome = "Treinamento Élfico com Armas",
            Descricao = "Você possui proficiência com espadas longas, espadas curtas, arcos longos e arcos curtos. "
        },
        new HabilidadeRacial
        {
            IdHabilidadeRacial = 12,
            Nome = "Truque",
            Descricao = "Você conhece um truque, à sua escolha, da lista de truques do mago. Inteligência é a habilidade usado para conjurar este truque. "
        },
        new HabilidadeRacial
        {
            IdHabilidadeRacial = 13,
            Nome = "Idioma Adicional",
            Descricao = " Você pode falar, ler e escrever um idioma adicional à sua escolha."
        },
        new HabilidadeRacial
        {
            IdHabilidadeRacial = 14,
            Nome = "Pés Ligeiros",
            Descricao = "Seu deslocamento base de caminhada aumenta para 10,5 metros."
        },
        new HabilidadeRacial
        {
            IdHabilidadeRacial = 15,
            Nome = "Máscara da Natureza",
            Descricao = "Você pode tentar se esconder mesmo quando você está apenas levemente obscurecido por folhagem, chuva forte, neve caindo, névoa ou outro fenômeno natural. "
        },
        new HabilidadeRacial
        {
            IdHabilidadeRacial = 16,
            Nome = "Visão no Escuro Superior",
            Descricao = " Sua visão no escuro tem alcance de 36 metros de raio"
        },
        new HabilidadeRacial
        {
            IdHabilidadeRacial = 17,
            Nome = "Sensibilidade à Luz Solar",
            Descricao = "Você possui desvantagem nas jogadas de ataque e testes de Sabedoria (Percepção) relacionados a visão quando você, o alvo do seu ataque, ou qualquer coisa que você está tentando perceber, esteja sob luz solar direta. "
        },
        new HabilidadeRacial
        {
            IdHabilidadeRacial = 18,
            Nome = "Magia Drow",
            Descricao = ". Você possui o truque globos de luz. Quando você alcança o 3° nível, você pode conjurar a magia fogo das fadas. Quando você alcança o 5° nível, você pode conjurar escuridão. Você precisa terminar um descanso longo para poder conjurar as magias desse traço novamente. Carisma é sua habilidade chave para conjurar essas magias. "
        },
        new HabilidadeRacial
        {
            IdHabilidadeRacial = 19,
            Nome = "Treinamento Drow com Armas",
            Descricao = "Você possui proficiência com rapieiras, espadas curtas e bestas de mão. "
        },
        new HabilidadeRacial
        {
            IdHabilidadeRacial = 20,
            Nome = "Sortudo",
            Descricao = "Quando você obtiver um 1 natural em uma jogada de ataque, teste de habilidade ou teste de resistência, você pode jogar de novo o dado e deve utilizar o novo resultado"
        },
        new HabilidadeRacial
        {
            IdHabilidadeRacial = 21,
            Nome = "Bravura",
            Descricao = "Você tem vantagem em testes de resistência contra ficar amedrontado"
        },
        new HabilidadeRacial
        {
            IdHabilidadeRacial = 22,
            Nome = "Agilidade Halfling",
            Descricao = "Você pode mover-se através do espaço de qualquer criatura que for de um tamanho maior que o seu"
        },
        new HabilidadeRacial
        {
            IdHabilidadeRacial = 23,
            Nome = "Furtividade Natural",
            Descricao = "Você pode tentar se esconder mesmo quando possuir apenas a cobertura de uma criatura que for no mínimo um tamanho maior que o seu"
        },
        new HabilidadeRacial
        {
            IdHabilidadeRacial = 24,
            Nome = "Resiliência dos Robustos",
            Descricao = "Você tem vantagem em testes de resistência contra veneno e tem resistência contra dano de veneno"
        },
        new HabilidadeRacial
        {
            IdHabilidadeRacial = 25,
            Nome = "Ancestral Dracônico",
            Descricao = "Você possui um ancestral dracônico. Escolha um tipo de dragão da tablea Ancestral Dracônico. sua arma de sopro e resistência a dano são determinadas pelo tipo de dragão, como mostrado na tabela"
        },
        new HabilidadeRacial
        {
            IdHabilidadeRacial = 26,
            Nome = "Arma de Sopro",
            Descricao = "Você pode usar uma ação para exalar energia destrutiva. Seu ancestral dracônico determina o tamanho, formado e tipo de dano que você expele.Quando você usa sua arma de sopro, cada criatura na área exalada deve realizar um teste de resistência, o tipo do teste é determinado pelo seu ancestral dracônico. A CD do teste de resistência é 8 + seu modificador de Constituição + seu bônus de proficiência. Uma criatura sofre 2d6 de dano num fracasso e metade desse dano num sucesso. O dano aumenta para 3d6 no 6° nível, 4d6 no 11° nível e 5d6 no 16° nível. Depois de usar sua arma de sopro, você não poderá utilizá-la novamente até completar um descanso curto ou longo. "
        },
        new HabilidadeRacial
        {
            IdHabilidadeRacial = 27,
            Nome = "Resistência a Dano",
            Descricao = "Você possui resistência ao tipo de dano associado ao seu ancestral dracônico"
        },
        new HabilidadeRacial
        {
            IdHabilidadeRacial = 28,
            Nome = "Esperteza Gnômica",
            Descricao = "Você possui vantagem em todos os testes de resistência de Inteligência, Sabedoria e Carisma contra magia"
        },
        new HabilidadeRacial
        {
            IdHabilidadeRacial = 29,
            Nome = "Ilusionista Nato",
            Descricao = "Você conhece o truque ilusão menor. Inteligência é a sua habilidade usada para cunjurá-la"
        },
        new HabilidadeRacial
        {
            IdHabilidadeRacial = 30,
            Nome = "Falar com Bestas Pequenas",
            Descricao = "Através de sons e gestos, você pode comunicar ideias simples para Bestas pequenas ou menores. Gnomos da floresta amam os animais e normalmente possuem esquilos, doninhas, coelhos, toupeiras, pica-paus e outras criaturas como amados animais de estimação. "
        },
        new HabilidadeRacial
        {
            IdHabilidadeRacial = 31,
            Nome = "Conhecimento de Artífice",
            Descricao = "Toda vez que você fizer um teste de Inteligência (História) relacionado a itens mágicos, objetos alquímicos ou mecanismos tecnológicos, você pode adicionar o dobro do seu bônus de proficiência, ao invés de qualquer bônus de proficiência que você normalmente use. "
        },
        new HabilidadeRacial
        {
            IdHabilidadeRacial = 32,
            Nome = "Engenhoqueiro",
            Descricao = "Você possui proficiência com ferramentas de artesão (ferramentas de engenhoqueiro). Usando essas ferramentas, você pode gastar 1 hora e 10 po em materiais para construir um mecanismo Miúdo (CA 5, 1 pv). O mecanismo para de funcionar após 24 horas (a não ser que você gaste 1 hora reparando-o para manter o mecanismo funcionando), ou quando você usa sua ação para desmantelá-lo; nesse momento, você pode recuperar o material usado para criá-lo. Você pode ter até três desses mecanismos ativos ao mesmo tempo. Quando você criar um mecanismo, escolha uma das seguintes opções: Brinquedo Mecânico. Esse brinquedo é um animal, monstro ou pessoa mecânica, como um sapo, rato, pássaro, dragão ou soldado. Quando colocado no chão, o brinquedo se move 1,5 metro pelo chão em cada um dos seus turnos em uma direção aleatória. Ele faz barulhos apropriados a criatura que ele representa. Isqueiro Mecânico. O mecanismo produz uma miniatura de chama, que você pode usar para acender uma vela, tocha ou fogueira. Usar o mecanismo requer sua ação. Caixa de Música. Quando aberta, essa caixa de música toca uma canção a um volume moderado. A caixa para de tocar quando alcança o fim da música ou quando é fechada."
        },
        new HabilidadeRacial
        {
            IdHabilidadeRacial = 33,
            Nome = "Versatilidade em Perícia",
            Descricao = "Você ganha proficiência em duas perícias, à sua escolha"
        },
        new HabilidadeRacial
        {
            IdHabilidadeRacial = 34,
            Nome = "Ameaçador",
            Descricao = "Você adquire proficiência na perícia Intimidação"
        },
        new HabilidadeRacial
        {
            IdHabilidadeRacial = 35,
            Nome = "Resistência Implacável",
            Descricao = "Quando você é reduzido a 0 pontos de vida mas não é completamente morto, você pode voltar para 1 ponto de vida. você não pode usar essa característica novamente até completar um descanso longo."
        },
        new HabilidadeRacial
        {
            IdHabilidadeRacial = 36,
            Nome = "Ataques Selvagens",
            Descricao = "Quando você atinge um ataque crítico com uma arma corpo-a-corpo, você pode rolar um dos dados de dano da arma mais uma vez e adicioná-lo ao dano extra causado pelo crítico"
        },
        new HabilidadeRacial
        {
            IdHabilidadeRacial = 37,
            Nome = "Resistência Infernal",
            Descricao = "Você possui resistência a dano do fogo"
        },
        new HabilidadeRacial
        {
            IdHabilidadeRacial = 38,
            Nome = "Legado Infernal",
            Descricao = "Você conhece o truque taumaturgia. Quando você atingir o 3° nível, você poderá conjurar a magia repreensão infernal como uma magia de 2° nível. Quando você atingir o 5° nível, você também poderá conjurar a magia escuridão. Você precisa terminar um descanso longo para poder usar as magias desse traço novamente. Sua habilidade de conjuração para essas magias é Carisma. "
        }
    );
        modelBuilder.Entity<TipoIdioma>().HasData(
        new TipoIdioma
        {
            IdTipoIdioma = 1,
            Tipo = "Padrão"
        },
        new TipoIdioma
        {
            IdTipoIdioma = 2,
            Tipo = "Exótico"
        }
        );
        modelBuilder.Entity<Idioma>().HasData(
        new Idioma
        {
            IdIdioma = 1,
            Nome = "Anão",
            FaladoPor = "Anões",
            Alfabeto = "Anão",
            IdTipoIdioma = 1
        },
        new Idioma
        {
            IdIdioma = 2,
            Nome = "Comum",
            FaladoPor = "Humanos",
            Alfabeto = "Comum",
            IdTipoIdioma = 1
        },
        new Idioma
        {
            IdIdioma = 3,
            Nome = "Élfico",
            FaladoPor = "Elfos",
            Alfabeto = "Élfico",
            IdTipoIdioma = 1
        },
        new Idioma
        {
            IdIdioma = 4,
            Nome = "Gigante",
            FaladoPor = "Ogros, gigantes",
            Alfabeto = "Anão",
            IdTipoIdioma = 1
        },
        new Idioma
        {
            IdIdioma = 5,
            Nome = "Gnômico",
            FaladoPor = "Gnomos",
            Alfabeto = "Anão",
            IdTipoIdioma = 1
        },
        new Idioma
        {
            IdIdioma = 6,
            Nome = "Goblin",
            FaladoPor = "Goblinoides",
            Alfabeto = "Anão",
            IdTipoIdioma = 1
        },
        new Idioma
        {
            IdIdioma = 7,
            Nome = "Halfling",
            FaladoPor = "Halfings",
            Alfabeto = "Comum",
            IdTipoIdioma = 1
        },
        new Idioma
        {
            IdIdioma = 8,
            Nome = "Orc",
            FaladoPor = "Orcs",
            Alfabeto = "Anão",
            IdTipoIdioma = 1
        },
        new Idioma
        {
            IdIdioma = 9,
            Nome = "Abissal",
            FaladoPor = "Demônios",
            Alfabeto = "Infernal",
            IdTipoIdioma = 2
        },
        new Idioma
        {
            IdIdioma = 10,
            Nome = "Celestial",
            FaladoPor = "Celestiais",
            Alfabeto = "Celestial",
            IdTipoIdioma = 2
        },
        new Idioma
        {
            IdIdioma = 11,
            Nome = "Dialeto Subterrâneo",
            FaladoPor = "Devoradores de mente, Observadores",
            Alfabeto = "-",
            IdTipoIdioma = 2
        },
        new Idioma
        {
            IdIdioma = 12,
            Nome = "Dracônico",
            FaladoPor = "Dragões, Draconatos",
            Alfabeto = "Dracônico",
            IdTipoIdioma = 2
        },
        new Idioma
        {
            IdIdioma = 13,
            Nome = "Infernal",
            FaladoPor = "Diabos",
            Alfabeto = "Infernal",
            IdTipoIdioma = 2
        },
        new Idioma
        {
            IdIdioma = 14,
            Nome = "Primordial",
            FaladoPor = "Elementais",
            Alfabeto = "Anão",
            IdTipoIdioma = 2
        },
        new Idioma
        {
            IdIdioma = 15,
            Nome = "Silvestre",
            FaladoPor = "Criaturas feéricas",
            Alfabeto = "Élfico",
            IdTipoIdioma = 2
        },
        new Idioma
        {
            IdIdioma = 16,
            Nome = "Subcomum",
            FaladoPor = "Comerciantes do Subterrâneo",
            Alfabeto = "Élfico",
            IdTipoIdioma = 2
        }
    );
        modelBuilder.Entity<Item>().HasData(
        new Item
        {
            IdItem = 1,
            Nome = "Ábaco",
            Peso = "1 Kg",
            Preco = "2 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 2,
            Nome = "Ácido (vidro)",
            Peso = "0.5 Kg",
            Preco = "25 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 3,
            Nome = "Água Benta (frasco)",
            Peso = "0.5 Kg",
            Preco = "25 Peças de Ouro",
            Descricao = "Usando uma ação, você pode espalhar o conteúdo desse frasco em uma criatura a até 1,5 metro de você ou arremessar a até 6 metros, quebrando o frasco com o impacto. Em ambos os casos, você deve realizar um ataque à distância contra uma criatura alvo, tratando a água benta como uma arma improvisada. Se o alvo for um corruptor ou morto-vivo, ele sofre 2d6 de dano radiante. Um clérigo ou paladino pode criar água benta realizando um ritual especial. O ritual leva 1 hora para ser realizado, consome 25 po de prata em pó e exige que se gaste um espaço de magia de 1º nível. "
        },
        new Item
        {
            IdItem = 4,
            Nome = "Algemas",
            Peso = "2 Kg",
            Preco = "2 Peças de Ouro",
            Descricao = " Essas algemas de metal podem prender uma criatura Pequena ou Média. Escapar das algemas exige sucesso em um teste de Destreza CD 20. Quebrá-las exige um teste de Força CD 20 bem sucedido. Cada conjunto de algemas vem com uma chave. Sem a chave, uma criatura proficiente com ferramentas de ladrão pode abrir a fechadura das algemas com um sucesso em um teste de Destreza CD 15. As algemas têm 15 pontos de vida. "
        },
        new Item
        {
            IdItem = 5,
            Nome = "Algibeira",
            Peso = "0.5 Kg",
            Preco = "5 Peças de Ouro",
            Descricao = " Uma bolsa de pano ou couro que pode armazenar até 20 munições de funda ou 50 munições de zarabatana, entre outras coisas. Para armazenar componentes de magia, veja bolsa de componentes, também descrita nessa seção. "
        },
        new Item
        {
            IdItem = 6,
            Nome = "Aljava",
            Peso = "0.5 Kg",
            Preco = "1 Peça de Ouro",
            Descricao = " Uma aljava pode guardar até 20 flechas."
        },
        new Item
        {
            IdItem = 7,
            Nome = "Ampulheta",
            Peso = "0.5 Kg",
            Preco = "25 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 8,
            Nome = "Antídoto",
            Peso = "0.5 Kg",
            Preco = "50 Peças de Ouro",
            Descricao = "Uma criatura que beber o líquido desse vidro tem vantagem em testes de resistência contra venenos por 1 hora. O antídoto não confere nenhum benefício para mortos-vivos ou constructos. "
        },
        new Item
        {
            IdItem = 9,
            Nome = "Apito de advertência",
            Peso = "0.5 Kg",
            Preco = "25 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 10,
            Nome = "Aríete portátil",
            Peso = "17.5 Kg",
            Preco = "4 Peças de Ouro",
            Descricao = "Você pode usar um aríete portátil para quebrar portas. Ao fazer isso, você ganha um bônus de +4 no teste de Força. Outra criatura pode ajudá-lo a usar o aríete, o que concede vantagem no teste. "
        },
        new Item
        {
            IdItem = 11,
            Nome = "Armadilha de caça",
            Peso = "12.5 Kg",
            Preco = "5 Peças de Ouro",
            Descricao = "Quando você usa sua ação para armá-la, essa armadilha forma um anel de aço com dentes serrilhados. Eles se fecham quando uma criatura pisa sobre uma placa de pressão no seu centro. A armadilha é fixada por uma pesada corrente em um objeto fixo e imóvel, como uma árvore ou um cravo enterrado no chão. Uma criatura que pisar na placa de pressão deve ser bem sucedida em um teste de resistência de Destreza CD 13 ou sofrerá 1d4 de dano perfurante e para de se mover. Daí em diante, até que a criatura se liberte da armadilha, seu movimento é limitado ao comprimento da corrente (tipicamente 1 metro de comprimento). A criatura presa pode usar sua ação para fazer um teste de Força CD 13 e se libertar, ou outra criatura no alcance pode fazer o teste para libertá-la. Cada fracasso no teste causa 1 de dano perfurante à criatura presa. "
        },
        new Item
        {
            IdItem = 12,
            Nome = "Arpéu",
            Peso = "2 Kg",
            Preco = "2 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 13,
            Nome = "Balança de mercador",
            Peso = "1.5 Kg",
            Preco = "5 Peças de Ouro",
            Descricao = "Trata-se de uma pequena balança, pratos e um sortimento adequado de pesos de até 1 kg. Com ela, você pode medir o peso exato de pequenos objetos, como metais preciosos brutos ou bens comerciais, para ajudar a determinar seu valor. "
        },
        new Item
        {
            IdItem = 14,
            Nome = "Balde",
            Peso = "1.5 Kg",
            Preco = "5 Peças de Cobre",
            Descricao = ""
        },
        new Item
        {
            IdItem = 15,
            Nome = "Barril",
            Peso = "35 Kg",
            Preco = "2 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 16,
            Nome = "Baú",
            Peso = "12.5 Kg",
            Preco = "5 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 17,
            Nome = "Bolsa de componentes",
            Peso = "1 Kg",
            Preco = "25 Peças de Ouro",
            Descricao = "Trata-se de uma pequena bolsa de couro à prova d'água que pode ser fixada em um cinto. Ela possui compartimentos para armazenar todos os componentes materiais e outros itens especiais que você precisa para lançar suas magias, exceto os componentes que possuem um custo específico (conforme indicado na descrição da magia)."
        },
        new Item
        {
            IdItem = 18,
            Nome = "Caixa de Fogo",
            Peso = "0.5 Kg",
            Preco = "5 Peças de Prata",
            Descricao = "Esse pequeno recipiente detém uma pederneira, isqueiro e um pavio (um pano geralmente seco embebido em óleo) usado para acender uma fogueira. Usá-lo para acender uma tocha – ou qualquer outra coisa exposta a um combustível abundante – leva uma ação. Acender qualquer outro fogo leva 1 minuto "
        },
        new Item
        {
            IdItem = 19,
            Nome = "Caneca",
            Peso = "0.5 Kg",
            Preco = "2 Peças de Cobre",
            Descricao = ""
        },
        new Item
        {
            IdItem = 20,
            Nome = "Caneta Tinteiro",
            Peso = "",
            Preco = "2 Peças de Cobre",
            Descricao = ""
        },
        new Item
        {
            IdItem = 21,
            Nome = "Cantil",
            Peso = "2.5 Kg",
            Preco = "2 Peças de Prata",
            Descricao = ""
        },
        new Item
        {
            IdItem = 22,
            Nome = "Cesto",
            Peso = "1 Kg",
            Preco = "4 Peças de Prata",
            Descricao = ""
        },
        new Item
        {
            IdItem = 23,
            Nome = "Cobertor de inverno",
            Peso = "1.5 Kg",
            Preco = "5 Peças de Prata",
            Descricao = ""
        },
        new Item
        {
            IdItem = 24,
            Nome = "Corda de cânhamo (15 metros)",
            Peso = "5 Kg",
            Preco = "1 Peça de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 25,
            Nome = "Corda de seda (15 metros)",
            Peso = "2.5 Kg",
            Preco = "10 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 26,
            Nome = "Corrente",
            Peso = "5 Kg",
            Preco = "5 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 27,
            Nome = "Equipamento de pescaria",
            Peso = "2 Kg",
            Preco = "1 Peça Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 28,
            Nome = "Escadas",
            Peso = "12.5 Kg",
            Preco = "1 Peça Prata",
            Descricao = ""
        },
        new Item
        {
            IdItem = 29,
            Nome = "Esferas (sacola com 1000)",
            Peso = "1 Kg",
            Preco = "1 Peça de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 30,
            Nome = "Espelho de aço",
            Peso = "0.25 Kg",
            Preco = "5 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 31,
            Nome = "Estrepes (bolsa com 20)",
            Peso = "1 Kg",
            Preco = "1 Peça de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 32,
            Nome = "Fechadura",
            Peso = "0.5 Kg",
            Preco = "10 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 33,
            Nome = "Bastão",
            Peso = "1 Kg",
            Preco = "10 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 34,
            Nome = "Cajado",
            Peso = "2 Kg",
            Preco = "5 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 35,
            Nome = "Cristal",
            Peso = "0.5 Kg",
            Preco = "10 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 36,
            Nome = "Orbe",
            Peso = "1.5 Kg",
            Preco = "20 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 37,
            Nome = "Varinha",
            Peso = "0.5 Kg",
            Preco = "10 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 38,
            Nome = "Cajado de madeira",
            Peso = "2 Kg",
            Preco = "5 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 39,
            Nome = "Ramo de visco",
            Peso = "-",
            Preco = "1 Peça de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 40,
            Nome = "Totem",
            Peso = "-",
            Preco = "1 Peça de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 41,
            Nome = "Varinha de teixo",
            Peso = "0.5 Kg",
            Preco = "10 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 42,
            Nome = "Fogo alquímico (frasco)",
            Peso = "0.5 Kg",
            Preco = "50 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 43,
            Nome = "Frasco",
            Peso = "1 Kg",
            Preco = "2 Peças de Cobre",
            Descricao = ""
        },
        new Item
        {
            IdItem = 44,
            Nome = "Garrafa de vidro",
            Peso = "1 Kg",
            Preco = "1 Peça de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 45,
            Nome = "Giz (1 peça)",
            Peso = "-",
            Preco = "1 Peça de Cobre",
            Descricao = ""
        },
        new Item
        {
            IdItem = 46,
            Nome = "Grimório",
            Peso = "1.5 Kg",
            Preco = "50 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 47,
            Nome = "Jarra",
            Peso = "2 Kg",
            Preco = "4 Peças de Cobre",
            Descricao = ""
        },
        new Item
        {
            IdItem = 48,
            Nome = "Kit de escalada",
            Peso = "6 Kg",
            Preco = "25 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 49,
            Nome = "Kit de primeiros-socorros",
            Peso = "1.5 Kg",
            Preco = "5 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 50,
            Nome = "Lâmpada",
            Peso = "0.5 Kg",
            Preco = "5 Peças de Prata",
            Descricao = ""
        },
        new Item
        {
            IdItem = 51,
            Nome = "Lanterna coberta",
            Peso = "1 Kg",
            Preco = "5 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 52,
            Nome = "Lanterna furta-fogo",
            Peso = "1 Kg",
            Preco = "10 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 53,
            Nome = "Lente de aumento",
            Peso = "-",
            Preco = "100 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 54,
            Nome = "Livro",
            Peso = "2.5 Kg",
            Preco = "25 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 55,
            Nome = "Luneta",
            Peso = "0.5 Kg",
            Preco = "1000 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 56,
            Nome = "Manto",
            Peso = "2 Kg",
            Preco = "1 Peça de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 57,
            Nome = "Marreta",
            Peso = "5 Kg",
            Preco = "2 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 58,
            Nome = "Martelo",
            Peso = "1.5 Kg",
            Preco = "1 Peça de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 59,
            Nome = "Mochila",
            Peso = "2.5 Kg",
            Preco = "2 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 60,
            Nome = "Balas de Funda (20)",
            Peso = "0.75 Kg",
            Preco = "4 Peças de Cobre",
            Descricao = ""
        },
        new Item
        {
            IdItem = 61,
            Nome = "Flechas (20)",
            Peso = "0.5 Kg",
            Preco = "1 Peça de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 62,
            Nome = "Virotes (20)",
            Peso = "0.75 Kg",
            Preco = "1 Peça de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 63,
            Nome = "Zarabatana (20)",
            Peso = "0.5 Kg",
            Preco = "1 Peça de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 64,
            Nome = "Óleo (frasco)",
            Peso = "0.5 Kg",
            Preco = "1 Peça de Prata",
            Descricao = ""
        },
        new Item
        {
            IdItem = 65,
            Nome = "Pá",
            Peso = "2.5 Kg",
            Preco = "2 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 66,
            Nome = "Panela de Ferro",
            Peso = "5 Kg",
            Preco = "2 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 67,
            Nome = "Papel (uma folha)",
            Peso = "-",
            Preco = "2 Peças de Prata",
            Descricao = ""
        },
        new Item
        {
            IdItem = 68,
            Nome = "Parafina",
            Peso = "-",
            Preco = "5 Peças de Prata",
            Descricao = ""
        },
        new Item
        {
            IdItem = 69,
            Nome = "Pé de cabra",
            Peso = "2.5 Kg",
            Preco = "2 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 70,
            Nome = "Pedra de amolar",
            Peso = "-",
            Preco = "1 Peça de Cobre",
            Descricao = ""
        },
        new Item
        {
            IdItem = 71,
            Nome = "Perfume (frasco)",
            Peso = "-",
            Preco = "5 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 72,
            Nome = "Pergaminho (uma folha",
            Peso = "-",
            Preco = "1 Peça de Prata",
            Descricao = ""
        },
        new Item
        {
            IdItem = 73,
            Nome = "Picareta de minerador",
            Peso = "5 Kg",
            Preco = "2 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 74,
            Nome = "Píton",
            Peso = "-",
            Preco = "5 Peças de Cobre",
            Descricao = ""
        },
        new Item
        {
            IdItem = 75,
            Nome = "Poção de Cura",
            Peso = "0.25 Kg",
            Preco = "50 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 76,
            Nome = "Porta mapas ou pergaminhos",
            Peso = "0.5 Kg",
            Preco = "1 Peça de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 77,
            Nome = "Porta virotes",
            Peso = "0.5 Kg",
            Preco = "1 Peça de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 78,
            Nome = "Pregos de ferro (10)",
            Peso = "2.5 Kg",
            Preco = "1 Peça de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 79,
            Nome = "Rações de viagem (1 dia)",
            Peso = "1 Kg",
            Preco = "5 Peças de Prata",
            Descricao = ""
        },
        new Item
        {
            IdItem = 80,
            Nome = "Robes",
            Peso = "2 Kg",
            Preco = "1 Peça de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 81,
            Nome = "Roldana e polia",
            Peso = "2.5 Kg",
            Preco = "2 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 82,
            Nome = "Roupas comuns",
            Peso = "1.5 Kg",
            Preco = "5 Peças de Prata",
            Descricao = ""
        },
        new Item
        {
            IdItem = 83,
            Nome = "Roupas de viajante",
            Peso = "2 Kg",
            Preco = "2 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 84,
            Nome = "Roupas de entretenimento",
            Peso = "2 Kg",
            Preco = "5 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 85,
            Nome = "Roupas finas",
            Peso = "3 Kg",
            Preco = "15 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 86,
            Nome = "Sabão",
            Peso = "-",
            Preco = "1 Peças de Cobre",
            Descricao = ""
        },
        new Item
        {
            IdItem = 87,
            Nome = "Saco",
            Peso = "0.25 Kg",
            Preco = "1 Peça de Cobre",
            Descricao = ""
        },
        new Item
        {
            IdItem = 88,
            Nome = "Saco de dormir",
            Peso = "3.5 Kg",
            Preco = "1 Peça de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 89,
            Nome = "Amuleto",
            Peso = "0.5 Kg",
            Preco = "5 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 90,
            Nome = "Emblema",
            Peso = "-",
            Preco = "5 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 91,
            Nome = "Relicário",
            Peso = "1 Kg",
            Preco = "5 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 92,
            Nome = "Sinete",
            Peso = "-",
            Preco = "5 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 93,
            Nome = "Sino",
            Peso = "-",
            Preco = "1 Peça de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 94,
            Nome = "Tenda para duas pessoas",
            Peso = "10 Kg",
            Preco = "2 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 95,
            Nome = "Tocha",
            Peso = "0.5 Kg",
            Preco = "1 Peça de Cobre",
            Descricao = ""
        },
        new Item
        {
            IdItem = 96,
            Nome = "Tinta (frasco de 30 ml)",
            Peso = "-",
            Preco = "10 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 97,
            Nome = "Vara (3 metros)",
            Peso = "3.5 Kg",
            Preco = "5 Peças de Cobre",
            Descricao = ""
        },
        new Item
        {
            IdItem = 98,
            Nome = "Vela",
            Peso = "-",
            Preco = "1 Peça de Cobre",
            Descricao = ""
        },
        new Item
        {
            IdItem = 99,
            Nome = "Veneno básico (frasco)",
            Peso = "-",
            Preco = "100 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 100,
            Nome = "Ferramentas de carpinteiro",
            Peso = "3 Kg",
            Preco = "8 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 101,
            Nome = "Ferramentas de cartógrafo",
            Peso = "3 Kg",
            Preco = "15 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 102,
            Nome = "Ferramentas de costureiro",
            Peso = "2.5 Kg",
            Preco = "5 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 103,
            Nome = "Ferramentas de entalhador",
            Peso = "2.5 Kg",
            Preco = "1 Peça de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 104,
            Nome = "Ferramentas de ferreiro",
            Peso = "4 Kg",
            Preco = "20 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 105,
            Nome = "Ferramentas de funileiro",
            Peso = "5 Kg",
            Preco = "50 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 106,
            Nome = "Ferramentas de joalheiro",
            Peso = "1 Kg",
            Preco = "25 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 107,
            Nome = "Ferramentas de oleiro",
            Peso = "1.5 Kg",
            Preco = "10 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 108,
            Nome = "Ferramentas de pedreiro",
            Peso = "4 Kg",
            Preco = "10 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 109,
            Nome = "Ferramentas de pintor",
            Peso = "2.5 Kg",
            Preco = "10 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 110,
            Nome = "Ferramentas de sapateiro",
            Peso = "2.5 Kg",
            Preco = "5 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 111,
            Nome = "Ferramentas de vidreiro",
            Peso = "2.5 Kg",
            Preco = "30 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 112,
            Nome = "Suprimentos de alquimista",
            Peso = "4 Kg",
            Preco = "50 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 113,
            Nome = "Suprimentos de cervejeiro",
            Peso = "4.5 Kg",
            Preco = "20 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 114,
            Nome = "Suprimentos de caligrafia",
            Peso = "2.5 Kg",
            Preco = "10 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 115,
            Nome = "Utensílios de cozinheiro",
            Peso = "4 Kg",
            Preco = "1 Peça de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 116,
            Nome = "Ferramentas de navegação",
            Peso = "1 Kg",
            Preco = "25 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 117,
            Nome = "Ferramentas de ladrão",
            Peso = "0.5 Kg",
            Preco = "25 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 118,
            Nome = "Alaúde",
            Peso = "1 Kg",
            Preco = "35 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 119,
            Nome = "Flauta",
            Peso = "0.5 Kg",
            Preco = "2 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 120,
            Nome = "Flauta de pã",
            Peso = "1 Kg",
            Preco = "12 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 121,
            Nome = "Gaita de foles",
            Peso = "3 Kg",
            Preco = "30 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 122,
            Nome = "Lira",
            Peso = "1 Kg",
            Preco = "30 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 123,
            Nome = "Oboé",
            Peso = "0.5 Kg",
            Preco = "2 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 124,
            Nome = "Tambor",
            Peso = "1.5 Kg",
            Preco = "6 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 125,
            Nome = "Trombeta",
            Peso = "1 Kg",
            Preco = "3 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 126,
            Nome = "Violino",
            Peso = "3 Kg",
            Preco = "30 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 127,
            Nome = "Xilofone",
            Peso = "5 Kg",
            Preco = "25 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 128,
            Nome = "Kit de disfarce",
            Peso = "1.5 Kg",
            Preco = "25 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 129,
            Nome = "Kit de falsificação",
            Peso = "2.5 Kg",
            Preco = "15 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 130,
            Nome = "Kit de herbalismo",
            Peso = "1.5 Kg",
            Preco = "5 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 131,
            Nome = "Baralho de cartas",
            Peso = "-",
            Preco = "5 Peças de Prata",
            Descricao = ""
        },
        new Item
        {
            IdItem = 132,
            Nome = "Conjunto de dados",
            Peso = "-",
            Preco = "1 Peça de Prata",
            Descricao = ""
        },
        new Item
        {
            IdItem = 133,
            Nome = "Jogo dos três dragões",
            Peso = "-",
            Preco = "5 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 134,
            Nome = "Xadrez do dragão",
            Peso = "0.25 Kg",
            Preco = "1 Peça de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 135,
            Nome = "Kit de venenos",
            Peso = "1 Kg",
            Preco = "50 Peças de Ouro",
            Descricao = ""
        },
        new Item
        {
            IdItem = 136,
            Nome = "Pacote de Artista",
            Peso = "-",
            Preco = "40 Peças de Ouro",
            Descricao = "Mochila; saco de dormir; duas fantasias; 5 velas; 5 dias de rações; cantil; kit de disfarce"
        },
        new Item
        {
            IdItem = 137,
            Nome = "Pacote de Assaltante",
            Peso = "-",
            Preco = "16 Peças de Ouro",
            Descricao = "Mochila; saco com 1000 esferas de metal; 3 metros de linha; sino; 5 velas; pé de cabra; martelo; 10 pítons; lanterna coberta; 2 fascos de óleo; 5 dias de ração; caixa de fogo; cantil; 15 metros de corda de cânhamo"
        },
        new Item
        {
            IdItem = 138,
            Nome = "Pacote de Aventureiro",
            Peso = "-",
            Preco = "12 Peças de Ouro",
            Descricao = "Mochila; pé de cabra; martelo; 10 pítons; 10 tochas; caixa de fogo; 10 dias de rações; cantil; 15 metros de corda de cânhamo"
        },
        new Item
        {
            IdItem = 139,
            Nome = "Pacote de Diplomata",
            Peso = "-",
            Preco = "39 Peças de Ouro",
            Descricao = "Baú; 2 caixas para mapas ou pergaminhos; conjunto de roupas finas; vidro de tinta; caneta tinteiro; lâmpada; 2 frascos de óleo; 5 folhas de papel; vidro de perfume; parafina; sabão"
        },
        new Item
        {
            IdItem = 140,
            Nome = "Pacote de Estudioso",
            Peso = "-",
            Preco = "40 Peças de Ouro",
            Descricao = "Mochila; livro de estudo; vidro de tinta; caneta tinteiro; 10 folhas de pergaminho; saquinho de areia; pequena faca"
        },
        new Item
        {
            IdItem = 141,
            Nome = "Pacote de Explorador",
            Peso = "-",
            Preco = "10 Peças de Ouro",
            Descricao = "Mochila; saco de dormir; kit de refeição; caixa de fogo; 10 tochas; 10 dias de rações; cantil; 15 metros de corda de cânhamo"
        },
        new Item
        {
            IdItem = 142,
            Nome = "Pacote de Sacerdote",
            Peso = "-",
            Preco = "19 Peças de Ouro",
            Descricao = "Mochila; cobertor; 10 velas; caixa de fogo; caixa de esmola; 2 blocos de incenso; incensário; vestes; 2 dias de rações; cantil"
        }

        );
        modelBuilder.Entity<TipoMagia>().HasData(
            new TipoMagia
            {
                IdTipoMagia = 1,
                Tipo = "Truque"
            },
            new TipoMagia
            {
                IdTipoMagia = 2,
                Tipo = "Ciclo"
            }
        );

        modelBuilder.Entity<Magia>().HasData(
        new Magia
        {
            IdMagia = 1,
            Nome = "Acalmar Emoções",
            Escola = "Encantamento",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático",
            Descricao = "Você tenta suprimir emoções fortes em um grupo de pessoas.Cada humanoide em uma esfera de 6 metros de raio, centrada em um ponto que você escolher dentro do alcance, deve realizar um teste de resistência de Carisma; uma criatura pode escolher falhar nesse teste, se desejar. Se uma criatura falhar na resistência, escolha um dentre os dois efeitos a seguir. Você pode suprimir qualquer efeito que esteja deixando a criatura enfeitiçada ou amedrontada.Quando essa magia terminar, qualquer efeito suprimido volta a funcionar, considerando que sua duração não tenha acabado nesse meio tempo. Alternativamente, você pode tornar um alvo indiferente às criaturas que você escolher que forem hostis a ele. Essa indiferença acaba se o alvo for atacado ou ferido por uma magia ou se ele testemunhar qualquer dos seus amigos sendo ferido.Quando a magia terminar, a criatura se tornará hostil novamente, a não ser que o Mestre diga o contrário. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 2,
            Nome = "Adivinhação",
            Escola = "Adivinhação (ritual)",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático, Material  (incenso e uma oferenda apropriada para sacrifício à sua religião, juntos valendo, no mínimo, 25 po, consumidos pela magia)",
            Descricao = "Sua magia e uma oferenda colocam você em contato com um deus ou servo divino. Você faz uma única pergunta a respeito de um objetivo, evento ou atividade específico que irá ocorrer dentro de 7 dias. O Mestre oferece uma resposta confiável. A resposta deve ser uma frase curta, uma rima enigmática ou um presságio. A magia não leva em consideração qualquer possível circunstância que possa mudar o que está por vir, como a conjuração de magias adicionais ou a perda ou ganho de um companheiro. Se você conjurar a magia duas ou mais vezes antes de completar seu próximo descanso longo, existe uma chance cumulativa de 25 por cento de cada conjuração, depois da primeira que você fez, ter um resultado aleatório. O Mestre faz essa jogada secretamente. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 3,
            Nome = "Ajuda",
            Escola = "Abjuração",
            Alcance = "9 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "8 horas",
            Componente = "Verbal, Somático, Material  (uma pequena fita de tecido branco)",
            Descricao = "Sua magia inspira seus aliados com vigor e determinação. Escolha até três criaturas dentro do alcance. O máximo de pontos de vida e os pontos de vida atuais de cada alvo aumentam em 5, pela duração. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 3° nível ou superior, os pontos de vida dos alvos aumentam em 5 pontos adicionais para cada nível do espaço acima do o 2°. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 4,
            Nome = "Alarme",
            Escola = "Abjuração (ritual)",
            Alcance = "9 metros",
            TempodeConjuracao = "1 minuto",
            Duracao = "8 horas",
            Componente = "Verbal, Somático, Material (um pequeno sino e um pequeno fio de prata) ",
            Descricao = "Você coloca um alarme para intrusos desavisados. Escolha uma porta, uma janela ou uma área dentro do alcance que não seja maior que 6 metros cúbicos. Até a magia acabar, um alarme alerta você sempre que uma criatura Miúda ou maior tocarem ou entrarem na área protegida. Quando você conjura a magia, você pode designar as criaturas que não ativarão o alarme. Você também escolhe se o alarme será mental ou audível. Um alarme mental alerta você com um silvo na sua mente, se você estiver a até de 1,5 quilômetro da área protegida. Esse silvo acordará você se você estiver dormindo. Um alarme audível produz o som de um sino de mão por 10 minutos num raio de 18 metros.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 5,
            Nome = "Aliado Planar",
            Escola = "Conjuração",
            Alcance = "18 metros",
            TempodeConjuracao = "10 minutos",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático",
            Descricao = "Você suplica a uma entidade transcendental por ajuda. O ser deve ser conhecido por você: seu deus, um primordial, um príncipe demônio ou algum outro ser de poder cósmico. Essa entidade envia um celestial, um corruptor ou um elemental leal a ela para ajudar você, fazendo a criatura aparecer em um espaço desocupado dentro do alcance. Se você conhecer o nome de uma criatura especifica, você pode falar o nome quando conjurar essa magia para requisitar essa criatura, do contrário, você pode receber uma criatura diferente de qualquer forma (à escolha do Mestre). Quando a criatura aparecer, ela não está sob nenhuma compulsão para se comportar de um modo em particular. Você pode pedir a criatura que realize um serviço em troca de um pagamento, mas ela não é obrigada a fazê-lo. A tarefa solicitada pode variar de simples (carregue-nos voando para o outro lado do abismo ou nos ajude a lutar essa batalha) a complexa (espione nossos inimigos ou nos proteja durante nossa incursão na masmorra). Você deve ser capaz de se comunicar com a criatura para barganhar os serviços dela. O pagamento pode ser feito de várias formas. Um celestial pode requerer uma generosa doação de ouro ou itens mágicos para um templo aliado, enquanto que um corruptor pode exigir um sacrifício vivo ou uma parte dos espólios. Algumas criaturas podem trocar seus serviços por uma missão feita por você. Como regra geral, uma tarefa que possa ser medida em minutos, exigirá um pagamento de 100 po por minuto. Uma tarefa medida em horas exigirá 1.000 po por hora. E uma tarefa medida em dias (até 10 dias) exigirá 10.000 po por dia. O Mestre pode ajustar esses pagamentos baseado nas circunstâncias pelas quais a magia foi conjurada. Se a tarefa estiver de acordo com o caráter da criatura, o pagamento pode ser reduzido à metade, ou mesmo dispensado. Tarefas que não proporcionem perigo, tipicamente requerem apenas metade do pagamento sugerido, enquanto que tarefas especialmente perigosas podem exigir um grande presente. As criaturas raramente aceitarão tarefas que pareçam suicidas. Após a criatura completar a tarefa ou quando a duração acordada para o serviço expirar, a criatura retornará para seu plano natal depois de relatar sua partida a você, se apropriado para a tarefa e se possível. Se você não for capaz de acertar um preço para os serviços da criatura, ela imediatamente voltará para o seu plano natal. Uma criatura convidada para se juntar ao seu grupo, conta como um membro dele, recebendo sua parte total na premiação de pontos de experiência. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 6,
            Nome = "Aljava Veloz",
            Escola = "Transmutação",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação bônus",
            Duracao = "Concentração, até 1 minuto",
            Componente = "V, S, M (uma aljava contendo, pelo menos, uma munição)",
            Descricao = "Você transmuta sua aljava para que ela produza um suprimento interminável de munições não-mágicas, que parecem saltar na sua mão quando você tenta pega-las. Em cada um dos seus turnos, até a magia acabar, você pode usar uma ação bônus para realizar dois ataques com uma arma que use munição de uma aljava. Cada vez que você fizer tais ataques à distância, sua aljava, magicamente, repõe a munição que você usou com uma munição não-mágica similar. Qualquer munição criada por essa magia se desintegra quando a magia acaba. Se a aljava não estiver mais com você, a magia acaba.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 7,
            Nome = "Alterar Forma",
            Escola = "Transmutação",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 hora",
            Componente = "V, S, M (uma argola de jade valendo, no mínimo, 1.500 po, que você deve colocar na sua cabeça antes de conjurar a magia) ",
            Descricao = "Você assume a forma de uma criatura diferente, pela duração. A nova forma pode ser qualquer criatura com um nível de desafio igual ao seu nível ou menor. A criatura não pode ser nem um constructo nem um mortovivo e você deve ter visto esse tipo de criatura pelo menos uma vez. Você se transforma num exemplar médio da criatura, um sem quaisquer níveis de classe nem característica Conjuração. Suas estatísticas de jogo são substituídas pelas estatísticas da forma escolhida, no entanto, você mantém sua tendência e valores de Inteligência, Sabedoria e Carisma. Você também mantem suas proficiências em testes de resistência, além de ganhar as da nova criatura. Se a criatura tiver a mesma proficiência que você e o bônus listado nas estatísticas dela for maior que o seu, use os bônus da criatura no lugar do seu. Você não pode usar qualquer ação lendária ou de covil da nova forma. Você assume os pontos de vida e Dados de Vida da sua nova forma. Quando você reverter a sua forma normal, você retorna à quantidade de pontos de vida que tinha antes da transformação. Se você reverter como resultado de ter caído a 0 pontos de vida, qualquer dano excedente é recebido pela sua forma normal. Contanto que o dano excedente não reduza os pontos de vida da sua forma normal a 0, você não cairá inconsciente. Você mantem os benefícios de qualquer característica da sua classe, raça ou outra fonte e pode usa-las, considerando que sua nova forma é fisicamente capaz de fazê-lo. Você não pode usar quaisquer sentidos especiais que você possua (por exemplo, visão no escuro) a não ser que a nova forma também possua o sentido. Você só poderá falar se a nova forma, normalmente, puder falar. Quando você se transforma, você pode escolher se o seu equipamento cai no chão, é assimilado a sua nova forma ou é usado por ela. Equipamentos vestidos e carregados funcionam normalmente. O Mestre decide qual equipamento é viável para a nova forma vestir ou  sar, baseado na forma e tamanho da criatura. O seu equipamento não muda de forma ou tamanho para se adaptar à nova forma e, qualquer equipamento que a nova forma não possa vestir deve, ou cair no chão ou ser assimilado por ela. Equipamentos assimilados não terão efeito nesse estado. Pela duração da magia, você pode usar sua ação para assumir uma forma diferente, seguindo as mesmas restrições e regras da forma anterior, com uma exceção: se sua nova forma tiver mais pontos de vida que sua forma atual, seus pontos de vida mantem o valor atual. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 8,
            Nome = "Alterar-se",
            Escola = "Transmutação",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 hora",
            Componente = "V, S",
            Descricao = "Você assume uma forma diferente. Quando conjurar essa magia, escolha uma das seguintes opções, o efeito durará pela duração da magia. Enquanto a magia durar, você pode terminar uma opção com uma ação para ganhar os benefícios de uma diferente. Adaptação Aquática. Você adapta seu corpo para um ambiente aquático, brotando guelras e crescendo membranas entre seus dedos. Você pode respirar embaixo d’água e ganha deslocamento de natação igual a seu deslocamento terrestre. Mudar Aparência. Você transforam sua aparência. Você decide com o que você parece, incluindo altura, peso, traços faciais, timbre da sua voz, comprimento do cabelo, coloração e características distintas, se tiverem. Você pode ficar parecido com um membro de outra raça, apesar de nenhuma de suas estatísticas mudar. Você também não pode parecer com uma criatura de um tamanho diferente do seu, e seu formado básico permanece o mesmo; se você for bípede, você não pode usar essa magia para se tornar quadrupede, por exemplo. A qualquer momento, pela duração da magia, você pode usar sua ação para mudar sua aparência dessa forma, novamente. Armas Naturais. Você faz crescerem garras, presas, espinhos, chifres ou armas naturais diferentes, à sua escolha. Seus ataques desarmados causam 1d6 de dano de concussão, perfurante ou cortante, como apropriado para a arma natural que você escolheu, e você é proficiente com seus ataques desarmados. Finalmente, a arma natural é mágica e você tem +1 de bônus nas jogadas de ataque e dano que você fizer com ela. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 9,
            Nome = "Amizade",
            Escola = "Encantamento",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "S, M (uma pequena quantidade de maquiagem aplicada ao rosto durante a conjuração da magia) ",
            Descricao = "Pela duração, você terá vantagem em todos os testes de Carisma direcionados a uma criatura, à sua escolha, que não seja hostil a você. Quando a magia acabar, a criatura perceberá que você usou maia para influenciar o humor dela, e ficará hostil a você. Uma criatura propensa a violência irá atacar você. Outra criatura pode buscar outras formas de retaliação (a critério do Mestre), dependendo da natureza da sua interação com ela.",
            IdTipoMagia = 1
        },
        new Magia
        {
            IdMagia = 10,
            Nome = "Amizade Animal",
            Escola = "Encantamento",
            Alcance = "9 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "24 horas",
            Componente = "V, S, M (um punhado de comida)",
            Descricao = "Essa magia deixa você convencer uma besta que você não quer prejudicar. Escolha uma besta que você possa ver dentro do alcance. Ela deve ver e ouvir você. Se a Inteligência da besta for 4 ou maior, a magia falha. Do contrário, a besta deve ser bem sucedida num teste de resistência de Sabedoria ou ficará enfeitiçada por você pela duração da magia. Se você ou um dos seus companheiros ferir o alvo, a magia termina. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 2° nível ou superior, você pode afetar uma besta adicional para cada nível do espaço acima do 1°. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 11,
            Nome = "Ampliar Plantas",
            Escola = "Transmutação",
            Alcance = "45 metros",
            TempodeConjuracao = "1 ação ou 8 horas",
            Duracao = "Instantânea",
            Componente = "V, S",
            Descricao = "Essa magia canaliza vitalidade nas plantas dentro de uma área especifica. Existem dois usos possíveis para essa magia, concedendo ou benefícios imediatos ou a longo prazo. Se você conjurar essa magia usando 1 ação, escolha um ponto dentro do alcance. Todas as plantas normais num raio de 30 metros centrado no ponto, tornam-se espessas e carregadas. Uma criatura se movendo na área deve gastar 6 metros de movimento para cada 1,5 metro que se mover. Você pode excluir uma ou mais áreas de qualquer tamanho, dentro da área da magia, para não ser afetada. Se você conjurar essa magia ao longo de 8 horas, você fertiliza a terra. Todas as plantas num raio de 800 metros, centrado no ponto dentro do alcance, ficam enriquecidas por 1 ano. As plantas fornecerão o dobro da quantidade normal de comida quando colhidas. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 12,
            Nome = "Âncora Planar",
            Escola = "Abjuração",
            Alcance = "18 metros",
            TempodeConjuracao = "1 hora",
            Duracao = "24 horas",
            Componente = "V, S, M (uma joia valendo, no mínimo, 1.000 po, consumida pela magia)",
            Descricao = "Com essa magia, você tenta obrigar um celestial, corruptor, elemental ou fada a servi-lo. A criatura deve estar dentro do alcance durante toda a conjuração da magia. (Tipicamente, a criatura, primeiramente, é invocada dentro de um círculo mágico invertido para mantê-la presa enquanto a magia é conjurada.) Ao completar a conjuração, o alvo deve realizar um teste de resistência de Carisma. Se falhar na resistência, ela é obrigada a servir você pela duração. Se a criatura foi invocada ou criada por outra magia, a duração da magia é estendida para se equiparar a dessa magia. Uma criatura obrigada deve seguir suas instruções da melhor forma que puder. Você poderia comandar a criatura a acompanhar você em uma aventura, a guardar um local ou a enviar uma mensagem. A criatura obedece ao pé da letra suas instruções, mas se a criatura for hostil a você, ela se esforçará para distorcer suas palavras para atingir seus próprios objetivos. Se a criatura atender suas instruções completamente antes da magia acabar, ela viajará até você para relatar esse fato se você estiver no mesmo plano de existência. Se você estiver em um plano de existência diferente, ela retornará para o lugar onde você a contatou e permanecerá lá até a magia acabar. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de nível superior, a duração aumenta para 10 dias com um espaço de 6° nível, para 30 dias com um espaço de 7° nível, para 180 dias com um espaço de 8° nível e para um ano com um espaço de magia de 9° nível. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 13,
            Nome = "Andar na Água",
            Escola = "Transmutação",
            Alcance = "9 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "1 hora",
            Componente = "V, S, M (uma rolha)",
            Descricao = "Essa magia concede a habilidade de se mover através de qualquer superfície líquida – como água, ácido, lama, neve, arreia movediça ou lava – como se ela fosse chão sólido inofensivo (as criaturas atravessando lava derretida ainda podem sofrer dano do calor). Até dez criaturas voluntárias que você possa ver, dentro do alcance, ganham essa habilidade pela duração. Se você afetar uma criatura submersa em um líquido, a magia ergue o alvo para a superfície do líquido a uma taxa de 18 metros por rodada. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 14,
            Nome = "Animar Mortos",
            Escola = "Necromancia",
            Alcance = "3 metros",
            TempodeConjuracao = "1 minuto",
            Duracao = "Instantânea",
            Componente = " V, S, M (uma gota de sangue, um pedaço de carne e um punhado de pó de osso)",
            Descricao = "Essa magia cria um servo morto-vivo. Escolha uma pilha de ossos ou um corpo de um humanoide Médio ou Pequeno dentro do alcance. Sua magia imbui o alvo com uma imitação corrompida de vida, erguendo-o como uma criatura morta-viva. O alvo se torna um esqueleto, se você escolheu ossos, ou um zumbi, se você escolheu um corpo (o Mestre tem as estatísticas de jogo da criatura). Em cada um dos seus turnos, você pode usar uma ação bônus para comandar mentalmente qualquer criatura que você criou com essa magia, se a criatura estiver a até 18 metros de você (se você controla diversas criaturas, você pode comandar qualquer uma ou todas elas ao mesmo tempo, emitindo o mesmo comando para cada uma). Você decide qual ação a criatura irá fazer e para onde ela irá se mover durante o próximo turno dela, ou você pode emitir um comando geral, como para guardar uma câmara ou corredor especifico. Se você não der nenhum comando, as criaturas apenas se defenderão contra criaturas hostis. Uma vez que receba uma ordem, a criatura continuará a segui-la até a tarefa estar concluída. A criatura fica sob seu controle por 24 horas, depois disso ela para de obedecer aos seus comandos. Para 218 manter o controle da criatura por mais 24 horas, você deve conjurar essa magia na criatura novamente, antes das 24 horas atuais terminarem. Esse uso da magia recupera seu controle sobre até quatro criaturas que você tenha animado com essa magia, ao invés de animar uma nova. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 4° nível ou superior, você pode animar ou recuperar o controle de duas criaturas mortas-vivas para cada nível do espaço acima do 3°. Cada uma dessas criaturas deve vir de um corpo ou pilha de ossos diferente. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 15,
            Nome = "Animar Objetos",
            Escola = "Transmutação",
            Alcance = "36 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "V, S",
            Descricao = "Objetos ganham vida ao seu comando. Escolha até dez objetos não-mágicos dentro do alcance, que não estejam sendo vestidos ou carregados. Alvos Médios contam como dois objetos, alvos Grandes contam como quatro objetos e alvos Enormes contam como oito objetos. Você não pode animar um objeto maior que Enorme. Cada alvo se anima e torna-se uma criatura sob seu controle até o final da magia ou até ser reduzido a 0 pontos de vida. Com uma ação bônus, você pode comandar mentalmente qualquer criatura que você criar com essa magia se a criatura estiver a até 150 metros de você (se você controla várias criaturas, você pode comandar qualquer ou todas elas ao mesmo tempo, emitindo o mesmo comando para cada uma). Você decide qual ação a criatura irá fazer e para onde ela irá se mover durante o próximo turno dela, ou você pode emitir um comando geral, como para guardar uma câmara ou corredor especifico. Se você não der nenhum comando, as criaturas apenas se defenderão contra criaturas hostis. Uma vez que receba uma ordem, a criatura continuará a segui-la até a tarefa estar concluída. Um objeto animado é um constructo com CA, pontos de vida, ataques, Força e Destreza determinados pelo seu tamanho. Sua Constituição é 10 e sua Inteligência e Sabedoria são 3 e seu Carisma é 1. Seu deslocamento é 9 metros; se o objeto não tiver pernas ou outros apêndices que ele possa usar para locomoção, ao invés, ele terá deslocamento de voo 9 metros e poderá planar. Se o objeto estiver firmemente preso a uma superfície ou objeto maior, como uma corrente presa a uma parede, seu deslocamento será 0. Ele tem percepção às cegas num raio de 9 metros e é cego além dessa distância. Quando o objeto animado cair a 0 pontos de vida, ele reverte a sua forma normal de objeto e qualquer dano restante é transferido para sua forma de objeto original. Se você ordenar a um objeto que ataque, ele pode realizar um único ataque corpo-a-corpo contra uma criatura a até 1,5 metro dele. Ele realiza um ataque de pancada com um bônus de ataque e dano de concussão determinado pelo seu tamanho. O Mestre pode definir que um objeto especifico inflige dano cortante ou perfurante, baseado na forma dele. Em Níveis Superiores. Se você conjurar essa magia usando um espaço de magia de 6° nível ou superior, você pode animar dois objetos adicionais para cada nível do espaço acima do 5°. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 16,
            Nome = "Antipatia/Simpatia",
            Escola = "Encantamento",
            Alcance = "18 metros",
            TempodeConjuracao = "1 hora",
            Duracao = "10 dias",
            Componente = "Componentes: V, S, M (ou um pedaço de alume embebido em vinagre para o efeito de antipatia, ou uma gota de mel para o efeito de simpatia) ",
            Descricao = "Essa magia atrai ou repele as criaturas de sua escolha. Você escolhe um alvo dentro do alcance, tanto um objeto ou criatura Enorme ou menor ou uma área que não seja maior que 60 metros cúbicos. Então, especifica um tipo de criatura inteligente, como dragões vermelhos, goblins ou vampiros. Você envolve o alvo com uma aura que pode atrair ou repelir as criaturas especificas pela duração. Escolha antipatia ou simpatia como efeito da aura. Antipatia. O encantamento faz com que criaturas do tipo designado por você sintam-se fortemente impelidos em deixar a área e evitar o alvo. Quando uma dessas criaturas puder ver o alvo ou ficar a 18 metros dele, a criatura deve ser bem sucedida num teste de resistência de Sabedoria ou ficará amedrontada. A criatura continuará amedrontada enquanto puder ver o alvo ou permanecer a 18 metros dele. Enquanto estiver amedrontada pelo alvo, a criatura deve usar seu deslocamento para se mover para o local seguro mais próximo o qual ela não possa ver o alvo. Se a criatura se mover para mais de 18 metros do alvo e não puder vê-lo, a criatura não estará mais amedrontada, mas ela ficará amedrontada novamente se voltar a ver o alvo ou ficar a 18 metros dele. Simpatia. O encantamento faz com que as criaturas especificadas sintam-se fortemente impelidos a se aproximar do alvo enquanto estiverem a 18 metros dele ou puderem vê-lo. Quando uma dessas criaturas puder ver o alvo ou ficar a 18 metros dele, a criatura deve ser bem sucedida num teste de resistência de Vontade ou usará seu deslocamento em cada um dos seus turnos para entrar na área ou se mover até o alcance do alvo. Quando a criatura tiver feito isso, ela não poderá se afastar do alvo voluntariamente. Se o alvo causar dano ou ferir a criatura afetada de alguma forma, a criatura afetada pode realizar um novo teste de resistência de Sabedoria para terminar o efeito, como descrito abaixo. Terminando o Efeito. Se uma criatura afetada terminar se turno enquanto não estiver a até 18 metros do alvo ou não for capaz de vê-lo, a  criatura faz um teste de resistência de Sabedoria. Em um sucesso, a criatura não estará mais afetada pelo alvo e  econhecerá o sentimento de repugnância ou atração como mágico. Além disso, uma criatura afetada pela magia tem direito a outro teste de resistência de Sabedoria a cada 24 horas enquanto a magia durar. Uma criatura que obtenha sucesso na resistência contra esse efeito ficará imune a ele por 1 minuto, depois desse tempo, ela pode ser afetada novamente. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 17,
            Nome = "Aprimorar Habilidade",
            Escola = "Transmutação",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 hora",
            Componente = "V, S, M (pelo ou penas de uma besta)",
            Descricao = "Você toca uma criatura e a agracia com aprimoramento mágico. Escolha um dos efeitos a seguir; o alvo ganha esse efeito até o fim da magia. Agilidade do Gato. O alvo tem vantagem em testes de Destreza. Ele também não sofre dano ao cair de 6 metros ou menos, se não estiver incapacitado. Esperteza da Raposa. O alvo tem vantagem em testes de Inteligência. Esplendor da Águia. O alvo tem vantagem em testes de Carisma. Força do Touro. O alvo tem vantagem em testes de Força e sua capacidade de carga é dobrada. Sabedoria da Coruja. O alvo tem vantagem em testes de Sabedoria. Vigor do Urso. O alvo tem vantagem em testes de Constituição. Ele também recebe 2d6 pontos de vida temporários, que são perdidos quando a magia termina. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 3° nível ou superior, você pode afetar uma criatura adicional para cada nível do espaço acima do 2°. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 18,
            Nome = "Aprisionamento",
            Escola = "Abjuração",
            Alcance = "9 metros",
            TempodeConjuracao = "1 minuto",
            Duracao = "Até ser dissipada",
            Componente = "V, S, M (um pergaminho de representação ou uma estatueta esculpida para se parecer com o alvo e um componente especial, que varia de acordo com a versão da magia que você escolher, valendo, no mínimo, 500 po por Dado de Vida)",
            Descricao = "Você cria um impedimento mágico para imobilizar uma criatura que você possa ver, dentro do alcance. O alvo deve ser bem sucedido num teste de resistência de Sabedoria ou será vinculado à magia; se ele for bem sucedido, ele será imune a essa magia se você conjura-la novamente. Enquanto estiver sob efeito dessa magia, a criatura não precisará respirar, comer ou beber e não envelhece. Magias de adivinhação não podem localizar ou perceber o alvo. Quando você conjura essa magia, você escolhe uma das seguintes formas de aprisionamento. Enterrar. O alvo é sepultado bem fundo na terra em uma esfera de energia mágica que é grande o suficiente para conter o alvo. Nada pode atravessar a esfera e nenhuma criatura pode se teletransportar ou usar viagem plantar para entrar ou sair dela. O componente especial para essa versão da magia é um pequeno globo de mitral. Acorrentar. Pesadas correntes, firmemente presas ao solo, matem o alvo no lugar. O alvo está impedido até a magia acabar e ele não pode se mover ou ser movido por nenhum meio, até lá. O componente especial para essa versão da magia é uma fina corrente de metal precioso. Prisão Cercada. A magia transporta o alvo para dentro de um pequeno semiplano que é protegido contra teletransporte e viagem planar. O semiplano pode ser um labirinto, uma jaula, uma torre ou qualquer estrutura ou área confinada similar, à sua escolha. O componente material especial para essa versão da magia é uma representação em miniatura da prisão, feita de jade. Contenção Reduzida. O alvo é reduzido até o tamanho de 30 centímetros e é aprisionado dentro de uma gema ou objeto similar. A luz pode passar através da gema normalmente (permitindo que o alvo veja o exterior e outras criaturas vejam o interior), mas nada mais pode atravessa-la, mesmo por meios de teletransporte ou viagem planar. A gema não pode ser partida ou quebrada enquanto a magia estiver efetiva. O componente especial para essa versão da magia é uma gema transparente grande, como um coríndon, diamante ou rubi. Torpor. O alvo cai no sono e não pode ser acordado. O componente especial para essa versão da magia consiste em ervas soporíferas raras. Terminando a Magia. Durante a conjuração da magia, em quaisquer das versões, você pode especificar uma condição que irá fazer a magia terminar e libertará o alvo. A condição pode ser o quão especifica ou elaborada quanto você quiser, mas o Mestre deve concordar que a condição é razoável e tem uma probabilidade de acontecer. As condições podem ser baseadas no nome, identidade ou divindade da criatura mas, no mais, devem ser baseadas em ações ou qualidades observáveis e não em valores intangíveis tais como nível, classe e pontos de vida. A magia dissipar magia pode terminar a magia apenas se for conjurada como uma magia de 9° nível, tendo como alvo ou a prisão ou o componente especial usado para cria-la. Você pode usar um componente especial em particular para criar apenas uma prisão por vez. Se você conjurar essa magia novamente usando o mesmo componente, o alvo da primeira conjuração é, imediatamente, liberado do vínculo.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 19,
            Nome = "Arca Secreta de Leomund",
            Escola = "Conjuração",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "V, S, M (um baú requintado, de 90 cm por 60 cm por 60 cm, construído com materiais raros valendo, no mínimo, 5.000 po e uma réplica Miúda feita do mesmo material valendo, no mínimo, 50 po)",
            Descricao = "Você esconde um baú, e todo o seu conteúdo, no Plano Etéreo. Você deve tocar o baú e a réplica em miniatura que serve como componente material para a magia. O baú pode acomodar até 3,6 metros cúbicos de matéria inorgânica (90 cm por 60 cm por 60 cm). Enquanto o baú permanecer no Plano Etéreo, você pode usar uma ação e tocar a réplica para revocar o baú. Ele aparece em um espaço desocupado no chão a 1,5 metro de você. Você pode enviar o baú de volta ao Plano Etéreo usando uma ação e tocando tanto no baú quanto na réplica. Após 60 dias, existe 5 por cento de chance, cumulativa, por dia do efeito da magia terminar. Esse efeito termina se você conjurar essa magia novamente, se a pequena réplica do baú for destruída ou se você decidir terminar a magia usando uma ação. Se a magia terminar enquanto o baú maior estiver no Plano Etéreo, ele estará irremediavelmente perdido.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 20,
            Nome = "Área Escorregadia",
            Escola = "Conjuração",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "1 minuto",
            Componente = "V, S, M (um pouco de pele de porco ou manteiga)",
            Descricao = "Graxa escorregadia cobre o solo em um quadrado de 3 metros centrado em um ponto, dentro do alcance, tornando essa área em terreno difícil pela duração. Quando a graxa aparece, cada criatura de pé na área deve ser bem sucedida num teste de resistência de Destreza ou cairá no chão. Uma criatura que entre na área ou termine seu turno nela, deve ser bem sucedido num teste de resistência de Destreza ou cairá no chão.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 21,
            Nome = "Arma Elemental",
            Escola = "Transmutação",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 hora",
            Componente = "Verbal, Somático",
            Descricao = "Uma arma não-mágica que você tocar se torna uma arma mágica. Escolha um dos tipos de dano a seguir: ácido, elétrico, frio, fogo ou trovejante. Pela duração, a arma tem +1 de bônus nas jogadas de ataque e causa 1d4 de dano extra, do tipo de elemento escolhido, ao atingir. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 5° ou 6° nível, o bônus nas jogadas de ataque aumenta pra +2 e o dano extra aumenta para 2d4. Quando você usar um espaço de magia de 7° nível ou superior, o bônus aumenta para +3 e o dano extra aumenta para 3d4.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 22,
            Nome = "Arma Espiritual",
            Escola = "Evocação",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação bônus",
            Duracao = "1 minuto",
            Componente = "Verbal, Somático",
            Descricao = "Você cria uma arma espectral flutuante, dentro do alcance, que permanece pela duração ou até você conjurar essa magia novamente. Quando você conjura essa magia, você pode realizar um ataque corpo-a-corpo com magia contra uma criatura a 1,5 metro da arma. Se atingir, o alvo sofre dano de energia igual a 1d8 + seu modificador de habilidade de conjuração. Com uma ação bônus, no seu turno, você pode mover a arma até 6 metros e repetir o ataque contra uma criatura a 1,5 metro dela. A arma pode ter a forma que você desejar. Clérigos de divindades associadas com uma arma em particular (como St. Cuthbert é conhecido por sua maça ou Thor por seu martelo) fazem o efeito dessa magia se assemelhar a essa arma. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 4° nível ou superior, o dano aumenta em 1d8 para cada dois níveis do espaço acima do 2°.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 23,
            Nome = "Arma Mágica",
            Escola = "Transmutação",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação bônus",
            Duracao = "Concentração, até 1 hora",
            Componente = "Verbal, Somático",
            Descricao = "Você toca uma arma não-mágica. Até a magia acabar, a arma se torna uma arma mágica com +1 de bônus nas jogadas de ataque e jogadas de dano. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 4° nível ou superior, o bônus aumenta para +2. Quando você usar um espaço de magia de 6° nível ou superior, o bônus aumenta para +3. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 24,
            Nome = "Armadura Arcana",
            Escola = "Abjuração",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação",
            Duracao = "8 horas",
            Componente = "Verbal, Somático, Material (um pedaço de couro curado)",
            Descricao = "Você toca uma criatura voluntária que não esteja vestindo armadura e uma energia mágica protetora a envolve até a magia acabar. A CA base do alvo se torna 13 + o modificador de Destreza dele. A magia acaba se o alvo colocar uma armadura ou se você dissipa-la usando uma ação. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 25,
            Nome = "Armadura de Agathys",
            Escola = "Abjuração",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 ação",
            Duracao = "1 hora",
            Componente = "Verbal, Somático, Material (um copo de água)",
            Descricao = "Uma força magica protetora envolve você, manifestandose como um frio espectral que cobre você e seu equipamento. Você ganha 5 pontos de vida temporários pela duração. Se uma criatura atingir você com um ataque corpo-a-corpo enquanto estiver com esses pontos de vida, a criatura sofrerá 5 de dano de frio. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 2° nível ou superior, tanto os pontos de vida temporários quanto o dano de frio aumentam em 5 para cada nível do espaço acima do 1°. ",
            IdTipoMagia = 2
        },
        //26
        new Magia
        {
            IdMagia = 26,
            Nome = "Arrombar",
            Escola = "Transmutação",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal",
            Descricao = "Escolha um objeto que você possa ver, dentro do alcance. O objeto pode ser uma porta, uma caixa, um baú ou um par de algemas, um cadeado ou outro objeto que contenha um meio mundano ou mágico que previne o acesso. Um alvo que esteja fechado por uma fechadura mundana ou preso ou barrado torna-se destrancado, destravado ou desbloqueado. Se o objeto tiver múltiplas fechaduras, apenas uma delas é destrancada. Se você escolher um alvo que esteja travado pela magia tranca arcana, essa magia será suprimida por 10 minutos, durante esse período o alvo pode ser aberto e fechado normalmente. Quando você conjurar essa magia, uma batida forte, audível a até 90 metros de distância, emana do objeto alvo. ",
            IdTipoMagia = 2
        },
        //27
        new Magia
        {
            IdMagia = 27,
            Nome = "Assassino Fantasmagórico",
            Escola = "Ilusão",
            Alcance = "36 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático",
            Descricao = "Você mexe com os pesadelos de uma criatura que você possa ver, dentro do alcance, e cria uma manifestação ilusória dos seus medos mais profundos, visível apenas para a criatura. O alvo deve realizar um teste de resistência de Sabedoria. Se falhar na resistência, ele ficará amedrontado pela duração. No final de cada turno do alvo, antes da magia acabar, ele deve ser bem sucedido num teste de resistência de Sabedoria ou sofrerá 4d10 de dano psíquico. Se passar na resistência, a magia acaba. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 5° nível ou superior, o dano aumenta em 1d10 para cada nível do espaço acima do 4°",
            IdTipoMagia = 2
        },
        //28
        new Magia
        {
            IdMagia = 28,
            Nome = "Ataque Certeiro",
            Escola = "Adivinhação",
            Alcance = "9 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 rodada",
            Componente = "Somático",
            Descricao = "Você estende sua mão e aponta o dedo para um alvo no alcance. Sua magia garante a você uma breve intuição sobre as defesas do alvo. No seu próximo turno, você terá vantagem na primeira jogada de ataque contra o alvo, considerando que essa magia não tenha acabado. ",
            IdTipoMagia = 1
        },
        //29
        new Magia
        {
            IdMagia = 29,
            Nome = "Ataque Visual",
            Escola = "Necromancia",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático",
            Descricao = "Pela duração da magia, seus olhos tornam-se manchas vazias imbuídas com poder terrível. Uma criatura, à sua escolha, a até de 18 metros de você que você puder ver, deve ser bem sucedida num teste de resistência de Sabedoria ou será afetada por um dos efeitos a seguir, à sua escolha, pela duração. A cada um dos seus turnos, até a magia acabar, você pode usar sua ação para afetar outra criatura, mas não pode afetar uma criatura novamente se ela tiver sido bem sucedida no teste de resistência contra essa conjuração de ataque visual. Adormecer. O alvo cai inconsciente. Ele acorda se sofrer qualquer dano ou se outra criatura usar sua ação para sacudir o adormecido até acordá-lo. Apavorar. O alvo está amedrontado. Em cada um dos turnos dele, a criatura amedrontada deve realizar a ação de Disparada e se mover para longe de você pela rota segura mais curta disponível, a não ser que não haja lugar para se mover. Se o alvo se mover para um local a, pelo menos, 18 metros de distância de você onde ela não possa mais te ver, esse efeito termina. Adoecer. O alvo tem desvantagem nas jogadas de ataque e testes de habilidade. No final de cada um dos turnos dele, ele pode realizar outro teste de resistência de Sabedoria. Se for bem sucedido, o efeito termina. ",
            IdTipoMagia = 2
        },
        //30
        new Magia
        {
            IdMagia = 30,
            Nome = "Augúrio",
            Escola = "Adivinhação (ritual)",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 minuto",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático, Material (varetas, ossos ou objetos similarmente marcados valendo, no mínimo, 25 Peças de Ouro",
            Descricao = "Ao lançar varetas cravejados com gemas, rolar ossos de dragão, puxar cartas ornamentadas ou usar outro tipo de ferramenta de adivinhação, você recebe um pressagio de uma entidade de outro mundo, sobre os resultados de cursos de ação específicos que você planeja tomar nos próximos 30 minutos. O Mestre escolhe dentre os possíveis presságios a seguir: • Êxito, para resultados bons • Fracasso, para resultados maus • Êxito e fracasso, para resultados bons e maus • Nada, para resultados que não são especialmente bons ou ruins A magia não leva em conta qualquer possível circunstancia que possa mudar o resultado, como a conjuração de magias adicionais ou a perda ou ganho de um companheiro. Se você conjurar a magia duas ou mais vezes antes de completar seu próximo descanso longo, existe uma chance cumulativa de 25 por cento de cada conjuração, depois da primeira que você fez, ter um resultado aleatório. O Mestre faz essa jogada secretamente. ",
            IdTipoMagia = 2
        },
        //31
        new Magia
        {
            IdMagia = 31,
            Nome = "Aumentar/Reduzir",
            Escola = "Transmutação",
            Alcance = "9 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático, Material (um pouco de pó de ferro",
            Descricao = "Você faz com que uma criatura ou um objeto que você possa ver dentro do alcance, fique maior ou menor, pela duração. Escolha entre uma criatura ou um objeto que não esteja sendo carregado nem vestido. Se o alvo for involuntário, ele deve realizar um teste de resistência de Constituição. Se for bem sucedido, a magia não surte efeito. Se o alvo for uma criatura, tudo que ele esteja vestindo ou carregando muda e tamanho com ela. Qualquer item largado por uma criatura afetada, retorna ao seu tamanho natural. Aumentar. O tamanho do alvo dobra em todas as dimensões e seu peso é multiplicado por oito. Esse aumento eleva seu tamanho em uma categoria – de Médio para Grande, por exemplo. Se não houver espaço suficiente para que o alvo dobre de tamanho, a criatura ou objeto alcança o tamanho máximo possível no espaço disponível. Até o fim da magia, o alvo também tem vantagem em testes de Força e testes de resistência de Força. O tamanho das armas do alvo crescem para se adequar ao seu novo tamanho. Quando essas armas são ampliadas, os ataques do alvo com elas causam 1d4 de dano extra. Reduzir. O tamanho do alvo é reduzido à metade em todas as dimensões e seu peso é reduzido a um oitavo do normal. Essa redução diminui o tamanho do alvo em uma categoria – de Médio para Pequeno, por exemplo. Até o fim da magia, o alvo tem desvantagem em testes de Força e testes de resistência de Força. O tamanho das armas doalvo diminuem para se adequar ao seu novo tamanho. Quando essas armas são reduzidas, os ataques do alvo com elas causam 1d4 de dano a menos (isso não pode reduzir o dano a menos de 1).",
            IdTipoMagia = 2
        },
        //32
        new Magia
        {
            IdMagia = 32,
            Nome = "Aura de Pureza",
            Escola = "Abjuração",
            Alcance = "Pessoal (9 metros de raio)",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 10 minutos",
            Componente = "Verbal",
            Descricao = "Energia purificante irradia de você em uma aura com 9 metros de raio. Até a magia acabar, a aura se move mantendo-se centrada em você. Todas as criaturas nãohostis na aura (incluindo você) não podem ficar doentes, tem resistência a dano de veneno e tem vantagem em testes de resistência contra efeitos que deixem ela com qualquer das condições a seguir: amedrontado, atordoado, cego, enfeitiçado, envenenado, paralisado e surdo. ",
            IdTipoMagia = 2
        },
        //33
        new Magia
        {
            IdMagia = 33,
            Nome = "Aura de Vida",
            Escola = "Abjuração",
            Alcance = "Pessoal (9 metros)",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 10 minutos",
            Componente = "Verbal",
            Descricao = "Energia de prevenção vital irradia de você em uma aura com 9 metros de raio. Até a magia acabar, a aura se move mantendo-se centrada em você. Todas as criaturas nãohostis na aura (incluindo você) tem resistência a dano necrótico e seu máximo de pontos de vida não pode ser reduzido. Além disso, uma criatura viva não-hostil, recupera 1 ponto de vida quando começa seu turno na aura com 0 pontos de vida. ",
            IdTipoMagia = 2
        },
        //34
        new Magia
        {
            IdMagia = 34,
            Nome = "Aura de Vitalidade",
            Escola = "Evocação",
            Alcance = "Pessoal (9 metros)",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal",
            Descricao = "Energia de prevenção vital irradia de você em uma aura com 9 metros de raio. Até a magia acabar, a aura se move mantendo-se centrada em você. Todas as criaturas nãohostis na aura (incluindo você) tem resistência a dano necrótico e seu máximo de pontos de vida não pode ser reduzido. Além disso, uma criatura viva não-hostil, recupera 1 ponto de vida quando começa seu turno na aura com 0 pontos de vida. ",
            IdTipoMagia = 2
        },
        //35
        new Magia
        {
            IdMagia = 35,
            Nome = "Aura Mágica de Nystul",
            Escola = "Ilusão",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação",
            Duracao = "24 horas",
            Componente = "Verbal, Somático, Material (um pequeno quadrade do seda)",
            Descricao = "Você coloca uma ilusão em uma criatura ou objeto que você tocar, então magias de adivinhação revelarão informações falsas sobre ele. O alvo pode ser uma criatura voluntária ou um objeto que não esteja sendo carregado ou vestido por outra criatura. Quando você conjura essa magia, escolha um ou ambos os efeitos seguintes. O efeito permanece pela duração. Se você conjurar essa magia na mesma criatura ou objeto a cada dia por 30 dias, colocando o mesmo efeito nele todas as vezes, a ilusão durará até ser dissipada. Aura Falsa. Você modifica a forma como o alvo aparece para magias e efeitos mágicos, como detectar magia, que detectam auras mágicas. Você pode fazer um objeto não-mágico parecer mágico ou mudar a aura mágica de um objeto para que ela pareça pertencer a outra escola de magia a sua escolha. Quando você usar esse efeito num objeto, você pode fazer a aura falsa aparente a qualquer criatura que manusear o item. Máscara. Você modifica a forma como o alvo aparece para magias e efeitos que detectam tipos de criaturas, como o Sentido Divino do paladino ou o gatilho de um magia símbolo. Você escolhe o tipo de criatura e outras magias e efeitos mágicos consideram o alvo como se ele fosse uma criatura desse tipo ou tendência.",
            IdTipoMagia = 2
        },
        //36
        new Magia
        {
            IdMagia = 36,
            Nome = "Aura Sagrada",
            Escola = "Abjuração",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático, Material (um minúsculo relicário valendo, no mínimo, 1000 Peças de Ouro, contendo uma relíquia sagrada, como um pedaço de tecido do robe de um santo ou um pedaço de um pergaminho de um texto religioso",
            Descricao = "Luz divina emana de você e adere em uma aureola suave num raio de 9 metros, em volta de você. As criaturas de sua escolha, no raio, quando você conjurar essa magia, emitem penumbra num raio de 1,5 metro e tem vantagem em todos os testes de resistência e as outras criaturas tem desvantagem nas jogadas de ataque contra elas, até a magia acabar. Além disso, quando um corruptor ou morto-vivo atingir uma criatura afetada com um ataque corpo-a-corpo, a aura lampeja com luz plena. O atacante deve ser bem sucedido num teste de resistência de Constituição ou ficara cego até a magia acabar. ",
            IdTipoMagia = 2
        },
        //37
        new Magia
        {
            IdMagia = 37,
            Nome = "Auxílio Divino",
            Escola = "Evocação",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 ação bônus",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático",
            Descricao = "Sua oração fortalece você com radiação divina. Até o fim da magia, seus ataques com arma causam 1d4 de dano radiante extra ao atingirem.",
            IdTipoMagia = 2
        },
        //38
        new Magia
        {
            IdMagia = 38,
            Nome = "Banimento",
            Escola = "Abjuração",
            Alcance = "9 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático, Material (um item desagradável ao alvo",
            Descricao = "Você tenta enviar uma criatura que você pode ver dentro do alcance, para outro plano de existência. O alvo deve ser bem sucedido num teste de resistência de Carisma ou será banido. Se o alvo for nativo do plano de existência que você está, você bane o alvo para um semiplano inofensivo. Enquanto estiver lá, a criatura estará incapacitada. Ela permanece lá até a magia acabar, a partir desse ponto, o alvo reaparece no espaço em que ela deixou ou no espaço desocupado mais próximo, se o espaço dela estive ocupado. Se o alvo for nativo de um plano de existência diferente do que você está, o alvo é banido em um lampejo sutil, retornando para o seu plano natal. Se a magia acabar antes de 1 minuto se passar, o alvo reaparece no lugar em que estava ou no espaço desocupado mais próximo, se o espaço dela estiver ocupado. Do contrário, o alvo não retorna. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 5° nível ou superior, você pode afetar uma criatura adicional para cada nível do espaço acima do 4°.",
            IdTipoMagia = 2
        },
        //39
        new Magia
        {
            IdMagia = 39,
            Nome = "Banquete de Heróis",
            Escola = "Conjuração",
            Alcance = "9 metros",
            TempodeConjuracao = "10 minutos",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático, Material (uma tigela encrustada de gemas valendo, no mínimo, 1000 Peças de Ouro, que é consumida pela magia",
            Descricao = "Você traz um grande banquete, incluindo comida e bebida magnificas. O banquete leva 1 hora para ser consumido e desaparece ao final desse tempo e os efeitos benéficos não se aplicam até essa hora terminar. Até doze criaturas podem participar do banquete. Uma criatura que participe do banquete ganha diversos benefícios. A criatura é curada de todas as doenças e venenos, torna-se imune a veneno e a ser amedrontada e faz todos os seus testes de resistência de Sabedoria com vantagem. Seu máximo de pontos de vida também aumenta em 2d10 e ela ganha a mesma quantidade de pontos de vida. Esses benefícios duram por 24 horas. ",
            IdTipoMagia = 2
        },
        //40
        new Magia
        {
            IdMagia = 40,
            Nome = "Barreira de Lâminas",
            Escola = "Evocação",
            Alcance = "24 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 10 minutos",
            Componente = "Verbal, Somático",
            Descricao = "Você cria uma muralha vertical de lâminas giratórias, afiadas como navalhas, feitas de energia mágica. A muralha aparece dentro do alcance e permanece pela duração. Você pode fazer uma muralha reta de até 30 metros de comprimento por 6 metros de altura e 1,5 metro de largura ou uma muralha anelar com até 18 metros de diâmetro, 6 metros de altura e 1,5 metro de largura. A muralha confere três-quartos de cobertura a criaturas atrás dela e seu espaço é terreno difícil. Quando uma criatura entrar a área da muralha pela primeira vez em um turno, ou começar seu turno nela, a criatura deve realizar um teste de resistência de Destreza. Se falhar, a criatura sofrerá 6d10 de dano cortante. Em um sucesso, a criatura sofre metade desse dano",
            IdTipoMagia = 2
        },
        //41
        new Magia
        {
            IdMagia = 41,
            Nome = "Benção",
            Escola = "Encantamento",
            Alcance = "9 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático, Material (um borrifo de água benta)",
            Descricao = "Você abençoa até três criaturas, à sua escolha, dentro do alcance. Sempre que um alvo realizar uma jogada de ataque ou teste de resistência antes da magia acabar, o alvo pode jogar um d4 e adicionar o valor jogado ao ataque ou teste de resistência. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 2° nível ou superior, você pode afetar uma criatura adicional para cada nível do espaço acima do 1°. ",
            IdTipoMagia = 2
        },
        //42
        new Magia
        {
            IdMagia = 42,
            Nome = "Boca Encantada",
            Escola = "Ilusão (ritual)",
            Alcance = "9 metros",
            TempodeConjuracao = "1 minuto",
            Duracao = "Até ser dissipada",
            Componente = "Verbal, Somático, Material (um pedaço de favo de mel e pó de jade valendo, no mínimo, 10 Peças de Ouro, consumidos pela magia)",
            Descricao = "Você implanta uma mensagem em um objeto dentro do alcance, uma mensagem que é pronunciada quando uma condição de ativação é satisfeita. Escolha um objeto que você possa ver e não esteja sendo vestido ou carregado por outra criatura. Então, fale a mensagem, que deve conter 25 palavras ou menos, apesar de ela poder ser entregue durante um período de até 10 minutos. Finalmente, determine a circunstância que irá ativar a magia para que sua mensagem seja entregue. Quando essa circunstância ocorrer, a boca encantada aparecerá no objeto e recitará a mensagem com sua voz e com o mesmo volume que você falou. Se o objeto que você escolheu tiver uma boca ou algo semelhante a uma boca (por exemplo, a boca de uma estátua), a boca mágica aparece ai, então, as palavras parecerão vir da boca do objeto. Quando você conjura essa magia, você pode fazer a magia acabar depois de enviar sua mensagem ou ela pode permanecer e repetir a mensagem sempre que a circunstância de ativação ocorrer. A circunstância de ativação pode ser tão genérica ou tão detalhada quando você quiser, apesar de ela precisar ser baseada em condições visuais ou audíveis que ocorram a até 9 metros do objeto. Por exemplo, você pode instruir a boca a falar quando uma criatura se aproximar a menos de 9 metros do objeto ou quando um sino de prata tocar a menos de 9 metros dela",
            IdTipoMagia = 2
        },
        //43
        new Magia
        {
            IdMagia = 43,
            Nome = "Bola de Fogo",
            Escola = "Evocação",
            Alcance = "45 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somática, Material (uma minúscula bola de guano de morcego e enxofre)",
            Descricao = "Um veio brilhante lampeja na ponta do seu dedo em direção a um ponto que você escolher, dentro do alcance, e então eclode com um estampido baixo, explodindo em chamas. Cada criatura em uma esfera de 6 metros de raio, centrada no ponto, deve realizar um teste de resistência de Destreza. Um alvo sofre 8d6 de dano de fogo se falhar na resistência, ou metade desse dano se obtiver sucesso. O fogo se espalha, dobrando esquinas. Ele incendeia objetos inflamáveis na área que não estejam sendo vestidos ou carregados. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 4° nível ou superior, o dano aumenta em 1d6 para cada nível do espaço acima do 3°. ",
            IdTipoMagia = 2
        },
        //44
        new Magia
        {
            IdMagia = 44,
            Nome = "Bola de Fogo Controlável",
            Escola = "Evocação",
            Alcance = "45 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático, Material (uma minúscula bola de guano de morcego e enxofre)",
            Descricao = "Um feixe de luz amarelada é disparado da ponta do seu dedo, então se condensa e aguarda no ponto escolhido, dentro do alcance, como uma conta brilhante, pela duração. Quando a magia termina, seja por sua concentração ter sido interrompida ou por você ter decidido termina-la, a conta eclode com um estampido baixo, explodindo em chamas que se espalhando, dobrando esquinas. Cada criatura numa esfera, com 6 metros de raio, centrada na conta, deve realizar um teste de resistência de Destreza. Uma criatura sofre dano igual ao total de dano acumulado se falhar na resistência, ou metade do total se obtiver sucesso. 224 O dano base da magia é 12d6. Se até o final do seu turno, a conta ainda não tiver sido detonada, o dano aumenta em 1d6. Se a conta brilhante for tocada antes do intervalo expirar, a criatura que a tocou deve realizar um teste de resistência de Destreza. Se falhar na resistência, a magia termina imediatamente, fazendo a conta explodir em chamas. Se obtiver sucesso na resistência, a criatura pode arremessar a conta a até 12 metros. Quando ela atinge uma criatura ou objeto solido, a magia termina e a conta explode. O fogo danifica objetos na área e incendeia objetos inflamáveis que não estejam sendo vestidos ou carregados. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 8° nível ou superior, o dano base aumenta e 1d6 para cada nível do espaço acima do 7°. ",
            IdTipoMagia = 2
        },
        //45
        new Magia
        {
            IdMagia = 45,
            Nome = "Bom Fruto",
            Escola = "Transmutação",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somática, Material (um raminho de visco)",
            Descricao = "Até dez frutos aparecem na sua mão e são infundidos com magia pela duração. Uma criatura pode usar sua ação para comer um fruto. Comer um fruto restaura 1 ponto de vida e um fruto produz nutrientes suficientes para sustentar uma criatura por um dia. Os frutos perdem seu potencial se não forem consumidos dentro de 24 horas da conjuração dessa magia",
            IdTipoMagia = 2
        },
        //46
        new Magia
        {
            IdMagia = 46,
            Nome = "Bordão Místico",
            Escola = "Transmutação",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação bônus",
            Duracao = "1 minuto",
            Componente = "Verbal, Somático, Material (visco, uma folha de trevo e uma clava ou bordão)",
            Descricao = "A madeira de uma clava ou bordão, que você esteja segurando, é imbuída com o poder da natureza. Pela duração, você pode usar sua habilidade de conjuração ao invés da sua Força para as jogadas de ataque e dano corpo-a-corpo usando essa arma, e o dado de dano da arma se torna um d8. A arma também se torna mágica, se ela já não for. A magia acaba se você conjura-la novamente ou se você soltar a arma.",
            IdTipoMagia = 1
        },
        //47
        new Magia
        {
            IdMagia = 47,
            Nome = "Braços de Hadar",
            Escola = "Conjuração",
            Alcance = "Pessoal (3 metros de raio)",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somática",
            Descricao = "Você invoca o poder de Hadar, o Faminto Sombrio. Tentáculos de energia negra brotam de você e golpeiam todas as criaturas a até 3 metros de você. Cada criatura na área deve realizar um teste de resistência de Força. Se falhar, o alvo sofre 2d6 de dano necrótico e não pode fazer reações até o próximo turno dela. Em um sucesso, uma criatura sofre metade do dano e não sofre qualquer outro efeito. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 2° nível ou superior, o dano aumenta em 1d6 para cada nível do espaço acima do 1°.",
            IdTipoMagia = 2
        },
        //48
        new Magia
        {
            IdMagia = 48,
            Nome = "Bruxaria",
            Escola = "Encantamento",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação bônus",
            Duracao = "Concentração, até 1 hora",
            Componente = "Verbal, Somático, Material (o olho petrificado de um tritão)",
            Descricao = "Você coloca uma maldição em uma criatura que você possa ver, dentro do alcance. Até a magia acabar, você causa 1d6 de dano necrótico extra no alvo sempre que atingi-lo com um ataque. Além disso, escolha uma habilidade quando você conjurar a magia. O alvo tem desvantagem em testes de habilidade feitos com a habilidade escolhida. Se o alvo cair a 0 pontos de vida antes da magia acabar, você pode usar uma ação bônus, em um turno subsequente, para amaldiçoar outra criatura. Uma magia remover maldição conjurada no alvo acaba com a magia prematuramente. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 3° ou 4° nível, você poderá manter sua concentração na magia por até 8 horas. Quando você usar um espaço de magia de 5° nível ou superior, você poderá manter sua concentração na magia por até 24 horas.",
            IdTipoMagia = 2
        },
        //49
        new Magia
        {
            IdMagia = 49,
            Nome = "Caminhar em Árvores",
            Escola = "Conjuração",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático",
            Descricao = "Você adquire a habilidade de entrar em uma árvore e se mover de dentro dela para dentro de outra árvore de mesmo tipo à até 150 metros. Ambas as árvores devem estar vivas e ter, pelo menos, o mesmo tamanho que você. Você deve usar 1,5 metro de deslocamento para entrar numa árvore. Você, instantaneamente, sabe a localização de todas as outras árvores de mesmo tipo à 150 metros e, como parte do movimento usado para entrar na árvore, pode tanto passar por uma dessas árvores quanto sair da árvore em que você está. Você aparece no espaço que você quiser a 1,5 metro da árvore destino, usando outro movimento de 1,5 metro. Se você não tiver movimento restante, você aparece a 1,5 metro da árvore que você terminou seu movimento. Você pode usar esse habilidade de transporte uma vez por rodada pela duração. Você deve terminar cada turno fora da árvore. ",
            IdTipoMagia = 2
        },
        //50
        new Magia
        {
            IdMagia = 50,
            Nome = "Caminhar no Vento",
            Escola = "Transmutação",
            Alcance = "9 metros",
            TempodeConjuracao = "1 minuto",
            Duracao = "8 horas",
            Componente = "Verbal, Somático, Material (fogo e água benta)",
            Descricao = "Você e até dez criaturas voluntária que você possa ver, dentro do alcance, assumem uma forma gasosa pela duração, parecidas com pedaços de nuvem. Enquanto estiver na forma de nuvem, uma criatura tem deslocamento de voo de 90 metros e tem resistência a dano de concussão, cortante e perfurante de ataques nãomágicos. As únicas ações que uma criatura pode realizar nessa forma são a ação de Disparada ou para reverter a sua forma normal. Reverter leva 1 minuto, período pelo qual a criatura estará incapacitada e não poderá se mover. Até a magia acabar, uma criatura pode reverter para a forma de nuvem, o que também requer a transformação de 1 minuto. Se uma criatura estiver na forma de nuvem e voando quando o efeito acabar, a criatura descerá a 18 metros por rodada por 1 minuto, até aterrissar na solo, o que é feito com segurança. Se ela não puder aterrissar em 1 minuto, a criatura cairá a distância restante. ",
            IdTipoMagia = 2
        },

        new Magia
        {
            IdMagia = 51,
            Nome = "Campo Antimagia",
            Escola = "Abjuração",
            Alcance = "Pessoal (3 metros de raio)",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 hora",
            Componente = "Verbal, Somático, Material (um punhado de pó de ferro ou limalhas de ferro)",
            Descricao = "Uma esfera invisível, de 3 metros de raio, de antimagia envolve você.Essa área é separada da energia mágica que se espalha pelo multiverso.Dentro da esfera, magias não podem ser conjuradas, criaturas invocadas desaparecem e, até mesmo itens mágicos, se tornam mundanos.Até o fim da magia, a esfera se move com você, centrada em você. Magias e outros efeitos mágicos, exceto os criados por artefatos ou divindades, são suprimidos na esfera e não podem adentra - la.Um espaço gasto para conjurar uma magia suprimida é consumido.Enquanto o efeito estiver suprimido, ela não funciona, mas o tempo que ela permanecer suprimida é descontado da sua duração. Efeitos de Alvo.Magias e outros efeitos mágicos, como mísseis mágicos e enfeitiçar pessoa, que forem usados em uma criatura ou objeto dentro da esfera, não surtem efeito no alvo. Áreas de Magia.A área de outra magia ou efeito mágico, como uma bola de fogo, não se estende para dentro da esfera.Se a esfera sobrepor um área mágica, a parte da área que for coberta pela espera é suprimida. Por exemplo, as chás criadas por uma muralha de fogo serão suprimidas dentro da esfera, criando um abertura na muralha se a sobreposição por grande o suficiente. Magias.Qualquer magia ativa ou outro efeito mágico em uma criatura ou objeto dentro da esfera é suprimido enquanto a criatura ou objeto permanecer dentro dela. Itens Mágicos.As propriedades e poderes de itens mágicos são suprimidas dentro da esfera.Por exemplo, uma espada longa + 1 dentro da esfera funciona como uma espada não - mágica. As propriedades e poderes de uma arma mágica são suprimidos se ela for usada contra um alvo dentro da esfera ou empunhada por um atacante dentro da esfera. Se uma arma mágica ou munição mágica deixar a esfera completamente(por exemplo, se você disparar uma flecha mágica ou arremessar uma lança mágica e um alvo fora da esfera), a magia do item deixa de ser suprimida tão logo ele deixe a esfera. Viagem Mágica. Teletransporte e viagem planar não funciona dentro da esfera, tanto se a esfera for o destino quando o ponto de partida para tais viagens mágicas.Um portal para outro lugar, mundo ou plano de existência, assim como um espaço extradimensional aberto, como o criado pela magia truque de corda, é temporariamente fechado enquanto estiver dentro da esfera. Criaturas e Objetos.Uma criatura ou objeto invocado ou criado através de magia, temporariamente desaparece da existência dentro da esfera.Tais criaturas reaparecem instantaneamente quando o espaço ocupado pela criatura não estiver mais dentro da esfera. Dissipar Magia.Magias e efeitos mágicos como dissipar magia, não surtem efeito sob esfera.Da mesma forma, esferas criadas por magias de campo antimagia diferentes não se anulam. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 52,
            Nome = "Cão Fiel de Mordenkainen",
            Escola = "Conjuração",
            Alcance = "9 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "8 horas",
            Componente = "Verbal, Somático, Material (um minúsculo apito de prata, um pedaço de osso e um fio)",
            Descricao = "Você conjura um cão de guarda fantasma em um espaço desocupado que você possa ver, dentro do alcance, que permanece pela duração, até você dissipa-lo com uma ação ou até você se mover para mais de 30 metros dele.\nO cão é invisível para todas as criaturas, exceto para você, e não pode ser ferido. Quando uma criatura Pequena ou maior se aproximar a 9 metros sem, primeiramente, falar a senha que você especifica quando conjura a magia, o cão começa a latir muito alto.O cão vê criaturas invisíveis e pode ver no Plano Etéreo. Ele ignora ilusões.\nNo começo de cada um dos seus turnos, o cão tenta morder uma criatura a 1,5 metro dele que seja hostil a você.O bônus de ataque do cão é igual ao seu modificador de habilidade de conjuração + seu bônus de proficiência. Se atingir, ele causa 4d8 de dano perfurante. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 53,
            Nome = "Cativar",
            Escola = "Encatamento",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "1 minuto",
            Componente = "Verbal, Somático",
            Descricao = "Você tece um cordão de palavras distrativas, fazendo as criaturas, à sua escolha, que você puder ver dentro do alcance e que puderem ouvir você, realizarem um teste de resistência de Sabedoria.Qualquer criatura que não puder ser enfeitiçada, passa automaticamente nesse teste de resistência e, se você ou seus companheiros estiverem lutando com a criatura, ela terá vantagem na resistência. Se falhar na resistência, a criatura terá desvantagem em testes de Sabedoria(Percepção) feitos para notar qualquer criatura além de você, até a magia acabar ou até o alvo não poder mais ouvir você. A magia acaba se você estiver incapacitado ou incapaz de falar. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 54,
            Nome = "Carne para Pedra",
            Escola = "Transmutaçao",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concetração, até 1 minuto",
            Componente = "Verbal, Somático, Material (uma pitada de cal, água e terra)",
            Descricao = "Você tenta transformar uma criatura que você possa ver, dentro do alcance, em pedra. Se o corpo do alvo for feito de carne, a criatura deve realizar um teste de resistência de Constituição.Em caso de falha, ela ficará impedida, à medida que sua carne começa a endurecer.Se obtiver sucesso, a criatura não é afetada. Uma criatura impedida por essa magia deve realizar outro teste de resistência de Constituição no final de cada um dos turnos dela.Se obtiver sucesso na resistência contra essa magia três vezes, a magia termina.Se ela falhar no teste de resistência três vezes, ela se torna pedra é afetada pela condição petrificado pela duração.Os sucessos e falhas não precisam ser consecutivos; anote ambos os resultados até o alvo acumular três de mesmo tipo. Se a criatura for quebrada fisicamente enquanto petrificada, ela sofre deformidades similares se for revertida ao seu estado original. Se você mantiver sua concentração nessa magia durante toda a duração possível, a criatura é transformada em pedra até o efeito ser removido. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 55,
            Nome = "Cegueira/Surdez",
            Escola = "Necromancia",
            Alcance = "9 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "1 minuto",
            Componente = "Verbal",
            Descricao = "Você pode cegar ou ensurdecer um oponente. Escolha uma criatura que você possa ver dentro do alcance para fazer um teste de resistência de Constituição. Se ela falhar, ficará ou cega ou surda(à sua escolha) pela duração. No final de cada um dos turnos dele, o alvo pode realizar um teste de resistência de Constituição.Se obtiver sucesso, a magia termina. Em Níveis Superiores.Se você conjurar essa magia usando um espaço de magia de 3° nível ou superior, você pode afetar uma criatura adicional para cada nível de espaço acima do 2°. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 56,
            Nome = "Chama Contínua",
            Escola = "Evocação",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação",
            Duracao = "Até ser dissipada",
            Componente = "Verbal, Somático, Material (pó de rubi no valor de 50 po, consumido pela magia)",
            Descricao = "Uma chama, que produz iluminação equivalente a uma tocha, surge de um objeto que você tocar.O efeito é parecido com o de uma chama normal, mas ele não produz calor e não consome oxigênio.Uma chama continua pode ser coberta ou escondida, mas não sufocada ou extinta.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 57,
            Nome = "Chama Sagrada",
            Escola = "Evocação",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático",
            Descricao = "Radiação similar a uma chama desce sobre uma criatura que você possa ver, dentro do alcance.O alvo deve ser bem sucedido num teste de resistência de Destreza ou sofrerá 1d8 de dano radiante.O alvo não recebe qualquer benefício de cobertura contra esse teste de resistência.\nO dano da magia aumenta em 1d8 quando você alcança o 5° nível(2d8), 11° nível(3d8) e 17° nível(4d8). ",
            IdTipoMagia = 1
        },
        new Magia
        {
            IdMagia = 58,
            Nome = "Chicote de Espinhos",
            Escola = "Transmutação",
            Alcance = "9 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático, Material (uma muda de uma planta com espinhos)",
            Descricao = "Você cria um longo chicote de vinhas coberto por espinhos que chicoteia, ao seu comando, em direção de uma criatura dentro do alcance.Realize um ataque corpo - acorpo com magia contra o alvo.Se o ataque atingir, a criatura sofrerá 1d6 de dano perfurante e, se a criatura for Grande ou menor, você a puxa até 3 metros para perto de você. O dano dessa magia aumenta em 1d6 quando você alcança o 5° nível(2d6), 11° nível(3d6) e 17° nível(4d6). ",
            IdTipoMagia = 1
        },
        new Magia
        {
            IdMagia = 59,
            Nome = "Chuva de Meteoros",
            Escola = "Evocação",
            Alcance = "1.5 quilômetro",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático",
            Descricao = "Esferas de fogo incandescentes atingem o solo em quatro pontos diferentes que você possa ver, dentro do alcance. Cada criatura numa esfera de 12 metros de raio, centrada em cada ponto escolhido por você, deve realizar um teste de resistência de Destreza. A esfera se espalha, dobrando esquinas.Uma criatura sofre 20d6 de dano de fogo e 20d6 de dano de concussão se falhar na resistência ou metade desse dano se obtiver sucesso.Uma criatura na área de mais de uma explosão de chamas é afetada apenas uma vez. A magia causa dano aos objetos na área e incendeia objetos inflamáveis que não estejam sendo vestidos ou carregados.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 60,
            Nome = "Círculo da Morte",
            Escola = "Necromancia",
            Alcance = "45 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático, Material (o pó de uma pérola negra esmagada valendo, no mínimo, 500 po)",
            Descricao = "Uma esfera de energia negativa ondula em um raio de 18 metros de um ponto ao alcance.Cada criatura na área deve realizar um teste de resistência de Constituição.Um alvo sofre 8d6 de dano necrótico se falhar no seu teste de resistência, ou metade desse dano se passar. Em Níveis Superiores.Se você conjurar essa magia usando um espaço de magia de 7° nível ou superior, o dano aumenta em 2d6 para cada nível do espaço acima do 6°. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 61,
            Nome = "Círculo de Poder",
            Escola = "Abjuração",
            Alcance = "Pessoal (9 metros de raio)",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 10 minutos",
            Componente = "Verbal",
            Descricao = "Energia divina irradia de você, distorcendo e espalhando energia mágica a até 9 metros de você.Até a magia acabar, a esfera se move com você, centrada em você.Pela duração, cada criatura amigável na área(incluindo você) tem vantagem em testes de resistência contra magias e outros efeitos mágicos.Além disso, quando uma criatura afetada for bem sucedida num teste de resistência contra uma magia ou efeito mágico realizado para sofrer apenas metade do dano, ao invés disso, ela não sofrerá dano nenhum se passar na resistência. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 62,
            Nome = "Círculo de Teletransporte",
            Escola = "Conjuração",
            Alcance = "3 metros",
            TempodeConjuracao = "1 minuto",
            Duracao = "1 rodada",
            Componente = "Verbal, Material (giz e tintas raros infundidos com pedras preciosas no valor de 50 po, consumidos pela magia)",
            Descricao = "À medida que você conjura essa magia, você desenha um círculo de 3 metros de diâmetro no chão, inscrevendo selos que conectam sua localização a um círculo de teletransporte permanente, à sua escolha, cuja sequência de selos você conheça e esteja no mesmo plano de existência que você.Um portal cintilante se abre dentro do círculo que você desenhou e permanece aberto até o final do seu próximo turno.Qualquer criatura que entrar no portal, instantaneamente, aparecerá a 1,5 metro do círculo de destino ou no espaço desocupado mais próximo, se o espaço estiver ocupado. Muitos templos principais, guildas e outros locais importantes possuem círculos de teletransporte permanentes inscritos em algum lugar dos seus confins. Cada círculo desse inclui uma sequência única de selos – uma sequência de runas mágicas dispostas em um padrão específico.Quando você adquire a capacidade de conjurar essa magia pela primeira vez, você aprende a sequência de selos de dois destinos no Plano Material, determinadas pelo Mestre.Você pode aprender sequências de selos adicionais durante suas aventuras. Você pode consignar uma nova sequência de selos a memória após estuda-la por 1 minuto. Você pode criar um círculo de teletransporte permanente ao conjurar essa magia no mesmo local a cada dia por um ano.Você não precisa usar o círculo para se teletransportar quando você conjurar a magia desse modo. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 63,
            Nome = "Círculo Mágico",
            Escola = "Abjuração",
            Alcance = "3 metros",
            TempodeConjuracao = "1 minuto",
            Duracao = "1 hora",
            Componente = "Verbal, Somático, Material (água benta ou pó de prata e ferro valendo, no mínimo, 100po, consumidos pela magia)",
            Descricao = "Você cria um cilindro de energia mágica de 3 metros de raio por 6 metros de altura, centrado num ponto no solo que você possa ver, dentro do alcance.Runas brilhantes aparecem toda vez que o cilindro toca o chão ou outra superfície. Escolha um ou mais dos tipos de criaturas seguintes: celestiais, corruptores, elementais, fadas ou mortos - vivos. O círculo afeta uma criatura do tipo escolhido das seguintes maneiras:  A criatura não consegue entrar no cilindro voluntariamente por meios não - mágicos.Se a criatura tentar usar teletransporte ou viagem interplanar para fazê - lo, ela deve, primeiro, ser bem sucedida num teste de resistência de Carisma.  A criatura tem desvantagem nas jogadas de ataque contra alvos dentro do cilindro.  Alvos dentro do cilindro não podem ser enfeitiçados, amedrontados ou possuídos pela criatura. Quando você conjurar essa magia, você pode decidir que a mágica dela opere na direção reversa, prevenindo que uma criatura de um tipo especifico saia do cilindro e protegendo os alvos fora dele. Em Níveis Superiores.Quando você conjurar essa magia usando um espaço de magia de 4° nível ou superior, a duração aumenta em 1 hora para cada nível do espaço acima do 3°. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 64,
            Nome = "Clarividência",
            Escola = "Adivinhação",
            Alcance = "1.5 quilômetro",
            TempodeConjuracao = "10 minutos",
            Duracao = "Concentração, até 10 minutos",
            Componente = "Verbal, Somático, Material ((um foco valendo, no mínimo, 100 po, também um chifre cravejado de joias para ouvir ou um olho de vidro para ver)",
            Descricao = "Você cria um sensor invisível, dentro do alcance, em um local familiar a você(um local que você tenha visitado ou visto antes) ou em um local obvio que não seja familiar a você(como atrás de uma porta, ao redor de um canto ou em um bosque de árvores).O sensor se mantem no local pela duração e não pode ser atacado ou manipulado de outra forma. Quando você conjurar essa magia, escolhe visão ou audição.Você pode escolher sentir através do sensor como se você estivesse no espaço dele.Com sua ação, você pode trocar entre visão e audição. Uma criatura que puder ver o sensor(como uma criatura beneficiada por ver o invisível ou visão verdadeira) vê um globo luminoso e intangível do tamanho do seu olho.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 65,
            Nome = "Clone",
            Escola = "Necromancia",
            Alcance = "Toque",
            TempodeConjuracao = "1 hora",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático, Material (um diamante valendo, no mínimo, 1.000 po e, no mínimo 3 centímetros cúbicos de carne da criatura que será clonada, consumida pela magia, e um receptáculo valendo, no mínimo, 2.000 po que tenha uma tampa selada e seja grande o suficiente para comportar uma criatura Média, como uma urna enorme, um caixão, um cisto cheio de lama no solo ou um recipiente de cristal cheio de água salgada)",
            Descricao = "Essa magia produz uma duplicata inerte de uma criatura viva como uma garantia contra a morte.Esse clone é formado dentro de um receptáculo selado e cresce ao seu tamanho total, atingindo a maturidade após 120 dias; Você também pode escolher que o clone seja uma versão mais jovem da mesma criatura.Ele permanece inerte e dura indefinidamente, enquanto seu receptáculo permanecer intocado. A qualquer momento, após o clone amadurecer, se a criatura original morrer, sua alma é transferida para o clone, considerando que a alma está livre e deseje retornar.O clone é fisicamente idêntico ao original e tem a mesma personalidade, memórias e habilidades, mas não possui qualquer equipamento do original.O físico da criatura original permanece, se ainda existir, se tornando inerte e não podendo, consequentemente, ser trazido de volta à vida, já que a alma da criatura está em outro lugar. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 66,
            Nome = "Coluna de Chamas",
            Escola = "Evocação",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático, Material (uma pitada de enxofre)",
            Descricao = "Uma coluna vertical de fogo divino emerge de baixo para os céus, no local que você especificar.Cada criatura num cilindro de 3 metros de raio por 12 metros de altura, centrado num ponto dentro do alcance, deve realizar um teste de resistência de Destreza. Uma criatura sofre 4d6 de dano de fogo e 4d6 de dano radiante se falhar na resistência, ou metade desse dano se obtiver sucesso. Em Níveis Superiores.Quando você conjurar essa magia usando um espaço de magia de 6° nível ou superior, o dano de fogo ou o dano radiante(à sua escolha) aumenta em 1d6 por nível do espaço acima do 5°",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 67,
            Nome = "Comando",
            Escola = "Encantamento",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "1 rodada",
            Componente = "Verbal",
            Descricao = "Você pronuncia uma palavra de comando para uma criatura que você possa ver dentro do alcance.O alvo deve ser bem sucedido num teste de resistência de Sabedoria ou seguirá seu comando no próximo turno dele.A magia não tem efeito se o alvo for um morto-vivo, se ele não entender seu idioma ou se o comando for diretamente nocivo a ele. Alguns comandos típicos e seus efeitos a seguir.Você pode proferir um comando diferente dos descritos aqui.Se o fizer, o Mestre descreve como o alvo reage.Se o alvo não puder cumprir o comando, a magia termina. Aproxime - se.O alvo se move para próximo de você o máximo que puder na rota mais direta, terminando seu turno, se ele se mover a até 1, 5 metro de você. Largue.O alvo larga o que quer que ele esteja segurando, e termina seu turno. Fuja.O alvo gasta seu turno se movendo para longe de você da forma mais rápida que puder. Deite - se.O alvo deita - se no chão e então, termina seu turno. Parado.O alvo não se move e não realiza nenhuma ação.Uma criatura voadora continua no alto, considerando que ela seja capaz de fazê - lo.Se ela tiver que se mover para continuar no alto, ela voa a mínima distância necessária para permanecer no ar. Em Níveis Superiores.Se você conjurar essa magia usando um espaço de magia de 2° nível ou superior, você pode afetar uma criatura adicional para cada nível do espaço acima do 1°. As criaturas devem estar a 9 metros entre si para serem afetadas. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 68,
            Nome = "Compreender Idiomas",
            Escola = "Adivinhação (ritual)",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 ação",
            Duracao = "1 hora",
            Componente = "Verbal, Somático, Material (uma pitada de fuligem e sal)",
            Descricao = "Pela duração, você compreende o significado literal de qualquer idioma falado que você ouvir.Você também compreende qualquer idioma escrito que vir, mas você deve tocar a superfície onde as palavras estão escritas. Leva, aproximadamente, 1 minuto para ler uma página de texto. Essa magia não decifra mensagens secretas em textos ou glifos, como um selo arcano, que não seja parte de um idioma escrito.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 69,
            Nome = "Compulsão",
            Escola = "Encantamento",
            Alcance = "9 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático",
            Descricao = "Criaturas, à sua escolha, que você puder ver dentro do alcance e que puderem ouvir você, devem realizar um teste de resistência de Sabedoria.Um alvo passa automaticamente nesse teste de resistência se ele não puder ser enfeitiçado.Se falhar no teste, um alvo é afetado por essa magia.Até a magia acabar, você pode usar uma ação bônus em cada um dos seus turnos, para designar uma direção horizontal a você.Cada criatura afetada deve se mover, da melhor forma possível, para essa direção no próximo turno dela.Ela pode realizar sua ação antes de se mover.Depois de se mover dessa forma, ela pode realizar outra resistência de Sabedoria para tentar acabar com o efeito. Um alvo não é obrigado a se mover em direção de um perigo obviamente mortal, como uma fogueira ou abismo, mas ele vai provocar ataques de oportunidade por se mover na direção designada.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 70,
            Nome = "Comunhão",
            Escola = "Adivinhação (ritual)",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 minuto",
            Duracao = "1 minuto",
            Componente = "Verbal, Somático, Material (incenso e um frasco de água benta ou profana)",
            Descricao = "Você contata sua divindade ou um representante divino e faz até três perguntas que podem ser respondidas com um sim ou não.Você deve fazer suas perguntas antes da magia terminar.Você recebe uma resposta correta para cada pergunta. Seres divinos não são necessariamente oniscientes, portanto, você pode receber “incerto” como uma resposta se uma pergunta que diga respeito a uma informação além do conhecimento da divindade.Em caso de uma resposta de única palavra puder levar ao engano ou contrariar os interesses da divindade, o Mestre pode oferecer uma frase curta como resposta, no lugar. Se você conjurar essa magia duas ou mais vezes antes de terminar um descanso longo, existe uma chance cumulativa de 25 por cento de cada conjuração, depois da primeira que você fez, ter um resultado aleatório.O Mestre faz essa jogada secretamente. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 71,
            Nome = "Comunhão com a Natureza",
            Escola = "Adivinhação (ritual)",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 minuto",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático",
            Descricao = "Você, momentaneamente, se torna uno com a natureza e ganha conhecimento do território ao seu redor.Ao ar livre, a magia lhe oferece conhecimento do terreno a até 4,5 quilômetros de você.Em cavernas e outros formações subterrâneas naturais, o raio é limitado a 150 metros.A magia não funciona onde a natureza foi substituída por construções, como em masmorras ou cidades. Você, instantaneamente, adquire conhecimento de até três fatos, à sua escolha, sobre qualquer dos assuntos a seguir, relacionados a área:  Terrenos e corpos de água  Plantas, minérios, animais e povo predominante  Celestiais, fadas, corruptores, elementais ou mortosvivos mais poderosos  Influência de outros planos de existência  Construções Por exemplo, você poderia determinar a localização de um morto-vivo poderoso na área, a localização da maior fonte de água potável e a localização de quaisquer cidades próximas. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 72,
            Nome = "Cone de Frio",
            Escola = "Evocação",
            Alcance = "Pessoal (cone de 18 metro)",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático, Material (um pequeno cristal ou cone de vidro)",
            Descricao = "Uma explosão de ar gelado irrompe das suas mãos. Cada criatura dentro do cone de 18 metros, deve realizar um teste de resistência de Constituição. Uma criatura sofre 8d8 de dano de frio se falhar na resistência, ou metade desse dano se passar. Uma criatura morta por essa magia se torna uma estátua congelada até derreter. Em Níveis Superiores.Se você conjurar essa magia usando um espaço de magia de 6° nível ou superior, o dano aumenta em 1d8 para cada nível do espaço acima do 5°. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 73,
            Nome = "Confusão",
            Escola = "Encantamento",
            Alcance = "27 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático, Material (três cascas de noz)",
            Descricao = "Essa magia ataca e embaralha as mentes das criaturas, gerando delírios e provocando ações descontroladas.Cada criatura em uma esfera com 3 metros de raio, centrada num ponto, à sua escolha, dentro do alcance, deve ser bem sucedida num teste de resistência de Sabedoria, quando você conjurar essa magia ou for afetada por ela. Um alvo afetado não pode realizar reações e deve rolar um d10 no início de cada um dos seus turnos para determinar seu comportamento nesse turno. d10 Comportamento 1 A criatura usa todo seu deslocamento para se mover em uma direção aleatória.Para determinar a direção, role um d8 e atribua uma direção a cada face do dado.A criatura não realiza uma ação nesse turno. 2–6 A criatura não se move ou realiza ações nesse turno. 7–8 A criatura usa sua ação para realizar um ataque corpo-acorpo contra uma criatura, determinada aleatoriamente, ao seu alcance. Se não houver criaturas dentro do alcance, a criatura não faz nada nesse turno. 9–10 A criatura pode agir e se mover normalmente. Ao final de cada um dos seus turnos, um alvo afetado pode realizar um teste de resistência de Sabedoria. Se for bem sucedido, esse efeito acaba nesse alvo. Em Níveis Superiores.Se você conjurar essa magia usando um espaço de magia de 5° nível ou superior, o raio da esfera aumenta em 1, 5 metro para cada nível do espaço acima do 4°. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 74,
            Nome = "Conhecimento Lendário",
            Escola = "Adivinhação",
            Alcance = "Pessoal",
            TempodeConjuracao = "10 minutos",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático, Material (incenso valendo, no mínimo, 250 po, consumido pela magia e quatro tiras de marfim valendo, no mínimo, 50 po cada)",
            Descricao = "Nomeie ou descreva uma pessoa, local ou objeto. A magia traz a sua mente um breve resumo do conhecimento significativo sobre a coisa que você nomeou.O conhecimento deve consistir em contos atuais, histórias esquecidas ou, até mesmo, conhecimento secreto que nunca foi amplamente divulgado. Se a coisa que você nomeou não for de importância lendária, você não recebe qualquer informação sofre ela. Quanto mais informação você possuir sobre a coisa, mais precisa e detalhada será a informação que você receberá. A informação que você aprende é precisa, mas pode ser redigida em linguagem figurada.Por exemplo, se você possuir um misterioso machado mágico na mão, a magia pode proporcionar essa informação: “Ai do malfeitor cuja mão toca o machado, até mesmo seu cabo corta a mão dos malignos.Só um verdadeiro Filho da Pedra, adorador e adorado de Moradin, pode despertar os verdadeiros poderes do machado e apenas com a palavra sagrada Rudnogg nos lábios.”",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 75,
            Nome = "Conjurar Animais",
            Escola = "Conjuração",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 hora",
            Componente = "Verbal, Somático",
            Descricao = "Você invoca espíritos feéricos, que assumem formas de bestas, que aparecem em espaços desocupados, que você possa ver dentro do alcance.Escolha uma das opções a seguir para aparecer:  Uma besta de nível de desafio 2 ou inferior  Duas bestas de nível de desafio 1 ou inferior  Quatro bestas de nível de desafio 1 / 2 ou inferior  Oito bestas de nível de desafio 1 / 4 ou inferior Cada besta é também considerada uma fada e desaparece quando cair a 0 pontos de vida ou quando a magia acabar. As criaturas invocadas são amigáveis a você e a seus companheiros.Role a iniciativa para as criaturas invocadas como um grupo, que age no seu próprio turno. Eles obedecem a quaisquer comandos verbais que você emitir(não requer uma ação sua).Se você não emitir nenhum comando a elas, elas se defenderão de criaturas hostis, mas no mais, não realizarão nenhuma ação. O Mestre possui as estatísticas das criaturas. Em Níveis Superiores.Se você conjurar essa magia usando certos espaços de magia superiores, você escolhe uma das opções de invocação acima e mais criaturas aparecem: o dobro delas com um espaço de 5° nível, o triplo delas com um espaço de 7° nível e o quadruplo delas com um espaço de 9° nível. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 76,
            Nome = "Conjurar Celestial",
            Escola = "Conjuração",
            Alcance = "27 metros",
            TempodeConjuracao = "1 minutos",
            Duracao = "Concetração, até 1 hora",
            Componente = "Verbal, Somático",
            Descricao = "Você invoca um celestial de nível de desafio 4 ou inferior, que aparece num espaço desocupado, que você possa ver dentro do alcance.O celestial desaparece se cair a 0 pontos de vida ou quando a magia acabar. O celestial é amigável a você e a seus companheiros pela duração. Role a iniciativa para o celestial, que age no seu próprio turno.Ele obedece a quaisquer comandos verbais que você emitir(não requer uma ação sua), contanto que não violem sua tendência. Se você não emitir nenhum comando a ele, ele se defenderá de criaturas hostis, mas no mais, não realizará nenhuma ação. O Mestre possui as estatísticas do celestial. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 9° nível, você invoca um celestial de nível de desafio 5 ou inferior. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 77,
            Nome = "Conjurar Elementais Menores",
            Escola = "Conjuração",
            Alcance = "27 metros",
            TempodeConjuracao = "1 minuto",
            Duracao = "Concentração, até 1 hora",
            Componente = "Verbal, Somático",
            Descricao = "Você invoca elementais que aparecem em espaços desocupados, que você possa ver dentro do alcance.Você escolhe uma das opções a seguir para aparecer:  Um elemental de nível de desafio 2 ou inferior  Dois elementais de nível de desafio 1 ou inferior  Quatro elementais de nível de desafio 1 / 2 ou inferior  Oito elementais de nível de desafio 1 / 4 ou inferior Um elemental invocado através dessa magia desaparece quando cair a 0 pontos de vida ou quando a magia acabar. As criaturas invocadas são amigáveis a você e a seus companheiros.Role a iniciativa para as criaturas invocadas como um grupo, que age no seu próprio turno. Eles obedecem a quaisquer comandos verbais que você emitir(não requer uma ação sua).Se você não emitir nenhum comando a elas, elas se defenderão de criaturas hostis, mas no mais, não realizarão nenhuma ação. O Mestre possui as estatísticas das criaturas. Em Níveis Superiores.Se você conjurar essa magia usando certos espaços de magia superiores, você escolhe uma das opções de invocação acima e mais criaturas aparecem: o dobro delas com um espaço de 6° nível e o triplo delas com um espaço de 8° nível.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 78,
            Nome = "Conjurar Elemental",
            Escola = "Conjuração",
            Alcance = "27 metros",
            TempodeConjuracao = "1 minuto",
            Duracao = "Concentração, até 1 hora",
            Componente = "Verbal, Somático, Material (incenso aceso para ar, argila mole para terra, enxofre e fósforo para fogo ou água e areia para água)",
            Descricao = "Você invoca um servo elemental. Escolha uma área de ar, água, fogo ou terra que preencha 3 metros cúbicos, dentro do alcance.Um elemental de nível de desafio 5 ou inferior, adequado a área que você escolheu, aparece em um espaço desocupado a até 3 metros dela. Por exemplo, um elemental do fogo emergiria de uma fogueira e um elemental da terra erguer-se - ia do solo.O elemental desaparece quando cair a 0 pontos de vida ou quando a magia acabar. O elemental é amigável a você e a seus companheiros pela duração. Role a iniciativa para o elemental, que age no seu próprio turno.Ele obedece a quaisquer comandos verbais que você emitir(não requer uma ação sua).Se você não emitir nenhum comando a ele, ele se defenderá de criaturas hostis, mas no mais, não realizará nenhuma ação.  Se sua concentração for interrompida, o elemental não desaparece.Ao invés disso, você perde o controle sobre o elemental e ele se torna hostil a você e aos seus companheiros, e irá atacar.Um elemental fora de controle não pode ser dispensado e desaparece 1 hora depois de você ter o invocado. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 79,
            Nome = "Conjurar Fada",
            Escola = "Conjuração",
            Alcance = "27 metros",
            TempodeConjuracao = "1 minuto",
            Duracao = "Concentração, até 1 hora",
            Componente = "Verbal, Somático",
            Descricao = "Você invoca uma criatura feérica de nível de desafio 6 ou inferior ou um espírito feérico que assume a forma de uma besta de nível de desafio 6 ou inferior.Ela aparece num espaço desocupado, que você possa ver dentro do alcance.A criatura feérica desaparece se cair a 0 pontos de vida ou quando a magia acabar. A criatura feérica é amigável a você e a seus companheiros pela duração.Role a iniciativa para a criatura, que age no seu próprio turno.Ela obedece a quaisquer comandos verbais que você emitir(não requer uma ação sua), contanto que não violem sua tendência. Se você não emitir nenhum comando a ela, ela se defenderá de criaturas hostis, mas no mais, não realizará nenhuma ação. Se sua concentração for interrompida, a criatura feérica não desaparece.Ao invés disso, você perde o controle sobre o elemental e ele se torna hostil a você e aos seus companheiros, e irá atacar.Uma criatura feérica fora de controle não pode ser dispensada e desaparece 1 hora depois de você ter a invocado. O Mestre possui as estatísticas da criatura feérica. Em Níveis Superiores.Quando você conjurar essa magia usando um espaço de magia de 7° nível ou superior, o nível de desafio aumenta em 1 para cada nível do espaço acima do 6°. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 80,
            Nome = "Conjurar Rajada",
            Escola = "Conjuração",
            Alcance = "Pessoal (cone de 18 metros)",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático, Material (uma munição ou arma de arremesso)",
            Descricao = "Você arremessa uma arma não-mágica ou dispara uma munição não - mágica no ar para criar um cone de armas idênticas que se lançam a frente e então desaparecem. Cada criatura num cone de 18 metros, deve ser bem sucedida num teste de resistência de Destreza.Uma criatura sofre 3d8 de dano se falhar na resistência, ou metade desse dano num sucesso.O tipo do dano é o mesmo da arma ou munição usada como componente",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 81,
            Nome = "Conjurar Saraivada",
            Escola = "Conjuração",
            Alcance = "45 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático, Material (uma munição ou arma de arremesso)",
            Descricao = "Você dispara uma munição não-mágica de uma arma à distância ou arremessa uma arma não - mágica no ar e escolhe um ponto dentro do alcance.Centenas de duplicatas da munição ou arma caem em uma saraivada vinda de cima e então desaparecem. Cada criatura num cilindro com 12 metros de raio e 6 metros de altura centrado no ponto, deve realizar um teste de resistência de Destreza.Uma criatura sofre 8d8 de dano se falhar na resistência, ou metade desse dano num sucesso.O tipo do dano é o mesmo da munição ou arma. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 82,
            Nome = "Conjurar Seres da Floresta",
            Escola = "Conjuração",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 hora",
            Componente = "Verbal, Somático, Material (um fruto sagrado por criatura invocada)",
            Descricao = "Você invoca criaturas feéricas que aparecem em espaços desocupados, que você possa ver dentro do alcance. Escolha uma das opções a seguir para aparecer:  Uma criatura feérica de nível de desafio 2 ou inferior  Duas criaturas feéricas de nível de desafio 1 ou inferior  Quatro criaturas feéricas de nível de desafio 1 / 2 ou inferior  Oito criaturas feéricas de nível de desafio 1 / 4 ou inferior Uma criatura invocado desaparece quando cair a 0 pontos de vida ou quando a magia acabar. As criaturas invocadas são amigáveis a você e a seus companheiros.Role a iniciativa para as criaturas invocadas como um grupo, que age no seu próprio turno. Eles obedecem a quaisquer comandos verbais que você emitir(não requer uma ação sua).Se você não emitir nenhum comando a elas, elas se defenderão de criaturas hostis, mas no mais, não realizarão nenhuma ação. O Mestre possui as estatísticas das criaturas. Em Níveis Superiores.Se você conjurar essa magia usando certos espaços de magia superiores, você escolhe uma das opções de invocação acima e mais criaturas aparecem: o dobro delas com um espaço de 6° nível e o triplo delas com um espaço de 8° nível.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 83,
            Nome = "Consagrar",
            Escola = "Evocação",
            Alcance = "Toque",
            TempodeConjuracao = "24 horas",
            Duracao = "Até ser dissipada",
            Componente = "Verbal, Somático, Material (ervas, óleos e incenso valendo, no mínimo, 1000 po, consumidos pela magia)",
            Descricao = "Você toca um ponto e infunde uma área ao redor com poder sagrado(ou profano).A área pode ter até 18 metros de raio e a magia falha se o raio incluir uma área já sob efeito da magia consagrar.A área afetada está sujeita aos seguintes efeitos. Primeiro, celestiais, corruptores, elementais, fadas e mortos - vivos não conseguem entrar na área, nem, tais criaturas, podem enfeitiçar, amedrontar ou possuir criaturas dentro da área.Qualquer criatura enfeitiçada, amedrontada ou possuída por uma criatura dessas, não estará mais enfeitiçada, amedrontada ou possuída ao adentrar a área.Você pode excluir um ou mais desses tipos de criaturas desse efeito. Segundo, você pode vincular um efeito extra a área. Escolha o efeito da lista a seguir, ou escolha um efeito oferecido pelo Mestre.Alguns desses efeitos se aplicam a criaturas na área; você pode definir seu o efeito se aplica a todas as criaturas, criaturas que seguem uma divindade ou líder especifico ou criaturas de uma espécie especifica, como orcs ou trolls.Quando uma criatura que seria afetada entrar na área da magia pela primeira vez em um turno, ou começar seu turno nela, ela pode fazer um teste de resistência de Carisma.Se obtiver sucesso, a criatura ignora o efeito extra até sair da área. Coragem.As criaturas afetadas não podem ser amedrontadas enquanto estiverem na área. Descanso Eterno. Cadáveres enterrados na área não podem ser transformados em mortos-vivos. Escuridão.Escuridão preenche a área.Luz normal, assim como luz mágica criada por magias de nível inferior ao nível do espaço usado para conjurar essa magia, não podem iluminar a área. Idiomas.As criaturas afetadas podem se comunicar com qualquer outra criatura na área, mesmo que elas não partilhem um idioma em comum. Interferência Extradimensional. As criaturas afetadas não podem se mover ou viajar usando teletransporte ou por meios extradimensionais ou interplanares. Luz do Dia.Luz plena preenche a área. Escuridão mágica criada por magias de nível inferior ao nível do espaço usado para conjurar essa magia, não podem extinguir a luz. Medo.As criaturas afetadas ficam amedrontadas enquanto estiverem na área. Proteção contra Energia.As criaturas afetadas na área tem resistência a um tipo de dano, à sua escolha, exceto de concussão, cortante ou perfurante. Silêncio.Nenhum som pode ser emitido de dentro da área e nenhum som pode adentra-la. Vulnerabilidade à Energia.As criaturas afetadas na área tem vulnerabilidade a um tipo de dano, à sua escolha, exceto de concussão, cortante ou perfurante.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 84,
            Nome = "Consertar",
            Escola = "Transmutação",
            Alcance = "Toque",
            TempodeConjuracao = "1 minuto",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático, Material (dois ímãs)",
            Descricao = "Essa magia repara um única quebra ou fissura em um objeto que você tocar, como um elo quebrado de uma corrente, duas metades de uma chave partida, um manto rasgado ou o vazamento em um odre.Contanto que a quebra ou fissura não tenha mais de 30 centímetros em qualquer dimensão, você pode remenda - la, não deixando qualquer vestígio do dano anterior. Essa magia pode reparar fisicamente um item mágico ou constructo, mas a magia não irá restaurar a magia em tais objetos. ",
            IdTipoMagia = 1
        },
        new Magia
        {
            IdMagia = 85,
            Nome = "Constrição",
            Escola = "Conjuração",
            Alcance = "27 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático",
            Descricao = "Ervas e vinhas poderosas brotam do solo num quadrado de 6 metros a partir de um ponto dentro do alcance.Pela duração, essas plantas transformam o solo na área em terreno difícil. Uma criatura na área quando você conjurar a magia deve ser bem sucedida num teste de resistência de Força ou ficará impedida pelo emaranhado de plantas, até a magia acabar.Uma criatura impedida pelas plantas pode usar sua ação para realizar um teste de Força, contra a CD da magia.Se for bem sucedido, irá se libertar. Quando a magia termina, as plantas conjuradas murcharão. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 86,
            Nome = "Contato Extraplanar",
            Escola = "Adivinhação (ritual)",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 minuto",
            Duracao = "1 minuto",
            Componente = "Verbal",
            Descricao = "Você contata mentalmente um semideus, o espírito de um sábio morto há muito tempo ou alguma outra entidade misteriosa de outro plano.Contatar esse extraplanar inteligente pode distorcer ou até mesmo arruinar com sua mente.Quando você conjurar essa magia, faça um teste de resistência de Inteligência CD 15.Se falhar, você sofre 6d6 de dano psíquico e fica insano até terminar um descanso longo.Enquanto estiver insano, você não pode realizar ações, não entende o que as outras criaturas dizem, não pode ler e fala apenas coisas sem sentido. Conjurar a magia restauração maior em você acaba com esse efeito. Se obtiver sucesso no teste de resistência, você pode fazer até cinco perguntas à entidade.Você deve fazer suas perguntas antes da magia acabar.O Mestre responde cada pergunta com uma única palavra, como “sim”, “não”, “talvez”, “nunca”, “irrelevante” ou “incerto” (se a entidade não souber a resposta para a pergunta).Em caso de uma resposta de única palavra puder levar ao engano, o Mestre pode, ao invés disso, oferecer uma frase curta como resposta.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 87,
            Nome = "Contramágica",
            Escola = "Abjuração",
            Alcance = "18 metros",
            TempodeConjuracao = "1 reação, que você realiza quando vê uma criatura a até 18 metros conjurando uma magia",
            Duracao = "Instantânea",
            Componente = "Somático",
            Descricao = "Você tenta interromper uma criatura no processo de conjuração de uma magia.Se a criatura estiver conjurando uma magia de 3° nível ou inferior, a magia falha e não gera nenhum efeito.Se ela estiver conjurando uma magia de 4° nível ou superior, faça um teste de habilidade usando sua habilidade de conjuração.A CD é igual a 10 + o nível da magia.Caso seja bem sucedido, a magia da criatura falha e não gera nenhum efeito. Em Níveis Superiores.Se você conjurar essa magia usando um espaço de magia de 4° nível ou superior, a magia interrompida não vai gerar efeito se o nível dela for menor ou igual ao nível do espaço de magia que você usar.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 88,
            Nome = "Contingência",
            Escola = "Evocação",
            Alcance = "Pessoal",
            TempodeConjuracao = "10 minutos",
            Duracao = "10 dias",
            Componente = "Verbal, Somático, Material (uma estátua sua esculpida em marfim e decorada com gemas valendo, no mínimo, 1.500 po)",
            Descricao = "Escolha uma magia de 5° nível ou inferior que você possa conjurar, que tenha um tempo de conjuração de 1 ação e que possa ter você como alvo.Você conjura essa magia – chamada de magia contingente – como parte da conjuração de contingência, gastando espaços de magia para ambas, mas a magia contingente não tem efeito imediato.Ao invés disso, ela se ativa quando uma certa circunstância ocorre.Você descreve a circunstância quando conjura as duas magias.Por exemplo, uma contingência conjurada com respirar na água pode estipular que respirar na água se ative quando você estiver imerso em água ou um líquido similar. A magia contingente se ativa imediatamente depois da circunstância ser satisfeita pela primeira vez, quer você queira, quer não, e a contingência termina. A magia contingente afeta apenas você, mesmo que ela normalmente possa afetar outros alvos.Você pode ter apenas uma contingência ativa por vez.Se você conjurar essa magia novamente, o efeito da outra magia contingência termina.Além disso, a contingência também termina em você se os componentes materiais dela não estiverem mais com você. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 89,
            Nome = "Controlar a Água",
            Escola = "Transmutação",
            Alcance = "90 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 10 minutos",
            Componente = "Verbal, Somático, Material (uma gota de água e uma pitada de poeira)",
            Descricao = "Até o fim da magia, você controla qualquer corpo de água dentro da área que você escolher, que é um cubo de 30 metros quadrados.Você pode escolher dentre quaisquer dos efeitos seguintes, quando você conjurar essa magia. Com uma ação no seu turno, você pode repetir o mesmo efeito ou escolher um diferente. Inundação.Você faz com que o nível da água de toda área afetada suba até 6 metros.Se a área incluir uma margem, a inundação ira transbordar para a terra seca. Se você escolher uma área em um extenso corpo de água, ao invés disso, você cria uma onda com 6 metros de altura que irá de um lado ao outro da área e então desaba.Qualquer veículo Enorme ou menor no caminho da onda será carregado por ela até o outro lado.Qualquer veículo Enorme ou menor atingido pela onda tem uma chance de 25 por cento de emborcar. O nível da água se mantem elevado até a magia acabar ou você escolher um efeito diferente.Se esse efeito produzir uma onda, a onda se repete no início do seu próximo turno enquanto o efeito de inundação durar. Dividir Água. Você faz com que a água na área se divida e crie uma trincheira. A trincheira se estende por toda área da magia e a água separada forma uma parede de cada lado.A trincheira permanece até a magia acabar ou você escolher um efeito diferente.A água, então, lentamente preenche a trincheira ao longo do curso da próxima rodada até o nível normal da água ser restaurado. Redirecionar Fluxo. Você faz com que o fluxo da água na área se mova na direção que você escolher, mesmo que a água tenha que fluir através de obstáculos, subir muros ou em outra direção improvável. A água na área se move na direção ordenada, mas uma vez que tenha se movido além da área da magia, ela conclui seu fluxo baseado nas condições do terreno.A água continua a se mover na direção que você escolheu até a magia acabar ou você escolher um efeito diferente. Redemoinho.Esse efeito requer um corpo de água de, pelo menos, 15 metros quadrados e 7,5 metros de profundidade.Você faz com que um redemoinho se forme no centro da área. O redemoinho forma um vórtice com 1,5 metro de largura na base, chegando a 15 metros de largura no topo e 7,5 metros de altura.Qualquer criatura ou objeto na água a até 7,5 metros do vórtice é puxado 3 metros na direção dele. Uma criatura pode tentar nadar para longe do vórtice com um teste de Força(Atletismo) contra a CD da magia. Quando uma criatura entrar no vórtice pela primeira vez no turno dela ou começar seu turno dentro dele, ela deve realizar um teste de resistência de Força. Se falhar, a criatura sofre 2d8 de dano de concussão e estará presa no vórtice até a magia acabar.Se passar na resistência, a criatura sofre metade do dano e não estará presa no vórtice.Uma criatura presa no vórtice pode usar sua ação para tentar nadar para fora do vórtice como descrito acima, mas terá desvantagem no teste de Força (Atletismo) para fazer isso. A primeira vez a cada turno que um objeto entrar no vórtice, o objeto sofre 2d8 de dano de concussão; esse dano se repete a cada rodada que ele permanecer no vórtice",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 90,
            Nome = "Controlar o Clima",
            Escola = "Transmutação",
            Alcance = "Pessoal (7.5 quilômetros de raio)",
            TempodeConjuracao = "10 minutos",
            Duracao = "Concentração, até 8 horas",
            Componente = "Verbal, Somático, Material (incenso aceso e pedaçós de terra e madeira misturados em água)",
            Descricao = "Você toma controle do clima numa área de 7,5 quilômetros de você pela duração.Você deve estar ao ar livre para conjurar essa magia.Se mover para um lugar onde você não tenha uma visão clara do céu termina a magia prematuramente. Quando você conjurar essa magia, você muda as condições climáticas atuais, que são determinadas pelo Mestre baseado no ambiente e estação.Você pode mudar a precipitação, temperatura e vento.Leva 1d4 x 10 minutos para as novas condições fazerem efeito.Quando a magia terminar, o clima, gradualmente, volta ao normal. Quando você altera as condições climáticas, encontre a condição atual nas tabelas a seguir e mude em um estágio, para cima ou para baixo.Quando mudar o vento, você pode mudar a direção do mesmo. PRECIPITAÇÃO Estágio Condição 1 Céu claro 2 Parcialmente encoberto 3 Céu escuro ou nublado 4 Chuva, granizo ou neve 5 Chuva torrencial, tempestade de granizo ou nevasca TEMPERATURA VENTO Estágio Condição Estágio Condição 1 Calor insuportável 1 Calmo 2 Quente 2 Vento moderado 3 Morno 3 Vento forte 4 Frio 4 Ventania 5 Gelado 5 Temporal 6 Frio ártico",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 91,
            Nome = "Convocar Familiar",
            Escola = "Conjuração (ritual)",
            Alcance = "3 metros",
            TempodeConjuracao = "1 hora",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático, Material (carvão, incenso e ervas no valor de 10 po, que dever ser consumidos pelo fogo em um braseiro de bronze)",
            Descricao = "Você adquire os serviços de uma familiar, um espírito que toma a forma de um animal, à sua escolha: aranha, caranguejo, cavalo marinho, coruja, corvo, doninha, gato, falcão, lagarto, morcego, peixe(arenque), polvo, rato, rã (sapo) ou serpente venenosa.Aparecendo em um espaço desocupado dentro do alcance, o familiar tem as mesmas estatísticas da forma escolhida, no entanto, ele é um celestial, corruptor ou fada(à sua escolha) ao invés de uma besta. Seu familiar age independentemente de você, mas ele sempre obedece aos seus comandos. Em combate, ele rola sua a própria iniciativa e age no seu próprio turno.Um familiar não pode atacar, mas ele pode realizar outras ações, como de costume. Quando um familiar cai a 0 pontos de vida, ele desaparece, não deixando qualquer corpo físico para trás. Ele reaparece depois de você conjurar essa magia novamente. Enquanto seu familiar estiver a até 30 metros de você, você pode se comunicar telepaticamente com ele.Além disso, com uma ação, você pode ver através dos olhos do familiar e ouvir através dos ouvidos dele, até o início do seu próximo turno, adquirindo os benefícios de qualquer sentido especial que o familiar possua.Durante esse período, você estará cego e surdo em relação aos seus próprios sentidos. Com uma ação, você pode, temporariamente, dispensar seu familiar. Ele desaparece dentro de uma bolsa dimensional onde ele aguarda sua convocação. Alternativamente, você pode dispensa - lo para sempre. Com uma ação, enquanto ele estiver temporariamente dispensado, você pode fazê - lo reaparecer em qualquer espaço desocupado a até 9 metros de você. Você não pode ter mais de um familiar por vez. Se você conjurar essa magia enquanto já tiver um familiar, ao invés disso, você faz seu familiar existente adotar uma nova forma. Escolha uma das formas da lista acima.Seu familiar se transforma na criatura escolhida. Finalmente, quando você conjura uma magia com alcance de toque, seu familiar pode transmitir a magia, como se ele tivesse conjurado ela.Seu familiar precisa estar a até 30 metros de você e deve usar a reação dele para transmitir a magia quando você a conjurar.Se a magia necessitar de uma jogada de ataque, você usa seu modificador de ataque para essa jogada. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 92,
            Nome = "Convocar Montaria",
            Escola = "Conjuração",
            Alcance = "9 metros",
            TempodeConjuracao = "10 minutos",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático",
            Descricao = "Você convoca um espírito que assume a forma de uma montaria excepcionalmente inteligente, forte e leal, criando uma ligação duradoura com ela.Aparecendo em um espaço desocupado dentro do alcance, a montaria adquire a forma que você escolher, como um cavalo de guerra, um pônei, um camelo, um alce ou um mastim. (Seu Mestre pode permitir outros animais para serem convocados como montarias.) A montaria tem as estatísticas da forma escolhida, no entanto, ele é um celestial, corruptor ou fada(à sua escolha) ao invés do seu tipo normal.Além disso, se sua montaria tiver Inteligência 5 ou menor, a Inteligência dela se torna 6 e ela ganha a capacidade de compreender um idioma, à sua escolha, que você fala. Sua montaria serve tanto para cavalgar quando para o combate e você tem uma ligação instintiva com ela que permite a vocês lutarem como uma unidade singular. Enquanto estiver montado na sua montaria, você pode fazer com que qualquer magia que você conjure que tenha alcance pessoal, também afete a sua montaria. Quando a montaria cair a 0 pontos de vida, ela desaparece, não deixando qualquer corpo físico para trás. Você também pode dispensar sua montaria a qualquer momento, com uma ação, fazendo - a desaparecer.Em ambos os casos, conjurar essa magia novamente convocará a mesma montaria, restaurando - a ao seu máximo de pontos de vida. Enquanto sua montaria estiver a até 1,5 quilômetro de você, você pode se comunicar telepaticamente com ela. Você não pode ter mais de uma montaria ligado por essa magia por vez. Com uma ação, você pode liberar a montaria da ligação a qualquer momento, fazendo-a desaparecer.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 93,
            Nome = "Convocar Relâmpago",
            Escola = "Conjuração",
            Alcance = "36 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 10 minutos",
            Componente = "Verbal, Somático",
            Descricao = "Uma nuvem tempestuosa aparece em formato cilíndrico com 3 metros de altura e 18 metros de raio, centrada num ponto que você possa ver, 30 metros acima de você.A magia falha se você não puder ver um ponto no ar em que a nuvem possa aparecer(por exemplo, se você estiver em uma sala que não possa comportar a nuvem). Quando você conjurar a magia, escolha um ponto que você possa ver dentro do alcance.Um raio de eletricidade é disparado da nuvem no ponto.Cada criatura a 1,5 metro desse ponto deve realizar um teste de resistência de Destreza.Uma criatura sofre 3d10 de dano elétrico se falhar no teste, ou metade desse dano se passar. Em cada um dos seus turnos, até a magia acabar, você pode usar sua ação para convocar um relâmpago dessa forma novamente, afetando o mesmo ponto ou um diferente. Se você estiver a céu aberto em condições tempestuosas quando conjurar essa magia, a magia lhe dá controle sobre a tempestade existente ao invés de criar uma nova.Sob tais condições, o dano da magia aumenta em 1d10. Em Níveis Superiores.Se você conjurar essa magia usando um espaço de magia de 4° nível ou superior, o dano aumenta em 1d10 para cada nível do espaço acima do 3°. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 94,
            Nome = "Coroa da Loucura",
            Escola = "Encantamento",
            Alcance = "36 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático",
            Descricao = "Um humanoide, à sua escolha, que você possa ver dentro do alcance, deve ser bem sucedido num teste de resistência de Sabedoria ou ficará enfeitiçado por você pela duração.Enquanto o alvo estiver enfeitiçado dessa forma, uma coroa retorcida de ferro denteado aparece na cabeça dele e a loucura brilha em seus olhos. A criatura enfeitiçada deve usar sua ação antes de se mover, em cada um dos turnos dela, para realizar um ataque corpo-a - corpo contra uma criatura, diferente de si mesma, que você escolher mentalmente. O alvo pode agir normalmente no turno dele se você não escolher uma criatura ou se você não estiver dentro do alcance. Nos seus turnos subsequentes, você deve usar sua ação para manter o controle sobre o alvo, ou a magia termina.Igualmente, o alvo pode realizar um teste de resistência de Sabedoria no final de cada um dos turnos dele.Se obtiver sucesso, a magia termina.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 95,
            Nome = "Cordão de Flechas",
            Escola = "Transmutação",
            Alcance = "1.5 metro",
            TempodeConjuracao = "1 ação",
            Duracao = "8 horas",
            Componente = "Verbal, Somático, Material (quatro ou mais flechas ou virotes)",
            Descricao = "Você enfinca quatro munições não-mágicas – flechas ou virotes de besta – no solo dentro do alcance e conjura magia neles para proteger uma área. Até a magia acabar, sempre que uma criatura diferente de você se aproximar a 9 metros das munições pela primeira vez em um turno ou terminar seu turno na área, uma das munições voa para atingi-la.A criatura deve ser bem sucedida num teste de resistência de Destreza ou sofrerá 1d6 de dano perfurante.A munição, então, é destruída.A magia termina quando não restar nenhuma munição. Quando você conjurar essa magia, você pode designar quaisquer criaturas, à sua escolha, e a magia ignora-as. Em Níveis Superiores.Quando você conjurar essa magia usando um espaço de magia de 3° nível ou superior, a quantidade de munições que você pode afetar aumenta em dois para cada nível do espaço acima do 2°.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 96,
            Nome = "Corrente de Relâmpago",
            Escola = "Evocação",
            Alcance = "45 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático, Material (um pouco de pelo; um pedaço de âmbar, vidro ou um bastão de cristal; e três pinos de prata)",
            Descricao = "Você cria um raio elétrico que atinge um alvo, à sua escolha, que você possa ver dentro do alcance.Três raios saltam do alvo para até três outros alvos, cada um a não mais de 9 metros do alvo primário. Um alvo pode ser uma criatura ou um objeto e só pode ser alvo de um único desses raios. Um alvo deve realizar um teste de resistência de Destreza.O alvo sofre 10d8 de dano elétrico se falhar no teste ou metade desse dano se for bem sucedido. Em Níveis Superiores.Se você conjurar essa magia usando um espaço de magia de 7° nível ou superior, um raio adicional salta do alvo primário para outro alvo para cada nível do espaço acima do 6°. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 97,
            Nome = "Crescer Espinhos",
            Escola = "Transmutação",
            Alcance = "45 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 10 minutos",
            Componente = "Verbal, Somático, Material (sete espinhos afiados ou sete gravetos, todos com uma ponta afiada)",
            Descricao = "O solo num raio de 6 metros, centrado num ponto dentro do alcance, se retorce e brotam cavilhas rígidas e espinhos.A área se torna terreno difícil pela duração. Quando uma criatura entrar ou se mover dentro da área, ela sofrerá 2d4 de dano perfurante para cada 1,5 metro que ela atravessar. A transformação do terreno é camuflada para parecer natural.Qualquer criatura que não puder ver a área no momento que a magia for conjurada, deve realizar um teste de Sabedoria(Percepção) contra a CD da magia para reconhecer o terreno como perigoso, antes de adentra - lo. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 98,
            Nome = "Criação",
            Escola = "Ilusão",
            Alcance = "9 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Especial",
            Componente = "Verbal, Somático, Material (um pequeno pedaço de material do mesmo tipo do item que você planeje criar)",
            Descricao = "Você puxa mechas de matéria sombria da Umbra para criar objetos inanimados de matéria vegetal dentro do alcance: bens finos, cordas, madeira ou algo similar. Você também pode usar a magia para criar objetos minerais como pedra, cristal ou metal. O objeto criado não pode ser maior que um cubo de 1,5 metro e o objeto deve ser de um formado e material que você já tenha visto antes. A duração depende do material do objeto.Se o objeto for composto por diversos materiais, use o de menor duração. Material Duração Matéria vegetal 1 dia Pedra ou cristal 12 horas Metais preciosos 1 hora Gemas 10 minutos Adamante ou mitral 1 minuto Usar qualquer material criado por essa magia como componente material de outra magia faz com que a magia falhe. Em Níveis Superiores.Quando você conjurar essa magia usando um espaço de magia de 6° nível ou superior, o tamanho do cubo aumenta em 1,5 metro para cada nível do espaço de magia acima do 5°. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 99,
            Nome = "Criar Alimentos",
            Escola = "Conjuração",
            Alcance = "9 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantâneo",
            Componente = "Verbal, Somático",
            Descricao = "Você cria 25 quilos de comida e 100 litros de água no solo ou em um recipiente dentro do alcance, suficiente para sustentar até quinze humanoide ou cinco montarias por 24 horas.A comida é insossa, porém, nutritiva e estraga se não for consumida após 24 horas.A água é limpa e não fica ruim. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 100,
            Nome = "Criar Chamas",
            Escola = "Conjuração",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 ação",
            Duracao = "10 minutos",
            Componente = "Verbal, Somático",
            Descricao = "Uma chama tremulante aparece na sua mão. A chama permanece ai pela duração e não machuca nem você nem seu equipamento.A chama emite luz plena num raio de 3 metros e penumbra por 3 metros adicionais.A magia acaba se você dissipa - la usando uma ação ou se conjura - la novamente. Você pode, também, atacar com a chama, no entanto, fazer isso acaba com a magia.Quando você conjura essa magia ou com uma ação em um turno posterior, você pode arremessar a chama numa criatura a até 9 metros de você.Faça um ataque à distância com magia.Se atingir, o alvo sofre 1d8 de dano de fogo. O dano dessa magia aumenta em 1d8 quando você alcança o 5° nível(2d8), 11° nível(3d8) e 17° nível(4d8).",
            IdTipoMagia = 1
        },
        new Magia
        {
            IdMagia = 101,
            Nome = "Criar Mortos-Vivos",
            Escola = "Necromancia",
            Alcance = "3 metros",
            TempodeConjuracao = "1 minuto",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático, Material (um pote de barro cheio de terra de sepultura, um pote de barro cheio de água salobra, e uma ônix negra no valor de 150 po, para cada corpo)",
            Descricao = "Você só pode conjurar essa magia durante a noite. Escolha até três corpos de humanoides Médios ou Pequenos dentro do alcance.Cada corpo se torna um carniçal sob seu controle. (O Mestre tem as estatísticas de jogo das criaturas.) Com uma ação bônus, em cada um dos seus turnos, você pode comandar mentalmente qualquer criatura que você animou com essa magia, se a criatura estiver a até 36 metros de você(se você controla diversas criaturas, você pode comandar qualquer uma ou todas elas ao mesmo tempo, emitindo o mesmo comando para cada uma).Você decide qual ação a criatura irá fazer e para onde ela irá se mover durante o próximo turno dela, ou você pode emitir um comando geral, como para guardar uma câmara ou corredor especifico. Se você não der nenhum comando, as criaturas apenas se defenderão contra criaturas hostis. Uma vez que receba uma ordem, a criatura continuará a segui-la até a tarefa estar concluída. A criatura fica sob seu controle por 24 horas, depois disso ela para de obedecer aos seus comandos.Para manter o controle da criatura por mais 24 horas, você deve conjurar essa magia na criatura novamente, antes das 24 horas atuais terminarem.Esse uso da magia recupera seu controle sobre até três criaturas que você tenha animado com essa magia, ao invés de animar novas. Em Níveis Superiores.Quando você conjurar essa magia usando um espaço de magia de 7° nível, você pode animar ou recuperar o controle de quatro carniçais. Quando você conjura essa magia usando um espaço de magia de 8° nível, você pode animar ou recuperar o controle de cinco carniçais ou dois lívidos ou aparições. Quando você conjurar essa magia usando um espaço de magia de 9° nível, você pode animar ou recuperar o controle de seis carniçais, três lívidos ou aparições ou duas múmias. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 102,
            Nome = "Criar ou Destruir Água",
            Escola = "Transmutação",
            Alcance = "9 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático, Material (uma gota de água se estiver criando ou alguns grãos de areia se estiver destruindo)",
            Descricao = "Você pode tanto criar quanto destruir água. Criar Água.Você cria 30 litros de água limpa dentro do alcance, em um recipiente aberto. Alternativamente, a água pode cair como chuva em um cubo de 9 metros dentro do alcance, extinguindo chamas expostas na área. Destruir Água. Você destrói até 30 litros de água de um recipiente aberto dentro do alcance. Alternativamente, você pode destruir um nevoeiro em um cubo de 9 metros dentro do alcance. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 2° nível ou superior, você pode criar ou destruir 30 litros de água adicionais, ou o tamanho do cubo aumenta em 1,5 metro, para cada nível do espaço acima do 1°. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 103,
            Nome = "Criar Passagem",
            Escola = "Transmutação",
            Alcance = "9 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "1 hora",
            Componente = "Verbal, Somático, Material (algumas sementes de gergelim)",
            Descricao = "Uma passagem aparece em um ponto, à sua escolha, que você possa ver em uma superfície de madeira, gesso ou rocha(como um muro, um teto ou um piso) dentro do alcance e permanece pela duração. Você escolhe as dimensões da passagem: até 1,5 metro de largura, 2,10 de altura e 6 metros de profundidade.A passagem não provoca instabilidade na estrutura ao seu redor. Quando a abertura desaparecer, qualquer criatura ou objeto que ainda estiver dentro da passagem criada pela magia é ejetada em segurança para o espaço desocupado mais próximo da superfície onde a magia foi conjurada. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 104,
            Nome = "Cúpula Antivida",
            Escola = "Abjuração",
            Alcance = "Pessoal (3 metros de raio)",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 hora",
            Componente = "Verbal, Somático",
            Descricao = "Uma barreira cintilante se estende de você até 3 metros de raio, e se move com você, permanecendo centrada em você e restringindo criaturas diferentes de mortos - vivos e constructos.A barreira mantem - se pela duração. A barreira previna uma criatura afetada de atravessala ou alcançar através dela.Uma criatura afetada pode conjurar magias ou realizar ataques à distância ou ataques com armas de haste através da barreira. Se você se mover forçando uma criatura afetada a atravessar a barreira, a magia termina. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 105,
            Nome = "Cura Completa",
            Escola = "Evocação",
            Alcance = "18 metrosa",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático",
            Descricao = "Escolha uma criatura que você possa ver, dentro do alcance.Um surto de energia positiva banha a criatura, fazendo - a recuperar 70 pontos de vida.Essa magia também acaba com efeitos de cegueira, surdez e qualquer doença que estejam afetando o alvo.Essa magia não tem efeito em constructos ou mortos - vivos. Em Níveis Superiores.Quando você conjurar essa magia usando um espaço de magia de 7° nível ou superior, a quantidade de cura aumenta em 10 para cada nível do espaço acima do 6°. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 106,
            Nome = "Cura Completa em Massa",
            Escola = "Evocação",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático",
            Descricao = "Uma inundação de energia curativa emerge de você para as criaturas feridas ao seu redor.Você restaura até 700 pontos de vida, divididos, à sua escolha, entre qualquer quantidade de criaturas que você possa ver, dentro do alcance.As criaturas curadas por essa magia também são curadas de todas as doenças e qualquer efeito que as deixou cegas ou surdas.Essa magia não afeta mortosvivos ou constructos.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 107,
            Nome = "Curar Ferimentos",
            Escola = "Evocação",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático",
            Descricao = "Uma criatura que você tocar recupera uma quantidade de pontos de vida igual a 1d8 + seu modificador de habilidade de conjuração.Essa magia não produz efeito em mortos - vivos ou constructos. Em Níveis Superiores.Se você conjurar essa magia usando um espaço de magia de 2° nível ou superior, a cura aumenta em 1d8 para cada nível do espaço acima do 1°. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 108,
            Nome = "Curar Ferimentos em Massa",
            Escola = "Evocação",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático",
            Descricao = "Uma onda de energia curativa emerge de um ponto, à sua escolha, dentro do alcance.Escolha até seis criaturas numa esfera de 9 metros de raio, centrada nesse ponto. Cada alvo recupera uma quantidade de pontos de vida igual a 3d8 + seu modificador de habilidade de conjuração.A magia não afeta mortos - vivos ou constructos. Em Níveis Superiores.Quando você conjurar essa magia usando um espaço de magia de 6° nível ou superior, a cura aumenta em 1d8 para cada nível do espaço acima do 5°.",
            IdTipoMagia = 2
        },

        new Magia
        {
            IdMagia = 109,
            Nome = "Dança Irresistível de Otto",
            Escola = "Encantamento",
            Alcance = "9 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal",
            Descricao = "Escolha uma criatura que você possa ver, dentro do alcance.O alvo começa a dançar comicamente no lugar: rodopiando, batendo os pés e saltitando pela duração.As criaturas que não podem ser enfeitiçadas são imunes a essa magia. Uma criatura dançando deve usar todo o seu movimento para dançar sem abandonar seu espaço e tem desvantagem nos testes de resistência de Destreza e nas jogadas de ataque.Enquanto o alvo estiver sob efeito dessa magia, as outras criaturas terão vantagem nas jogadas de ataque contra ele.Com uma ação, uma criatura dançando pode realizar um teste de resistência de Sabedoria para recuperar controle sobre si mesmo. Num sucesso na resistência, a magia acaba.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 110,
            Nome = "Dedo da Morte",
            Escola = "Necromancia",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático",
            Descricao = "Você envia energia negativa na direção de uma criatura que você possa ver, dentro do alcance, causando dores severas nela. O alvo deve realizar um teste de resistência de Constituição. Ele sofre 7d8 + 30 de dano necrótico se falhar na resistência, ou metade desse dano se obtiver sucesso. Um humanoide morto por essa magia, se ergue no início do seu próximo turno como um zumbi que está permanentemente sob seu controle, seguindo suas ordens verbais da melhor forma possível. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 111,
            Nome = "Desejo",
            Escola = "Conjuração",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal",
            Descricao = "Desejo é a magia mais poderosa que uma criatura mortal pode conjurar.Apenas ao falar em voz alta, você pode alterar os próprios fundamentos da realidade, de acordo com seus desejos. O uso básico dessa magia é de copiar qualquer magia de 8° nível ou inferior.Você não precisa atender a qualquer pré - requisito da magia copiada, incluindo os componentes dispendiosos.A magia simplesmente acontece. Alternativamente, você pode criar um dos seguintes efeitos, à sua escolha:  Você cria um objeto no valor de até 25.000 po, que não seja mágico.O objeto não pode ter dimensões maiores que 90 metros e ele aparece em um espaço desocupado que você possa ver, no chão.  Você permite que até doze criaturas que você possa ver, recuperem todos os seus pontos de vida e você acaba com todos os efeitos descritos na magia restauração maior.  Você concede a até dez criaturas que você possa ver, resistência a um tipo de dano, à sua escolha.  Você concede a até dez criaturas que você possa ver, imunidade a uma única magia ou outro efeito mágico por 8 horas.Por exemplo, você poderia deixar você e todos os seus companheiros imunes ao ataque de dreno de vida de um lich.  Você desfaz um único evento recente forçando uma nova jogada de qualquer jogada feita na última rodada (incluindo seu último turno).A realidade remodela - se para acomodar o novo resultado.Por exemplo, uma magia desejo poderia desfazer o teste de resistência bem sucedido de um oponente, um acerto crítico de um inimigo ou o teste de resistência fracassado de um amigo.Você pode forçar que a nova jogada seja feita com vantagem ou desvantagem e você pode escolher se irá usar o resultado da nova jogada ou da jogada original. Você é capaz de fazer coisas além do alcance dos exemplos acima.Apresente seu desejo ao Mestre o mais precisamente possível.O Mestre tem grande amplitude em definir o que ocorre em tais circunstâncias; quanto maior o desejo, maior será a possibilidade de que algo dê errado.Essa magia pode simplesmente falhar, o efeito do ",
            IdTipoMagia = 2
        },
        
        new Magia
        {
            IdMagia = 112,
            Nome = "Desintegrar",
            Escola = "Transmutação",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático, Material (um ímã e uma pitada de poeira)",
            Descricao = "Um fino raio esverdeado é lançado da ponta do seu dedo em um alvo que você possa ver dentro do alcance.O alvo pode ser uma criatura, um objeto ou uma criação de energia mágica, como uma muralha criada por muralha de energia. Uma criatura afetada por essa magia deve realizar um teste de resistência de Destreza. Se falhar na resistência, o alvo sofrerá 10d6 + 40 de dano de energia. Se esse dano reduzir os pontos de vida do alvo a 0, ele será desintegrado. Uma criatura desintegrada e tudo que ela está vestindo ou carregando, exceto itens mágicos, são reduzidos a uma pilha de um fino pó acinzentado. A criatura só pode ser trazida de volta a vida por meio das magias ressurreição verdadeira ou desejo. Essa magia desintegra, automaticamente, um objeto não - mágico Grande ou menor ou uma criação de energia mágica.Se o alvo for um objeto ou criação de energia Enorme ou maior, a magia desintegra uma porção de 3 metros cúbicos dele.Um item mágico não pode ser afetado por essa magia. Em Níveis Superiores.Se você conjurar essa magia usando um espaço de magia de 7° nível ou superior, o dano aumenta em 3d6 para cada nível do espaço acima do 6°. ",
            IdTipoMagia = 2
        },

        new Magia
        {
            IdMagia = 113,
            Nome = "Despedaçar",
            Escola = "Evocação",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático, Material (uma lasca de mica)",
            Descricao = "Um alto som estridente, dolorosamente intenso, emerge de um ponto, à sua escolha, dentro do alcance.Cada criatura, numa esfera de 3 metros de raio, centrada no ponto deve fazer um teste de resistência de Constituição. Uma criatura sofre 3d8 de dano trovejante se falhar na resistência ou metade desse dano se obtiver sucesso. Uma criatura feita de material inorgânico como pedra, cristal ou metal, tem desvantagem nesse teste de resistência. Um objeto não - mágico que não esteja sendo vestido ou carregado, também sofre o dano, se estiver na área da magia. Em Níveis Superiores.Quando você conjurar essa magia usando um espaço de magia de 3° nível ou superior, o dano aumenta em 1d8 para cada nível do espaço acima do 2°",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 114,
            Nome = "Despertar",
            Escola = "Transmutação",
            Alcance = "Toque",
            TempodeConjuracao = "8 horas",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático, Material (uma ágata valendo, no mínimo, 1000 po que será consumida pela magia)",
            Descricao = "Depois de gastar o tempo de conjuração traçando runas mágicas com uma gema preciosa, você toca uma besta ou planta Enorme ou menor.O alvo deve ter ou um valor de Inteligência nulo, ou Inteligência 3 ou menor.O alvo ganha Inteligência 10.O alvo também ganha a capacidade de falar um idioma que você conheça.Se o alvo for uma planta, ela ganha a habilidade de mover seus membros, raízes, vinhas, trepadeiras e assim por diante, e ganha sentidos similares ao de um humano.Seu Mestre escolhe as estatísticas apropriadas para o arbusto desperto ou árvore desperta. A besta ou planta desperta estará enfeitiçada por você por 30 dias ou até você ou seus companheiros fazerem qualquer coisa nociva contra ela.Quando a condição enfeitiçado terminar, a criatura desperta pode escolher permanecer amigável a você, baseado em como ela foi tratada enquanto estava enfeitiçada.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 115,
            Nome = "Despistar",
            Escola = "Ilusão",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 hora",
            Componente = "Somático",
            Descricao = "Você fica invisível ao mesmo tempo que uma cópia ilusória sua aparece onde você estava.A cópia permanece pela duração, mas a invisibilidade acaba se você atacar ou conjurar uma magia. Você pode usar sua ação para mover a cópia ilusória até o dobro do seu deslocamento e fazê - la gesticular, falar e se comportar da forma que você quiser. Você pode ver através dos olhos e ouvir através dos ouvidos da cópia como se você estivesse localizado onde ela está.Em cada um dos seus turnos, com uma ação bônus, você pode trocar o uso dos sentidos dela pelo seu ou voltar novamente.Enquanto você está usando os sentidos dela, você fica cego e surdo ao que está a sua volta.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 116,
            Nome = "Destruição Banidora",
            Escola = "Abjuração",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 ação bônus",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal",
            Descricao = "Da próxima vez que você atingir uma criatura com um ataque com arma, antes do fim da magia, seu ataque crepita com energia e o ataque causa 5d6 de dano de energia extra ao alvo.Além disso, se esse ataque reduzir o alvo a 50 pontos de vida ou menos, você a bane.Se o alvo for nativo de um plano de existência diferente do que você está, o alvo desaparece, retornando ao seu plano natal.Se o alvo for nativo do plano que você está, a criatura é enviada para um semiplano inofensivo. Enquanto estiver lá, a criatura estará incapacitada. Ela permanece lá até a magia acabar, a partir desse ponto, o alvo reaparece no espaço em que ela deixou ou no espaço desocupado mais próximo, se o espaço dela estiver ocupado.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 117,
            Nome = "Destruição Cegante",
            Escola = "Evocação",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 ação bônus",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal",
            Descricao = "Da próxima vez que você atingir uma criatura com um ataque com arma, antes do fim da magia, sua arma emite uma luz intensa, e o ataque causa 3d8 de dano radiante extra ao alvo. Além disso, o alvo deve ser bem sucedido num teste de resistência de Constituição ou ficará cego até a magia acabar. Uma criatura cega por essa magia realiza outro teste de resistência de Constituição no final de cada um dos turnos dela.Se obtiver sucesso, não estará mais cega. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 118,
            Nome = "Destruição Colérica",
            Escola = "Evocação",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 ação bônus",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal",
            Descricao = "Da próxima vez que você atingir com um ataque corpo-acorpo com arma enquanto essa magia durar, seu ataque causará 1d6 de dano psíquico extra.Além disso, se o alvo for uma criatura, ele deve realizar um teste de resistência de Sabedoria ou ficará amedrontado por você até a magia acabar.Com uma ação, a criatura pode realizar um teste de resistência de Sabedoria contra a CD da magia para se manter resoluto e terminar a magia. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 119,
            Nome = "Destruição Estonteante",
            Escola = "Evocação",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 ação bônus",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal",
            Descricao = "Da próxima vez que você atingir uma criatura com um ataque corpo - a - corpo com arma, antes do fim da magia, sua arma penetra tanto no corpo quanto na mente e o ataque causa 4d6 de dano psíquico adicional ao alvo. O alvo deve realizar um teste de resistência de Sabedoria. Se falhar na resistência, ele terá desvantagem nas jogadas de ataque e testes de habilidade e não poderá efetuar reações até o final do próximo turno dele. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 120,
            Nome = "Destruição Lancinante",
            Escola = "Evocação",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 ação bônus",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal",
            Descricao = "Da próxima vez que você atingir uma criatura com um ataque corpo - a - corpo com arma enquanto essa magia durar, sua arma flameja com intensas chamas brancas e o ataque causa 1d6 de dano de fogo extra ao alvo, fazendo - o incendiar pelas chamas.No início de cada turno dele, até a arma acabar, o alvo deve realizar um teste de resistência de Constituição.Se falhar na resistência, ele sofre 1d6 de dano de fogo.Se passar na resistência, a magia acaba.Se o alvo ou uma criatura a 1, 5 metro dele usar uma ação para apagar as chamas ou se algum outro efeito extinguir as chamas (como submergir o alvo em água), a magia acaba. Em Níveis Superiores.Quando você conjurar essa magia usando um espaço de magia de 2° nível ou superior, o dano extra inicial causado por esse ataque aumenta em 1d6 para cada nível do espaço acima do 1°.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 121,
            Nome = "Destruição Trovejante",
            Escola = "Evocação",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 ação bônus",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal",
            Descricao = "Da primeira vez que você atingir um ataque corpo-a-corpo com arma enquanto essa magia durar, sua arma é rodeada por trovões que são audíveis a até 90 metros de você e o ataque causa 2d6 de dano trovejante extra no alvo.Além disso, se o alvo for uma criatura, ele deve ser bem sucedido num teste de resistência de Força ou será empurrado 3 metros para longe de você e cairá no chão. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 122,
            Nome = "Detectar o Bem e Mal",
            Escola = "Adivinhação",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 10 minutos",
            Componente = "Verbal, Somático",
            Descricao = "Pela duração, você sabe se existe uma aberração, celestial, corruptor, elemental, fada ou morto - vivo, a até 9 metros de você, assim como onde a criatura está localizada.Similarmente, você sabe se existe um local ou objeto, a até 9 metros de você, que tenha sido consagrado ou profanado magicamente. A magia pode penetrar a maioria das barreiras, mas é bloqueada por 30 centímetros de rocha, 2, 5 centímetros de metal comum, uma fina camada de chumbo, ou 90 centímetros de madeira ou terra.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 123,
            Nome = "Detectar Magia",
            Escola = "Adivinhação (ritual)",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 10 minutos",
            Componente = "Verbal, Somático",
            Descricao = "Pela duração, você sente a presença de magia a até 9 metros de você.Se você sentir magia dessa forma, você pode usar sua ação para ver uma aura suave em volta de qualquer criatura ou objeto visível, na área que carrega magia, e você descobre a escolha de magia, se houver uma. A magia pode penetrar a maioria das barreiras, mas é bloqueada por 30 centímetros de rocha, 2, 5 centímetros de metal comum, uma fina camada de chumbo, ou 90 centímetros de madeira ou terra. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 124,
            Nome = "Detectar Pensamentos",
            Escola = "Adivinhação",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático, Material (um pedaço de cobre)",
            Descricao = "Pela duração, você pode ler os pensamentos de certas criaturas.Quando você conjura essa magia e, com sua ação a cada turno até o fim da magia, você pode focar sua mente em qualquer criatura que você puder ver a até 9 metros de você.Se a criatura escolhida possuir Inteligência 3 ou inferior ou não falar nenhum tipo de idioma, a criatura não poderá ser afetada. Você, inicialmente, descobre os pensamentos superficiais da criatura – o que está mais presente na sua mente no momento.Com uma ação, você pode tanto mudar sua atenção para os pensamentos de outra criatura, como tentar sondar mais profundamente na mente da mesma criatura.Se você resolver sondar profundamente, a criatura deve realizar um teste de resistência de Sabedoria.Se falhar, você ganha ciência do seu raciocínio(se possuir), seu estado emocional e algo que tome grande parte da sua mente(como algo que ele se preocupe, amores ou ódios). Se ele for bem sucedido, a magia termina.Em ambas situações, o alvo saberá que você está sondando a mente dele e, a não ser que você mude sua atenção para os pensamentos de outra criatura, a criatura pode usar a ação dela, no turno dela, para realizar um teste de Inteligência resistido por seu teste de Inteligência; se ela for bem sucedida, a magia termina. Perguntas feitas diretamente para a criatura alvo, normalmente moldarão o curso dos seus pensamentos, portanto, essa magia é particularmente eficiente como parte de um interrogatório. Você pode, também, usar essa magia para detectar a presença que criaturas pensantes que você não possa ver. Quando você conjura essa magia ou, com sua ação enquanto ela durar, você pode procurar por pensamentos a até 9 metros de você.A magia pode penetrar a maioria das barreiras, mas é bloqueada por 30 centímetros de rocha, 2, 5 centímetros de metal comum, uma fina camada de chumbo, ou 90 centímetros de madeira ou terra.Você não pode detectar uma criatura com Inteligência 3 ou inferior ou uma que não fale qualquer idioma. Uma vez que você tenha detectado a presença de uma criatura dessa forma, você pode ler os pensamentos dela pelo resto da duração, como descrito acima, mesmo que você não possa vê - la, mas ela ainda precisa estar dentro do alcance. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 125,
            Nome = "Detectar Veneno e Doença",
            Escola = "Adivinhação (ritual)",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 10 minutos",
            Componente = "Verbal, Somático, Material (uma folha de teixo)",
            Descricao = "Pela duração, você sente a presença e localização de venenos, criaturas venenosas e doenças a até 9 metros de você. Você também identifica o tipo de veneno, criatura venenosa ou doença em cada caso. A magia pode penetrar a maioria das barreiras, mas é bloqueada por 30 centímetros de rocha, 2,5 centímetros de metal comum, uma fina camada de chumbo, ou 90 centímetros de madeira ou terra.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 126,
            Nome = "Dificultar Detecção",
            Escola = "Abjuração",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação",
            Duracao = "8 horas",
            Componente = "Verbal, Somático, Material (um pouco de pó de diamante valendo 25 po polvilhado sobre o alvo, consumido pela magia)",
            Descricao = "Pela duração, você esconde um alvo que você tocar de magias de adivinhação. O alvo pode ser uma criatura voluntária, um local ou um objeto com não mais de 3 metros em qualquer dimensão. O alvo não pode ser alvo de magias de adivinhação ou percebi     do através de sensores mágicos de vidência",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 127,
            Nome = "Disco Flutuante de Tenser",
            Escola = "Conjuração (ritual)",
            Alcance = "9 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "1 hora",
            Componente = "Verbal, Somático, Material (uma gota de mercúrio)",
            Descricao = "Essa magia cria um plano horizontal, circular de energia de 90 cm de diâmetro por 2,5 cm de espessura, que flutua 90 centímetros acima do chão em um espaço desocupado, à sua escolha, que você possa ver dentro do alcance. O disco permanece pela duração e pode suportar até 250 quilos. Se mais peso for colocado nele, a magia termina, e tudo em cima do disco cai no chão. O disco é imóvel enquanto você estiver a até 6 metros dele. Se você se afastar a mais de 6 metros dele, o disco seguirá você, mantendo-se a 6 metros de você. Ele pode atravessar terreno irregular, subir ou descer escadas, encostas e similares, mas ele não pode atravessar mudanças de elevação de 3 metros ou mais. Por exemplo, o disco não pode atravessar um fosso de 3 metros de profundidade nem poderia sair de tal fosso se tivesse sido criado no fundo dele. Se você se afastar mais de 30 metros do disco (tipicamente por ele não poder rodear um obstáculo para seguir você), a magia acaba.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 128,
            Nome = "Disfarçar-se",
            Escola = "Ilusão",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 ação",
            Duracao = "1 hora",
            Componente = "Verbal, Somático",
            Descricao = "Você faz com que você mesmo – incluindo suas roupas, armadura, armas e outros pertences no seu personagem – pareça diferente até a magia acabar ou até você usar sua ação para dispensa-la. Você pode se parecer 30 centímetros mais baixo ou mais alto, e pode parecer magro, gordo ou entre ambos. Você não pode mudar o tipo do seu corpo, portanto, você deve adotar uma forma que tenha a mesma disposição básica de membros. No mais, a extensão da sua ilusão cabe a você. As mudanças criadas por essa magia não conseguem se sustentar perante uma inspeção física. Por exemplo, se você usar essa magia para adicionar um chapéu ao seu visual, objetos que passarem pelo chapéu e qualquer um que tocá-lo não sentirá nada ou sentirá sua cabeça e cabelo. Se você usar essa magia para aparentar ser mais magro do que é, a mão de alguém que a erguer para tocar em você, irá esbarrar em você enquanto ainda está, aparentemente, está no ar. Para perceber que você está disfarçado, uma criatura pode usar a ação dela para inspecionar sua aparência e deve ser bem sucedida em um teste de Inteligência (Investigação) contra a CD da sua magia",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 129,
            Nome = "Dissipar Magia",
            Escola = "Abjuração",
            Alcance = "36 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático",
            Descricao = "Escolha uma criatura, objeto ou efeito mágico dentro do alcance. Qualquer magia de 3° nível ou inferior no alvo, termina. Para cada magia de 4° nível ou superior no alvo, realize um teste de habilidade usando sua habilidade de conjuração. A CD é igual a 10 + o nível da magia. Se obtiver sucesso, a magia termina. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 4° nível ou superior, você dissipa automaticamente os efeitos de magias no alvo se o nível da magia for igual ou inferior ao nível do espaço de magia que você usar.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 130,
            Nome = "Dissipar o Bem e o Mal",
            Escola = "Abjuração",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático, Material (água benta ou pó de prata e ferro)",
            Descricao = "Energia cintilante envolve e protege você de fadas, mortos-vivos e criaturas originarias além do Plano Material. Pela duração, celestiais, corruptores, elementais, fadas e mortos-vivos tem desvantagem nas jogadas de ataque contra você. Você pode terminar a magia prematuramente usando uma das funções especiais a seguir. Cancelar Encantamento. Com sua ação, você toca uma criatura que você possa alcançar que esteja enfeitiçada, amedrontada ou possuída por um celestial, corruptor, elemental, fada ou morto-vivo. A criatura tocada não estará mais enfeitiçada, amedrontada ou possuída por tais criaturas. Demissão. Com sua ação, faça um ataque corpo-acorpo com magia contra um celestial, corruptor, elemental, fada ou morto-vivo que você possa alcançar. Se atingir, você pode tentar guiar a criatura de volta ao seu plano natal. A criatura deve ser bem sucedida num teste de resistência de Carisma ou será enviada de volta ao seu plano natal (se já não for aqui). Se elas não estiverem em seus planos de origem, mortos-vivos serão enviados para Umbra e fadas serão enviadas para Faéria.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 131,
            Nome = "Doença Plena",
            Escola = "Necromancia",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático",
            Descricao = "Você introduz uma doença virulenta em uma criatura que você puder ver, dentro do alcance. O alvo deve realizar um teste de resistência de Constituição. Se falhar na resistência, ele sofre 14d6 de dano necrótico ou metade desse dano se obtiver sucesso na resistência. O dano não pode reduzir os pontos de vida do alvo abaixo de 1. Se o alvo falhar no teste de resistência, seu máximo de pontos de vida é reduzidos por 1 hora em uma quantidade igual ao dano necrótico causado. Qualquer efeito que remova uma doença permitirá que o máximo de pontos de vida do alvo volte ao normal antes do período indicado. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 132,
            Nome = "Dominar Besta",
            Escola = "Encantamento",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático",
            Descricao = "Você tenta seduzir uma besta que você possa ver dentro do alcance. Ela deve ser bem sucedida num teste de resistência de Sabedoria ou ficará enfeitiçada por você pela duração. Se você ou criaturas amigáveis a você estiverem lutando com ela, ela terá vantagem no teste de resistência. Enquanto a besta estiver enfeitiçada, você terá uma ligação telepática com ela, contanto que ambos estejam no mesmo plano de existência. Você pode usar essa ligação telepática para emitir comandos para a criatura enquanto você estiver consciente (não requer uma ação), aos quais ela obedece da melhor forma possível. Você pode especificar um curso de ação simples e genérico, como “Ataque aquela criatura”, “Corra até ali”, ou “Traga aquele objeto”. Se a criatura completar a ordem e não receber direções posteriores de você, ela se defenderá e se auto preservará da melhor forma que puder. Você pode usar sua ação para tomar controle total e preciso do alvo. Até o final do seu próximo turno, a criatura realiza apenas as ações que você escolher e não faz nada que você não permita que ela faça. Durante esse período, você também pode fazer com que a criatura use uma reação, mas isso requer que você usa sua própria reação também. Cada vez que o alvo sofrer dano, ele realiza um novo teste de resistência de Sabedoria contra a magia. Se obtiver sucesso no teste de resistência, a magia termina. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 5° nível, a duração será concentração, até 10 minutos. Quando você usar um espaço de magia de 6° nível, a duração será concentração, até 1 hora. Quando você usar um espaço de magia de 7° nível, a duração será concentração, até 8 horas. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 133,
            Nome = "Dominar Monstro",
            Escola = "Encantamento",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 hora",
            Componente = "Verbal, Somático",
            Descricao = "Você tenta seduzir uma criatura que você possa ver dentro do alcance. Ela deve ser bem sucedida num teste de resistência de Sabedoria ou ficará enfeitiçada por você pela duração. Se você ou criaturas amigáveis a você estiverem lutando com ela, ela terá vantagem no teste de resistência. Enquanto a criatura estiver enfeitiçada, você terá uma ligação telepática com ela, contanto que ambos estejam no mesmo plano de existência. Você pode usar essa ligação telepática para emitir comandos para a criatura enquanto você estiver consciente (não requer uma ação), aos quais ela obedece da melhor forma possível. Você pode especificar um curso de ação simples e genérico, como “Ataque aquela criatura”, “Corra até ali”, ou “Traga aquele objeto”. Se a criatura completar a ordem e não receber direções posteriores de você, ela se defenderá e se auto preservará da melhor forma que puder. Você pode usar sua ação para tomar controle total e preciso do alvo. Até o final do seu próximo turno, a criatura realiza apenas as ações que você escolher e não faz nada que você não permita que ela faça. Durante esse período, você também pode fazer com que a criatura use uma reação, mas isso requer que você usa sua própria reação também. Cada vez que o alvo sofrer dano, ele realiza um novo teste de resistência de Sabedoria contra a magia. Se obtiver sucesso no teste de resistência, a magia termina. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 9° nível, a duração será concentração, até 8 horas. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 134,
            Nome = "Dominar Pessoa",
            Escola = "Encantamento",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático",
            Descricao = "Você tenta seduzir um humanoide que você possa ver dentro do alcance. Ele deve ser bem sucedido num teste de resistência de Sabedoria ou ficará enfeitiçado por você pela duração. Se você ou criaturas amigáveis a você estiverem lutando com ele, ele terá vantagem no teste de resistência. Enquanto o alvo estiver enfeitiçado, você terá uma ligação telepática com ela, contanto que ambos estejam no mesmo plano de existência. Você pode usar essa ligação telepática para emitir comandos para a criatura enquanto você estiver consciente (não requer uma ação), aos quais ela obedece da melhor forma possível. Você pode especificar um curso de ação simples e genérico, como “Ataque aquela criatura”, “Corra até ali”, ou “Traga aquele objeto”. Se a criatura completar a ordem e não receber direções posteriores de você, ela se defenderá e se auto preservará da melhor forma que puder. Você pode usar sua ação para tomar controle total e preciso do alvo. Até o final do seu próximo turno, a criatura realiza apenas as ações que você escolher e não faz nada que você não permita que ela faça. Durante esse período, você também pode fazer com que a criatura use uma reação, mas isso requer que você usa sua própria reação também. Cada vez que o alvo sofrer dano, ele realiza um novo teste de resistência de Sabedoria contra a magia. Se obtiver sucesso no teste de resistência, a magia termina. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 6° nível, a duração será concentração, até 10 minutos. Quando você usar um espaço de magia de 7° nível, a duração será concentração, até 1 hora. Quando você usar um espaço de magia de 8° nível, a duração será concentração, até 8 horas.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 135,
            Nome = "Druidismo",
            Escola = "Transmutação",
            Alcance = "9 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático",
            Descricao = "Sussurrando para os espíritos da natureza, você cria um dos seguintes efeitos, dentro do alcance:  Você cria um efeito sensorial minúsculo e inofensivo que prevê como será o clima na sua localização pelas próximas 24 horas. O efeito deve se manifestar como um globo dourado para céu claro, uma nuvem para chuva, flocos de neve para nevasca e assim por diante. Esse efeito persiste por 1 rodada.  Você faz uma flor florescer, uma semente brotar ou um folha amadurecer, instantaneamente.  Você cria um efeito sensorial inofensivo instantâneo, como folhas caindo, um sopro de vento, o som de um pequeno animal ou o suave odor de um repolho. O efeito deve caber num cubo de 1,5 metro.  Você, instantaneamente, acende ou apaga uma vela, tocha ou fogueira pequena.",
            IdTipoMagia = 1
        },
        new Magia
        {
            IdMagia = 136,
            Nome = "Duelo Compelido",
            Escola = "Encantamento",
            Alcance = "9 metros",
            TempodeConjuracao = "1 ação bônus",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal",
            Descricao = "Sussurrando para os espíritos da natureza, você cria um dos seguintes efeitos, dentro do alcance:  Você cria um efeito sensorial minúsculo e inofensivo que prevê como será o clima na sua localização pelas próximas 24 horas. O efeito deve se manifestar como um globo dourado para céu claro, uma nuvem para chuva, flocos de neve para nevasca e assim por diante. Esse efeito persiste por 1 rodada.  Você faz uma flor florescer, uma semente brotar ou um folha amadurecer, instantaneamente.  Você cria um efeito sensorial inofensivo instantâneo, como folhas caindo, um sopro de vento, o som de um pequeno animal ou o suave odor de um repolho. O efeito deve caber num cubo de 1,5 metro.  Você, instantaneamente, acende ou apaga uma vela, tocha ou fogueira pequena.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 137,
            Nome = "Encarnação Fantasmagórica",
            Escola = "Ilusão",
            Alcance = "36 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático",
            Descricao = "Baseado nos mais profundos medos de um grupo de criaturas, você cria criaturas ilusórias nas mentes delas, visíveis apenas por elas. Cada criatura numa esfera com 9 metros de raio centrada num ponto, à sua escolha, dentro do alcance, deve realizar um teste de resistência de Sabedoria. Se falhar na resistência, uma criatura ficará amedrontada pela duração. A ilusão invoca os medos mais profundos da criatura, manifestando seus piores pesadelos como uma ameaça implacável. No final de cada turno da criatura amedrontada, ela deve ser bem sucedida num teste de resistência de Sabedoria ou sofrerá 4d10 de dano psíquico. Se obtiver sucesso na resistência, a magia termina para essa criatura.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 138,
            Nome = "Encontrar Armadilhas",
            Escola = "Adivinhação",
            Alcance = "36 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático",
            Descricao = "Você sente a presença de qualquer armadilha dentro do alcance a qual você tenha linha de visão. Uma armadilha, para os propósitos dessa magia, inclui qualquer coisa que possa causar um efeito repentino ou inesperado em você, considerado nocivo ou indesejável, que foi especificamente planejado para ser por seu criador. Portanto, a magia sentirá a área afetada pela magia alarme, um glifo de vigilância ou uma armadilha mecânica de fosso, mas ela não revelará uma fragilidade natural no piso, um teto instável ou um sumidouro escondido. Essa magia apenas revela que existe uma magia presente. Você não descobre a localização de cada armadilha, mas você também descobre a natureza genérica do perigo representando pela armadilha que você sentiu. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 139,
            Nome = "Encontrar o Caminho",
            Escola = "Adivinhação",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 Minuto",
            Duracao = "Concentração, até 1 dia",
            Componente = "Verbal, Somático, Material (um conjunto de ferramentas de adivinhação – como ossos, bastões de marfim, dentes ou runas esculpidas – no valor de 100 po e um objeto do lugar que você deseja encontrar)",
            Descricao = "Essa magia permite que você encontre a rota física mais curta e direta para um local especifico estático, que você seja familiar, no mesmo plano de existência. Se você denominar um destino em outro plano de existência, um local que se mova (como uma fortaleza andante) ou um destino que não seja especifico (como “o covil do dragão verde”), a magia falha. Pela duração, contanto que você esteja no mesmo plano de existência do destino, você saberá o quão longe ele está e em que direção ele se encontra. Enquanto estiver viajando, sempre que você se deparar com uma escolha de trajetória no caminho, você automaticamente determina qual trajetória tem a rota mais curta e direta (mas não necessariamente a rota mais segura) para o destino. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 140,
            Nome = "Enfeitiçar Pessoa",
            Escola = "Encantamento",
            Alcance = "9 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "1 hora",
            Componente = "Verbal, Somático",
            Descricao = "Você tenta enfeitiçar um humanoide que você possa ver dentro do alcance. Ele deve realizar um teste de resistência de Sabedoria, e recebe vantagem nesse teste se você ou seus companheiros estiverem lutando com ele. Se ele falhar, ficará enfeitiçado por você até a magia acabar ou até você ou seus companheiros fizerem qualquer coisa nociva contra ele. A criatura enfeitiçada reconhece você como um conhecido amigável. Quando a magia acabar, a criatura saberá que foi enfeitiçada por você. Em Níveis Superiores. Se você conjurar essa magia usando um espaço de magia de 2° nível ou superior, você pode afetar uma criatura adicional para cada nível do espaço acima do 1°. As criaturas devem estar a até 9 metros umas das outras quando você for afeta-las. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 141,
            Nome = "Enfraquecer Intelecto",
            Escola = "Encantamento",
            Alcance = "45 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático, Material (um punhado de barro, cristal, vidro ou esferas minerais)",
            Descricao = "Você ataca a mente de uma criatura que você possa ver, dentro do alcance, tentando despedaçar seu intelecto e personalidade. O alvo sofre 4d6 de dano psíquico e deve realizar um teste de resistência de Inteligência. Se falhar na resistência, os valores de Inteligência e Carisma da criatura se tornam 1. A criatura não pode conjurar magias, ativar itens mágicos, compreender idiomas ou se comunicar de qualquer forma inteligível. A criatura pode, no entanto, identificar seus amigos, seguilos e, até mesmo, protege-los. Ao final de cada 30 dias, a criatura pode repetir seu teste de resistência contra essa magia. Se ela obtiver sucesso no teste de resistência, a magia termina. Essa magia também pode ser terminada através de restauração maior, cura completa ou desejo. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 142,
            Nome = "Enviar Mensagem",
            Escola = "Evocação",
            Alcance = "Ilimitado",
            TempodeConjuracao = "1 ação",
            Duracao = "1 rodada",
            Componente = "Verbal, Somático, Material (um pequeno e fino pedaço de fio de cobre)",
            Descricao = "Você envia uma mensagem curta, de vinte e cinco palavras ou menos, para uma criatura que seja familiar a você. A criatura ouve a mensagem na sua mente, reconhecendo que foi enviada por você, se ela te conhecer, e pode responder da mesma maneira, imediatamente. A magia permite que criaturas com valores de Inteligência de no mínimo 1, compreendam o sentido da sua mensagem. Você pode enviar a mensagem através de qualquer distância e, até mesmo, para outro plano de existência, mas se o alvo estiver em um plano diferente do seu, existe 5 por cento de chance da mensagem não chegar. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 143,
            Nome = "Escrita Ilusória",
            Escola = "Ilusão (ritual)",
            Alcance = "Toque",
            TempodeConjuracao = "1 minuto",
            Duracao = "10 dias",
            Componente = "Somático, Material (uma tinta à base de chumbo valendo, no mínimo, 10 po, que é consumida pela magia)",
            Descricao = "Você escreve em um pergaminho, papel ou qualquer outro material adequado e tinge ele com uma poderosa ilusão que permanece pela duração. Para você e para qualquer criatura que você designar quando você conjura essa magia, a escrita parece normal, escrita com a sua caligrafia e transmite qualquer que seja a mensagem que você desejava quando escreveu o texto. Para todos os outros, a escrita aparece como se tivesse sido escrita com uma caligrafia desconhecida ou mágica que é inteligível. Alternativamente, você pode fazer a escrita parecer uma mensagem totalmente diferente, escrita com uma caligrafia e idioma diferentes, apesar de o idioma precisar ser um que você conheça. No caso da magia ser dissipada, tanto a escrita original quanto a ilusória desaparecem. Uma criatura com visão verdadeira pode ler a mensagem escondida. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 144,
            Nome = "Escudo Arcano",
            Escola = "Abjuração",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 reação, que você faz quando é atingido por um ataque ou alvo da magia mísseis mágicos",
            Duracao = "1 rodada",
            Componente = "Verbal, Somático",
            Descricao = "Uma barreira de energia invisível aparece e protege você. Até o início do seu próximo turno, você recebe +5 de bônus na CA, incluindo contra o ataque que desencadeou a magia, e você não sofre dano de mísseis mágicos.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 145,
            Nome = "Escudo da Fé",
            Escola = "Abjuração",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação bônus",
            Duracao = "Concentração, até 10 minutos",
            Componente = "Verbal, Somático, Material (um pequeno pergaminho com alguns textos sagrados escritos nele)",
            Descricao = "Um campo cintilante aparece ao redor de uma criatura, à sua escolha, dentro do alcance, concedendo +2 de bônus na CA pela duração. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 146,
            Nome = "Escudo de Fogo",
            Escola = "Evocação",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 ação",
            Duracao = "10 minutos",
            Componente = "Verbal, Somático, Material (um pouco de fósforo ou um vaga-lume)",
            Descricao = "Finas e discretas chamas rodeiam seu corpo pela duração, emitindo luz plena em 3 metros de raio e penumbra por mais 3 metros adicionais. Você pode terminar a magia prematuramente usando sua ação para dissipa-la. As chamas lhe conferem um escudo quente ou um escudo frio, à sua escolha. O escudo quente lhe garante resistência a dano de frio e o escudo frio lhe concede resistência a dano de fogo. Além disso, sempre que uma criatura a 1,5 metro de você atingir você com um ataque corpo-a-corpo, o escudo expele chamas. O atacante sofre 2d8 de dano de fogo do escudo quente ou 2d8 de dano de frio do escudo frio.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 147,
            Nome = "Escuridão",
            Escola = "Evocação",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 10 minutos",
            Componente = "Verbal, Material (pelo de morcego e uma gota de poiche ou pedaço de carvão)",
            Descricao = "Escuridão mágica se espalha a partir de um ponto, à sua escolha, dentro do alcance e preenche uma esfera de 4,5 metros de raio pela duração. A escuridão se estende, dobrando esquinas. Uma criatura com visão no escuro não pode ver através dessa escuridão e luz não-mágica não pode iluminar dentro dela. Se o ponto que você escolheu for um objeto que você esteja segurando, ou um que não esteja sendo vestido ou carregado, a escuridão emanará do objeto e se moverá com ele. Cobrir completamente a fonte da escuridão com um objeto opaco, como uma vasilha ou um elmo, bloqueará a escuridão. Se qualquer área dessa magia sobrepor uma área de luz criada por uma magia de 2° ou inferior, a magia que criou a luz será dissipada. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 148,
            Nome = "Esfera Congelante de Otiluke",
            Escola = "Evocação",
            Alcance = "90 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático, Material (uma pequena esfera de cristal)",
            Descricao = "Um globo frigido de energia gelada é arremessado das pontas dos seus dedos para um ponto, à sua escolha, dentro do alcance, onde ele explode numa esfera de 18 metros de raio. Cada criatura dentro da área deve realizar um teste de resistência de Constituição. Se falhar na resistência, uma criatura sofre 10d6 de dano de frio. Se obtiver sucesso na resistência, ela sofre metade desse dano. Se o globo atingir um corpo de água ou liquido composto principalmente de água (não incluindo criaturas feitas de água), ele congela o líquido até uma profundidade de 15 centímetros numa área de 9 metros quadrados. Esse gelo dura por 1 minuto. Criaturas que estiverem nadando na superfície de água congelada estarão presas no gelo. Uma criatura presa pode usar sua ação para realizar um teste de Força contra a CD da magia para se libertar. Você pode evitar de disparar o globo após completar a magia, se desejar. Um pequeno globo, do tamanho de uma pedra de funda, frio ao toque, aparece em sua mão. A qualquer momento, você ou uma criatura a quem você entregar o globo, pode arremessa-lo (a uma distância de 12 metros) ou atira-lo com uma funda (ao alcance normal da funda). Ele se despedaça no impacto, produzindo o mesmo efeito da conjuração normal da magia. Você pode, também, soltar o globo no chão sem despedaça-lo. Após 1 minuto, se o globo ainda não tiver se despedaçado, ele explode. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 7° nível ou superior, o dano aumenta em 1d6 para cada nível do espaço acima do 6°. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 149,
            Nome = "Esfera Flamejante",
            Escola = "Conjuração",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático, Material (um pouco de seco, uma pitada de enxofre e uma camada de pó de ferro)",
            Descricao = "Uma esfera de fogo, com 1,5 metro de diâmetro, aparece em um espaço desocupado, à sua escolha, dentro do alcance e permanece pela duração. Qualquer criatura que terminar seu turno a até 1,5 metro da esfera, deve realizar um teste de resistência de Destreza. A criatura sofre 2d6 de dano de fogo se falhar na resistência, ou metade desse dano se obtiver sucesso. Com uma ação bônus, você pode mover a esfera até 9 metros. Se você arremessar a esfera contra uma criatura, essa criatura deve realizar o teste de resistência contra o dano da esfera e a esfera para de se mover esse turno. Quando você move a esfera, você pode direciona-la para barreira de até 1,5 metro de altura e ela salta sobre fossos de até 3 metros de distância. A esfera incendeia objetos inflamáveis que não estejam sendo vestidos ou carregados e emite luz plena a 6 metros de raio e penumbra por mais 6 metros adicionais. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 3° nível ou superior, o dano aumenta em 1d6 para cada nível do espaço acima do 2°. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 150,
            Nome = "Esfera Resiliente de Otiluke",
            Escola = "Evocaao",
            Alcance = "9 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático, Material (uma peça hemisférica de cristal transparente e uma peça hemisférica que combine de goma arábica)",
            Descricao = "Uma esfera de energia brilhante engloba uma criatura ou objeto de tamanho Grande ou menor, dentro do alcance. Uma criatura involuntária deve realizar um teste de resistência de Destreza. Se falhar na resistência, a criatura estará enclausurada pela duração. Nada – nem objetos físicos, energia ou outros efeitos mágicos – pode passar através da barreira, para dentro ou para fora, apesar da criatura na esfera poder respirar lá dentro. A esfera é imune a todos os danos e a criatura ou objeto dentro não pode sofrer dano de ataques ou efeitos originados de fora, nem a criatura dentro da esfera, pode causar dano a nada fora dela. A esfera não tem peso e é grande o suficiente apenas para conter a criatura ou objeto dentro. Uma criatura enclausurada pode usar sua ação para empurrar a parede da esfera e, assim, rolar a esfera a metade do deslocamento da criatura. Similarmente, o globo pode ser erguido e movido por outras criaturas. A magia desintegrar lançada no globo o destruirá sem causar ferimentos a nada dentro dele.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 151,
            Nome = "Espada de Mordenkainen",
            Escola = "Evocação",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático, Material (espada de platina em miniatura com cabo e promo de cobre e zinco valendo, no mínimo, 250 po)",
            Descricao = "Você cria um plano de energia em formato de espada que flutua dentro do alcance. Ela permanece pela duração. Quando a espada aparece, você realiza um ataque com magia contra um alvo, à sua escolha, a 1,5 metro da espada. Se atingir, o alvo sofre 3d10 de dano de energia. Até a magia acabar, você pode usar uma ação bônus, em cada um dos seus turnos, para mover a espada até 6 metros para um local que você possa ver e repetir esse ataque contra o mesmo alvo ou um diferente.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 152,
            Nome = "Espíritos Guardiões",
            Escola = "Conjuração",
            Alcance = "Pessoal (4.5 metros de raio)",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 10 minutos",
            Componente = "Verbal, Somático, Material (um símbolo sagrado)",
            Descricao = "Você evoca espíritos para protege-lo. Eles flutuam a seu redor, a uma distância de 4,5 metros, pela duração. Se você for bom ou neutro, as formas espectrais deles aparenta ser angelical ou feérica (à sua escolha). Se você for mau, eles pareceram demoníacos. Quando você conjura essa magia, você pode designar qualquer quantidade de criaturas que você possa ver para não serem afetadas por ela. O deslocamento de uma criatura afetada é reduzido à metade na área e, quando a criatura entrar na área pela primeira vez num turno ou começar seu turno nela, ela deve realizar um teste de resistência de Sabedoria. Se falhar na resistência, a criatura sofrerá 3d8 de dano radiante (se você for bom ou neutro) ou 3d8 de dano necrótico (se você for mau). Com um sucesso na resistência, a criatura sofre metade desse dano. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 4° nível ou superior, o dano aumenta em 1d8 para cada nível do espaço acima do 3°.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 153,
            Nome = "Espirro Ácido",
            Escola = "Conjuração",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático",
            Descricao = "Você arremessa uma bolha de ácido. Escolha uma criatura dentro do alcance, ou escolha duas criaturas dentro do alcance que estejam a 1,5 metro uma da outra. Um alvo deve ser bem sucedido num teste de resistência de Destreza ou sofrerá 1d6 de dano ácido. O dano dessa magia aumenta em 1d6 quando você alcança o 5° nível (2d6), 11° nível (3d6) e 17° nível (4d6).",
            IdTipoMagia = 1
        },
        new Magia
        {
            IdMagia = 154,
            Nome = "Esquentar Metal",
            Escola = "Transmutação",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático, Material (um pedaço de ferro e uma chama)",
            Descricao = "Escolha uma objeto manufaturado de metal, como uma arma de metal ou uma armadura pesada ou média de metal, que você possa ver dentro do alcance. Você faz com que o objeto brilhe vermelho-incandescente. Qualquer criatura em contato físico com o objeto sofrerá 2d8 de dano de fogo quando você conjurar a magia. Até a magia acabar, você pode usar uma ação bônus, em cada um dos seus turnos subsequentes, para causar esse dano novamente. Se uma criatura estiver segurando ou vestindo o objeto e sofrer o dano dele, a criatura deve ser bem sucedida num teste de resistência de Constituição ou largará o objeto se ela puder. Se ela não largar o objeto, ela terá desvantagem em jogadas de ataque e testes de habilidade até o início do seu próximo turno. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 3° nível ou superior, o dano aumenta em 1d8 para cada nível do espaço acima do 2°. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 155,
            Nome = "Estabilizar",
            Escola = "Necromancia",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático",
            Descricao = "Você toca uma criatura viva que esteja com 0 pontos de vida. A criatura é estabilizada. Essa magia não afeta mortos-vivos ou constructos. ",
            IdTipoMagia = 1
        },
        new Magia
        {
            IdMagia = 156,
            Nome = "Explosão Solar",
            Escola = "Evocação",
            Alcance = "45 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático, Material (fogo e um pedaço de pedra do sol)",
            Descricao = "Luz solar brilhante lampeja num raio de 18 metros, centrada num ponto, à sua escolha, dentro do alcance. Cada criatura nessa luz, deve realizar um teste de resistência de Constituição. Com uma falha na resistência, uma criatura sofrerá 12d6 de dano radiante e ficará cega por 1 minuto. Se obtiver sucesso na resistência, ela sofrerá metade desse dano e não ficará cega por essa magia. Mortos-vivos e limos tem desvantagem nos seus testes de resistência. Uma criatura cega por essa magia faz outro teste de resistência de Constituição no final de cada um dos turnos dela. Se obtiver sucesso, ela não estará mais cega. Essa magia dissipa qualquer escuridão na área dela que tenha sido criada por um magia. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 157,
            Nome = "Fabricar",
            Escola = "Transmutação",
            Alcance = "36 metros",
            TempodeConjuracao = "10 minutos",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático",
            Descricao = "Você converte matéria-prima em produtos do mesmo material. Por exemplo, você pode construir uma ponte de madeira usando um amontoado de árvores, uma corda de um pedaço de cânhamo e roupas usando linho ou lã. Escolha matérias-primas que você possa ver, dentro do alcance. Você pode fabricar um objeto Grande ou menor (contido em 3 metros cúbicos ou em oito cubos de 1,5 metro conectados), tendo uma quantidade suficiente de matéria-prima. Se você estiver trabalhando com metal, pedra ou outra substância mineral, no entanto, o objeto fabricado não pode ser maior que Médio (contido em apenas 1,5 metro cúbico). A quantidade de objetos feitos por essa magia é proporcional com a quantidade de matéria-prima. Criaturas ou itens mágicos não podem ser criados ou transmutados por essa magia. Você também não pode usá-la para criar itens que, geralmente, requerem um alto grau de perícia, como joalheria, armas, vidros ou armaduras, a não ser que você tenha proficiência com o tipo de ferramenta de artesanato usada para construir tais objetos. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 158,
            Nome = "Falar com Animais",
            Escola = "Adivinhação (ritual)",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 ação",
            Duracao = "10 minutos",
            Componente = "Verbal, Somático",
            Descricao = "Você adquire a habilidade de compreender e se comunicar verbalmente com bestas, pela duração. O conhecimento e consciência de muitas bestas é limitado pela inteligência delas mas, no mínimo, as bestas poderão dar informações a você sobre os locais e monstros próximos, incluindo tudo que eles possam perceber ou tenham percebido no dia anterior. Você pode tentar persuadir uma besta a lhe prestar um favor, à critério do Mestre. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 159,
            Nome = "Falar com os Mortos",
            Escola = "Necromancia",
            Alcance = "3 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "10 minutos",
            Componente = "Verbal, Somático, Material (incenso aceso)",
            Descricao = "Você concede o aspecto de vida e inteligência a um corpo, à sua escolha, dentro do alcance, permitindo que ele responda as perguntas que você fizer. O corpo ainda deve possuir uma boca e não pode ser um morto-vivo. A magia falha se o corpo já tiver sido alvo dessa magia nos últimos 10 dias. Até a magia acabar, você pode fazer ao corpo até cinco perguntas. O corpo sabe apenas o que ele sabia em vida, incluindo o idioma que ele conhecia. As respostas normalmente são breves, enigmáticas ou repetitivas e o corpo não está sob nenhuma compulsão que o obrigue a oferecer respostas verdadeiras se você for hostil a ele ou se ele reconhecer você como um inimigo. Essa magia não traz a alma da criatura de volta ao corpo, apenas anima seu espírito. Portanto, o corpo não pode aprender novas informações, não compreende nada que tenha acontecido depois da sua morte e não pode especular sobre eventos futuros.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 160,
            Nome = "Falar com Plantas",
            Escola = "Adivinhação (ritual)",
            Alcance = "Pessoal (9 metros de raio)",
            TempodeConjuracao = "1 ação",
            Duracao = "10 minutos",
            Componente = "Verbal, Somático",
            Descricao = "Você imbui as plantas a até 9 metros de você com consciência e animação limitadas, dando-lhes a habilidade de se comunicar com você e seguir seus comandos simples. Você pode perguntar as plantas sobre eventos na área da magia, acontecidos desde o dia anterior, recebendo informações sobre criaturas que passaram, clima e outras circunstâncias. Você também pode tornar terreno difícil causado pelo crescimento de plantas (como arbustos e vegetação rasteira) em terreno normal, permanecendo assim pela duração. Ou você pode tornar terreno normal onde as plantas estiverem presentes, em terreno difícil, permanecendo assim pela duração, fazendo as vinhas e ramos atrasarem perseguidores, por exemplo. As plantas podem ser capazes de realizar outras tarefas em seu favor, à critério do Mestre. A magia não permite que as plantas desenraizem-se e se movam, mas elas podem mover, livremente, seus ramos, galhos e caules. Se uma criatura planta estiver na área, você pode se comunicar com ela se você partilhar um idioma em comum, mas você não recebe qualquer habilidade mágica para influencia-la. Essa magia pode fazer as plantas criadas pela magia constrição soltarem uma criatura impedida. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 161,
            Nome = "Flecha Ácida de Melf",
            Escola = "Evocação",
            Alcance = "36 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático, Material (folha de ruibarbo em pó e o estômago de uma vírbora)",
            Descricao = "Uma flecha esverdeada cintilante voa em direção de um alvo dentro do alcance e explode em um jato de ácido. Faça um ataque à distância com magia contra o alvo. Se atingir, o alvo sofre 4d4 de dano de ácido imediatamente e 2d4 de dano de ácido no final do próximo turno dele. Se errar, a flecha salpica o alvo com ácido, causando metade do dano inicial e nenhum dano no final do próximo turno dele. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 3° nível ou superior, o dano (tanto inicial quanto posterior) aumenta em 1d4 para cada nível do espaço acima do 2°. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 162,
            Nome = "Flecha Relampejante",
            Escola = "Transmutação",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 ação bônus",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático",
            Descricao = "Da próxima vez que você realizar um ataque com uma arma à distância enquanto a magia durar, a munição da arma ou a própria arma, se ela for uma arma de arremesso, se transforma num relâmpago. Realize uma jogada de ataque normal. O alvo sofre 4d8 de dano elétrico se atingir ou metade desse dano se errar, ao invés do dano normal da arma. Independentemente de você acertar ou errar, cada criatura a até 3 metros do alvo deve realizar um teste de resistência de Destreza. Cada uma dessas criaturas sofre 2d8 de dano elétrico se falhar na resistência ou metade desse dano se obtiver sucesso. A munição ou arma então, volta a sua forma normal. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 4° nível ou superior, o dano de ambos os efeitos da magia aumenta em 1d8 para cada nível do espaço acima do 3°. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 163,
            Nome = "Fogo das Fadas",
            Escola = "Evocação",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal",
            Descricao = "Cada objeto num cubo de 6 metros dentro do alcance fica delineado com luz azul, verde ou violeta (à sua escolha). Qualquer criatura na área, quando a magia é conjurada, também fica delineada com luz, se falhar num teste de resistência de Destreza. Pela duração, os objetos e criaturas afetadas emitem penumbra num raio de 3 metros. Qualquer jogada de ataque contra uma criatura afetada ou objeto tem vantagem, se o atacante puder ver o alvo e, a criatura afetada ou objeto não recebe benefício por estar invisível.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 164,
            Nome = "Fome de Hadar",
            Escola = "Conjuração",
            Alcance = "45 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático, Material (um tentáculo de polve em conserva)",
            Descricao = "Você abre um portal para a escuridão entre as estrelas, uma região infestada de horrores desconhecidos. Uma esfera de 6 metros de raio de negritude e frio severo aparece, centrada num ponto dentro do alcance, e permanece pela duração. Esse vazio está preenchido por uma cacofonia de sussurros suaves e barulhos de rangidos que podem ser ouvidos a até 9 metros. Nenhuma luz, mágica ou qualquer que seja, pode iluminar a área e as criaturas totalmente dentro da área estarão cegas. O vazio cria uma dobra no tecido do espaço e a área é de terreno difícil. Qualquer criatura que começar seu turno na área sofre 2d6 de dano de frio. Qualquer criatura que terminar seu turno na área, deve ser bem sucedida num teste de resistência de Destreza ou sofrerá 2d6 de dano de ácido, à medida que tentáculos leitosos extraterrestres se esfregam contra ela.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 165,
            Nome = "Força Fantasmagórica",
            Escola = "Ilusão",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático, Material (um pouco de lã)",
            Descricao = "Você constrói uma ilusão que se enraíza na mente de uma criatura que você possa ver, dentro do alcance. O alvo deve realizar um teste de resistência de Inteligência. Se falhar na resistência, você cria um objeto, criatura ou outro fenômeno visível – porém, fantasmagórico – à sua escolha, com não mais de 3 metros cúbicos e que será percebido apenas pelo alvo, pela duração. Essa magia não afeta mortos-vivos ou constructos. O fantasma inclui som, temperatura e outros estímulos, também evidentes apenas para o alvo. O alvo pode usar sua ação para examinar o fantasma com um teste de Inteligência (Investigação) contra a CD da as magia. Se for bem sucedido, o alvo percebe que o fantasma é uma ilusão e a magia acaba. Enquanto o alvo estiver sob efeito dessa magia, ele considerará o fantasma como sendo real. O alvo racionalizará quaisquer resultados ilógicos ao interagir com o fantasma. Por exemplo, um alvo tentado atravessar uma ponte fantasmagórica que atravesse um abismo, cairá quando pisar na ponte. Se o alvo sobreviver a queda, ele ainda acreditará que a ponte existe e procurará outra explicação para a sua queda – ele foi puxado, ele escorregou ou um vento forte pode ter o jogado pra fora. Um alvo afetado está tão convencido da realidade do fantasma que pode até mesmo sofrer dano da ilusão. Um fantasma criado para se parecer com uma criatura pode atacar o alvo. Similarmente, um fantasma criado para se parecer com fogo, um poço de ácido ou lava, podem queimar o alvo. A cada rodada, no seu turno, o fantasma pode causar 1d6 de dano psíquico no alvo, se ele estiver na área do fantasma ou a 1,5 metro dele, considerando que a ilusão é de uma criatura ou perigo que, logicamente, possa causar dano, como por atacar. O alvo entende o dano como sendo de um tipo apropriado para a ilusão.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 166,
            Nome = "Forjar Morte",
            Escola = "Necromancia (ritual)",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação",
            Duracao = "1 hora",
            Componente = "Verbal, Somático, Material (uma pitada de terra de cemitério)",
            Descricao = "Você toca uma criatura voluntária e a coloca em um estado catatônico que é indistinguível da morte. Pela duração da magia, ou até você usar uma ação para tocar o alvo e dissipar a magia, o alvo aparenta estar morto para todas as inspeções externas e para magias usadas para determinar a condição do alvo. O alvo está cego e incapacitado e seu deslocamento cai para 0. O alvo tem resistência a todos os danos, exceto dano psíquico. Se o alvo estava doente ou envenenado quando você conjurou a magia, ou ficou doente ou envenenado durante o período em que estava sob efeito da magia, a doença e veneno não terá qualquer efeito até a magia terminar. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 167,
            Nome = "Forma Etérea",
            Escola = "Transmutação",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 ação",
            Duracao = "Até 8 horas",
            Componente = "Verbal, Somático",
            Descricao = "Você dá um passo para dentro das fronteiras do Plano Etéreo, na área em que ele se sobrepõem com o seu plano atual. Você se mantem na Fronteira Etérea pela duração ou até você usar sua ação para dissipar a magia. Durante esse período, você pode se mover para qualquer direção. Se você se mover para cima ou para baixo, cada passo de deslocamento custa um passo extra. Você pode ver e ouvir o plano que você se originou, mas tudo parece cinzento e você não pode ver nada além de 18 metros de você. Enquanto estiver no Plano Etéreo, você pode afetar e ser afetado apenas por criaturas nesse plano. As criaturas que não estiverem no Plano Etéreo não podem notar sua presença e não podem interagir com você, a menos que uma habilidade especial ou magia dê a elas a capacidade de fazê-lo. Você ignora todos os objetos e efeitos que não estiverem no Plano Etéreo, permitindo que você se mova através de objetos que você perceba no plano de onde você veio. Quando a magia acabar, você imediatamente retorna para o plano de onde você se originou, no lugar que você está ocupando atualmente. Se você estiver ocupando o mesmo espaço de um objeto sólido ou de uma criatura quando isso ocorrer, você é, imediatamente, desviado para o espaço desocupado mais próximo que você puder ocupar e sofre dano de energia igual a dez vezes a quantidade de quadrados de 1,5 metro que você foi movido. Essa magia não tem efeito se você conjura-la enquanto estiver no Plano Etéreo ou um plano que não faça fronteira com ele, como um dos Planos Exteriores. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 8° nível ou superior, você pode afetar até três criaturas voluntária (incluindo você) para cada nível do espaço acima do 7°. As criaturas devem estar a até 3 metros de você quando você conjurar a magia.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 168,
            Nome = "Forma Gasosa",
            Escola = "Transmutação",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 hora",
            Componente = "Verbal, Somático, Material (um pouco de gaze e um pouco de fumaça)",
            Descricao = "Você transforma uma criatura voluntária que você tocar, junto com tudo que ela estiver vestindo e carregando, em uma nuvem nebulosa, pela duração. A magia termina se a criatura cair a 0 pontos de vida. Uma criatura incorpórea não pode ser afetada. Enquanto estiver nessa forma, o único meio de movimentação do alvo é 3 metros de deslocamento de voo. O alvo pode entrar e ocupar o espaço de outra criatura. O alvo tem resistência a dano não-mágico e tem vantagem em testes de resistência de Força, Destreza e Constituição. O alvo pode passar através de pequenos buracos, aberturas estreitas e, até mesmo, meras rachaduras, embora ele trate líquidos como se fossem superfícies sólidas. O alvo não pode cair e se mantem flutuando no ar, mesmo se estiver atordoado ou incapacitado de alguma outra forma. Enquanto estiver na forma de uma nuvem nebulosa, o alvo não pode falar ou manipular objetos e, quaisquer objetos que ele estava carregando ou segurando não pode ser derrubado, usado ou, de outra forma, interagido. O alvo não pode atacar ou conjurar magias. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 169,
            Nome = "Formas Animais",
            Escola = "Transmutação",
            Alcance = "9 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 24 horas",
            Componente = "Verbal, Somático",
            Descricao = "Sua magia transforma você em bestas. Escolha qualquer quantidade de criaturas voluntárias que você possa ver, o alcance. Você muda cada alvo para a forma de uma besta Grande ou menor, com um nível de desafio de 4 ou inferior. Nos turnos subsequentes, você pode usar sua ação para mudar uma criatura afetada para uma nova forma. A transformação permanece pela duração para cada alvo, ou até o alvo cair para 0 pontos de vida ou morrer. Você pode escolher uma forma diferente para cada alvo. As estatísticas de jogo do alvo são substituídas pelas estatísticas da besta escolhida, mas o alvo mantem sua tendência e valores de Inteligência, Sabedoria e Carisma. O alvo adquire os pontos de vida da sua nova forma, e quando ele reverte para sua forma normal, ele volta aos pontos de vida que tinha antes de ser transformado. Se ele reverter como resultado de ter caído a 0 pontos de vida, todo dano excedente é recebido pela sua forma normal. Contanto que o dano excedente não reduza os pontos de vida da forma normal da criatura a 0, ela não cairá inconsciente. A criatura é limitada em suas ações pela natureza da sua nova forma e ela não pode falar nem conjurar magias. O equipamento do alvo mescla-se a sua nova forma. O alvo não pode ativar, empunhar ou, de outra forma, se beneficiar de qualquer de seus equipamentos.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 170,
            Nome = "Glifo de Vigilância",
            Escola = "Abjuração",
            Alcance = "Toque",
            TempodeConjuracao = "1 hora",
            Duracao = "Até ser dissipada ou ativada",
            Componente = "Verbal, Somático, Material (incenso e pó de diamante valendo, no mínimo, 200 po, consumidos pela magia)",
            Descricao = "Quando você conjura essa magia, você inscreve um glifo que fere outras criaturas, tanto sobre uma superfície (como uma mesa ou uma secção de piso ou parede) quanto dentro de um objeto que possa ser fechado (como um livro, um pergaminho ou um baú de tesouro) para ocultar o glifo. Se você escolher uma superfície, o glifo pode cobrir uma área da superfície não superior a 3 metros de diâmetro. Se você escolher um objeto, o objeto deve permanecer no seu local; se ele for movido mais de 3 metros de onde você conjurou essa magia, o glifo será quebrado e a magia termina sem ser ativada. O glifo é quase invisível e requer um teste de Inteligência (Investigação) contra a CD da magia para ser encontrado. Você define o que ativa o glifo quando você conjura a magia. Para glifos inscritos em uma superfície, os gatilhos mais típicos incluem tocar ou ficar sobre o glifo, remover outro objeto cobrindo o glifo, aproximar-se a uma certa distância do glifo ou manipular um objeto onde o glifo esteja inscrito. Para glifos inscritos dentro de objetos, os gatilhos mais comuns incluem abrir o objeto, aproximarse a uma certa distância do objeto ou ver ou ler o glifo. Uma vez que o glifo seja ativado, a magia termina. Você pode, posteriormente, aperfeiçoar o gatilho para que a magia se ative apenas sob certas circunstâncias ou de acordo com as características físicas (como altura ou peso), tipo de criatura (por exemplo, a proteção poderia ser definida para afetar aberrações ou drow) ou tendência. Você pode, também, definir condições para criaturas não ativarem o glifo, como aqueles que falarem determinada senha. Quando você inscreve o glifo, escolha runas explosivas ou glifo de magia. Runas Explosivas. Quando ativado, o glifo irrompe com energia mágica numa esfera com 6 metros de raio, centrada no glifo. A esfera se espalha, dobrando esquinas. Cada criatura na área deve realizar um teste de resistência de Destreza. Uma criatura sofre 5d8 de dano de ácido, elétrico, fogo, frio ou trovejante se falhar no teste de resistência (você escolhe o tipo quando cria o glifo) ou metade desse dano se obtiver sucesso. Glifo de Magia. Você pode armazenar uma magia preparada de 3° nível ou inferior no glifo ao conjura-la como parte da criação do glifo. A magia a ser armazenada não tem efeito imediato quando conjurada dessa forma. Quando o glifo for ativado, a magia armazenada é conjurada. Se a magia tiver um alvo, esse alvo será a criatura que ativou o glifo. Se a magia afetar uma área, a área será centrada na criatura. Se a magia invocar criaturas hostis ou criar objetos ou armadilhas nocivos, eles aparecerão o mais próximo possível do intruso e o atacarão. Se a magia precisar de concentração, ela dura o máximo possível da sua duração. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 4° nível ou superior, o dano do glifo de runas explosivas aumenta em 1d8 para cada nível do espaço acima do 3°. Se você criar um glifo de magia, você pode armazenar qualquer magia do mesmo nível, ou inferior, do espaço que você usar para o glifo de vigilância.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 171,
            Nome = "Globo de Invulnerabilidade",
            Escola = "Abjuração",
            Alcance = "Pessoal (3 metros de raio)",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático, Material (uma pérola de vidro ou cristal que se despedaça quando a magia termina)",
            Descricao = "Uma barreira imóvel, levemente cintilante, surge do nada num raio de 3 metros centrado em você e permanece pela duração. Qualquer magia de 5° nível ou inferior conjurada de fora da barreira não poderá afetar as criaturas ou objetos dentro dela, mesmo que a magia seja conjurada usando um espaço de magia de nível superior. Tais magias podem ter como alvo criaturas e objetos dentro da barreira, mas a magia não produz nenhum efeito neles. Similarmente, a área dentro da barreira é excluída das áreas afetadas por tais magias. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 7° nível ou superior, a barreira bloqueia magias de um nível superior para cada nível do espaço acima do 6°. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 172,
            Nome = "Globos de Luz",
            Escola = "Evocação",
            Alcance = "36 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático, Material (um pouco de fósforo ou wychwood ou um inseto luminoso)",
            Descricao = "Você cria até quatro luzes do tamanho de tochas dentro do alcance, fazendo-as parecerem tochas, lanternas ou esferas luminosas que flutuam no ar pela duração. Você também pode combinar as quatro luzes em uma forma luminosa, vagamente humanoide, de tamanho Médio. Qualquer que seja a forma que você escolher, cada luz produz penumbra num raio de 3 metros. Com uma ação bônus, no seu turno, você pode mover as luzes, até 18 metros, para um novo local dentro do alcance. Uma luz deve estar a, pelo menos, 6 metros de outra luz criada por essa magia e uma luz some se exceder o alcance da magia. ",
            IdTipoMagia = 1
        },
        new Magia
        {
            IdMagia = 173,
            Nome = "Golpe Constritor",
            Escola = "Conjuração",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 ação bônus",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal",
            Descricao = "Da próxima vez que você atingir uma criatura com um ataque com arma, antes do final da magia, um emaranhado maciço de vinhas espinhentas aparecem no local do impacto e o alvo deve ser bem sucedido num teste de resistência de Força ou ficará impedido pelas vinhas mágicas, até o fim da magia. Uma criatura Grande ou maior tem vantagem no seu teste de resistência. Se o alvo for bem sucedido na resistência, as vinhas murcharão. Enquanto estiver impedido pela magia, um alvo sofre 1d6 de dano perfurante no início de cada um dos turnos dele. Uma criatura impedida pelas vinhas ou uma que possa tocar a criatura, pode usar sua ação para realizar um teste de Força contra a CD da magia. Num sucesso, o alvo é libertado. Em Níveis Superiores. Se você conjurar essa magia usando um espaço de magia de 2° nível ou superior, o dano aumenta em 1d6 para cada nível do espaço acima do 1°. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 174,
            Nome = "Guardião da Fé",
            Escola = "Conjuração",
            Alcance = "9 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "8 horas",
            Componente = "Verbal",
            Descricao = "Um guardião espectral Grande aparece e flutua, pela duração, em um espaço desocupado, à sua escolha, que você possa ver dentro do alcance. O guardião ocupa esse espaço e é indistinto, exceto por uma espada reluzente e um escudo brasonado com o símbolo da sua divindade. Qualquer criatura hostil a você que se mover para um espaço a até 3 metros do guardião pela primeira vez em um turno, deve ser bem sucedida num teste de resistência de Destreza. A criatura sofre 20 de dano radiante se falhar na resistência ou metade desse dano se obtiver sucesso. O guardião desaparece após ter causado um total de 60 de dano. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 175,
            Nome = "Heroísmo",
            Escola = "Encantamento",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático",
            Descricao = "Uma criatura voluntária que você tocar é imbuída com bravura. Até a magia acabar, a criatura é imune a ser amedrontada e ganha pontos de vida temporários igual ao seu modificador de habilidade de conjuração, no início de cada turno dela. Quando a magia acabar, o alvo perde qualquer ponto de vida temporário restante dessa magia. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 2° nível ou superior, você pode afetar uma criatura adicional para cada nível do espaço acima do 1°. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 176,
            Nome = "Identificação",
            Escola = "Adivinhação (ritual)",
            Alcance = "Toque",
            TempodeConjuracao = "1 minuto",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático, Material (uma pérola valendo, no mínimo, 100 po e uma pena de coruja)",
            Descricao = "Você escolhe um objeto que você deve tocar durante toda a conjuração da magia. Se ele for um item mágico ou algum outro objeto imbuído por magia, você descobre suas propriedades e como usá-lo, se exige sintonia para ser usado e quantas cargas ele tem, se aplicável. Você descobre se quaisquer magias estão afetando o item e quais eles são. Se o item foi criado por magia, você descobre que magia o criou. Se você, ao invés, tocar uma criatura durante toda a conjuração, você descobre quais magias, se houver alguma, estão afetando-a atualmente.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 177,
            Nome = "Idiomas",
            Escola = "Adivinhação",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação",
            Duracao = "1 hora",
            Componente = "Verbal, Material (uma pequena estátua de argila de um zigurate)",
            Descricao = "Essa magia garante a criatura que você tocar a habilidade de compreender e falar o idioma que ela ouvir. Além disso, quando o alvo fala, qualquer criatura que saiba, pelo menos, um idioma pode ouvir o alvo e compreender o que ele diz",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 178,
            Nome = "Ilusão Menor",
            Escola = "Ilusão",
            Alcance = "9 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "1 minuto",
            Componente = "Verbal, Material (um pouco de lã)",
            Descricao = "Você cria um som ou uma imagem de um objeto, dentro do alcance, que permanece pela duração. A ilusão também termina se você dissipa-la usando uma ação ou conjurar essa magia novamente. Se você criar um som, seu volume pode variar entre um sussurro até um grito. Pode ser a sua voz, a voz de outrem, o rugido de um leão, batidas de tambor ou qualquer outro som que você quiser. O som permanece no mesmo volume durante toda duração ou você pode fazer sons distintos em momentos diferentes, antes da magia acabar. Se você criar uma imagem de um objeto – como uma cadeira, pegadas de lama ou um pequeno baú – ela não pode ter mais de 1,5 metro cúbico. A imagem não pode produzir som, luz, cheiro ou qualquer outro efeito sensorial. Interação física com a imagem revelará que ela é uma ilusão, já que as coisas podem atravessa-la. Se uma criatura usar sua ação para examinar a imagem, ela pode determinar que ela é uma ilusão se obtiver sucesso num teste de Inteligência (Investigação) contra a CD da magia. Se uma criatura discernir a ilusão como sendo isso, a ilusão se tornará suave para a criatura.",
            IdTipoMagia = 1
        },
        new Magia
        {
            IdMagia = 179,
            Nome = "Ilusão Programada",
            Escola = "Ilusão",
            Alcance = "36 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Até ser dissipada",
            Componente = "Verbal, Somático, Material (um pouco de lã e pó de jade valendo, no mínimo, 25 po)",
            Descricao = "Você cria uma ilusão de um objeto, uma criatura ou de algum outro fenômeno visível, dentro do alcance, que se ativa quando uma condição especifica ocorre. A ilusão é imperceptível até esse momento. Ela não pode ter mais de 9 metros cúbicos e você decide, quando conjura a magia, como a ilusão se comporta e quais sons ela faz. Essa performance roteirizada por durar até 5 minutos. Quando a condição que você especificou ocorrer, a ilusão surge do nada e age da maneira que você descreveu. Uma vez que a ilusão tenha acabado de agir, ela desaparece e permanece dormente por 10 minutos. Após desse período, a ilusão pode se ativar novamente. A condição de ativação pode ser tão genérica ou tão detalhada quando você quiser, apesar de ela precisar ser baseada em condições visuais ou audíveis que ocorram a até 9 metros da área. Por exemplo, você poderia criar uma ilusão, de si mesmo, que aparecerá e avisará a outros que tentarem abrir a porta com armadilha ou você pode programar a ilusão para se ativar apenas quando uma criatura disser a palavra ou frase correta. Interação física com a imagem revelará ela como sendo uma ilusão, já que as coisas podem atravessa-la. Uma criatura que usar sua ação para examinar a imagem, pode determinar que ela é uma ilusão sendo bem sucedida num teste de Inteligência (Investigação) contra a CD da magia para desacredita-la. Se a criatura discernir a ilusão como ela é, a criatura poderá ver através da imagem e qualquer barulho que ela fizer soará oco para a criatura. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 180,
            Nome = "Imagem Maior",
            Escola = "Ilusão",
            Alcance = "36 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 10 minutos",
            Componente = "Verbal, Somático, Material (um pedaço de lã)",
            Descricao = "Você cria uma imagem de um objeto, uma criatura ou algum outro fenômeno visível que não tenha mais de 6 metros cúbicos. A imagem aparece em um local que você possa ver, dentro do alcance e permanece pela duração. Ela parece completamente real, incluindo sons, cheiros e temperatura apropriados para a coisa retratada. Você não pode criar calo ou frio suficiente para causar dano, um som alto o suficiente para causar dano trovejante ou ensurdecer uma criatura ou um cheiro que poderia nausear uma criatura (como o fedor de um troglodita). Enquanto você estiver dentro do alcance da ilusão, você pode usar sua ação pra fazer a imagem se mover para qualquer outro local dentro do alcance. À medida que a imagem muda de lugar, você pode alterar a aparência dela para que seu movimento pareça ser o natural para a imagem. Por exemplo, se você criar uma imagem de uma criatura e move-la, você pode alterar a imagem para que ela pareça estar andando. Similarmente, você pode fazer a ilusão emitir sons diferentes em momentos diferentes, sendo possível até mesmo manter uma conversa, por exemplo. Interação física com a imagem, revelará que ela é uma ilusão, já que as coisas podem passar através dela. Uma criatura que usar sua ação para examinar a imagem, pode determinar que ela é uma ilusão com um teste de Inteligência (Investigação) bem sucedido contra a CD da magia. Se uma criatura discernir a ilusão como sendo isso, a criatura verá através da imagem e suas outras qualidades sensoriais se tornaram suaves para a criatura. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 6° nível ou superior, a magia irá durar até ser dissipada, sem necessitar da sua concentração.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 181,
            Nome = "Imagem Silenciosa",
            Escola = "Ilusão",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 10 minutos",
            Componente = "Verbal, Somático, Material (um pouco de lã)",
            Descricao = "Você cria a imagem de um objeto, criatura ou outro fenômeno visual que não tenha mais de 4,5 metros cúbicos. A imagem aparece num ponto, dentro do alcança, e permanece pela duração. A imagem é puramente visual; não é acompanhada por som, cheiro ou outros efeitos sensoriais. Você pode usar sua ação para fazer a imagem se mover para qualquer ponto, dentro do alcance. À medida que a imagem muda de lugar, você pode alterar a aparência dela para que seu movimento pareça ser o natural para a imagem. Por exemplo, se você criar uma imagem de uma criatura e move-la, você pode alterar a imagem para que ela pareça estar andando. Interação física com a imagem, revelará que ela é uma ilusão, já que as coisas podem passar através dela. Uma criatura que usar sua ação para examinar a imagem, pode determinar que ela é uma ilusão com um teste de Inteligência (Investigação) bem sucedido contra a CD da magia. Se uma criatura discernir a ilusão como sendo isso, a criatura poderá ver através da imagem",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 182,
            Nome = "Imobilizar Monstro",
            Escola = "Encantamento",
            Alcance = "27 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático, Material (uma pequena peça de ferro reta)",
            Descricao = "Escolha uma criatura que você possa ver, dentro do alcance. O alvo deve ser bem sucedido num teste de resistência de Sabedoria ou ficará paralisado pela duração. Essa magia não tem efeito em mortos-vivos. No final de cada um dos turnos dele, o alvo pode realizar outro teste de resistência de Sabedoria. Se obtiver sucesso, a magia termina no alvo. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 6° nível ou superior, você pode afetar uma criatura adicional para cada nível de magia acima do 5°. As criaturas devem estar a 9 metros entre si para serem afetadas",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 183,
            Nome = "Imobilizar Pessoa",
            Escola = "Encantamento",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático, Material (uma pequena peça de ferro reta)",
            Descricao = "Escolha um humanoide que você possa ver, dentro do alcance. O alvo deve ser bem sucedido num teste de resistência de Sabedoria ou ficará paralisado pela duração. Essa magia não tem efeito em mortos-vivos. No final de cada um dos turnos dele, o alvo pode realizar outro teste de resistência de Sabedoria. Se obtiver sucesso, a magia termina no alvo. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 3° nível ou superior, você pode afetar um humanoide adicional para cada nível de magia acima do 2°. Os humanoides devem estar a 9 metros entre si para serem afetados. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 184,
            Nome = "Infringir Ferimentos",
            Escola = "Necromancia",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático",
            Descricao = "Faça um ataque corpo-a-corpo com magia contra uma criatura dentro do alcance. Se atingir, o alvo sofre 3d10 de dano necrótico. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 2° nível ou superior, o dano aumenta em 1d10 para cada nível acima do 1°",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 185,
            Nome = "Inseto Gigante",
            Escola = "Transmutação",
            Alcance = "9 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 10 minutos",
            Componente = "Verbal, Somático",
            Descricao = "Você transforma até dez centopeias, três aranhas, cinco vespas ou um escorpião, dentro do alcance, em versões gigantes das suas formas naturais, pela duração. Uma centopeia se torna uma centopeia gigante, uma aranha se torna uma aranha gigante, uma vespa se torna uma vespa gigante e um escorpião se torna um escorpião gigante. Cada criatura obedece aos seus comando verbais e, em combate, elas agem no seu turno a cada rodada. O Mestre possui as estatísticas dessas criaturas e determina suas ações e movimentação. Uma criatura permanece no tamanho gigante pela duração, ou até cair a 0 pontos de vida ou até você usar sua ação para dissipar o efeito nela. O Mestre pode permitir que você escolha alvos diferentes. Por exemplo, se você transformar uma abelha, sua versão gigante poderia ter as mesmas estatísticas da vespa gigante. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 186,
            Nome = "Inverter a Gravidade",
            Escola = "Transmutação",
            Alcance = "30 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático, Material (um ímã e limalha de ferro)",
            Descricao = "Essa magia inverte a gravidade num cilindro de 15 metros de raio por 30 metros de altura, centrado num ponto dentro do alcance. Todas as criaturas e objetos que não esteja, de alguma forma, presos ao solo na área, caem para cima e alcançam o topo da área, quando você conjura essa magia. Uma criatura pode fazer um teste de resistência de Destreza para se agarrar em algum objeto fixo que ela possa alcançar, assim, evitando a queda. Se algum objeto sólido (como um teto) for encontrado durante essa queda, objetos e criaturas caindo atingem ele, exatamente como fariam durante uma queda normal. Se um objeto ou criatura alcançar o topo da área sem atingir nada, ele permanecerá lá, oscilando ligeiramente, pela duração No final da duração, objetos e criaturas afetadas caem de volta para baixo. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 187,
            Nome = "Invisibilidade",
            Escola = "Ilusão",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 hora",
            Componente = "Verbal, Somático, Material (uma pestana envolta em goma-arábica)",
            Descricao = "Uma criatura que você tocar, se torna invisível até a magia acabar. Qualquer coisa que o alvo esteja vestindo ou carregando fica invisível enquanto estiver de posse do alvo. A magia termina para o alvo caso ele ataque ou conjure uma magia. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 3° nível ou superior, você pode afetar um alvo adicional para cada nível do espaço acima do 2°.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 188,
            Nome = "Invisibilidade Maior",
            Escola = "Ilusão",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático",
            Descricao = "Você ou uma criatura que você possa tocar, se torna invisível até a magia acabar. Qualquer coisa que o alvo estiver vestindo ou carregando fica invisível enquanto estiver de posse do alvo. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 189,
            Nome = "Invocação Instantânea de Drawmij",
            Escola = "Conjuração (ritual)",
            Alcance = "Toque",
            TempodeConjuracao = "1 minuto",
            Duracao = "Até ser dissipada",
            Componente = "Verbal, Somático, Material (uma safira no valor de 1000 po)",
            Descricao = "Você toca um objeto pesando 5 quilos ou menos com maior dimensão de 1,8 metro ou menos. A magia deixa uma marca invisível na sua superfície e grava invisivelmente o nome do item na safira que você usou como componente material. A cada vez que você conjurar essa magia, você deve usar uma safira diferente. A qualquer momento, posteriormente, você pode usar sua ação para falar o nome do item e esmagar a safira. O item aparece instantaneamente em suas mãos, independentemente de distâncias físicas ou planares, e a magia termina. Se outra criatura estiver segurando ou carregando o item, esmagar a safira não irá transportar o item até você, ao invés disso, você descobre quem é a criatura possuindo o objeto e onde, vagamente, a criatura está localizada no momento. Dissipar magia ou um efeito similar aplicado com sucesso na safira, termina o efeito da magia.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 190,
            Nome = "Isolamento",
            Escola = "Transmutação",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação",
            Duracao = "Até ser dissipada",
            Componente = "Verbal, Somático, Material (um composto de pós de diamante, esmeralda, rubi e safira valendo, no mínimo, 5000 po, consumidos pela magia)",
            Descricao = "Através dessa magia, uma criatura voluntária ou um objeto, pode ser escondido, seguro contra detecção pela duração. Quando você conjura essa magia e toca o alvo, ele fica invisível e não pode ser alvo de magias de adivinhação ou percebido através de sensores de vidência criados por magias de adivinhação. Se o alvo for uma criatura, ela entra num estado de animação suspensa. O tempo para de fluir para ela e ela não envelhece. Você pode determinar uma condição para que a magia termine prematuramente. A condição pode ser qualquer coisa, à sua escolha, mas deve ocorrer ou ser visível a até 1,5 quilômetro do alvo. Exemplos incluem “depois de 1.000 anos” ou “quando o tarrasque despertar”. Essa magia também acaba se o alvo sofrer qualquer dano. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 191,
            Nome = "Labirinto",
            Escola = "Conjuração",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 10 minutos",
            Componente = "Verbal, Somático",
            Descricao = "Você bane uma criatura que você possa ver, dentro do alcance, para um semiplano labiríntico. O alvo permanece lá pela duração ou até escapar do labirinto. O alvo pode usar sua ação para tentar escapar. Quando o fizer, ele realiza um teste de Inteligência com CD 20. Se for bem sucedido, ele escapa e a magia termina (um minotauro ou um demônio goristro, obtém sucesso automaticamente). Quando a magia termina, o alvo reaparece no espaço que ela estava ou, se o espaço estiver ocupado, no espaço desocupado mais próximo.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 192,
            Nome = "Lâmina Flamejante",
            Escola = "Evocação",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 ação bônus",
            Duracao = "Concentração, até 10 minutos",
            Componente = "Verbal, Somático, Material (folha de sumagre)",
            Descricao = "Você evoca uma lâmina ardente em sua mão livre. A lâmina é similar em tamanho e formato a uma cimitarra e ela permanece pela duração. Se você soltar a lâmina, ela desaparece, mas você pode evocar a lâmina novamente com uma ação bônus. Você pode usar sua ação para realizar ataques corpo-acorpo com magia com a lâmina ardente. Se atingir, o alvo sofrerá 3d6 de dano de fogo. A lâmina flamejante emite luz plena a 3 metros de raio e penumbra por mais 3 metros adicionais. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 4° nível ou superior, o dano aumenta em 1d6 para cada dois níveis do espaço acima do 2°. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 193,
            Nome = "Lentidão",
            Escola = "Transmutação",
            Alcance = "36 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático, Material (uma gota de melaço)",
            Descricao = "Você altera o tempo ao redor de até seis criaturas, à sua escolha, num cubo de 12 metros, dentro do alcance. Cada criatura deve ser bem sucedida num teste de resistência de Sabedoria ou será afetada por essa magia pela duração. O deslocamento de um alvo afetado é reduzido à metade, ele sofre –2 de penalidade na CA e nos testes de resistência de Destreza e não pode usar reações. No turno dele, ele pode usar ou uma ação ou uma ação bônus, mas não ambas. Independentemente das habilidades ou itens mágicos da criatura, ela não poderá realizar mais de um ataque corpo-a-corpo ou à distância durante o turno dela. Se a criatura tentar conjurar uma magia com tempo de conjuração maior que 1 rodada, jogue um d20. Se cair 11 ou maior, a magia não surte efeito até o próximo turno da criatura e a criatura deve usar sua ação nesse turno para completar a magia. Se ela não puder, a magia é perdida. Uma criatura afetada por essa magia faz outro teste de resistência de Sabedoria no final do turno dela. Se passar na resistência, o efeito acaba nela.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 194,
            Nome = "Leque Cromático",
            Escola = "Ilusão",
            Alcance = "Pessoal (cone de 4.5 metros)",
            TempodeConjuracao = "1 ação",
            Duracao = "1 rodada",
            Componente = "Verbal, Somático, Material (um punhado de pó ou areia nas cores vermelha, amarela e azul)",
            Descricao = "Um feixe ofuscante de luzes coloridas ordenadas, surge da sua mão. Role 6d10; o total é a quantidade de pontos de vida de criaturas que essa magia pode afetar. As criaturas num cone de 4,5 metros, originado de você, são afetadas em ordem ascendente dos seus pontos de vida (ignorando criaturas inconsciente e que não podem ver). Começando com as criaturas que tiverem menos pontos de vida, cada criatura afetada por essa magia ficará cega até o fim da magia. Subtraia os pontos de vida de cada criatura do total antes de considerar os pontos de vida da próxima criatura. Os pontos de vida de uma criatura devem ser iguais ou menores que o total restante para que essa criatura seja afetada Em Níveis Superiores. Se você conjurar essa magia usando um espaço de magia de 2° nível ou superior, jogue 2d10 adicionais para cada nível do espaço acima do 1°.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 195,
            Nome = "Levitação",
            Escola = "Transmutação",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 10 minutos",
            Componente = "Verbal, Somático, Material (uma pequena presilha de couro ou um pedaço de fio dourado dobrado em forma de copo com uma haste longa em uma extremidade)",
            Descricao = "Uma criatura ou objeto, à sua escolha, que você possa ver, dentro do alcance, ergue-se verticalmente, até 6 metros e permanece suspenso lá pela duração. A magia pode levitar um alvo pesando até 250 quilos. Uma criatura involuntária que for bem sucedida num teste de resistência de Constituição não é afetada O alvo pode se mover apenas ao puxar ou empurrar um objeto fixo ou superfície ao seu alcance (como um muro ou teto), permitindo que ele se mova como se estivesse escalando. Você pode mudar a altitude do alvo em até 6 metros em ambas as direções no seu turno. Se você for o alvo, você pode se mover para cima ou para baixo como parte do seu movimento. Do contrário, você precisa usar sua ação para mover o alvo, que deve permanecer dentro do alcance da magia. Quando a magia acaba, o alvo flutua suavemente até o chão, se ele ainda estiver no ar",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 196,
            Nome = "Ligação Telepática de Rary",
            Escola = "Adivinhação (ritual)",
            Alcance = "9 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "1 hora",
            Componente = "Verbal, Somático, Material (pedaços de cascas de ovos de dois tipos diferentes de criatura)",
            Descricao = "Você forja uma ligação telepática entre até oito criaturas voluntárias, à sua escolha, dentro do alcance, ligando psiquicamente cada criatura a todas as outras, pela duração. Criaturas com valores de Inteligência 2 ou menos não são afetadas por essa magia. Até a magia acabar, os alvos podem se comunicar telepaticamente através do elo, independentemente de terem ou não um idioma em comum. A comunicação é possível a qualquer distância, apesar de não se estender a outros planos de existência. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 197,
            Nome = "Limpar a Mente",
            Escola = "Abjuração",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação",
            Duracao = "24 horas",
            Componente = "Verbal, Somático",
            Descricao = "Até a magia acabar, uma criatura voluntária que você tocar fica imune a dano psíquico, a qualquer efeito que poderia sentir suas emoções ou ler seus pensamentos, a magias de adivinhação e a condição enfeitiçado. A magia pode até mesmo evitar a magia desejo e magias ou efeitos de poder similar usados para afetar a mente do alvo ou para adquirir informações sobre ele. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 198,
            Nome = "Localizar Animais ou Plantas",
            Escola = "Advinhação (ritual)",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático, Material (um pouco de pelo de um cão de caça)",
            Descricao = "Descreva ou nomeie um tipo especifico de besta ou planta. Concentre-se na voz da natureza ao seu redor, você descobre a direção e distância da criatura ou planta mais próxima desse tipo dentro de 7,5 quilômetros, se houver alguma presente. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 199,
            Nome = "Localizar Criatura",
            Escola = "Adivinhação",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 hora",
            Componente = "Verbal, Somático, Material (um pouco de pelo de um cão de caça)",
            Descricao = "Descreva ou nomeie uma criatura que seja familiar a você. Você sente a direção da localização da criatura, contanto que a criatura esteja a até 300 metros de você. Se a criatura se mover, você saberá a direção do movimento dela. A magia pode localizar uma criatura especifica que você conheça ou a criatura mais próxima de um tipo especifico (como um humano ou um unicórnio), desde que você já tenha visto tal criatura de perto – a até 9 metros – pelo menos uma vez. Se a criatura que você descreveu ou nomeou estiver em uma forma diferente, como se estiver sob efeito da magia metamorfose, essa magia não localizará a criatura. Essa magia não pode localizar uma criatura se água corrente de, pelo menos 3 metros de largura, bloquear o caminho direito entre você e a criatura",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 200,
            Nome = "Localizar Objeto",
            Escola = "Adivinhação",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 10 minutos",
            Componente = "Verbal, Somático, Material (um galho bifurcado)",
            Descricao = "Descreva ou nomeie um objeto que seja familiar a você. Você sente a direção da localização do objeto, contanto que o objeto esteja a até 300 metros de você. Se o objeto estiver em movimento, você saberá a direção do movimento dele. A magia pode localizar um objeto especifico que você, desde que você já tenha o visto de perto – a até 9 metros – pelo menos uma vez. Alternativamente, a magia pode localizar o objeto de um tipo em particular mais próximo, como certo tipo de vestuário, joia, móvel, ferramenta ou arma. Essa magia não pode localizar um objeto se qualquer espessura de chumbo, até mesmo uma folha fina, bloquear o caminho direto entre você e o objeto.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 201,
            Nome = "Loquacidade",
            Escola = "Transmutação",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 ação",
            Duracao = "1 hora",
            Componente = "Verbal",
            Descricao = "Até o fim da magia, quando você realizar um teste de Carisma, você pode substituir o número rolado por você por um 15. Além disso, não importa o que você diga, magias que determinam se você está dizendo a verdade indicarão que você está sendo sincero. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 202,
            Nome = "Lufada de Vento",
            Escola = "Evocação",
            Alcance = "Pessoal (linha de 18 metros)",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático, Material (uma semente de legume)",
            Descricao = "Uma linha de vento forte, com 18 metros de comprimento e 3 metros de largura, é soprada de você em uma direção, à sua escolha, pela duração da magia. Cada criatura que começar seu turno na linha, deve ser bem sucedida num teste de resistência de Força ou será empurrada 4,5 metros para trás, na direção seguida pela linha. Qualquer criatura na linha deve gastar 3 metros de movimentação para cada 1,5 metro que ela se mover enquanto se aproxima de você. As lufadas dispersam gases ou vapores e apagam velas, tochas e chamas similares desprotegidas na área. Elas fazem com que chamas protegidas, como as de lanternas, vibrem descontroladamente e tenham 50 por cento de chance de serem extintas. Com uma ação bônus, em cada um dos seus turnos, antes da magia acabar, você pode mudar a direção à qual a linha é soprada de você.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 203,
            Nome = "Luz",
            Escola = "Evocação",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação",
            Duracao = "1 hora",
            Componente = "Verbal, Material (um vaga-lume ou musgo fosforecente)",
            Descricao = "Você toca um objeto que não tenha mais 3 metros em qualquer dimensão. Até a magia acabar, o objeto emite luz plena num raio de 6 metros e penumbra por 6 metros adicionais. Cobrir o objeto completamente com alguma coisa opaca bloqueará a luz. A magia termina se você conjura-la novamente ou dissipa-la com uma ação. Se você tentar afetar um objeto segurado ou vestido por uma criatura hostil, a criatura deve ser bem sucedida num teste de Destreza para evitar a magia. ",
            IdTipoMagia = 1
        },
        new Magia
        {
            IdMagia = 204,
            Nome = "Luz do Dia",
            Escola = "Evocação",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "1 hora",
            Componente = "Verbal, Somático",
            Descricao = "Uma esfera de luz, com 18 metros de raio, se espalha a partir de um ponto, à sua escolha, dentro do alcance. A esfera produz luz plena num raio de 18 metros e penumbra por 18 metros adicionais. Se você escolher um ponto em um objeto que você esteja segurando, ou um que não esteja sendo vestido ou carregado, a luz brilha a partir do objeto e se move com ele. Cobrir completamente o objeto afetado com um objeto opaco, como uma vasilha ou um elmo, bloqueará a luz. Se qualquer área dessa magia sobrepor uma área de escuridão criada por uma magia de 3° ou inferior, a magia que criou a escuridão será dissipada. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 205,
            Nome = "Malogro",
            Escola = "Necromancia",
            Alcance = "9 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático",
            Descricao = "Energia necromântica inunda uma criatura, à sua escolha, que você possa ver dentro do alcance, drenando sua umidade e vitalidade. O alvo deve realizar um teste de resistência de Concentração. O alvo sofre 8d8 de dano necrótico se falhar no teste, ou metade desse dano se obtiver sucesso. Essa magia não surte efeito em mortosvivos ou constructos. Se você afetar uma criatura planta ou planta mágica, ela faz seu teste de resistência com desvantagem e a magia causa o máximo de dano a ela. Se você afetar uma planta não-mágica que não seja uma criatura, como uma árvore ou arbusto, ele não faz um teste de resistência; ela simplesmente seca e morre. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 5° nível ou superior, o dano aumenta em 1d8 para cada nível do espaço acima do 4°. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 206,
            Nome = "Mansão Magnífica de Mordenkainen",
            Escola = "Conjuração",
            Alcance = "90 metros",
            TempodeConjuracao = "1 minuto",
            Duracao = "24 horas",
            Componente = "Verbal, Somático, Material (um portal em miniatura esculpido em marfim, um pedaço de mármore polido e uma pequena colher de prata, cada item valendo, no mínimo, 5 po)",
            Descricao = "Você conjura uma residência extradimensional, dentro do alcance, que permanece pela duração. Você escolhe onde sua única entrada é localizada. A entrada brilha discretamente e tem 1,5 metro de largura por 3 metros de altura. Você e qualquer criatura que você designou, quando conjurou a magia, pode entrar na residência extradimensional enquanto o portal permanecer aberto. Você pode abrir ou fechar o portal se estiver a até 9 metros dele. Enquanto estiver fechado, o portal é invisível. Além do portal existe um magnifico salão com inúmeros aposentos. A atmosfera é limpa, fresca e morna. Você pode criar qualquer projeto de piso que quiser, mas o espaço não pode exceder 50 cubos, cada cubo tendo 3 metros de cada lado. O local é mobiliado e decorado como você desejar. Ele contém comida suficiente para servir nove banquetes para até 100 pessoas. Uma equipe de 100 servos quase-transparentes atende todos que entrarem. Você decide a aparência visual dos servos e o vestuário deles. Eles são completamente obedientes as suas ordens. Cada servo pode realizar qualquer tarefa que um servo humano comum poderia fazer, mas eles não podem atacar ou realizar qualquer ação que poderia causar maleficio direto a outra criatura. Portanto, os servos podem buscar coisas, limpar, remendar, dobrar roupas, acender lareiras, servir comida, despejar vinho e assim por diante. Os servos podem ir a qualquer lugar na mansão, mas não podem deixa-la. Mobília e outros objetos criados por essa magia viram fumaça se forem removidos da mansão. Quando a magia acabar, qualquer criatura dentro do espaço extradimensional é expelida para o espaço vago mais próximo da entrada.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 207,
            Nome = "Manto do Cruzado",
            Escola = "Evocação",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal",
            Descricao = "Poder sagrado irradia de você em uma aura de 9 metros de raio, despertando a audácia nas criaturas amigáveis. Até o final da magia, a aura se move, se mantendo centrada em você. Enquanto estiver na aura, cada criatura não-hostil (incluindo você) causa 1d4 de dano radiante extra quando atingir com ataques com arma.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 208,
            Nome = "Mão de Bigby",
            Escola = "Evocação",
            Alcance = "36 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concetração, até 1 minuto",
            Componente = "Verbal, Somático, Material (uma casca de ovo e uma luva de couro de cobra)",
            Descricao = "Você cria uma mão Grande de energia cintilante e translucida em um espaço desocupado que você possa ver dentro do alcance. A mão permanece pela duração da magia e ela se move ao seu comando, imitando os movimentos da sua própria mão. A mão é um objeto com CA 20 e pontos de vida igual ao seu máximo de pontos de vida. Se ela cair a 0 pontos de vida, a magia termina. Ela tem Força 26 (+8) e Destreza 10 (+0). A mão não preenche o espaço dela. Quando você conjura essa magia você pode, com uma ação bônus, nos seus turnos subsequentes, mover a mão até 18 metros e então causar um dos seguintes efeitos com ela. Mão Esmagadora. A mão tenta agarrar uma criatura Enorme ou menor a 1,5 metro dela. Você usa o valor de Força da mão para determinar o agarrão. Se o alvo for Médio ou menor, você terá vantagem no teste. Enquanto a mão estiver agarrando o alvo, você pode usar uma ação bônus para fazer a mão esmaga-lo. Quando o fizer, o alvo sofre dano de concussão igual a 2d6 + seu modificador de habilidade de conjuração. Mão Interposta. A mão se interpõem entre você e uma criatura a sua escolha até você lhe dar um comando diferente. A mão se move para ficar entre você e o alvo, concedendo a você meia-cobertura contra o alvo. O alvo não pode se mover através do espaço da mão se o valor de Força dele for menor ou igual ao valor de Força da mão. Se o valor de Força dele for maior que o valor de Força da mão, o alvo pode se mover até você através do espaço da mão, mas aquele espaço será considerado terreno difícil para o alvo. Mão Poderosa. A mão tenta empurrar uma criatura a 1,5 metro dela em uma direção a sua escolha. Realize um teste com a Força da mão, resistido por um teste de Força (Atletismo) do alvo. Se o alvo for Médio ou menor, você tem vantagem no teste. Se você for bem sucedido, a mão empurra o alvo até 1,5 metro mais uma quantidade de metros igual ao modificador da sua habilidade de conjuração multiplicado por 1,5. A mão se move com o alvo, permanecendo a 1,5 metro dele. Punho Cerrado. A mão golpeia uma criatura ou objeto a 1,5 metro dela. Realize uma jogada de ataque corpo-a-corpo com magia para a mão usando suas estatísticas de jogo. Se atingir, o alvo sofre 4d8 de dano de energia. Em Níveis Superiores. Se você conjurar essa magia usando um espaço de magia de 6° nível ou superior, o dano da opção punho cerrado aumenta em 2d8 e o dano da mão esmagadora aumenta em 2d6 para cada nível do espaço acima do 5°.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 209,
            Nome = "Mãos Flamejantes",
            Escola = "Evocação",
            Alcance = "Pessoal (cone de 4.5 metros)",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático",
            Descricao = "Enquanto você mantiver suas mãos com os polegares juntos e os dedos abertos, uma fino leque de chamas emerge das pontas dos seus dedos erguidos. Cada criatura num cone de 4,5 metros deve realizar um teste de resistência de Destreza. Uma criatura sofre 3d6 de dano de fogo se falhar no teste, ou metade desse dano se obtiver sucesso. O fogo incendeia qualquer objeto inflamável na área que não esteja sendo vestido ou carregado. Em Níveis Superiores. Se você conjurar essa magia usando um espaço de magia de 2° nível ou superior, o dano aumenta em 1d6 para cada nível do espaço acima do 1°. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 210,
            Nome = "Mãos Mágicas",
            Escola = "Conjuração",
            Alcance = "9 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "1 minuto",
            Componente = "Verbal, Somático",
            Descricao = "Uma mão espectral flutuante aparece num ponto, à sua escolha, dentro do alcance. A mão permanece pela duração ou até você dissipa-la com uma ação. A mão some se estiver a mais de 9 metros de você ou se você conjurar essa magia novamente. Você pode usar sua ação para controlar a mão. Você pode usar a mão para manipular um objeto, abrir uma porta ou recipiente destrancado, guardar ou pegar um item de um recipiente aberto ou derramar o conteúdo de um frasco. Você pode mover a mão até 9 metros a cada vez que a usa. A mão não pode atacar, ativar itens mágicos ou carregar mais de 5 quilos.",
            IdTipoMagia = 1
        },
        new Magia
        {
            IdMagia = 211,
            Nome = "Marca da Punição",
            Escola = "Evocação",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 ação bônus",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal",
            Descricao = "Da próxima vez que você atingir uma criatura com um ataque com arma, antes do fim da magia, a arma cintilará com radiação astral quando você golpear. O ataque causa 2d6 de dano radiante extra ao alvo, que se torna visível, se estava invisível, e o alvo emite penumbra em um raio de 1,5 metro e não pode ficar invisível até a magia acabar. Em Níveis Superiores. Se você conjurar essa magia usando um espaço de magia de 3° nível ou superior, o dano extra aumenta em 1d6 para cada nível do espaço acima do 2°. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 212,
            Nome = "Marca do Caçador",
            Escola = "Adivinhação",
            Alcance = "27 metros",
            TempodeConjuracao = "1 ação bônus",
            Duracao = "Concentração, até 1 hora",
            Componente = "Verbal",
            Descricao = "Você escolhe uma criatura que possa ver, dentro do alcance e a marca misticamente como sua presa. Até a magia acabar, você causa 1d6 de dano extra ao alvo sempre que você o atingir com um ataque com arma e você tem vantagem em quaisquer testes de Sabedoria (Percepção) ou Sabedoria (Sobrevivência) feitos para encontrá-la. Se o alvo cair a 0 pontos de vida antes da magia acabar, você pode usar uma ação bônus, no seu turno subsequente para marcar uma nova criatura. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 3° ou 4° nível, você poderá manter sua concentração na magia por até 8 horas. Quando você usar um espaço de magia de 5° nível ou superior, você poderá manter sua concentração na magia por até 24 horas.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 213,
            Nome = "Medo",
            Escola = "Ilusão",
            Alcance = "Pessola (cone de 9 metros)",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático, Material (uma pena branca ou o coração de uma galinha)",
            Descricao = "Você projeta uma imagem fantasmagórica dos piores medos de uma criatura. Cada criatura num cone de 9 metros, deve ser bem sucedida num teste de resistência de Sabedoria ou largara o que quer que esteja segurando e ficará amedrontada pela duração. Enquanto estiver amedrontada por essa magia, uma criatura deve usar a ação de Disparada e fugir de você pela rota mais curta disponível em cada um dos turnos dela, a não ser que não haja lugar para onde se mover. Se a criatura terminar o turno dela em um local onde ela não tenha linha de visão sua, a criatura pode realizar um teste de resistência de Sabedoria. Se obtiver sucesso, a magia termina naquela criatura. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 214,
            Nome = "Mensageiro Animal",
            Escola = "Encantamento (ritual)",
            Alcance = "9 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "24 horas",
            Componente = "Verbal, Somático, Material (um punhado de comida)",
            Descricao = "Através dessa magia, você usa um animal para entregar uma mensagem. Escolha uma besta Miúda que você possa ver dentro do alcance, como um esquilo, um gaio-azul ou um morcego. Você especifica um local, que você já deve ter visitado, e um remetente com uma descrição geral, como “um homem ou mulher vestido em um uniforme da guarda da cidade” ou “um anão ruivo vestindo um chapéu pontudo”. Você também fala uma mensagem com até vinte e cindo palavras. A besta alvo viaja pela duração da magia para o local especifico, cobrindo 75 quilômetros em 24 horas para um mensageiro voador ou 37,5 quilômetros para outros animais. Quando o mensageiro chegar, ele entrega sua mensagem para a criatura que você descreveu, repetindo o som da sua voz. O mensageiro fala apenas para uma criatura que tenha uma descrição compatível com a que ele recebeu. Se o mensageiro não alcançar o destino antes do fim da magia, a mensagem é perdida e a besta faz seu caminho de volta para onde você conjurou a magia. Em Níveis Superiores. Se você conjurar essa magia usando um espaço de magia de 3° nível ou superior, a duração da magia aumenta em 48 horas para cada nível do espaço acima do 2°.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 215,
            Nome = "Mensagem",
            Escola = "Transmutação",
            Alcance = "36 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "1 rodada",
            Componente = "Verbal, Somático, Material (um pedaço curto de fio de cobre)",
            Descricao = "Você aponta seu dedo para uma criatura dentro do alcance e sussurra uma mensagem. O alvo (e apenas ele) ouvi a mensagem e pode responder com um sussurro que apenas você pode ouvir. Você pode conjurar essa magia através de objetos sólidos se você tiver familiaridade com o alvo. Silêncio mágico, 30 centímetros de rocha, 2,5 centímetros de metal comum, uma fina camada de chumbo, ou 90 centímetros de madeira ou terra bloqueiam a magia. A magia não precisa seguir uma linha reta e pode viajar livremente, dobrando esquinas ou através de aberturas. ",
            IdTipoMagia = 1
        },
        new Magia
        {
            IdMagia = 216,
            Nome = "Mesclar-se às Rochas",
            Escola = "Transmutação (ritual)",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação",
            Duracao = "8 horas",
            Componente = "Verbal, Somático",
            Descricao = "Você aponta seu dedo para uma criatura dentro do alcance e sussurra uma mensagem. O alvo (e apenas ele) ouvi a mensagem e pode responder com um sussurro que apenas você pode ouvir. Você pode conjurar essa magia através de objetos sólidos se você tiver familiaridade com o alvo. Silêncio mágico, 30 centímetros de rocha, 2,5 centímetros de metal comum, uma fina camada de chumbo, ou 90 centímetros de madeira ou terra bloqueiam a magia. A magia não precisa seguir uma linha reta e pode viajar livremente, dobrando esquinas ou através de aberturas. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 217,
            Nome = "Metamorfose",
            Escola = "Transmutação",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 hora",
            Componente = "Verbal, Somático, Material (um casulo de lagarta)",
            Descricao = "Essa magia transforma uma criatura que você possa ver, dentro do alcance, em uma nova forma. Uma criatura involuntária deve realizar um teste de resistência de Sabedoria para evitar o efeito. Um metamorfo obtém sucesso automaticamente nesse teste de resistência. A transformação permanece pela duração, ou até o alvo cair a 0 pontos de vida ou morrer. A nova forma pode ser qualquer besta a qual o nível de desafio seja igual ou menor que o do alvo (ou o nível do alvo, se ele não possuir um nível de desafio). As estatísticas de jogo do alvo, incluindo seus valores de habilidades mentais, são substituídas pelas estatísticas da besta escolhida. Ele mantem sua tendência e personalidade. O alvo assume os pontos de vida da sua nova forma. Quando ele reverter a sua forma normal, a criatura retorna à quantidade de pontos de vida que ela tinha antes da transformação. Se ela reverter como resultado de ter caído a 0 pontos de vida, qualquer dano excedente é recebido pela sua forma normal. Contanto que o dano excedente não reduza os pontos de vida da forma normal da criatura a 0, ela não cairá inconsciente. Essa magia não pode afetar um alvo com 0 pontos de vida. A criatura é limitada em suas ações pela natureza da sua nova forma e ela não pode falar, conjurar magias ou realizar qualquer outra ação que precise de mãos ou de vocalização. O equipamento do alvo mescla-se a sua nova forma. O alvo não pode ativar, empunhar ou, de outra forma, se beneficiar de qualquer de seus equipamentos. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 218,
            Nome = "Metamorfose Verdadeira",
            Escola = "Transmutação",
            Alcance = "9 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 hora",
            Componente = "Verbal, Somático, Material (uma gota de mercúrio, uma porção de goma arábica e um pouco de fumaça)",
            Descricao = "Escolha uma criatura ou objeto não-mágico que você possa ver, dentro do alcance. Você transforma a criatura em uma criatura diferente, a criatura em um objeto ou o objeto em uma criatura (o objeto não pode nem estar sendo vestido nem carregado por outra criatura). A transformação permanece pela duração ou até o alvo cair a 0 pontos de vida ou morrer. Se você se concentrar nessa magia por toda a duração, a transformação será permanente. Metamorfos não são afetados por essa magia. Uma criatura involuntária pode realizar um teste de resistência de Constituição e, se for bem sucedida, não será afetada por essa magia. Criatura em Criatura. Se você transformar uma criatura em outro tipo de criatura, a nova forma pode ser de qualquer tipo que você desejar, contanto que o nível de desafio seja igual ou menor que o do alvo (ou o nível dele, caso o alvo não possua nível de desafio). As estatísticas de jogo do alvo, incluindo seus valores de habilidades mentais, são substituídas pelas estatísticas da nova forma. Ele mantem sua tendência e personalidade. O alvo assume os pontos de vida da sua nova forma e, quando ela reverter a sua forma normal, a criatura retorna à quantidade de pontos de vida que ela tinha antes da transformação. Se ela reverter como resultado de ter caído a 0 pontos de vida, qualquer dano excedente é recebido pela sua forma normal. Contanto que o dano excedente não reduza os pontos de vida da forma normal da criatura a 0, ela não cairá inconsciente. Essa magia não pode afetar um alvo com 0 pontos de vida. A criatura é limitada em suas ações pela natureza da sua nova forma e ela não pode falar, conjurar magias ou realizar qualquer outra ação que precise de mãos ou de vocalização, a não ser que a nova forma seja capaz de tais ações. O equipamento do alvo mescla-se a sua nova forma. O alvo não pode ativar, empunhar ou, de outra forma, se beneficiar de qualquer de seus equipamentos. Objeto em Criatura. Você pode transformar um objeto em um tipo de criatura, contanto que o tamanho da criatura não seja maior que o tamanho do objeto e, o nível de desafio da criatura será 9 ou menor. A criatura é amigável a você e aos seus companheiros. Ela age em cada um dos seus turnos. Você decide qual ação ela realizará e como ela se move. O Mestre tem as estatísticas da criatura e resolve todas as ações e movimentos dela. Se a magia se tornar permanente, você não terá mais controle sobre a criatura. Ele pode continuar amigável a você, dependendo da forma como você a tratou. Criatura em Objeto. Se você transformar uma criatura em um objeto, ela se transformará, junto com tudo que estiver vestindo ou carregando, nessa forma. As estatísticas da criatura tornam-se as do objeto e a criatura não se lembrará do tempo que passou nessa forma, depois da magia acabar e ela retornar a sua forma normal. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 219,
            Nome = "Miragem",
            Escola = "Ilusão",
            Alcance = "Visão",
            TempodeConjuracao = "10 minutos",
            Duracao = "10 dias",
            Componente = "Verbal, Somático",
            Descricao = "Você faz um terreno em uma área de até 1,5 quilômetro quadrados pareça, soe, cheire e, até, sinta com outro tipo de terreno natural. Os formatos gerais do terreno permanecem os mesmos, no entanto. Campos abertos ou uma estrada podem ser modificados para se assemelharem a um pântano, colina, fenda ou algum outro tipo de terreno difícil ou intransponível. Uma lagoa pode ser modificada para se parecer com um prado, um precipício com um declive suave ou um barranco pedregoso com uma estrada larga e lisa. Similarmente, você pode alterar a aparência de estruturas ou adiciona-las onde nenhuma existia. A magia não disfarça, esconde ou adiciona criaturas. A ilusão inclui elementos audíveis, visuais, táteis e olfativos, portanto, ela pode transformar solo limpo em terreno difícil (ou vice-versa) ou, de outra forma, impedir o movimento através da área. Qualquer porção de terreno ilusório (como uma rocha ou galho) que seja removida da área da magia desaparece imediatamente. Criaturas com visão verdadeira podem ver através da ilusão a verdadeira forma do terreno; porém, todos os outros elementos da ilusão permanecem, então, mesmo que a criatura esteja ciente da presença da ilusão, ela ainda interage fisicamente com a ilusão.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 220,
            Nome = "Missão",
            Escola = "Encantamento",
            Alcance = "18 metros",
            TempodeConjuracao = "1 minuto",
            Duracao = "30 dias",
            Componente = "Verbal",
            Descricao = "Você impõe um comando mágico a uma criatura que você possa ver, dentro do alcance, forçando-a a fazer algum serviço ou reprimindo-a por alguma ação ou curso de atividade, como você decidir. Se a criatura puder compreender você, ela deve ser bem sucedida num teste de resistência de Sabedoria ou ficará enfeitiçada por você pela duração. Enquanto a criatura estiver enfeitiçada por você, ela sofrerá 5d6 de dano psíquico toda vez que ela agir de maneira diretamente contrária às suas instruções, mas não mais de uma vez por dia. Uma criatura que não puder compreender você não é afetada por essa magia. Você pode emitir qualquer comando que escolher, exceto uma atividade que resulte em morte certa. Se você emitir um comando suicida, a magia termina. Você pode terminar a magia prematuramente usando uma ação para dissipa-la. As magias remover maldição, restauração maior ou desejo também podem termina-la. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 7° ou 8° nível, a duração será 1 ano. Quando você conjurar essa magia usando um espaço de magia de 9° nível, a magia dura até ser terminada por uma das magias mencionadas acima. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 221,
            Nome = "Mísseis Mágicos",
            Escola = "Evocação",
            Alcance = "36 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático",
            Descricao = "Você cria três dardos brilhantes de energia mística. Cada dardo atinge uma criatura, à sua escolha, que você possa ver, dentro do alcance. Um dardo causa 1d4 + 1 de dano de energia ao alvo. Todos os dardos atingem simultaneamente e você pode direciona-los para atingir uma criatura ou várias. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 222,
            Nome = "Modificar Memoria",
            Escola = "Encantamento",
            Alcance = "9 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático",
            Descricao = "Você tenta modelar as memórias de outra criatura. Uma criatura que você possa ver, deve realizar um teste de resistência de Sabedoria. Se você estiver lutando com a criatura, ela terá vantagem no teste de resistência. Se falhar na resistência, o alvo fica enfeitiçado por você pela duração. O alvo enfeitiçado está incapacitado e não sabe o que está acontecendo seu redor, apesar de ainda poder ouvir você. Se ele sofrer qualquer dano ou for alvo de outra magia, essa magia acaba, e nenhuma das memórias do alvo é modificada. Enquanto esse feitiço durar, você pode afetar a memória sobre um evento que o alvo participou nas últimas 24 horas e que não tenha durado mais de 10 minutos. Você pode, permanentemente, eliminar todas as memórias desse evento, permitir que o alvo relembre do evento com perfeita clareza e riqueza de detalhes, mudar sua memória sobre os detalhes do evento ou criar uma memória de outro evento qualquer. Você deve falar ao alvo para descrever como sua memória é afetada e ele deve ser capaz de compreender seu idioma para que as memórias modificadas se enraízem. A mente dele preenche qualquer lacuna nos detalhes da sua descrição. Se a magia terminar antes de você ter finalizado a descrição das memórias modificadas, a memória da criatura não será alterada. Do contrário, as memórias modificadas tomam lugar quando a magia acabar. Uma memória modificada não afeta, necessariamente, como uma criatura se comporta, particularmente se a memória contradiz as inclinações, tendência ou crenças naturais da criatura. Uma modificação ilógica na memória, como implantar uma memória de como a criatura gosta de se encharcar de ácido, é repudiada, talvez como um sonho ruim. O Mestre pode considerar uma modificação na memória muito absurda para afetar uma criatura de uma forma significativa. Uma magia remover maldição ou restauração maior, conjurada no alvo, restaura a verdadeira memória da criatura. Em Níveis Superiores. Se você conjurar essa magia usando um espaço de magia de 6° nível ou superior, você pode alterar a memória do alvo de um evento que aconteceu a até 7 dias atrás (6° nível), 30 dias atrás (7° nível), 1 ano atrás (8° nível) ou em qualquer momento do passado da criatura (9° nível). ",
            IdTipoMagia = 2
        },
         new Magia
        {
            IdMagia = 223,
            Nome = "Moldar Rochas",
            Escola = "Transmutação",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático, Material ( (barro mole, que deve ser trabalhado aproximadamente com a forma desejada para o objeto de pedra) ",
            Descricao = "Você toca um objeto de pedra de tamanho Médio ou menor, ou uma seção de rocha com não mais de 1,5 metro em qualquer dimensão e modela-a em qualquer forma que sirva aos seus propósitos. Então, por exemplo, você poderia modelar uma pedra grande em uma arma, ídolo ou caixão, ou fazer uma pequena passagem através de um muro, contanto que o muro não tenha mais de 1,5 metro de espessura. Você poderia, também, modelar uma porta de pedra ou sua moldura para selar a porta. O objeto que você cria pode ter até duas dobradiças e um trinco, mas detalhes mecânicos mais complexos não são possíveis.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 224,
            Nome = "Montaria Fantasmagórica",
            Escola = "Ilusão",
            Alcance = "9 metros",
            TempodeConjuracao = "1 minuto",
            Duracao = "1 hora",
            Componente = "Verbal, Somático",
            Descricao = "Uma criatura Grande, quase-real, similar a um cavalo, aparece no solo em um espaço desocupado, à sua escolha, dentro do alcance. Você decide a aparência da criatura, mas ela é equipada com sela, estribo e arreio. Qualquer equipamento criado por essa magia vira fumaça caso se afaste a mais de 3 metros da montaria. Pela duração, você ou a criatura que você escolher, pode cavalgar a montaria. A criatura usa as estatísticas de um cavalo de montaria, exceto por seu deslocamento ser de 30 metros e poder viajar 15 quilômetros em uma hora, ou 20 quilômetros em um ritmo rápido. Quando a magia acaba, a montaria desaparece gradualmente, dando ao cavaleiro 1 minuto para desmontar. A magia acaba se você usar uma ação para dissipa-la ou se a montaria sofrer qualquer dano. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 225,
            Nome = "Mover Terra",
            Escola = "Transmutação",
            Alcance = "36 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 2 horas",
            Componente = "Verbal, Somático, Material  (uma lâmina de ferro e uma pequena sacola contendo uma mistura de solos – argila, barro e areia) ",
            Descricao = "Escolha uma área de terreno não maior que 12 metros de lado, dentro do alcance. Você pode remodelar terra, areia ou barro na área da maneira que quiser, pera duração. Você pode erguer ou abaixar a elevação da área, criar ou preencher valas, levantar ou deitar um muro ou formar uma coluna. A extensão de tais mudanças não pode exceder metade da maior dimensão da área. Portanto, se você afetar um quadrado de 12 metros, você poderá criar um pilar de até 6 metros de altura, erguer ou abaixar a elevação do quadrado em até 6 metros ou cavar uma vala de até 6 metros de profundidade e assim por diante. Leva 10 minutos para completar essas modificações. Ao final de cada 10 minutos que você gastar se concentrando nessa magia, você pode escolher uma nova área de terreno para afetar. Devido às transformações no terreno ocorrerem lentamente, as criaturas na área normalmente não podem ficar presas ou sofrer dano pela movimentação do solo. Essa magia pode manipular rocha natural ou construções de pedra. Pedra e estruturas deslocam-se para acomodar o novo terreno. Se a forma pela qual você modela o terreno poderia tornar uma estrutura instável, ela poderá desmoronar. Similarmente, essa magia não afeta diretamente o crescimento da vegetação. A terra movida carrega quaisquer plantas no caminho junto com ela.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 226,
            Nome = "Movimentação Livre",
            Escola = "Abjuração",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação",
            Duracao = "1 hora",
            Componente = "Verbal, Somático, Material (uma fita de couro, enrolada no braço ou apêndice similar)",
            Descricao = "Você toca uma criatura voluntária. Pela duração, os movimentos do alvo não são afetados por terreno difícil e magias e outros efeitos mágicos também não podem reduzir o deslocamento do alvo ou fazer com que o alvo fique paralisado ou impedido. O alvo também pode gastar 1,5 metro de deslocamento para escapar, automaticamente, de impedimentos nãomágicos, como algemas ou o agarrão de uma criatura. Finalmente, estar submerso não impõe penalidades no deslocamento ou ataques do alvo. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 227,
            Nome = "Muralha de Energia",
            Escola = "Evocação",
            Alcance = "36 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 10 minutos",
            Componente = "Verbal, Somático, Material (um pouco de pó feita de uma gema transparente esmagada)",
            Descricao = "Uma muralha invisível de energia aparece do nada num ponto, à sua escolha, dentro do alcance. A muralha aparece em qualquer orientação que você escolher, como uma barreira horizontal ou vertical ou em uma angulação. Ela pode estar flutuando no ar ou apoiada em uma superfície sólida. Você pode molda-la em uma cúpula hemisférica ou uma esfera com um raio de até dez painéis de 3 metros por 3 metros. Cada painel deve ser contíguo com outro painel. Em qualquer formato, a muralha terá 0,6 centímetros de espessura. Ela permanece pela duração. Se a muralha passar pelo espaço ocupado por uma criatura quando ela surgir, a criatura será empurrada para um dos lados da muralha (você escolhe qual lado). Nada pode passar fisicamente através da muralha. Ela é imune a todos os danos e não pode ser dissipada por dissipar magia. A magia desintegrar destrói a muralha instantaneamente, no entanto. A muralha também se estende ao Plano Etéreo, bloqueando a viagem etérea através dela. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 228,
            Nome = "Muralha de Espinhos",
            Escola = "Conjuração",
            Alcance = "36 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 10 minutos",
            Componente = "Verbal, Somático, Material (um punhado de espinhos)",
            Descricao = "Você cria uma muralha de arbustos robustos, flexíveis, emaranhados e eriçados com espinhos pontudos. A muralha aparece, dentro do alcance, em uma superfície sólida e permanece pela duração. Você escolher fazer a muralha com até 18 metros de comprimento, 3 metros de altura e 1,5 metro de espessura ou um círculo com 6 metros de diâmetro e até 6 metros de altura com 1,5 metro de espessura. A muralha bloqueia a visão. Quando a muralha aparece, cada criatura dentro da área deve realizar um teste de resistência de Destreza. Se falhar na resistência, uma criatura sofrerá 7d8 de dano perfurante ou metade desse dano se obtiver sucesso. Uma criatura pode se mover através da muralha, embora lentamente e dolorosamente. Para cada 1,5 metro que a criatura atravesse da muralha, ela deve gastar 6 metros de movimento. Além disso, a primeira vez que a criatura entrar na muralha num turno ou termina o turno nela, ela deve fazer um teste de resistência de Destreza. Ela sofre 7d8 de dano cortante se falhar na resistência ou metade desse dano se obtiver sucesso. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 7° nível ou superior, ambos os tipos de dano aumentam em 1d8 para cada nível do espaço acima do 6°. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 229,
            Nome = "Muralha de Fogo",
            Escola = "Evocação",
            Alcance = "36 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático, Material (um pequeno pedaço de fósforo)",
            Descricao = "Você cria uma muralha de fogo numa superfície sólida dentro do alcance. Você pode fazer uma muralha de até 18 metros de comprimento, 6 metros de altura e 30 centímetros de espessura ou uma muralha anelar de até 6 metros de diâmetro, 6 metros de altura e 30 centímetros de espessura. A muralha é opaca e permanece pela duração. Quando a muralha aparece, cada criatura dentro da área dela deve realizar um teste de resistência de Destreza. Se falhar na resistência, uma criatura sofrerá 5d8 de dano, ou metade desse dano se passar na resistência. Um lado da muralha, escolhido por você no momento da conjuração da magia, causa 5d8 de dano de fogo a cada criatura que terminar o turno dela a até 3 metros desse lado ou dentro da muralha. Uma criatura sofre o mesmo dano quando entra na muralha pela primeira vez num turno ou termina seu turno nela. O outro lado da muralha não causa dano algum. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 5° nível ou superior, o dano aumenta em 1d8 para cada nível do espaço acima do 4°. ",
            IdTipoMagia = 2 
        },
        new Magia
        {
            IdMagia = 230,
            Nome = "Muralha de Gelo",
            Escola = "Evocação",
            Alcance = "36 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 10 minutos",
            Componente = "Verbal, Somático, Material (um pequeno pedaço de quartzo)",
            Descricao = "Você cria uma muralha de gelo numa superfície sólida dentro do alcance. Você pode molda-la em uma cúpula hemisférica ou uma esfera com um raio de até dez painéis de 3 metros por 3 metros. Cada painel deve ser contíguo com outro painel. Em qualquer formato, a muralha terá 0,6 centímetros de espessura. Ela permanece pela duração. Se a muralha passar pelo espaço ocupado por uma criatura quando ela surgir, a criatura na área será empurrada para um dos lados da muralha (você escolhe qual lado) e deve realizar um teste de resistência de Destreza. Se falhar na resistência, a criatura sofrerá 10d6 de dano de frio ou metade desse dano se passar na resistência. A muralha é um objeto que pode ser danificado e então, partido. Ela tem CA 12, 30 pontos de vida por seção de 3 metros e é vulnerável a dano de fogo. Reduzir os pontos de vida de uma seção de 3 metros da muralha a 0 destruirá essa seção, deixando para trás uma camada de ar gelado no espaço ocupado pela muralha. Uma criatura que atravesse a camada de ar gelado pela primeira vez num turno, deve realizar um teste de 262 263 resistência de Constituição. Essa criatura sofrerá 5d6 de dano de frio se fracassar na resistência, ou metade desse dano se obtiver sucesso. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 7° nível ou superior, o dano causado quando ela aparece aumenta em 2d6 e o dano por atravessar através da camada de ar gelado aumenta em 1d6 para cada nível do espaço acima do 6°. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 231,
            Nome = "Muralha de Pedra",
            Escola = "Conjuração",
            Alcance = "36 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 10 minutos",
            Componente = "Verbal, Somática, Material (um pequeno bloco de granito)",
            Descricao = "Uma muralha não-mágica de rocha sólida surge do nada num ponto, à sua escolha, dentro do alcance. A muralha tem 15 centímetros de espessura e é composta por dez painéis de 3 metros por 3 metros. Cada painel deve ser contíguo com, pelo menos, outro painel. Alternativamente, você pode criar painéis de 3 metros por 6 metros com apenas 7,5 centímetros de espessura. Se a muralha passar pelo espaço ocupado por uma criatura quando ela surgir, a criatura será empurrada para um dos lados da muralha (você escolhe qual lado). Se a criatura fosse ser rodeada por todos os lados da muralha (ou pela muralha e outra superfície sólida), a criatura pode realizar um teste de resistência de Destreza. Se obtiver sucesso, ela pode usar sua reação para se mover até seu deslocamento, assim não ficando mais cercada pela muralha. A muralha pode ter qualquer formato que você desejar, no entanto, ela não pode ocupar o mesmo espaço de uma criatura ou objeto. A muralha não precisa ser vertical ou se apoiar em qualquer fundação estável. Ela deve, no entanto, se fundir e estar solidamente suportada por rocha existente. Então, você pode usar essa magia para criar uma ponte sobre um abismo ou criar uma rampa. Se você criar um vão com mais de 6 metros de comprimento, você deve reduzir o tamanho de cada painel à metade para criar suportes. Você pode moldar grosseiramente a parede para criar merlões, ameias e assim por diante. A muralha é um objeto feito de pedra que pode ser danificado e então, partido. Cada painel tem CA 15 e 30 pontos de vida para cada 2,5 centímetros de espessura. Reduzir os pontos de vida de um painel a 0, o destruirá e pode fazer painéis conectados desmoronarem, à critério do Mestre. Se você mantiver sua concentração nessa magia por toda a duração, a muralha se tornará permanente e não poderá ser dissipada. Do  contrário, a muralha desaparece quando a magia acabar.",
            IdTipoMagia = 2 
        },
        new Magia
        {
            IdMagia = 232,
            Nome = "Muralha de Vento",
            Escola = "Evocação",
            Alcance = "36 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático, Material (um leque minúsculo e uma pena de origem exótica)",
            Descricao = "Uma muralha de ventos fortes ergue-se do chão num ponto, à sua escolha, dentro do alcance. Você pode fazer a muralha ter até 15 metros de comprimento, 4,5 metros de altura e 30 centímetros de espessura. Você pode moldar a muralha em qualquer forma que desejar, contanto que ela faça um caminho contínuo pelo solo. A muralha permanece pela duração. Quando a muralha aparece, cada criatura dentro da área dela deve realizar um teste de resistência de Força. Uma criatura sofre 3d8 de dano de concussão se falhar na resistência, ou metade desse dano se obtiver sucesso. Os ventos fortes mantem névoa, fumaça e outros gases afastados. Criaturas ou objetos voadores Pequenos ou menores, não podem atravessar a muralha. Materiais leves e soltos trazidos para a muralha são arremessados para cima. Flechas, virotes e outros projéteis ordinários disparados contra alvos além da muralha são defletidos para cima e erram automaticamente. (Pedras arremessadas por gigantes ou armas de cerco e projéteis similares, não são afetados.) As criaturas em forma gasosa não podem atravessa-la.",
            IdTipoMagia = 2 
        },
        new Magia
        {
            IdMagia = 233,
            Nome = "Muralha Prismática",
            Escola = "Abjuração",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "10 minutos",
            Componente = "Verbal, Somático",
            Descricao = "Uma plano cintilante multicolorido de luzes forma uma parece vertical opaca – de até 27 metros de comprimento, 9 metros de altura e 2,5 centímetros de espessura – centrada num ponto que você possa ver, dentro do alcance. Alternativamente, você pode moldar a muralha numa esfera de 9 metros de diâmetro centrada num ponto, à sua escolha, dentro do alcance. A muralha permanece no lugar pela duração. Se você posicionar a muralha de forma que ela passaria através do espaço ocupado por uma criatura, a magia falha e sua ação e o espaço de magia são desperdiçados. A muralha emite luz plena num raio de 30 metros e penumbra por 30 metros adicionais. Você e as criaturas designadas, no momento que você conjurou a magia, podem passar através e permanecer perto da muralha sem se ferirem. Se outra criatura que puder ver a muralha se aproximar mais de 6 metros dela ou começar seu turno lá, a criatura deve realizar um teste de resistência de Constituição ou ficará cega por 1 minuto. A muralha consiste em sete camadas, cada uma de uma cor diferente. Quando uma criatura tenta tocar ou passar através da muralha, ela atravessa uma camada de cada vez, até atravessar todas as camadas da muralha. À medida que ela passa ou toca cada camada, a criatura realiza um teste de resistência de Destreza ou será afetada pelas propriedades daquela camada, como descrito abaixo. A muralha pode ser destruída, também, uma camada por vez, em ordem de vermelho à violeta, pelos meios especificados em cada camada. Quando uma camada é destruída, ela permanece assim pela duração da magia. Um bastão do cancelamento destrói uma muralha prismática, mas um campo antimagia não produz efeito nela. 1. Vermelho. O alvo sofre 10d6 de dano de fogo se falhar na resistência ou metade desse dano se obtiver sucesso. Enquanto essa camada estiver no lugar, ataques à distância não-mágicos não podem atravessar a muralha. A camada pode ser destruída causando, pelo menos, 25 de dano de frio a ela. 2. Laranja. O alvo sofre 10d6 de dano de ácido se falhar na resistência ou metade desse dano se obtiver sucesso. Enquanto essa camada estiver no lugar, ataques à distância mágicos não podem atravessar a muralha. A camada pode ser destruída por um vento forte. 264 3. Amarelo. O alvo sofre 10d6 de dano elétrico se falhar na resistência ou metade desse dano se obtiver sucesso. A camada pode ser destruída causando, pelo menos, 60 de dano de energia a ela. 4. Verde. O alvo sofre 10d6 de dano de veneno se falhar na resistência ou metade desse dano se obtiver sucesso. A magia criar passagem ou outra magia de nível igual ou superior que possam abrir um portal em uma superfície sólida, destroem essa camada. 5. Azul. O alvo sofre 10d6 de dano de frio se falhar na resistência ou metade desse dano se obtiver sucesso. A camada pode ser destruída causando, pelo menos, 25 de dano de fogo a ela. 6. Anil. Se falhar na resistência, o alvo ficará impedido. Ele deve então, fazer um teste de resistência de Constituição ao final de cada um dos turnos dele. Se obtiver sucesso três vezes, a magia termina. Se falhar na resistência três vezes, ela se torna pedra é afetada pela condição petrificado. Os sucessos e falhas não precisam ser consecutivos; anote ambos os resultados até o alvo acumular três de mesmo tipo. Enquanto essa camada estiver no lugar, magias não podem ser conjuradas através da muralha. A camada pode ser destruída por luz plena emitida pela magia luz do dia ou uma magia similar de nível equivalente ou superior. 7. Violeta. Se falhar na resistência, o alvo ficará cego. Ele deve realizar um teste de resistência de Sabedoria no início do seu próximo turno. Um sucesso na resistência acaba com a cegueira. Se falhar na resistência, a criatura é transportada para outro plano de existência, escolhido pelo Mestre, e não estará mais cego. (Tipicamente, uma criatura que esteja em um plano que não seja o seu plano natal é banida para lá, enquanto que outras criaturas geralmente são enviadas para os Planos Astral ou Etéreo.) Essa camada é destruída pela magia dissipar magia ou por uma magia similar de nível equivalente ou superior que possa acabar com magias e efeitos mágicos.",
            IdTipoMagia = 2 
        },
        new Magia
        {
            IdMagia = 234,
            Nome = "Nevasca",
            Escola = "Conjuração",
            Alcance = "45 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático, Material (um punhado de poeira ",
            Descricao = "Até a magia acabar, uma chuva congelante e neve caem num cilindro de 6 metros de altura por 12 metros de raio, centrado num ponto, à sua escolha, dentro do alcance. A área é de escuridão densa e, chamas expostas na área são extintas. O solo na área é coberto por gelo escorregadio, tornando-o terreno difícil. Quando uma criatura entrar na área da magia pela primeira vez num turno ou começar seu turno nela, ela deve realizar um teste de resistência de Destreza. Se falhar, cairá no chão. Se um, criatura estiver se concentrando na área da magia, a criatura deve realizar um teste de resistência de Constituição contra a CD da magia, ou perderá a concentração.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 235,
            Nome = "Névoa Fétida",
            Escola = "Conjuração",
            Alcance = "27 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático, Material (um ovo podre ou várias folhas de repolho)",
            Descricao = "Você cria uma esfera, de 6 metros de raio, de gás amarelado nauseante, centrada num ponto dentro do alcance. A névoa se espalha, dobrando esquinas, e sua área é de escuridão densa. A névoa perdura no ar pela duração. Cada criatura que estiver completamente dentro da névoa no início do seu turno deve realizar um teste de resistência de Constituição contra veneno. Se falhar na resistência, a criatura gastará sua ação nesse turno tentando vomitar e cambaleando. Um vento moderado (pelo menos 15 quilômetros por hora) dispersará a névoa depois de 4 rodadas. Um vento forte (pelo menos 30 quilômetros por hora) dispersará a névoa após 1 rodada. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 236,
            Nome = "Névoa Mortal",
            Escola = "Conjuração",
            Alcance = "36 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 10 minutos",
            Componente = "Verbal, Somático",
            Descricao = "Você cria uma esfera de nevoeiro venenoso de cor amarelo-esverdeado, com 6 metros de raio, centrado em um ponto, à sua escolha, dentro do alcance. O nevoeiro se espalha, dobrando esquinas. Ele permanece pela duração ou até um vento forte dispersar o nevoeiro, terminando a magia. Sua área é de escuridão densa. Quando uma criatura entra na área da magia pela primeira vez no turno dela ou começa seu turno lá, essa criatura deve realizar um teste de resistência de Constituição. A criatura sofre 5d8 de dano de veneno, ou metade desse dano, se passar no teste. As criaturas serão afetadas mesmo se prenderem a respiração ou não precisarem respirar. O nevoeiro se afasta 3 metros de você no começo de cada um dos seus turnos, deslizando pela superfície do solo. Os vapores são mais pesados que o ar, mantendo-se nos níveis mais baixos do terreno, até mesmo caindo em aberturas. Em Níveis Superiores. Se você conjurar essa magia usando um espaço de magia de 6° nível ou superior, o dano aumenta em 1d8 para cada nível do espaço acima do 5°.",
            IdTipoMagia = 2 
        },
        new Magia
        {
            IdMagia = 237,
            Nome = "Névoa Obscurecente",
            Escola = "Conjuração",
            Alcance = "36 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 hora",
            Componente = "Verbal, Somatório",
            Descricao = "Você cria uma esfera de 6 metros de raio de névoa, centrada num ponto, dentro do alcance. A esfera se espalha, dobrando esquinas, e a área dela é de escuridão densa. Ela permanece pela duração ou até um vento moderado ou mais rápido (pelo menos 15 quilômetros por hora) dispersa-la. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 2° nível ou superior, o raio da névoa aumenta em 6 metros para cada nível do espaço acima do 1°. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 238,
            Nome = "Nublar",
            Escola = "Ilusão",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal",
            Descricao = "Seu corpo se torna turvo, mudando e oscilando para todos que puderem ver você. Pela duração, qualquer criatura terá desvantagem nas jogadas de ataque contra você. Um atacante é imune a esse efeito se não depender de visão, como os que tenham percepção às cegas ou os que puderem ver através de ilusões, como os com visão verdadeira. ",
            IdTipoMagia = 2 
        },
        new Magia
        {
            IdMagia = 239,
            Nome = "Nuvem de Adagas",
            Escola = "Conjuração",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somatório, Material (uma lasca de vidro)",
            Descricao = "Você preenche o ar com adagas giratórias num cubo de 1,5 metro quadrado, centrado em m ponto, à sua escolha, dentro do alcance. Uma criatura sofre 4d4 de dano cortante quando entra na área da magia pela primeira vez no turno dela ou começa seu turno na área. Em Níveis Superiores. Se você conjurar essa magia usando um espaço de magia de 3° nível ou superior, o dano aumenta em 2d4 para cada nível do espaço acima do 2°. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 240,
            Nome = "Nuvem Incendiária",
            Escola = "Conjuração",
            Alcance = "45 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somatório",
            Descricao = "Uma nuvem de fumaça rodopiante que dispara brasas incandescentes aparece numa esfera de 6 metros centrada num ponto, dentro do alcance. A nuvem se espalha, dobrando esquinas, e gera escuridão densa. Ela permanece pela duração ou até que um vento de velocidade moderada ou mais forte (pelo menos 15 quilômetros por hora) a disperse. Quando a nuvem aparece, cada criatura deve realizar um teste de resistência de Destreza. Uma criatura sofre 10d8 de dano de fogo se falhar na resistência ou metade desse dano se passar. Uma criatura deve, também, realizar um teste de resistência quando entrar na área da magia pela primeira vez num turno ou terminar seu turno nela. A nuvem se afasta 3 metros de você numa direção, que você escolheu, no começo de cada um dos seus turnos.",
            IdTipoMagia = 2 
        },
        new Magia
        {
            IdMagia = 241,
            Nome = "Olho Arcano",
            Escola = "Adivinhação",
            Alcance = "9 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 hora",
            Componente = "Verbal, Somatório, Material (um punhado de pelo de morcego)",
            Descricao = "Você cria um olho mágico invisível, dentro do alcance, que flutua no ar pela duração. Você mentalmente recebe informações visuais do olho, que possui visão normal e visão no escuro com alcance de 9 metros. O olho pode ver em todas as direções. Com uma ação, você pode mover o olho até 9 metros em qualquer direção. Não existe limite de quão longe de você o olho pode se mover, mas ele não pode entrar em outro plano de existência. Uma barreira solida bloqueia o movimento do olho, mas o olho pode passar através de aberturas de até 3 centímetros de diâmetro.",
            IdTipoMagia = 2 
        },
        new Magia
        {
            IdMagia = 242,
            Nome = "Onda Destrutiva",
            Escola = "Evocação",
            Alcance = "Pessoal (9 metros de raio)",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal",
            Descricao = "Você golpeia o chão, criando uma explosão de energia divina que se propaga de você. Cada criatura, à sua escolha, a até 9 metros de você, deve ser bem sucedida em um teste de resistência de Constituição ou sofrerá 5d5 de dano trovejante, assim como 5d6 de dano radiante ou necrótico (à sua escolha), e será derrubada no chão. Uma criatura que obtenha sucesso no teste de resistência sofre metade desse dano e não é derrubada no chão.",
            IdTipoMagia = 2  
        },
        new Magia
        {
            IdMagia = 243,
            Nome = "Onda Trovejante",
            Escola = "Evocação",
            Alcance = "Pessoal (cubo de 4,5 metros)",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático",
            Descricao = "Uma onda de força trovejante varre tudo a partir de você. Cada criatura num cubo de 4,5 metros originado em você, deve realizar um teste de resistência de Constituição. Se falhar na resistência, uma criatura sofrerá 2d8 de dano trovejante e será empurrada 3 metros para longe de você. Se obtive sucesso na resistência, a criatura sofrerá metade desse dano e não será empurrada. Além disso, objetos soltos que estiverem completamente dentro da área de efeito serão automaticamente empurrados 3 metros para longe de você pelo efeito da magia e a magia emitirá um ressonante barulho de trovão audível a até 90 metros. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 2° nível ou superior, o dano aumenta em 1d8 para cada nível acima do 1°.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 244,
            Nome = "Oração Curativa",
            Escola = "Evocação",
            Alcance = "9 metros",
            TempodeConjuracao = "10 minutos",
            Duracao = "Instantânea",
            Componente = "Verbal",
            Descricao = "Até seis criaturas, à sua escolha, que você possa ver, dentro do alcance, recuperam uma quantidade de pontos de vida igual a 2d8 + seu modificador de habilidade de conjuração, cada uma. Essa magia não afeta mortos-vivos ou constructos. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 3° nível ou superior, a cura aumenta em 1d8 para cada nível do espaço acima do 2°.",
            IdTipoMagia = 2 
        },
        new Magia
        {
            IdMagia = 245,
            Nome = "Orbe Cromática",
            Escola = "Evocação",
            Alcance = "27 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático, Material (um diamante valendo, no mínimo, 50 po)",
            Descricao = "Você arremessa uma esfera de energia de 12 centímetros de diâmetro numa criatura que você possa ver dentro do alcance. Você escolhe ácido, frio, fogo, elétrico, veneno ou trovejante para o tipo de orbe que você cria e, então, realiza um ataque à distância com magia. Se o ataque atingir, a criatura sofre 3d8 de dano do tipo escolhido. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 2° nível ou superior, o dano aumenta em 1d8 para cada nível do espaço acima do 1°. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 246,
            Nome = "Orientação",
            Escola = "Adivinhação",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático",
            Descricao = "Você toca uma criatura voluntária. Uma vez, antes da magia acabar, o alvo pode rolar um d4 e adicionar o número rolado a um teste de habilidade a escolha dele. Ele pode rolar o dado antes ou depois de realizar o teste de habilidade. Após isso, a magia termina.",
            IdTipoMagia = 1
        },
        new Magia
        {
            IdMagia = 247,
            Nome = "Padrão Hipnótico",
            Escola = "Ilusão",
            Alcance = "36 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Somático, Material (uma vareta brilhante de incenso ou um frasco de cristal cheio de material fosforecente)",
            Descricao = "Você cria um padrão retorcido de cores que se entrelaça através do ar dentro de um cubo de 9 metros, dentro do alcance. O padrão aparece por um momento depois desaparece. Cada criatura na área que ver o padrão, deve realizar um teste de resistência de Sabedoria. Se falhar na resistência, a criatura fica enfeitiçada pela duração. Enquanto estiver enfeitiçada por essa magia, a criatura está incapacitada e tem deslocamento 0. A magia acaba em uma criatura afetada se ela sofrer dano ou se alguém usar uma ação para agitar a criatura para tira-la de seu estupor.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 248,
            Nome = "Palavra Curativa",
            Escola = "Evocação",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação bônus",
            Duracao = "Instantânea",
            Componente = "Verbal",
            Descricao = "Uma criatura, à sua escolha, que você possa ver dentro do alcance recupera uma quantidade de pontos de vida igual a 1d4 + seu modificador de habilidade de conjuração. Essa magia não tem efeito em mortos-vivos ou constructos Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 2° nível ou superior, a cura aumenta em 1d4 para cada nível do espaço acima do 1°.",
            IdTipoMagia = 2 
        },
        new Magia
        {
            IdMagia = 249,
            Nome = "Palavra Curativa em Massa",
            Escola = "Evocação",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação bônus",
            Duracao = "Instantânea",
            Componente = "Verbal",
            Descricao = "À medida que você brada palavras de restauração, até seis criaturas, à sua escolha, que você possa ver, dentro do alcance, recuperam uma quantidade de pontos de vida igual a 1d4 + seu modificador de habilidade de conjuração. Essa magia não afeta mortos-vivos ou constructos. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 4° nível ou superior, a cura aumenta em 1d4 para cada nível do espaço acima do 3°. ",
            IdTipoMagia = 2 
        },
        new Magia
        {
            IdMagia = 250,
            Nome = "Palavra de Poder Artodoar",
            Escola = "Encantamento",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal",
            Descricao = "Você pronuncia uma palavra de poder que pode oprimir a mente de uma criatura que você possa ver, dentro do alcance, deixando-a estupefata. Se o alvo escolhido estiver com 150 pontos de vida ou menos, ele ficará atordoado. Do contrário, essa magia não produz efeito. O alvo atordoado deve realizar um teste de resistência de Constituição no final de cada um dos turnos dele. Se obtiver sucesso na resistência, o efeito de atordoamento termina.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 251,
            Nome = "Palavra de Poder Curar",
            Escola = "Evocação",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático",
            Descricao = "Uma onda de energia curativa inunda a criatura tocada. O alvo recupera todos os seus pontos de vida. Se a criatura estiver enfeitiçada, amedrontada, paralisada ou atordoada, a condição termina. Se a criatura estiver caída, ela pode usar a reação dela para se levantar. Essa magia não afeta mortos-vivos ou constructos. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 252,
            Nome = "Palavra de Poder Matar",
            Escola = "Encantamento",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal",
            Descricao = "Você profere uma palavra de poder que pode compelir uma criatura que você possa ver, dentro do alcance, a morrer instantaneamente. Se o alvo escolhido estiver com 100 pontos de vida ou menos, ele morre. Do contrário, essa magia não produz efeito. ",
            IdTipoMagia = 2 
        },
        new Magia
        {
            IdMagia = 253,
            Nome = "Palavra de Recordação",
            Escola = "Conjuração",
            Alcance = "1,5 metro",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal",
            Descricao = "Você e até cinco criaturas voluntária a 1,5 metro de você, instantaneamente são teletransportadas para um santuário previamente designado. Você e qualquer criatura que se teletransportar com você, aparece no espaço desocupado mais próximo do ponto que você designou quando preparou seu santuário (veja abaixo). Se você conjurar essa magia sem ter preparado um santuário primeiro, a magia não funciona. Você deve designar um santuário na conjuração dessa magia dentro de um local, como um templo dedicado ou fortemente ligado a sua divindade. Se você tentar conjurar essa magia dessa forma em uma área que não seja dedicada à sua divindade, a magia não funciona.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 254,
            Nome = "Palavra Divina",
            Escola = "Evocação",
            Alcance = "9 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal",
            Descricao = "Você profere uma palavra divina, imbuída com o poder que moldou o mundo na aurora da criação. Escolha qualquer quantidade de criaturas que você possa ver dentro do alcance. Cada criatura que puder ouvir você deve realizar um teste de resistência de Carisma. Ao falhar na resistência, uma criatura sofre um efeito baseado nos seus pontos de vida atuais:  50 pontos de vida ou menos: surda por 1 minuto  40 pontos de vida ou menos: surda e cega por 10 minutos  30 pontos de vida ou menos: surda, cega e atordoada por 1 hora  20 pontos de vida ou menos: morta instantaneamente Independentemente dos seus pontos de vida atuais, um celestial, corruptor, elemental ou fada que falhar na sua resistência é obrigado a voltar para o plano de origem dele (se já não for aqui) e não pode retornar para o plano atual por 24 horas através de nenhum meio inferior à magia desejo. ",
            IdTipoMagia = 2 
        },
        new Magia
        {
            IdMagia = 255,
            Nome = "Parar o Tempo",
            Escola = "Transmutação",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal",
            Descricao = "Você, por um breve momento, para o fluxo do tempo pra tudo, menos pra você. Nenhum tempo se passa para as outras criaturas, enquanto você realiza 1d4 + 1 turnos de uma vez, durante os quais você pode usar ações e se mover normalmente. Essa magia termina se uma das ações que você fizer durante esse período ou qualquer efeito que você criar, afetar uma criatura diferente de você ou um objeto que esteja sendo vestido ou carregado por outro que não você. Além disso, a magia termina se você se mover para um lugar a mais de 300 metros do local onde você conjurou essa magia.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 256,
            Nome = "Passo Nebuloso",
            Escola = "Conjuração",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 ação bônus",
            Duracao = "Instantânea",
            Componente = "Verbal",
            Descricao = "Brevemente envolto por uma neblina prateada, você se teletransporta a até 9 metros para um espaço desocupado que você possa ver.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 257,
            Nome = "Passos Longos",
            Escola = "Transmutação",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação",
            Duracao = "1 hora",
            Componente = "Verbal, Somático, Material (um pouco de barro)",
            Descricao = "Você toca uma criatura. O deslocamento do alvo aumenta em 3 metros, até a magia acabar. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 2° nível ou superior, você pode afetar uma criatura adicional para cada nível do espaço acima do 1°. ",
            IdTipoMagia = 2 
        },
        new Magia
        {
            IdMagia = 258,
            Nome = "Passos Sem Pegadas",
            Escola = "Abjuração",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 hora",
            Componente = "Verbal, Somático, Material (cinzas de uma folha de visco queimada e um ramo de pinheiro)",
            Descricao = "Um véu de sombras e silencia irradia de você, encobrindo você e seus companheiros contra detecção. Pela duração, cada criatura, à sua escolha, a até 9 metros de você (incluindo você) recebe +10 de bônus em testes de Destreza (Furtividade) e não pode ser rastreada, exceto por meio mágicos. Uma criatura que receber esse bônus não deixa quaisquer pegadas ou outros vestígios da sua passagem. ",
            IdTipoMagia = 2 
        },
        new Magia
        {
            IdMagia = 259,
            Nome = "Patas de Aranha",
            Escola = "Transmutação",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 hora",
            Componente = "Verbal, Somático, Material (uma gota de betume e uma aranha)",
            Descricao = "Até a magia acabar, uma criatura voluntária que você tocar, recebe a habilidade de se mover para cima, para baixo e através de superfícies verticais e de cabeça para baixo pelos tetos, enquanto deixa suas mãos livres. O alvo também ganha deslocamento de escalada igual a seu deslocamento de caminhada.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 260,
            Nome = "Pele de Árvore",
            Escola = "Transmutação",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 hora",
            Componente = "Verbal, Somático, Material (um pedaço de casca de carvalho)",
            Descricao = "Você toca uma criatura voluntária. Até o fim da magia, a pele da criatura fica rígida, similar a casca de um carvalho, e a CA do alvo não pode ser inferior a 16, independentemente do tipo de armadura que ela esteja vestindo.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 261,
            Nome = "Pele de Pedra",
            Escola = "Abjuração",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 hora",
            Componente = "Verbal, Somático, Material (pó de diamante no valor de 100 po, consumido pela magia)",
            Descricao = "Essa magia transforma a pele de uma criatura voluntária que você tocar em rocha sólida. Até a magia acabar, o alvo tem resistência a dano de concussão, cortante e perfurante não-mágico. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 262,
            Nome = "Pequena Cabana de Leomund",
            Escola = "Evocação (ritual)",
            Alcance = "Pessoal (hemisfério de 3 metros de raio)",
            TempodeConjuracao = "1 minuto",
            Duracao = "8 horas",
            Componente = "Verbal, Somático, Material (uma pequena conta de cristal)",
            Descricao = "Um domo de energia imóvel, de 3 metros de raio, aparece do nada, ao seu redor e acima de você e permanece parado pela duração. A magia termina se você deixar a área. Nove criaturas de tamanho Médio ou menor podem caber dentro do domo com você. A magia falha se a área 269 incluir criaturas maiores ou mais de nove criaturas. Criaturas e objetos dentro do domo quando você conjurou essa magia, podem se mover através dele livremente. Todas as outras criaturas e objetos são bloqueados ao tentarem atravessa-lo. Magias e outros efeitos mágicos não podem se estender através do domo ou serem conjurados através dele. A atmosfera dentro do espaço é confortável e seca, independente do clima do lado de fora. Até a magia acabar, você pode comandar o interior para que fique mal iluminado ou escuro. O domo é opaco do lado de fora, de qualquer cor que você desejar, mas é transparente do lado de dentro. ",
            IdTipoMagia = 1
        },
        new Magia
        {
            IdMagia = 263,
            Nome = "Perdição",
            Escola = "Encantamento",
            Alcance = "9 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático, Material (uma gota de sangue)",
            Descricao = "Até três criaturas, à sua escolha, que você possa ver dentro do alcance, devem realizar um teste de resistência de Carisma. Sempre que um alvo que falhou nessa resistência realizar uma jogada de ataque ou um teste de resistência antes da magia acabar, o alvo deve rolar um d4 e subtrair o valor rolado da jogada de ataque ou teste de resistência. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 2° nível ou superior, você pode afetar uma criatura adicional para cada nível do espaço acima do 1°. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 264,
            Nome = "Piscar",
            Escola = "Transmutação",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 ação",
            Duracao = "1 minuto",
            Componente = "Verbal, Somático",
            Descricao = "Role um d20 no final de cada um dos seus turnos pela duração da magia. Com um resultado de 11 ou maior, você desaparece do seu plano de existência atual e reaparece no Plano Etéreo (a magia falha e a conjuração é perdida se você já estiver nesse plano). No início do seu próximo turno e quando a magia terminar, se você estiver no Plano Etéreo, você retorna a um espaço desocupado de sua escolha que você possa ver a até 3 metros do espaço em que você desapareceu. Se não houver um espaço disponível dentro do alcance, você reaparece no espaço desocupado mais próximo (escolhido aleatoriamente, se existir mais de um espaço a mesma distância). Você pode dissipar a magia com uma ação. Quando estiver no Plano Etéreo, você pode ver e ouvir o plano de onde você veio, que aparece em tons de cinza, e você não pode ver nada além de 18 metros. Você só pode afetar ou ser afetado por outras criaturas no Plano Etéreo. As criaturas que não estiverem lá não podem notar você nem interagir com você, a não ser que elas tenham uma habilidade que as permita. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 265,
            Nome = "Porta Dimensional",
            Escola = "Conjuração",
            Alcance = "150 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal",
            Descricao = "Você se teletransporte da sua posição atual para qualquer local dentro do alcance. Você aparece exatamente no local desejado. Pode ser um lugar que você possa ver, um que você possa visualizar ou um que você possa descrever indicando a distância e direção, como “60 metros diretamente pra baixo” ou “90 metros, subindo para noroeste num ângulo de 45 graus”. Você pode levar objetos com você, contanto que o peso deles não exceda o que você pode carregar. Você também pode levar uma criatura voluntária do seu tamanho ou menor, que esteja carregando equipamento até o limite da capacidade de carga dela. A criatura deve estar a 1,5 metro de você quando você conjurar a magia. Se você aparecer em um lugar que já esteja ocupado por um objeto ou uma criatura, você e qualquer criatura viajando com você, sofrem 4d6 de dano de energia cada um e a magia falha em teletransportar vocês.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 266,
            Nome = "Portal",
            Escola = "Conjuração",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático, Material (um diamante valendo, no mínimo, 5.000 po)",
            Descricao = "Você conjura um portal conectando um espaço desocupado que você possa ver, dentro do alcance, a uma localização precisa em um plano de existência diferente. O portal é uma abertura circular, que você pode fazer ter de 1,5 a 6 metros de diâmetro. Você pode orientar o portal em qualquer direção, à sua escolha. O portal permanece pela duração. O portal terá uma frente e um fundo em cada plano que ele aparecer. Viajar pelo portal só é possível ao atravessa-lo pela frente. Qualquer coisa que o fizer, é instantaneamente transportado para o outro plano, aparecendo no espaço desocupado mais próximo do portal. Divindades e outros soberanos planares podem impedir que portais criados através dessa magia se abram na presença deles ou em qualquer parte dos seus domínios. Quando você conjurar essa magia, você pode falar o nome de uma criatura especifica (um pseudônimo, título ou apelido não funcionará). Se essa criatura estiver em um plano diferente do que você está, o portal se abre na vizinhança imediata da criatura nomeada e suga a criatura para dentro do portal, fazendo-a aparecer no espaço desocupado mais próximo do seu lado do portal. Você não adquire qualquer poder especial sobre a criatura e ela está livre para agir como o Mestre julgar apropriado. Ela pode ir embora, atacar você ou ajudar você. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 267,
            Nome = "Portal Arcano",
            Escola = "Conjuração",
            Alcance = "150 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 10 minutos",
            Componente = "Verbal, Somático",
            Descricao = "Você cria portais de teletransporte conectados que permanecem abertos pela duração. Escolha dois pontos no solo que você possa ver, um ponto a até 3 metros de você e outro a até 150 metros de você. Um portal circular, com 3 metros de diâmetro, se abre em cada ponto. Se o portal se abriria num local ocupado por uma criatura, a magia falha e a conjuração é perdida. Os portais são dois anéis dimensionais brilhantes cheios de névoa, flutuando a centímetros do chão, perpendicular a ele no ponto escolhido. Um anel é visível apenas de um lado (à sua escolha), que é o lado que funciona como portal. 270 Qualquer criatura ou objeto que adentrar o portal, sairá pelo outro portal, como se ambos estivessem adjacentes um ao outro; atravessar um portal do lado que não é um portal não tem efeito. A névoa que preenche cada portal é opaca e bloqueia a visão através dele. No seu turno, você pode girar os anéis, com uma ação bônus, fazendo o lado ativo ficar em uma direção diferente",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 268,
            Nome = "Praga",
            Escola = "Necromancia",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação",
            Duracao = "7 dias",
            Componente = "Verbal, Somático",
            Descricao = "Seu toque inflige uma doença. Faça um ataque de magia corpo-a-corpo contra uma criatura ao seu alcance. Se atingir, você aflige a criatura com uma doença, de sua escolha, entre qualquer um das descritas abaixo. No final de cada turno do alvo, ele deve realizar um teste de resistência de Constituição. Após obter três falhas nesses testes de resistência, o efeito da doença permanece pela duração e a criatura para de fazer testes de resistência. Após obter três sucessos nesses testes de resistência, a criatura se recupera da doença e a magia termina. Já que essa magia induz uma doença natural no alvo, qualquer efeito que remova uma doença, ou de outra forma, melhore os efeitos de uma doença, se aplica a ela. Ardência Mental. A mente da criatura fica febril. A criatura tem desvantagem em testes de Inteligência, testes de resistência de Inteligência e a criatura age como se estivesse sob efeito da magia confusão durante um combate. Enjoo Cegante. A dor se agarra a mente da criatura e seus olhos ficam branco-leitosos. A criatura tem desvantagem em testes de Sabedoria e testes de resistência de Sabedoria e está cega. Febre do Esgoto. Uma febre voraz se espalha pelo corpo da criatura. A criatura tem desvantagem em testes de Força, testes de resistência de Força e jogadas de ataque que usem Força. Necrose da Carne. A carne da criatura se decompõe. A criatura tem desvantagem em testes de Carisma e vulnerabilidade a todos os danos. Perdição Pegajosa. A criatura começa a sangrar incontrolavelmente. A criatura tem desvantagem em testes de Constituição e testes de resistência de Constituição. Além disso, sempre que a criatura sofrer dano, ela ficará atordoada até o fim do seu próximo turno. Tremedeira. A criatura é acometida por espasmos. A criatura tem desvantagem em testes de Destreza, testes de resistência de Destreza e jogadas de ataque que usem Destreza. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 269,
            Nome = "Praga de Insetos",
            Escola = "Conjuração",
            Alcance = "90 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 10 minutos",
            Componente = "Verbal, Somático, Material (alguns grãos de açúcar, alguns miolos de grão e uma mancha de gordura)",
            Descricao = "Um enxame voraz de gafanhotos preenche uma esfera de 6 metros de raio, centrada no ponto que você escolher, dentro do alcance. A esfera se espalha dobrando esquinas. A esfera permanece pela duração e sua área é de escuridão leve. A área da esfera é de terreno difícil. Quando a área aparece, cada criatura dentro dela deve realizar um teste de resistência de Constituição. Uma criatura sofre 4d10 de dano perfurante se falhar na 271 resistência ou metade desse dano se passar. Uma criatura deve, também, realizar um teste de resistência quando entrar na área da magia pela primeira vez num turno ou terminar seu turno nela. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 6° nível ou superior, o dano aumenta em 1d10 para cada nível do espaço acima do 5°.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 270,
            Nome = "Prestidigitação",
            Escola = "Transmutação",
            Alcance = "3 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Até 1 hora",
            Componente = "Verbal, Somático",
            Descricao = "Essa magia é um truque mágico simples que conjuradores iniciantes usam para praticar. Você cria um dos seguintes efeitos mágicos dentro do alcance:  Você cria, instantaneamente, um efeito sensorial inofensivo, como uma chuva de faíscas, um sopro de vento, notas musicais suaves ou um odor estranho.  Você, instantaneamente, acende ou apaga uma vela, uma tocha ou uma pequena fogueira.  Você, instantaneamente, limpa ou suja um objeto de até 1 metro cúbico.  Você esfria, esquenta ou melhora o sabor de até 1 metro cubico de matéria inorgânica por 1 hora.  Você faz uma cor, uma pequena marca ou um símbolo aparecer em um objeto ou superfície por 1 hora.  Você cria uma bugiganga não-mágica ou uma imagem ilusória que caiba na sua mão e que dura até o final do seu próximo turno. Se você conjurar essa magia diversas vezes, você pode ter até três dos seus efeitos não-instantâneos ativos, ao mesmo tempo, e você pode dissipar um desses efeitos com uma ação. ",
            IdTipoMagia = 1
        },
        new Magia
        {
            IdMagia = 271,
            Nome = "Prisão de Energia",
            Escola = "Evocação",
            Alcance = "30 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "1 hora",
            Componente = "Verbal, Somático, Material (pó de rubi no valor de 1.500 po)",
            Descricao = "Uma prisão em formato cúbico, imóvel e invisível, composta de energia mágica brota do nada, em volta de uma área, à sua escolha, dentro do alcance. A prisão pode ser uma cela ou uma caixa sólida, à sua escolha. Uma prisão em formato de cela pode ter até 6 metros quadrados e é feita de barras com 1,5 centímetro de diâmetro espaçadas a 1,5 centímetro umas das outras. Uma prisão em formato de caixa pode ter até 3 metros quadrados, criando uma barreira sólida que impede qualquer matéria de atravessa-la e bloqueia qualquer magia conjurada de entrar ou sair da área. Quando você conjura a magia, qualquer criatura que estiver completamente dentro da área da prisão ficará presa. As criaturas que estiverem apenas parcialmente na área, ou as grandes demais para caber dentro da área, são empurradas do centro da área, até estarem completamente fora dela. Uma criatura dentro da prisão não pode sair dela por meios não-mágicos. Se a criatura tentar usar teletransporte ou viagem entre planos para abandonar a prisão, ela deve, primeiro, realizar um teste de resistência de Carisma. Se obtiver sucesso, a criatura pode usar a magia e sair da prisão. Se falhar, a criatura não pode sair da prisão e desperdiça o uso da magia ou efeito. A prisão também se estende ao Plano Etéreo, bloqueando viagem etérea. Essa magia não pode ser dissipada por dissipar magia.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 272,
            Nome = "Proibição",
            Escola = "Abjuração (ritual)",
            Alcance = "Toque",
            TempodeConjuracao = "10 minutos",
            Duracao = "1 dia",
            Componente = "Verbal, Somático, Material (uma borrifada de água benta, incensos raros e pó de rubi valendo, no mínimo, 1.000 po)",
            Descricao = "Você cria uma defesa contra viagem mágica que protege até 12.000 metros quadrados de solo até 9 metros de altura do solo. Pela duração, criaturas não conseguem se teletransportar para dentro da área ou usar portais, como os criados pela magia portal, para entrar na área. A magia protege a área contra viagem planar e, portanto, impede criaturas de acessarem a área por meio do Plano Astra, Plano Etéreo, Faéria, Umbra ou pela magia viagem planar. Além disso, a magia causa dano a certos tipos de criatura, à sua escolha, quando a conjurar. Escolha um ou mais dentre os seguintes: celestiais, corruptores, elementais, fadas ou mortos-vivos. Quando uma criatura escolhida entrar na área da magia pela primeira vez em um turno ou começa seu turno nela, a criatura sofre 5d6 de dano radiante ou necrótico (à sua escolha, quando você conjura a magia). Quando você conjura essa magia, você pode definir uma senha. Uma criatura que falar a senha quando entrar na área não sofrerá dano dessa magia. A área da magia não pode sobrepor a área de outra magia proibição. Se você conjurar proibição a cada dia por 30 dias no mesmo local, a magia durará até ser dissipada, e os componentes materiais serão consumidos apenas na última conjuração. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 273,
            Nome = "Projeção Astral",
            Escola = "Necromancia",
            Alcance = "3 metros",
            TempodeConjuracao = "1 hora",
            Duracao = "Especial",
            Componente = "Verbal, Somático, Material (para cada criatura que você afetar com essa magia, você deve fornecer um jacinto valendo, no mínimo, 1.000 po e uma barra de prata com ornamentos esculpidos valendo, no mínimo, 100 po, todos consumidos pela magia)",
            Descricao = "Você e até oito criaturas voluntárias dentro do alcance, projetam seus corpos astrais para o Plano Astral (a magia falha e a conjuração é perdida se você já estiver no plano). O corpo material que você deixa para trás ficará inconsciente e em estado de animação suspensa; ele não precisa de comida ou ar e não envelhece. Seu corpo astral assemelhasse à sua forma mortal em praticamente tudo, copiando suas estatísticas de jogo e posses. A principal diferença é a adição de um cordão prateado que se estende de trás da sua omoplata e traça um caminho atrás de você, sumindo após 30 centímetros. Esse cordão é a sua corrente com o seu corpo material. Enquanto sua corrente permanecer intacta, você pode encontrar seu caminho de volta pra casa. Se o cordão for cortado – algo que só pode acontecer se um efeito dizer 272 especificamente que faz isso – sua alma e corpo estão separados, matando você instantaneamente. Sua forma astral pode viajar livremente dentro do Plano Astral e pode passar através de portais que levam a qualquer outro plano. Se você entrar em um novo portal ou retornar para o plano que você estava quando conjurou a magia, seu corpo e posses são transportados ao longo do cordão de prata, permitindo que você reentre no seu corpo ao entrar no novo plano. Sua forma astral é uma encarnação separada. Qualquer dano ou outros efeitos que se aplicarem a ela, não terão efeito no seu corpo físico, nem persistem quando você voltar. A magia termina para você e seus companheiros quando você usar sua ação para dissipa-la. Quando a magia termina, as criaturas afetadas voltam para seus corpos físicos e acordam. A magia também pode terminar prematuramente para você ou um dos seus companheiros. Uma magia dissipar magia, bem sucedida, usada contra um corpo astral ou físico termina a magia para a criatura. Se o corpo original de uma criatura ou sua forma astral caírem a 0 pontos de vida, a magia termina para essa criatura. Se a magia terminar e o cordão prateado estiver intacto, o cordão puxa a forma astral da criatura de volta para seu corpo, terminando seu estado de animação suspensa. Se você retornar para o seu corpo prematuramente, seus companheiros permanecem nas suas formas astrais e devem encontrar seus próprios meios de voltar para seus corpos, geralmente caindo a 0 pontos de vida. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 274,
            Nome = "Projetar Imagem",
            Escola = "Ilusão",
            Alcance = "750 quilômetros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 dia",
            Componente = "Verbal, Somático, Material (uma pequena réplica sua feita com materiais valendo, no mínimo, 5 po)",
            Descricao = "Você cria uma cópia ilusória de si mesmo, que permanece pela duração. A cópia pode aparecer em qualquer lugar, dentro do alcance, que você já tenha visto antes, independentemente da intervenção de obstáculos. A ilusão se parece e fala como você, mas é intangível. Se a ilusão sofrer qualquer dano, ela desaparece e a magia acaba. Você pode ver através dos olhos e ouvir através dos ouvidos da cópia como se você estivesse no lugar dela. Em cada um dos seus turnos, com uma ação bônus, você pode trocar o uso dos sentidos dela pelo seu ou voltar novamente. Enquanto você está usando os sentidos dela, você fica cego e surdo ao que está a sua volta. Interação física com a imagem revelará ela como sendo uma ilusão, já que as coisas podem atravessa-la. Uma criatura que usar sua ação para examinar a imagem, pode determinar que ela é uma ilusão sendo bem sucedida num teste de Inteligência (Investigação) contra a CD da magia para desacredita-la. Se a criatura discernir a ilusão como ela é, a criatura poderá ver através da imagem e qualquer barulho que ela fizer soará oco para a criatura. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 275,
            Nome = "Proteção Contra a Morte",
            Escola = "Abjuração",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação",
            Duracao = "8 horas",
            Componente = "Verbal, Somático",
            Descricao = "Você toca uma criatura e concede a ela uma certa proteção contra a morte. A primeira vez que o alvo cair a 0 pontos de vida, como resultado de ter sofrido dano, o alvo, ao invés disso, cai a 1 ponto de vida e a magia termina. Se a magia ainda estiver funcionando quando o alvo for afetado por um efeito que poderia mata-lo instantaneamente sem causar dano, o efeito, ao invés disso, não funciona no alvo e a magia termina. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 276,
            Nome = "Proteção contra Energia",
            Escola = "Abjuração",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 hora",
            Componente = "Verbal, Somático",
            Descricao = "Pela duração, a criatura voluntária que você tocar terá resistência a um tipo de dano de sua escolha: ácido, elétrico, fogo, frio ou trovejante.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 277,
            Nome = "Proteção contra Lâminas",
            Escola = "Abjuração",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 ação",
            Duracao = "1 rodada",
            Componente = "Verbal, Somático",
            Descricao = "Você estende suas mãos e desenha um símbolo de proteção no ar. Até o final do seu próximo turno, você terá resistência contra dano de concussão, cortante e perfurante causado por ataques com armas.",
            IdTipoMagia = 1
        },
        new Magia
        {
            IdMagia = 278,
            Nome = "Proteção contra o Bem e Mal",
            Escola = "Abjuração",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 10 minutos",
            Componente = "Verbal, Somático, Material (água benta ou pó de prata e ferro, consumidos pela magia)",
            Descricao = "Até a magia acabar, uma criatura voluntária que você tocar estará protegida contra certos tipos de criaturas: aberrações, celestiais, corruptores, elementais, fadas e mortos-vivos. A proteção garante diversos benefícios. As criaturas desse tipo tem desvantagem nas jogadas de ataque contra o alvo. O alvo não pode ser enfeitiçado, amedrontado ou possuído por elas. Se o alvo já estiver enfeitiçado, amedrontado ou possuído por uma dessas criaturas, o alvo terá vantagem em qualquer novo teste de resistência contra o efeito relevante.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 279,
            Nome = "Proteção contra Veneno",
            Escola = "Abjuração",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação",
            Duracao = "1 hora",
            Componente = "Verbal, Somático",
            Descricao = "Você toca uma criatura. Se ela estiver envenenada, você neutraliza o veneno. Se mais de um veneno estiver afligindo o alvo, você neutraliza um veneno, que você saiba estar presente, ou neutraliza um aleatório. 273 Pela duração, o alvo terá vantagem em testes de resistência para não envenenado e terá resistência a dano de veneno. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 280,
            Nome = "Proteger Fortaleza",
            Escola = "Abjuração",
            Alcance = "Toque",
            TempodeConjuracao = "10 minutos",
            Duracao = "24 horas",
            Componente = "Verbal, Somático, Material (incenso aceso, uma porção de enxofre e óleo, uma corda amarrada, uma porção de sangue de tribulo brutal e um pequeno bastão de prata valendo, no mínimo, 10 po)",
            Descricao = "Você cria uma defesa que protege até 225 metros quadrados de espaço (uma área de um quadrado de 15 metros ou cem quadrados de 1,5 metro ou vinte e cinco quadrados de 3 metros). A área protegida pode ter até 6 metros de altura, no formado que você desejar. Você pode proteger diversos armazéns de uma fortaleza dividindo a área entre eles, contanto que você possa andar em cada área contígua enquanto estiver conjurando a magia. Quando você conjura essa magia, você pode especificar indivíduos que não serão afetados por qualquer dos efeitos que você escolher. Você também pode especificar uma senha que, ao ser falada em voz alta, deixa o orador imune aos efeitos. Proteger fortaleza cria os seguintes efeitos dentro da área protegida. Corredores. Névoa preenche todos os corredores protegidos, tornando-os área de escuridão densa. Além disso, cada interseção ou passagem ramificada oferecendo uma escolha de direção, há 50 por cento de chance de uma criatura diferente de você acredite que está indo na direção oposta à que escolheu. Portas. Todas as portas na área protegida estão trancadas magicamente, como se estivessem seladas pela magia tranca arcana. Além disso, você pode cobrir até dez portas com uma ilusão (equivalente a função de objeto ilusório da magia ilusão menor) para fazê-las parecer seções simples da parede. Escadas. Teias preenchem todas as escadas na área protegida do topo ao solo, como a magia teia. Esses fios voltam a crescer em 10 minutos se forem queimados ou partidos enquanto proteger fortaleza durar. Outros Efeitos de Magia. Você pode colocar, à sua escolha, um dos seguintes efeitos mágicos dentro da área protegida de uma fortaleza.  Colocar globos de luz em quatro corredores. Você pode designar uma programação simples que as luzes repetem enquanto proteger fortaleza durar.  Colocar boca encantada em duas localizações.  Colocar névoa fétida em duas localizações. Os vapores aparecem nos locais que você designar; eles retornam dentro de 10 minutos, se forem dispersados por um vento, enquanto proteger fortaleza durar.  Colocar uma lufada de vento constante em um corredor ou aposento.  Colocar uma sugestão em uma localização. Você seleciona uma área de um quadrado de 1,5 metro e, qualquer criatura que entrar ou passar através dessa área recebe a sugestão mentalmente. A área protegida inteira irradia magia. Uma dissipar magia conjurada em uma área especifica, se for bem sucedida, remove apenas aquele efeito. Você pode criar uma estrutura, permanentemente, afetada por proteger fortaleza ao conjurar essa magia nela a cada dia por um ano.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 281,
            Nome = "Purificar Alimentos",
            Escola = "Transmutação (ritual)",
            Alcance = "3 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático",
            Descricao = "Toda comida e bebida não-mágica dentro de uma esfera de 1,5 metro de raio centrada num ponto, à sua escolha, dentro do alcance é purificada e se livrada de venenos ou doenças. ",
            IdTipoMagia = 2 
        },
        new Magia
        {
            IdMagia = 282,
            Nome = "Queda Suave",
            Escola = "Transmutação",
            Alcance = "18 metros",
            TempodeConjuracao = "1 reação, que você realiza quando você ou uma criatura a até 18 metros cair",
            Duracao = "1 minuto",
            Componente = "Verbal, Material",
            Descricao = "Escolha até cinco criaturas caindo, dentro do alcance. A taxa de descendência de uma criatura caindo é reduzida para 18 metros por rodada, até o fim da magia. Se a criatura aterrissar antes da magia acabar, ela não sofre nenhum dano de queda, pode aterrissar em pé e a magia termina para essa criatura.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 283,
            Nome = "Raio Adoecente",
            Escola = "Necromancia",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático",
            Descricao = "Um raio adoecente de energia esverdeada chicoteia na direção de uma criatura dentro do alcance. Faça um ataque à distância com magia contra o alvo. Se atingir, o alvo sofrerá 2d8 de dano de veneno e deve realizar um teste de resistência de Constituição. Se falhar na resistência, ele também ficará envenenado até o final do seu próximo turno. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 2° nível ou superior, o dano da magia aumenta em 1d8 para cada nível do espaço acima do 1°. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 284,
            Nome = "Raio Ardente",
            Escola = "Evocação",
            Alcance = "36 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático",
            Descricao = "Você cria três raios de fogo e os arremessa em alvos dentro do alcance. Você pode arremessa-los em um alvo ou em vários. Realize um ataque à distância com magia para cada raio. Se atingir, o alvo sofrerá 2d6 de dano de fogo. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 3° nível ou superior, você cria um raio adicional para cada nível do espaço acima do 2°.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 285,
            Nome = "Raio de Bruxa",
            Escola = "Evocação",
            Alcance = "9 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático, Material (um galho de uma árvore que tenha sido atingida por um relâmpago)",
            Descricao = "Um raio crepitante de energia azul é arremessado em uma criatura dentro do alcance, formando um arco elétrico contínuo entre você e o alvo. Faça um ataque à distância com magia contra a criatura. Se atingir, o alvo sofrerá 1d12 de dano elétrico e, em cada um dos seus turnos, pela duração, você pode usar sua ação para causar 1d12 de dano elétrico ao alvo, automaticamente. A magia acaba se você usar sua ação para fazer qualquer outra coisa. A magia também acaba se o alvo estiver fora do alcance da magia ou se você tiver cobertura total para ele. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 2° nível ou superior, o dano inicial aumenta em 1d12 para cada nível do espaço acima do 1°.",
            IdTipoMagia = 2 
        },
        new Magia
        {
            IdMagia = 286,
            Nome = "Raio de Fogo",
            Escola = "Evocação",
            Alcance = "36 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático",
            Descricao = "Você arremessa um cisco de fogo em uma criatura ou objeto dentro do alcance. Faça um ataque à distância com magia contra o alvo. Se atingir, o alvo sofre 1d10 de dano de fogo. Um objeto inflamável atingido por essa magia, incendeia se não estiver sendo vestido ou carregado. O dano dessa magia aumenta em 1d10 quando você alcança o 5° nível (2d10), 11° nível (3d10) e 17° nível (4d10). ",
            IdTipoMagia = 1 
        },
        new Magia
        {
            IdMagia = 287,
            Nome = "Raio de Gelo",
            Escola = "Evocação",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático",
            Descricao = "Um raio frigido de luz azul clara parte em direção de uma criatura, dentro do alcance. Realize um ataque à distância com magia contra o alvo. Se atingir, ele sofre 1d8 de dano de frio e seu deslocamento é reduzido em 3 metros até o começo do seu próximo turno. O dano da magia aumenta em 1d8 quando você alcança o 5° nível (2d8), 11° nível (3d8) e 17° nível (4d8).",
            IdTipoMagia = 1 
        },
        new Magia
        {
            IdMagia = 288,
            Nome = "Raio do Enfraquecimento",
            Escola = "Necromancia",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático",
            Descricao = "Um raio negro de energia enervante parte do seu dedo em direção de uma criatura, dentro do alcance. Faça um ataque à distância com magia contra o alvo. Se atingir, o alvo causará metade do dano com ataques com armas que usem Força, até a magia acabar. No final de cada um dos turnos do alvo, ele pode realizar um teste de resistência de Constituição contra a magia. Se obtiver sucesso, a magia acaba. ",
            IdTipoMagia = 2 
        },
        new Magia
        {
            IdMagia = 289,
            Nome = "Raio Guiador",
            Escola = "Evocação",
            Alcance = "36 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "1 rodada",
            Componente = "Verbal, Somático",
            Descricao = "Um lampejo de luz se lança em direção de uma criatura, à sua escolha, dentro do alcance. Realize um ataque à distância com magia contra o alvo. Se atingir, o alvo sofre 275 4d6 de dano radiante e, a próxima jogada de ataque contra esse alvo, antes do final do seu próximo turno, terá vantagem, graças a penumbra mística cintilando no alvo, até então. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 2° nível ou superior, o dano aumenta em 1d6 para cada nível do espaço acima do 1°.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 290,
            Nome = "Raio Lunar",
            Escola = "Evocação",
            Alcance = "36 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático, Material (várias sementes de qualquer planta lunar e um pedaço de feldspato opalescente)",
            Descricao = "Um raio prateado de luz pálida brilha para baixo em um cilindro com 1,5 metro de raio e 12 metros de altura, centrado num ponto dentro do alcance. Até a magia acabar, penumbra preenche o cilindro. Quando uma criatura entrar na área da magia pela primeira vez em um turno, ou começar seu turno lá, ela é engolfada por chamas fantasmagóricas que causam dores lancinantes e ela deve realizar um teste de resistência de Constituição. Ela sofre 2d10 de dano radiante se falhar na resistência ou metade desse dano se passar. Um metamorfo faz seu teste de resistência com desvantagem. Se ele falhar, ele, também, reverte instantaneamente para sua forma original e não pode assumir uma forma diferente até deixar a luz da magia. Em cada um dos seus turnos após conjurar essa magia, você pode usar uma ação para mover o raio 18 metros em qualquer direção. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 3° nível ou superior, o dano aumenta em 1d10 para cada nível do espaço acima do 2°. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 291,
            Nome = "Raio Solar",
            Escola = "Evocação",
            Alcance = "Pessoal (linha de 18 metros)",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático, Material (uma lente de aumento)",
            Descricao = "Um raio de luz brilhante surge da sua mão em uma linha de 18 metros de comprimento por 1,5 metro de largura. Cada criatura na linha deve realizar um teste de resistência de Constituição. Se falhar na resistência, uma criatura sofrerá 6d8 de dano radiante e ficará cega até seu próximo turno. Se passar na resistência, ela sofrerá metade desse dano e não ficará cega pela magia. Mortosvivos e limos tem desvantagem nos seus testes de resistência. Você pode criar uma linha de radiação com sua ação em qualquer turno, até a magia acabar. Pela duração, uma fagulha de radiação luminosa brilha na sua mão. Ela emite luz plena num raio de 9 metros e penumbra por 9 metros adicionais. Essa luz é luz do sol.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 292,
            Nome = "Rajada de Veneno",
            Escola = "Conjuração",
            Alcance = "3 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático",
            Descricao = "Você ergue sua mão em direção de uma criatura que você possa ver, dentro do alcance e projeta um sopro de gás tóxico da sua palma. A criatura deve ser bem sucedida num teste de resistência de Constituição ou sofrerá 1d12 de dano de veneno. O dano dessa magia aumenta em 1d12 quando você alcança o 5° nível (2d12), 11° nível (3d12) e 17° nível (4d12). ",
            IdTipoMagia = 1
        },
        new Magia
        {
            IdMagia = 293,
            Nome = "Rajada Mística",
            Escola = "Evocação",
            Alcance = "36 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático",
            Descricao = "Um feixe de energia crepitante vai em direção a uma criatura dentro do alcance. Realize uma jogada de ataque à distância com magia contra o alvo. Se atingir, o alvo sofre 1d10 de dano de energia. A magia cria mais de um feixe quando você alcança níveis elevados: dois feixes no 5° nível, três feixes no 11° nível e quatro feixes no 17° nível. Você pode direcionar os feixes para o mesmo alvo ou para alvos diferentes. Realize jogadas de ataque separadas para cada feixe. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 294,
            Nome = "Rajada Prismática",
            Escola = "Evocação",
            Alcance = "Pessoal (cone de 18 metros)",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático",
            Descricao = "Oito raios de luz multicoloridos lampejam da sua mão. Cada raio é uma cor diferente e tem poderes e propósitos diferentes. Cada criatura em um cone de 18 metros deve realizar um teste de resistência de Destreza. Para cada alvo, role um d8 para determinar qual cor de raio afetou ele. 1. Vermelho. O alvo sofre 10d6 de dano de fogo se falhar na resistência ou metade desse dano se obtiver sucesso. 2. Laranja. O alvo sofre 10d6 de dano de ácido se falhar na resistência ou metade desse dano se obtiver sucesso. 3. Amarelo. O alvo sofre 10d6 de dano elétrico se falhar na resistência ou metade desse dano se obtiver sucesso. 4. Verde. O alvo sofre 10d6 de dano de veneno se falhar na resistência ou metade desse dano se obtiver sucesso. 5. Azul. O alvo sofre 10d6 de dano de frio se falhar na resistência ou metade desse dano se obtiver sucesso. 6. Anil. Se falhar na resistência, o alvo ficará impedido. Ele deve então, fazer um teste de resistência de Constituição ao final de cada um dos turnos dele. Se obtiver sucesso três vezes, a magia termina. Se falhar na resistência três vezes, ela se torna pedra é afetada pela condição petrificado. Os sucessos e falhas não precisam ser consecutivos; anote ambos os resultados até o alvo acumular três de mesmo tipo. 7. Violeta. Se falhar na resistência, o alvo ficará cego. Ele deve realizar um teste de resistência de Sabedoria no início do seu próximo turno. Um sucesso na resistência acaba com a cegueira. Se falhar na resistência, a criatura é transportada para outro plano de existência, escolhido pelo Mestre, e não estará mais cego. (Tipicamente, uma criatura que esteja em um plano que não seja o seu plano natal é banida para lá, enquanto que outras criaturas geralmente são enviadas para os Planos Astral ou Etéreo.) 8. Especial. O alvo é atingido por dois raios. Role mais duas vezes e jogue novamente qualquer 8.",
            IdTipoMagia = 2 
        },
        new Magia
        {
            IdMagia = 295,
            Nome = "Recipiente Arcano",
            Escola = "Necromancia",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 minuto",
            Duracao = "Até ser dissipada",
            Componente = "Verbal, Somático, Material (uma gema, cristal, relicário ou algum outro tipo de recipiente ornamental valendo, no mínimo, 500 po)",
            Descricao = "Seu corpo entra em um estado catatônico, enquanto sua alma o abandona e entra num recipiente que você usa como componente material da magia. Enquanto sua alma permanecer no recipiente, você estará ciente do seu entorno como se você estivesse no espaço do recipiente. Você não pode se mover ou usar reações. A única ação que você pode realizar é projetar sua alma a até 30 metros do recipiente, tanto para retornar para o seu corpo (terminando a magia) ou para tentar possuir um corpo humanoide. Você pode tentar possuir qualquer humanoide a até 30 metros de você que você possa ver (criaturas protegidas pelas magias proteção contra o bem e mal ou círculo mágico não podem ser possuídas). O alvo deve realizar um teste de resistência de Carisma. Se falhar, sua alma se move para o corpo do alvo e a alma do alvo fica aprisionada no recipiente. Se obtiver sucesso, o alvo resiste aos seus esforços em possuí-lo e você não poderá tentar possuí-lo novamente por 24 horas. Uma vez que tenha possuído o corpo de uma criatura, você a controla. Suas estatísticas de jogo são substituídas pelas estatísticas da criatura, no entanto, você mantem sua tendência e seus valores de Inteligência, Sabedoria e Carisma. Você mantem os benefícios das suas características de classe. Se o alvo tiver quaisquer níveis de classe, você não pode usar quaisquer das características de classe dele. Nesse período, a alma da criatura possuída pode perceber do recipiente usando os sentidos dela, mas, no mais, não pode se mover ou realizar quaisquer ações. Enquanto estiver possuindo um corpo, você pode usar sua ação para retornar do corpo do hospedeiro para o recipiente se ele estiver a até 30 metros de você, devolvendo a alma da criatura hospedeira para o corpo dela. Se o corpo do hospedeiro morrer enquanto você estiver dentro dele, a criatura morre e você deve realizar um teste de resistência de Carisma contra a sua CD de conjuração. Se obtiver sucesso, você retorna ao recipiente se ele estiver a até 30 metros de você. Caso contrário, você morre. Se o recipiente for destruído ou a magia acabar, sua alma, imediatamente, retorna para o seu corpo. Se seu corpo estiver a mais de 30 metros de você ou se seu corpo estiver morto quando você tentar retornar para ele, você morre. Se a alma de outra criatura estiver no recipiente quando ele for destruído, a alma da criatura volta para o corpo dela se o corpo estiver vivo e a até 30 metros dela. Caso contrário, a criatura morre. Quando a magia acabar, o recipiente é destruído. ",
            IdTipoMagia = 2 
        },
        new Magia
        {
            IdMagia = 296,
            Nome = "Recuo Acelerado",
            Escola = "Transmutação",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 ação bônus",
            Duracao = "Concentração, até 10 minutos",
            Componente = "Verbal, Somático",
            Descricao = "Essa magia permite que você se mova a um ritmo incrível. Quando você conjura essa magia e, a partir de então, com uma ação bônus em cada um dos seus turnos, até a magia acabar, você pode realizar a ação de Disparada. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 297,
            Nome = "Reencarnação",
            Escola = "Transmutação",
            Alcance = "Toque",
            TempodeConjuracao = "1 hora",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático, Material (óleos e unguentos raros valendo, no mínimo, 1.000 po, consumidos pela magia)",
            Descricao = "Você toca um humanoide morto ou um pedaço de um humanoide morto. Considerando que a criatura não esteja morta a mais de 10 dias, a magia forma um novo corpo adulto para ele e então, chama a alma para entrar no corpo. Se a alam do alvo não estiver livre ou deseje fazêlo, a magia falha. A magia forma um novo corpo para que a criatura habite, o que, provavelmente, fará com que a raça da criatura mude. O Mestre rola um d100 e consulta a tabela seguinte para determinar qual forma a criatura terá quando voltar a vida, ou o Mestre pode escolher uma forma. d100 Raça 01–04 Draconato 05–13 Anão, colina 14–21 Anão, montanha 22–25 Elfo, negro 26–34 Elfo, alto 35–42 Elfo, floresta 43–46 Gnomo, floresta 47–52 Gnomo, rochas 53–56 Meio-elfo 57–60 Meio-orc 61–68 Halfling, pés leves 69–76 Halfling, robusto 77–96 Humano 97–00 Tiefling A criatura reencarnada lembra-se da sua vida e experiências anteriores. Ela mantem as capacidades que a sua forma original tinha, exceto por trocar sua raça original pela nova e mudar suas características raciais adequadamente. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 298,
            Nome = "Reflexos",
            Escola = "Ilusão",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 ação",
            Duracao = "1 minuto",
            Componente = "Verbal, Somático",
            Descricao = "Três duplicatas ilusórias de você aparecem no seu espaço. Até a magia acabar, as duplicatas se movem com você e copiam as suas ações, trocando de posição, tornando impossível rastrear qual imagem é real. Você pode usar sua ação para dissipar as duplicatas ilusórias. Cada vez que uma criatura mirar você com um ataque enquanto a magia durar, role um d20 para determinar se o ataque, em vez de você, mira uma das suas duplicatas. Se você tiver três duplicatas, você deve rolar um 6 ou maior para mudar o alvo do ataque para uma duplicata. Com duas duplicatas, você deve rolar um 8 ou maior. Com uma duplicata, você deve rolar um 11 ou maior. A CA de uma duplicata é igual a 10 + seu modificador de Destreza. Se um ataque atingir uma duplicata, ela é destruída. Uma duplicata só pode ser destruída por um ataque que a atinja. Ela ignora todos os outros danos e 278 efeitos. A magia acaba quando todas as três duplicatas forem destruídas. Uma criatura não pode ser afetada por essa magia se não puder enxergar, se ela contar com outros sentidos além da visão, como percepção às cegas, ou se ela puder perceber ilusões como falsas, como com visão verdadeira.",
            IdTipoMagia = 2 
        },
        new Magia
        {
            IdMagia = 299,
            Nome = "Regeneração",
            Escola = "Transmutação",
            Alcance = "Toque",
            TempodeConjuracao = "1 minuto",
            Duracao = "1 hora",
            Componente = "Verbal, Somático, Material (uma conta de oração e água benta)",
            Descricao = "Você toca uma criatura e estimula sua habilidade de cura natural. O alvo recupera 4d8 + 15 pontos de vida. Pela duração da magia o alvo recupera 1 ponto de vida no início de cada turno dela (10 pontos de vida por minuto). Os membro decepados do corpo do alvo (dedos, pernas, rabos e assim por diante), se tiver algum, são restaurados após 2 minutos. Se você tiver a parte decepada e segurala contra o topo, a magia, instantaneamente, faz com que o membro se grude ao toco.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 300,
            Nome = "Relâmpago",
            Escola = "Evocação",
            Alcance = "Pessoal (linha de 30 metros)",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático, Material (um pouco de pelo e uma haste de âmbar, cristal ou vidro)",
            Descricao = "Um relâmpago forma uma linha de 30 metros de comprimento e 1,5 metro de largura que é disparado por você em uma direção, à sua escolha. Cada criatura na linha deve realizar um teste de resistência de Destreza. Uma criatura sofre 8d6 de dano elétrico se falhar na resistência ou metade desse dano se obtiver sucesso. O relâmpago incendeia objetos inflamáveis na área que não estejam sendo vestidos ou carregados. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 4° nível ou superior, o dano aumenta em 1d6 para cada nível do espaço acima do 3°. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 301,
            Nome = "Remover Maldição",
            Escola = "Abjuração",
            Alcance = "Toque",
            TempodeConjuracao = "Verbal, Somatório",
            Duracao = "Instantânea",
            Componente = "Verbal, Somatório",
            Descricao = "Ao seu toque, todas as maldições afetando uma criatura ou objeto terminam. Se o objeto for um item mágico amaldiçoado, sua maldição persiste, mas a magia rompe a sintonia do portador com o objeto, então permitindo que ele o remova ou descarte.",
            IdTipoMagia = 2 
        },
        new Magia
        {
            IdMagia = 302,
            Nome = "Repouso Tranquilo",
            Escola = "Necromancia (ritual)",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação",
            Duracao = "10 dias",
            Componente = "Verbal, Somático, Material ",
            Descricao = "Você toca um corpo ou outros restos mortais. Pela duração, o alvo estará protegido de decomposição e não pode se tornar um morto-vivo. A magia também estende, efetivamente, o limite de tempo para que o alvo seja trazido de volta a vida, já que os dias passados sob a influência dessa magia não contam no tempo limite de tais magias, como reviver os mortos. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 303,
            Nome = "Repreensão Infernal",
            Escola = "Evocação",
            Alcance = "18 metros",
            TempodeConjuracao = ": 1 reação, que você faz em resposta ao sofre dano de uma criatura a até 18 metros de você e que você possa ver",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático",
            Descricao = "Você aponta seu dedo e a criatura que causou dano a você é, momentaneamente, envolta por chamas infernais. A criatura deve realizar um teste de resistência de Destreza. Ela sofre 2d10 de dano de fogo se falhar na resistência ou metade desse dano se obtiver sucesso. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 2° nível ou superior, o dano aumenta em 1d10 para cada nível do espaço acima do 1°.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 304,
            Nome = "Resistência",
            Escola = "Abjuração",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático, Material (um manto em miniatura)",
            Descricao = "Você toca uma criatura voluntária. Uma vez, antes da magia acabar, o alvo pode rolar um d4 e adicionar o valor jogado a um teste de resistência de sua escolha. Ele pode rolar o dado antes ou depois de realizar o teste de resistência. Então, a magia termina.",
            IdTipoMagia = 1
        },
        new Magia
        {
            IdMagia = 305,
            Nome = "Respirar na Água",
            Escola = "Transmutação (ritual)",
            Alcance = "9 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "24 horas",
            Componente = "Verbal, Somático, Material (um pedaço de cana ou palha)",
            Descricao = "Essa magia concede a até dez criaturas voluntária que você possa ver, dentro do alcance, a habilidade de respirar embaixo d’água até a magia acabar. As criaturas afetadas também mantem sua forma normal de respiração. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 306,
            Nome = "Ressurreição",
            Escola = "Necromancia",
            Alcance = "Toque",
            TempodeConjuracao = "1 hora",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático, Material (um diamante valendo, no mínimo, 1.000po, consumido pela magia)",
            Descricao = "Você toca uma criatura morta que não esteja assim a mais de um século, que não tenha morrido por velhice e que não seja um morto-vivo. Se a alma da criatura estiver disposta e livre, o alvo volta a vida com todos os seus pontos de vida. Essa magia neutraliza quaisquer venenos e cura doenças normais que afetavam a criatura no momento da morte. Essa magia, no entanto, não remove doenças mágicas, maldições ou efeitos similares; se eles não tiverem sido removidos antes da conjuração da magia, eles voltam a afetar a criatura quando ela volta a viver. Essa magia fecha todos os ferimentos mortais e restaura partes do corpo perdidas. 279 Voltar dos mortos é um calvário. O alvo sofre –4 de penalidade em todas as suas jogadas de ataque, testes de resistência e testes de habilidade. A cada vez que o alvo terminar um descanso longo, as penalidades são reduzidas em 1, até desaparecerem. Conjurar essa magia para trazer de volta a vida uma criatura que tenha morrido a um ano ou mais tempo é extremamente desgastante para você. Até você terminar um descanso longo, você não pode conjurar magias novamente e terá desvantagem em todas as jogadas de ataque, testes de habilidade e testes de resistência.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 307,
            Nome = "Ressurreição Verdadeira",
            Escola = "Necromancia",
            Alcance = "Toque",
            TempodeConjuracao = "1 hora",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático, Material (um borrifo de água benta e diamantes valendo, no mínimo, 25.000 po, consumidos pela magia)",
            Descricao = "Você toca uma criatura morta que não esteja assim a mais de 200 anos e que tenha morrido por qualquer motivo, exceto velhice. Se a alma da criatura estiver disposta e livre, o alvo volta a vida com todos os seus pontos de vida. Essa magia fecha todos os ferimentos, neutraliza quaisquer venenos, cura todas as doenças e suspende quaisquer maldições que afligiam a criatura quando ela morreu. A magia recupera órgão e membros danificados ou perdidos. Essa magia pode, até mesmo, prover um novo corpo, se o original não existir mais, nesse caso, você deve falar o nome da criatura. Ela aparece em um espaço desocupado, à sua escolha, a até 3 metros de você",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 308,
            Nome = "Restauração Maior",
            Escola = "Abjuração",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático, Material (pó de diamente valendo, no mínimo, consumido pela magia)",
            Descricao = "Você imbui uma criatura que você toca, com energia positiva para desfazer um efeito debilitante. Você pode reduzir a exaustão do alvo em um nível ou remover um dos seguintes do alvo:  Um efeito que enfeitice ou petrifique o alvo  Uma maldição, incluindo a sintonização do alvo com um item mágico amaldiçoado  Qualquer redução a um dos valores de habilidade do alvo  Um efeito que esteja reduzindo o máximo de pontos de vida do alvo",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 309,
            Nome = "Restauração Menor",
            Escola = "Abjuração",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático",
            Descricao = "Você toca uma criatura e pode, ou acabar com uma doença ou uma condição que a esteja afligindo. A condição pode ser cega, surda, paralisada ou envenenada. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 310,
            Nome = "Reviver os Mortos",
            Escola = "Necromancia",
            Alcance = "Toque",
            TempodeConjuracao = "1 hora",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático, Material (um diamante valendo, no mínimo, 500 po, consumido pela magia)",
            Descricao = "Você traz uma criatura morta que você tocar de volta a vida, considerando que ela não esteja morta a mais de 10 dias. Se a alma da criatura estiver tanto disposta quando livre para juntar-se ao corpo dela, a criatura volta a vida com 1 ponto de vida. Essa magia também neutraliza quaisquer venenos e cura doenças não-mágicas que afetavam a criatura no momento da morte. Essa magia, no entanto, não remove doenças mágicas, maldições ou efeitos similares; se eles não tiverem sido removidos antes da conjuração da magia, eles voltam a afetar a criatura quando ela volta a viver. A magia não pode trazer uma criatura morta-viva de volta à vida. Essa magia fecha todos os ferimentos mortais, mas ela não restaura partes do corpo perdidas. Se a criatura não tiver uma parte do corpo ou órgão fundamental para sua sobrevivência – sua cabeça, por exemplo – a magia falha automaticamente. Voltar dos mortos é um calvário. O alvo sofre –4 de penalidade em todas as suas jogadas de ataque, testes de resistência e testes de habilidade. A cada vez que o alvo terminar um descanso longo, as penalidades são reduzidas em 1, até desaparecerem. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 311,
            Nome = "Revivificar",
            Escola = "Necromancia",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático, Material (um diamante no valor de 300 po, consumido pela magia)",
            Descricao = "Você toca uma criatura que tenha morrido dentro do último minuto. Essa criatura volta a vida com 1 ponto de vida. Essa magia não pode trazer de volta a vida criaturas que tenham morrido de velhice nem pode restaurar quaisquer partes do corpo perdidas. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 312,
            Nome = "Riso Histérico de Tasha",
            Escola = "Encantamento",
            Alcance = "9 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático, Material (pequenas tortas e uma pena que é balançada no ar)",
            Descricao = "Uma criatura, à sua escolha, que você possa ver, dentro do alcance, acha tudo hilariantemente engraçado e cai na gargalhada, se essa magia afeta-la. O alvo deve ser bem sucedido em um teste de resistência de Sabedoria ou cairá no chão, ficando incapacitado e incapaz de se levantar pela duração. Uma criatura com valor de Inteligência 4 ou inferior não é afetada. Ao final de cada um dos turnos dela e, toda vez que sofrer dano, o alvo pode realizar outro teste de resistência de Sabedoria. O alvo terá vantagem no teste de resistência se ele for garantido por ele ter sofrido dano. Se obtiver sucesso, a magia acaba",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 313,
            Nome = "Rogar Maldição",
            Escola = "Necromancia",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático",
            Descricao = "Você toca uma criatura e a criatura deve ser bem sucedida em um teste de resistência de Sabedoria ou será amaldiçoada pela duração da magia. Quando você conjura essa magia, escolha a natureza da maldição dentre as seguintes opções:  Escolha um valor de habilidade. Enquanto amaldiçoado, o alvo tem desvantagem em testes de habilidade e testes de resistência feitos com esse valor de habilidade,  Enquanto amaldiçoado, o alvo tem desvantagem nas jogadas de ataque contra você.  Enquanto amaldiçoado, o alvo deve realizar um teste de resistência de Sabedoria no começo de cada um dos turnos dela. Se ela falhar, ela perderá sua ação aquele turno, não fazendo nada.  Enquanto o alvo estiver amaldiçoado, seus ataques e magias causam 1d8 de dano necrótico extra a ele. Uma magia remover maldição termina esse efeito. Com a permissão do Mestre, você pode escolher um efeito alternativo de maldição, mas ele não deve ser mais poderoso que os descritos acima. O Mestre tem a palavra final sobre o efeito de uma maldição. Em Níveis Superiores. Se você conjurar essa magia usando um espaço de magia de 4° nível, a duração da concentração sobe para 10 minutos. Se você usar um espaço de magia de 5° ou 6° nível, a duração será de 8 horas. Se você usar um espaço de magia de 7° ou 8° nível, a duração será de 24 horas. Se você usar um espaço de magia de 9° nível, a magia dura até ser dissipada. Usar um espaço de magia de 5° nível ou superior faz com que a duração não necessite de concentração. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 314,
            Nome = "Salto",
            Escola = "Transmutação",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação",
            Duracao = "1 minuto",
            Componente = "Verbal, Somático, Material (uma perna de gafanhotos)",
            Descricao = "Você toca uma criatura. A distância de salto da criatura é triplicada até a magia acabar",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 315,
            Nome = "Santuário",
            Escola = "Abjuração",
            Alcance = "9 metros",
            TempodeConjuracao = "1 ação bônus",
            Duracao = "1 minuto",
            Componente = "Verbal, Somático, Material (um pequeno espelho de prata)",
            Descricao = "Você protege uma criatura, dentro do alcance, contra ataques. Até a magia acabar, qualquer criatura que tentar atacar ou usar magias que causem dano contra criatura protegida deve, primeiro, realizar um teste de resistência de Sabedoria. Se falhar na resistência, a criatura deve escolher um novo alvo ou perderá o ataque ou magia. Essa magia não protege a criatura contra efeitos de área, como a explosão de uma bola de fogo. Se a criatura protegida realizar um ataque ou conjurar uma magia que afete uma criatura inimiga, essa magia acaba. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 316,
            Nome = "Santuário Particular de Mordenkainen",
            Escola = "Abjuração",
            Alcance = "36 metros",
            TempodeConjuracao = "10 minutos",
            Duracao = "24 horas",
            Componente = "Verbal, Somático, Material (uma folha de chumbo, um pedaço de vidro opaco, um chumaço de algodão ou pano e pó de crisólita)",
            Descricao = "Você deixa uma área, dentro do alcance, magicamente segura. A área é um cubo que pode ser tão pequen quanto 1,5 metro ou tão grande quanto 30 metros de cada lado. A magia permanece pela duração ou até você usa uma ação para dissipa-l Quando você conjura essa magia, você decide que ti de segurança ela fornecerá, escolhendo qualquer ou tod as propriedades a segu  Sons não podem atravessar a barreira na fronteira d área protegida.  A barreira da área protegida escura e nebulosa impedindo visão (inclusive visão no escuro) através dela  Sensores criados por magia de adivinhação não pod aparecer dentro da área protegida ou atravessa barreira no perímetro  As criaturas na área não podem ser alvo de magias adivinhaç  Nada pode se teletransportar para dentro ou para fo da área protegida.  Viagem planar está bloqueada para dentro da ár protegida. Conjurar essa magia no mesmo lugar, a cada dia,  um ano, torna o efeito permanente Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 5° nível  superior, você pode aumentar o tamanho do cubo em  metros de cada lado para cada nível do espaço acima do 4°. Então, você poderia proteger um cubo de até 60 metro de lado usando um espaço de magia de 5° nível. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 317,
            Nome = "Saraivada de Espinhos",
            Escola = "Conjuração",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 ação bônus",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal",
            Descricao = "Da próxima vez que você atingir uma criatura com um ataque à distância com arma, antes da magia acabar, essa magia cria uma chuva de espinhos que brota da sua arma à distância ou munição. Além do efeito normal do ataque, o alvo do ataque e cada criatura a até 1,5 metro dele, devem realizar um teste de resistência de Destreza. Uma criatura sofre 1d10 de dano perfurante se falhar na resistência ou metade desse dano se obtiver sucesso. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 2° nível ou superior, o dano aumenta em 1d10 para cada nível do espaço acima do 1° (até o máximo de 6d10). ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 318,
            Nome = "Semiplano",
            Escola = "Conjuração",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "1 hora",
            Componente = "Verbal",
            Descricao = "Você cria uma porta umbral em uma superfície sólida e lisa que você possa ver, dentro do alcance. A porta é grande o suficiente para permitir a passagem de criaturas Médias sem dificuldade. Quando aberta, a porta levará a um semiplano que parece uma sala vazia de 9 metros quadrados de dimensão, feita de madeira ou pedra. Quando a magia termina, a porta desaparece e, qualquer criatura ou objeto dentro do semiplano, permanecerá preso lá, a medida que a porta desaparece do outro lado. 281 Cada vez que você conjura essa magia, você pode criar um novo semiplano ou fazer a porta umbral se conectar a um semiplano que você tenha criado em uma conjuração anterior dessa magia. Além disso, se você conhecer a natureza e conteúdo do semiplano criado através da conjuração dessa magia por outra criatura, você pode fazer com que a porta umbral se conecte a esse semiplano.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 319,
            Nome = "Sentido Bestial",
            Escola = "Adivinhação (ritual",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 hora",
            Componente = "Somático",
            Descricao = "Você toca uma besta voluntária. Pela duração da magia, você pode usar sua ação para ver através dos olhos e ouvir através dos ouvidos da besta e continua a fazê-lo até você usar sua ação para retornar aos seus sentidos normais. Enquanto estiver utilizando os sentidos da besta, você ganha os benefícios de qualquer sentido especial possuído pela criatura, no entanto, você estará cego e surdo em relação aos seus próprios sentidos. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 320,
            Nome = "Servo Invisível",
            Escola = "Conjuração (ritual)",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "1 hora",
            Componente = "Verbal, Somático, Material (um pedaço de barbante e um pouco de madeira)",
            Descricao = "Essa magia cria uma força invisível, sem mente e sem forma que realiza tarefas simples, ao seu comando, até a magia acabar. O servo aparece do nada em um espaço desocupado no chão, dentro do alcance. Ele tem CA 10, 1 ponto de vida, Força 2 e não pode atacar. Se ele cair a 0 pontos de vida, a magia acaba. Uma vez em cada um dos seus turnos, com uma ação bônus, você pode comandar, mentalmente, o servo para se mover até 4,5 metros e interagir com um objeto. O servo pode realizar tarefas simples que um serviçal humano faria, como buscar coisas, limpar, consertar, dobrar roupas, acender chamas, servir comida ou derramar vinho. Uma vez que um comando seja dado, o servo realiza a tarefa da melhor forma possível, até completar a tarefa, então esperará o seu próximo comando. Se você comandar o servo a realizar uma tarefa que poderia afasta-lo a mais de 18 metros de você, a magia termina",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 321,
            Nome = "Sexto Sentido",
            Escola = "Adivinhação",
            Alcance = "Toque",
            TempodeConjuracao = "1 minuto",
            Duracao = "8 horas",
            Componente = "Verbal, Somático, Material (uma pena de colibri)",
            Descricao = "Você toca uma criatura voluntária e a abençoa com uma habilidade limitada de ver o futuro iminente. Pela duração, o alvo não pode ser surpreendido e tem vantagem nas jogadas de ataque, testes de habilidade e testes de resistência. Além disso, outras criaturas tem desvantagem nas jogadas de ataque contra o alvo, pela duração. Essa magia termina imediatamente, se você conjura-la novamente antes da duração acabar. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 322,
            Nome = "Silêncio",
            Escola = "Ilusão",
            Alcance = "36 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 10 minutos",
            Componente = "Verbal, Somático",
            Descricao = "Pela duração, nenhum som pode ser criado dentro ou atravessar uma esfera de 6 metros de raio centrada num ponto, à sua escolha, dentro do alcance. Qualquer criatura ou objeto totalmente dentro da esfera é imune a dano trovejante e as criaturas estarão surdas enquanto estiverem completamente dentro dela. Conjurar magias que inclua a componente verbal é impossível ai. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 323,
            Nome = "Símbolo",
            Escola = "Abjuração",
            Alcance = "Toque",
            TempodeConjuracao = "1 minuto",
            Duracao = "Até ser dissipada ou ativada",
            Componente = "Verbal, Somático, Material (mercúrio, fósforo e pó de diamante e opala, com um valor total de, no mínimo, 1.000 po, consumidos pela magia) ",
            Descricao = "Quando você conjura essa magia, você inscreve um glifo nocivo, tanto sobre uma superfície (como uma secção de piso, uma parede ou mesa) quanto dentro de um objeto que possa ser fechado (como um livro, um pergaminho ou um baú de tesouro). Se você escolher uma superfície, o glifo pode cobrir uma área da superfície não superior a 3 metros de diâmetro. Se você escolher um objeto, o objeto deve permanecer no seu local; se ele for movido mais de 3 metros de onde você conjurou essa magia, o glifo será quebrado e a magia termina sem ser ativada. O glifo é quase invisível e requer um teste de Inteligência (Investigação) contra a CD da magia para ser encontrado. Você define o que ativa o glifo quando você conjura a magia. Para glifos inscritos em uma superfície, os gatilhos mais típicos incluem tocar ou ficar sobre o glifo, remover outro objeto cobrindo o glifo, aproximar-se a uma certa distância do glifo ou manipular um objeto onde o glifo esteja inscrito. Para glifos inscritos dentro de objetos, os gatilhos mais comuns incluem abrir o objeto, aproximarse a uma certa distância do objeto ou ver ou ler o glifo. Você pode, posteriormente, aperfeiçoar o gatilho para que a magia se ative apenas sob certas circunstâncias ou de acordo com as características físicas (como altura ou peso), tipo de criatura (por exemplo, a proteção poderia ser definida para afetar aberrações ou drow) ou tendência. Você pode, também, definir condições para criaturas não ativarem o glifo, como aqueles que falarem determinada senha. Quando você inscreve o glifo, escolha uma das opções abaixo para seu efeito. Uma vez ativado, o glifo brilha, preenchendo uma esfera de 18 metros de raio com penumbra por 10 minutos, após esse tempo, a magia termina. Cada criatura na esfera, quando o glifo é ativado, é afetada por seu efeito, assim como uma criatura que entrar na esfera a primeira vez num turno ou termina seu turno nela. Atordoamento. Cada alvo deve realizar um teste de resistência de Sabedoria e ficará atordoada por 1 minuto se falhar na resistência. Desespero. Cada alvo deve realizar um teste de resistência de Carisma. Com uma falha na resistência, o alvo será consumido pelo desespero por 1 minuto. Durante esse período, ele não poderá atacar ou afetar qualquer criatura com habilidades, magias ou outros efeitos mágicos nocivos. 282 Discórdia. Cada alvo deve realizar um teste de resistência de Sabedoria. Com uma falha na resistência, um alvo irá brigar e discutir com outras criaturas por 1 minuto. Durante esse período, ele será incapaz de se comunicar compreensivamente e terá desvantagem nas jogadas de ataque e testes de habilidade. Dor. Cada alvo deve realizar um teste de resistência de Constituição e ficará incapacitada com dores excruciantes por 1 minuto se falhar na resistência. Insanidade. Cada alvo deve realizar um teste de resistência de Inteligência. Com uma falha na resistência, o alvo é levado a loucura por 1 minuto. Uma criatura insana, não pode realizar ações, não entende o que as outras criaturas dizem, não pode ler e fala apenas coisas sem sentido. O Mestre controla seus movimentos, que serão erráticos. Medo. Cada alvo deve realizar um teste de resistência de Sabedoria e ficará amedrontado por 1 minuto se falhar na resistência. Enquanto estiver amedrontado, o alvo largará o que quer que esteja segurando e deve se afastar, pelo menos 9 metros do glifo em cada um dos seus turnos, se for capaz. Morte. Cada alvo deve realizar um teste de resistência de Constituição, sofrendo 10d10 de dano necrótico se falhar na resistência ou metade desse dano se passar na resistência. Sono. Cada alvo deve realizar um teste de resistência de Sabedoria e cairá inconsciente por 10 minutos se falhar na resistência. Uma criatura acorda se sofrer dano ou se alguém usar sua ação para sacudi-la e estapeá-la até ela acordar. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 324,
            Nome = "Similaridade",
            Escola = "Ilusão",
            Alcance = "9 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "8 horas",
            Componente = "Verbal, Somáticp",
            Descricao = "Essa magia permite que você mude a aparência de qualquer quantidade de criaturas que você possa ver, dentro do alcance. Você dá a cada alvo que você escolheu uma nova aparência ilusória. Um alvo involuntário pode realizar um teste de resistência de Carisma, se for bem sucedido, a magia não o afetará. A magia disfarça a aparência física, assim como roupa, armadura, armas e equipamentos. Você pode fazer com que cada criatura pareça 30 centímetros mais baixa ou alta e aparente ser magra, gorda ou entre. Você não pode mudar o tipo do seu corpo, portanto, você deve adotar uma forma que tenha a mesma disposição básica de membros. No mais, a extensão da sua ilusão cabe a você. A magia permanece pela duração, a menos que você usa sua ação para dissipa-la precocemente. As mudanças criadas por essa magia não conseguem se sustentar perante uma inspeção física. Por exemplo, se você usar essa magia para adicionar um chapéu ao seu visual, objetos que passarem pelo chapéu e qualquer um que tocá-lo não sentirá nada ou sentirá sua cabeça e cabelo. Se você usar essa magia para aparentar ser mais magro do que é, a mão de alguém que a erguer para tocar em você, irá esbarrar em você enquanto ainda está, aparentemente, está no ar. Uma criatura pode usar a ação dela para inspecionar um alvo e fazer um teste de Inteligência (Investigação) contra a CD da sua magia. Se for bem sucedido, ele estará ciente de que o alvo está disfarçado. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 325,
            Nome = "Simulacro",
            Escola = "Ilusão",
            Alcance = "Toque",
            TempodeConjuracao = "12 horas",
            Duracao = "Até ser dissipada",
            Componente = "Verbal, Somático, Material (neve ou gelo em quantidade suficiente para fazer uma cópia em tamanho real da criatura duplicada; algum cabelo, recortes de unha ou outro pedaço do corpo da criatura, colocado dentro da neve ou gelo; e pó de rubi no valor de 1.500 po, polvilhado sobre a duplicata e consumido pela magia)",
            Descricao = "Você modela uma duplicata ilusória de uma besta ou humanoide, dentro do alcance, durante todo tempo de conjuração da magia. A duplicada é uma criatura, parcialmente real, formada de gelo ou neve e pode realizar ações e, no mais, ser tratada como uma criatura normal. Ela aparenta ser igual a original, mas tem metade do máximo de pontos de vida da criatura e é formada sem qualquer equipamento. No mais, a ilusão usa todas as estatísticas da criatura que ela copiou. O simulacro é amigável a você e às criaturas que você designar. Ele obedece aos seus comandos verbais, se movendo e agindo de acordo com seus desejos, agindo no seu turno em combate. O simulacro não possui capacidade de aprender ou de se tornar mais poderoso, portanto, ele nunca subirá de nível ou ganhará outras habilidades, nem poderá recuperar espaços de magia gastos. Se o simulacro sofrer dano, você pode repara-lo em um laboratório alquímico, usando ervas e minerais raros no valor de 100 po por ponto de vida recuperado. O simulacro dura até cair a 0 pontos de vida, no momento em que ele volta a ser neve e derrete instantaneamente. Se você conjurar essa magia novamente, qualquer duplicata atualmente ativa, que você criou com essa magia, é instantaneamente destruída. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 326,
            Nome = "Sinal de Esperança",
            Escola = "Abjuração",
            Alcance = "9 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático",
            Descricao = "Essa magia confere esperança e vitalidade. Escolha qualquer quantidade de criaturas dentro do alcance. Pela duração, cada alvo tem vantagem em testes de resistência de Sabedoria e testes de resistência contra a morte e recuperam o máximo de pontos de vida possível em qualquer cura. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 327,
            Nome = "Sonho",
            Escola = "Ilusão",
            Alcance = "Especial",
            TempodeConjuracao = "1 minuto",
            Duracao = "8 horas",
            Componente = "Verbal, Somático, Material (um punhado de areia, um pouco de tinta e uma pena de escrita arrancada de um pássaro adormecido)",
            Descricao = "Essa magia molda os sonhos de uma criatura. Escolha uma criatura que você conheça como alvo dessa magia. O alvo deve estar no mesmo plano de existência que você. Criaturas que não dormem, como elfos, não podem ser contatados por essa magia. Você, ou uma criatura voluntária que você tocar, entram em um estado de transe. Enquanto estiver me transe, o mensageiro está ciente dos seus arredores, mas não pode realizar ações ou se mover. 283 Se o alvo estiver dormindo, o mensageiro aparece no sonho do alvo e pode conversar com o alvo enquanto ele estiver dormindo, até o limite da duração da magia. O mensageiro também pode modificar o meio ambiente do sonho, criando paisagens, objetos e outras imagens. O mensageiro pode sair do transe a qualquer momento, terminando o efeito da magia prematuramente. O alvo se lembra do sonho perfeitamente quando acorda. Se o alvo estiver acordado quando a magia for conjurada, o mensageiro saberá disso e pode, tanto terminar o transe (e a magia) quando esperar o alvo cair no sono, no momento em que o mensageiro aparecerá nos sonhos do alvo. Você pode fazer o mensageiro parecer monstruoso e aterrorizante para o alvo. Se o fizer, o mensageiro pode enviar uma mensagem de não mais que dez palavras, então o alvo deve realizar um teste de resistência de Sabedoria. Se falhar na resistência, ecos da monstruosidade fantasmagórica criarão um pesadelo que permanecerá pela duração do sono do alvo e impede o alvo de ganhar qualquer benefício do descanso. Além disso, quando o alvo acordar, ele sofrerá 3d6 de dano psíquico. Se você tiver uma parte do corpo, mecha de cabelo, recorte de unha ou porção similar do corpo do alvo, o alvo realiza seu teste de resistência com desvantagem. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 328,
            Nome = "Sono",
            Escola = "Encantamento",
            Alcance = "36 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "1 minuto",
            Componente = "Verbal, Somático, Material (um punhado de areia fina, pétalas de rosas ou um grilo)",
            Descricao = "Essa magia põem as criaturas num entorpecimento mágico. Jogue 5d8; o total é a quantidade de pontos de vida de criaturas afetados pela magia. As criaturas numa área de 6 metros de raio, centrada no ponto escolhido, dentro do alcance, são afetadas em ordem ascendente dos pontos de vida atuais delas (ignorando criaturas inconscientes). Começando com as criaturas com menos pontos de vida atuais, cada criatura afetada por essa magia cai inconsciente até a magia acabar, sofrer dano ou alguém usar sua ação para sacudi-la ou esbofeteá-la até acordar. Subtraia os pontos de vida de cada criatura do total antes de seguir para a próxima criatura com menos pontos de vida atuais. Os pontos de vida atuais da criatura devem ser iguais ou menores que o valor restante para que a criatura possa ser afetada. Mortos-vivos e criaturas imunes a serem enfeitiçadas não são afetadas por essa magia. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 2º nível ou superior, jogue 2d8 adicionais para cada nível do espaço acima do 1°",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 329,
            Nome = "Sugestão",
            Escola = "Encantamento",
            Alcance = "9 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 8 horas",
            Componente = "Verbal, Material (uma língua de cobra e, ou um pedaço de favo de mel ou uma gota de azeite doce)",
            Descricao = "Você sugere um curso de atividade (limitado a uma ou duas sentenças) e, magicamente, influencia um criatura que você possa ver, dentro do alcance, e que possa ouvir e compreender você. Criaturas que não podem ser enfeitiçadas são imunes a esse efeito. A sugestão deve ser formulada de modo que o curso de ação soe razoável. Dizer para a criatura se esfaquear, se arremessar em uma lança, tocar fogo em si mesma ou fazer algum outro ato obviamente nocivo anulará o efeito da magia. O alvo deve realizar um teste de resistência de Sabedoria. Se falhar na resistência, ele seguirá o curso de ação que você descreveu, da melhor forma possível. O curso de ação sugerido pode continuar por toda a duração. Se a atividade sugerida puder ser completada em um tempo menor, a magia termina quando o alvo completar o que lhe foi dito para que fizesse. Você pode, também, especificar condições que irão ativar uma atividade especial pela duração. Por exemplo, você poderia sugerir a um cavaleiro que entregasse seu cavalo de guerra ao primeiro mendigo que ele encontrar. Se a condição não for satisfeita antes da magia expirar, a atividade não será concluída. Se você ou um dos seus companheiros causar dano a uma criatura afetada por essa magia, a magia termina.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 330,
            Nome = "Sugestão em Massa",
            Escola = "Encantamento",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "24 horas",
            Componente = "Verbal, Material (uma língua de cobra, ou um pedaço de favo de mel ou uma gota de azeite doce)",
            Descricao = "Você sugere um curso de atividade (limitado a uma ou duas sentenças) e, magicamente, influencia até dozes criaturas, à sua escolha, que você possa ver dentro do alcance e que possam ouvir e compreender você. Criaturas que não podem ser enfeitiçadas são imunes a esse efeito. A sugestão deve ser formulada de modo que o curso de ação soe razoável. Dizer para a criatura se esfaquear, se arremessar em uma lança, tocar fogo em si mesma ou fazer algum outro ato obviamente nocivo anulará o efeito da magia. Cada alvo deve realizar um teste de resistência de Sabedoria. Se falhar na resistência, ele seguirá o curso de ação que você descreveu, da melhor forma possível. O curso de ação sugerido pode continuar por toda a duração. Por exemplo, você poderia sugeria a um grupo de soldados que deem todo o seu dinheiro para o primeiro mendigo que encontrarem. Se a condição não for atingida antes da magia acabar, a atividade não é realizada. Se você ou um dos seus companheiros causar dano a uma criatura afetada por essa magia, a magia termina para aquela criatura. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 7° nível, a duração será de 10 dias. Quando você usar um espaço de magia de 8° nível, a duração será de 30 dias. Quando você usar um espaço de magia de 9° nível, a duração será de 1 ano e 1 dia. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 331,
            Nome = "Sussuros Dissonantes",
            Escola = "Encantamento",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal",
            Descricao = "Você sussurra uma melodia dissonante que apenas uma criatura, à sua escolha, dentro do alcance pode ouvir, causando-lhe uma terrível dor. O alvo deve realizar um teste de resistência de Sabedoria. Se falhar na resistência, ele sofrerá 3d6 de dano psíquico e deve, imediatamente, usar sua reação, se disponível, para se mover para o mais longe possível de você. A criatura não 284 se moverá para um terreno obviamente perigoso, como uma fogueira ou abismo. Se obtiver sucesso na resistência, o alvo sofre metade do dano e não precisa se afastar de você. Uma criatura surda obtém sucesso automaticamente na sua resistência. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 2° nível ou superior, o dano aumenta em 1d6 para cada nível do espaço acima do 1°. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 332,
            Nome = "Taumaturgia",
            Escola = "Transmutação",
            Alcance = "9 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Até 1 minuto",
            Componente = "Verbal",
            Descricao = "Você manifesta pequenas maravilhas, um sinal de poder sobrenatural, dentro do alcance. Você cria um dos seguintes efeitos mágicos dentro do alcance:  Sua voz ressoa com o triplo do volume normal por 1 minuto.  Você provoca tremores inofensivos no solo por 1 minuto.  Você cria, instantaneamente, um som que se origina de um ponto, à sua escolha, dentro do alcance, como o barulho de um trovão, o gralhar de um corvo ou sussurros sinistros.  Você, instantaneamente, faz uma porta ou janela destrancada se abrir ou se fechar.  Você altera a aparência dos seus olhos por 1 minuto. Se você conjurar essa magia diversas vezes, você pode ter até três dos efeitos de 1 minuto ativos por vez, e você pode dissipar um desses efeitos com uma ação. ",
            IdTipoMagia = 1
        },
        new Magia
        {
            IdMagia = 333,
            Nome = "Teia",
            Escola = "Conjuração",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 hora",
            Componente = "Verbal, Somático, Material (um pedaço de teia de aranha)",
            Descricao = "Você conjura uma massa de teias espessas e pegajosas num ponto, à sua escolha, dentro do alcance. As teias preenchem um cubo de 6 metros naquele ponto, pela duração. As teias são terreno difícil e causam escuridão leve na área delas. Se as teias não estiverem sendo suportadas por duas massas sólidas (como duas paredes ou árvores) ou em camadas sobre um chão, parede ou teto, a teia conjurada desaba sobre si mesma e a magia termina no início do seu próximo turno. As teias em camadas sobre uma superfície plana terão 1,5 metro de profundidade. Cada criatura que começar seu turno nas teias ou entrar nelas durante seu turno, deve realizar um teste de resistência de Destreza. Se falhar na resistência, a criatura estará impedida enquanto permanecer nas teias ou até se libertar. Uma criatura impedida pelas teias pode usar sua ação para realizar um teste de Força contra a CD da magia. Se obtiver sucesso, ela não estará mais impedida. As teias são inflamáveis. Qualquer cubo de 1,5 metro de teia exposto ao fogo, é consumida por ele em 1 rodada, causando 2d4 de dano de fogo a qualquer criatura que começar seu turno nas chamas. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 334,
            Nome = "Telecinésia",
            Escola = "Transmutação",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 10 minutos",
            Componente = "Verbal, Somático",
            Descricao = "Você adquire a habilidade de mover ou manipular criaturas ou objetos através do pensamento. Quando você conjura a magia e, com sua ação a cada turno, pela duração, você pode exercer sua vontade sobre uma criatura ou objeto que você possa ver, dentro do alcance, causando os efeitos apropriados abaixo. Você pode afetar o mesmo alvo rodada após rodada, ou escolher um novo a qualquer momento. Se você mudar de alvos, o alvo anterior não será mais afetado pela magia. Criatura. Você pode tentar mover uma criatura Enorme ou menor. Faça um teste de habilidade com sua habilidade de conjuração resistido por um teste Força da criatura. Se você vencer a disputa, você move a criatura até 9 metros em qualquer direção, incluindo para cima, mas não além do alcance da magia. Até o final do seu próximo turno, a criatura estará impedida pelo seu agarrão telecinético. Uma criatura erguida para cima estará suspensa no ar. Em rodadas subsequente, você pode usar sua ação para tentar manter seu agarrão telecinético na criatura repetindo o teste resistido. Objeto. Você pode tentar mover um objeto pesando até 500 quilos. Se o objeto não estiver sendo vestido ou carregado, você o move, automaticamente, até 9 metros em qualquer direção, mas não além do alcance dessa magia. Se o objeto estiver sendo vestido ou carregado por uma criatura, você deve realizar um teste de habilidade com sua habilidade de conjuração resistido por um teste de Força da criatura. Se você for bem sucedido, você arranca o objeto da criatura e o move até 9 metros, em qualquer direção, mas não além do alcance dessa magia. Você pode exercer um controle refinado sobre os objetos com seu agarrão telecinético, como manipular ferramentas simples, abrir uma porta ou um recipiente, guardar ou recuperar um item de um recipiente aberto ou derramar o conteúdo de um frasco. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 335,
            Nome = "Telepatia",
            Escola = "Adivinhação",
            Alcance = "Ilimitado",
            TempodeConjuracao = "1 ação",
            Duracao = "24 horas",
            Componente = "Verbal, Somático, Material (um par de anéis de prata unidos)",
            Descricao = "Você cria uma ligação telepática entre você e uma criatura voluntária com a qual você seja familiarizado. A criatura pode estar em qualquer lugar no mesmo plano de existência que você. A magia termina se você ou o alvo não estiver mais no mesmo plano. Até a magia acabar, você e o alvo podem, instantaneamente, compartilhar palavras, imagens, sons e outras mensagens sensoriais uma com a outra através da ligação e o alvo reconhece que é você a criatura que está se comunicando com ele. A magia permite que uma criatura com valor de Inteligência mínimo de 1 compreenda o sentido das suas palavras e capta o sentido geral de qualquer mensagem sensorial que você enviar. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 336,
            Nome = "Teletransporte",
            Escola = "Conjuração",
            Alcance = "3 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal",
            Descricao = "Essa magia, instantaneamente, transporta você e até oito criaturas voluntárias, à sua escolha, que você possa ver dentro do alcance ou um único objeto que você possa ver no alcance, para um destino que você selecionou. Se você for afetar um objeto, ele deve ser capaz de caber inteiro dentro de um cubo de 3 metros e não pode estar sendo empunhado ou carregado por uma criatura involuntária. O destino que você escolher deve ser conhecido por você e deve ser no mesmo plano de existência que você está. Sua familiaridade com o destino determina se você chegará nele com sucesso. O Mestre rola um d100 e consulta a tabela. Familiaridade Fiasco Área Similar Fora do Alvo No Alvo Círculo permanente – – – 01–100 Objeto associado – – – 01–100 Muito familiar 01–05 06–13 14–24 25–100 Visto casualmente 01–33 34–43 44–53 54–100 Visto uma vez 01–43 44–53 54–73 74–100 Descrição 01–43 44–53 54–73 74–100 Descrição falsa 01–50 51–100 – – Familiaridade. “Círculo permanente” significa um círculo de teletransporte permanente o qual você conhece a sequência de selos. “Objeto associado” significa que você possui um objeto retirado do destino desejado nos últimos seis meses, como um livro da biblioteca do mago, roupa de cama de uma suíte real ou um pedaço de mármore da tumba secreta do lich. “Muito familiar” é um lugar que você já tenha ido muitas vezes, um lugar que você estudou cuidadosamente ou um local que você possa ver enquanto conjura a magia. “Visto casualmente” é algum lugar que você tenha visto mais de uma vez, mas que não seja muito familiar. “Visto uma vez” é um lugar que você só viu uma vez, possivelmente através de magia. “Descrição” é um lugar cuja localização e aparência você conhece através da descrição de outrem, talvez através de um mapa. “Destino falso” é um local que não existe. Talvez você tenha tentado espionar o santuário de um inimigo, mas, ao invés, viu uma ilusão ou você está tentando se teletransportar para um local familiar que não existe mais. No Alvo. Você e seu grupo (ou objeto alvo) aparecem onde você queria. Fora do Alvo. Você e seu grupo (ou objeto alvo) aparecem a uma distância aleatória fora do destino em uma direção aleatória. A distância do alvo é 1d10 x 1d10 por cento da distância que você viajou. Por exemplo, se você tentou viajar 180 quilômetros, mas apareceu fora do alvo e rolou um 5 e um 3 nos dois d10s, então você saiu do alvo 15 por cento ou 27 quilômetros. O Mestre determina a direção de fora do alvo aleatoriamente rolando um d8 e designando 1 como norte, 2 como nordeste, 3 como leste e assim por diante ao redor dos pontos cardeais. Se você seria teletransportado para uma cidade costeira, podendo cair a 27 quilômetros dela, no mar, você poderia ter problemas. Área Similar. Você e seu grupo (ou objeto alvo) aparecem em uma área diferente que, visualmente ou tematicamente, é similar a área alvo. Se você estava indo para o laboratório na sua casa, por exemplo, você pode parar em outro laboratório de mago ou em uma loja de suprimentos alquímicos que terá muitas ferramentas iguais às encontradas no seu laboratório. Geralmente, você aparecerá no local similar mais próximo, mas já que a magia não tem limite de alcance, você pode, concebivelmente, viajar para qualquer lugar no plano. Fiasco. A mágica imprevisível da magia resulta em uma jornada difícil. Cada criatura teletransportada (ou o objeto alvo) sofrem 3d10 de dano de energia e o Mestre rola novamente a tabela para ver onde você foi parar (fiascos múltiplos podem ocorrer, causando dano a cada vez). ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 337,
            Nome = "Teletransporte por Árvores",
            Escola = "Conjuração",
            Alcance = "3 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "1 rodada",
            Componente = "Verbal, Somático",
            Descricao = "Essa magia cria uma ligação mágica entre uma planta inanimada Grande ou maior, dentro do alcance, e outra planta a qualquer distância, no mesmo plano de existência. Você deve ter visto ou tocado a planta de destino, pelo menos uma vez antes. Pela duração, qualquer criatura pode entrar na planta alvo e sair da planta destino usando 1,5 metro de movimento. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 338,
            Nome = "Tempestade da Vingança",
            Escola = "Conjuração",
            Alcance = "Visão",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático",
            Descricao = "Uma agitada nuvem tempestuosa se forma, centrada num ponto que você possa ver e se espalha num raio de 108 metros. Relâmpagos riscam a área, trovões ressoam e ventos fortes silvam. Cada criatura embaixo da nuvem (a não mais de 1.500 metros abaixo da nuvem) quando ela aparece deve realizar um teste de resistência de Constituição. Com uma falha na resistência, uma criatura sofre 2d6 de dano trovejante e ficará surda por 5 minutos. A cada rodada que você mantiver a concentração nessa magia, a tempestade produzirá efeitos adicionais no seu turno. Rodada 2. Chuva ácida cai da nuvem. Cada criatura e objeto abaixo dela nuvem sofre 1d6 de dano ácido. Rodada 3. Você convoca seis relâmpagos da nuvem para atingir seis criaturas ou objetos, à sua escolha, abaixo da nuvem. Uma mesma criatura ou objeto não pode ser atingido por mais de um raio. Uma criatura atingida deve realizar um teste de resistência de Destreza. A criatura sofrerá 10d6 de dano elétrico se falhar na resistência ou metade desse dano se passar. Rodada 4. Granizo chove da nuvem. Cada criatura abaixo da nuvem sofre 2d6 de dano de concussão. Rodada 5–10. Ventos e chuva gelados atacam a área abaixo da nuvem. A área se torna terreno difícil e de escuridão densa. Cada criatura sofre 1d6 de dano de frio. Ataques com armas à distância na área são impossíveis. O vento e chuva contam como uma distração grave com os propósitos de manter a concentração em magias. Finalmente, ventos fortes (entre 30 e 75 quilômetros por hora) automaticamente dispersam nevoa, neblina e fenômenos similares na área, independentemente de serem mundanos ou mágicos. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 339,
            Nome = "Tempestade de Fogo",
            Escola = "Evocação",
            Alcance = "45 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somáticp",
            Descricao = "Uma tempestade feita de camadas de chamas crepitantes aparece num local, à sua escolha, dentro do alcance. A área da tempestade consiste de até dez cubos de 3 metros, que você pode organizar como desejar. Cada cubo deve ter, pelo menos, uma face adjacente a face de outro cubo. Cada criatura na área deve realizar um teste de resistência de Destreza. Ela sofre 7d10 de dano de fogo se falhar na resistência, ou metade desse dano se obtiver sucesso. O fogo causa dano aos objetos na área e incendeia objetos inflamáveis que não estejam sendo vestidos ou carregados. Se desejar, a vida vegetal na área pode não ser afetada por essa magia. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 340,
            Nome = "Tempestade de Gelo",
            Escola = "Evocação",
            Alcance = "90 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático, Material (um pouco de poeira e algumas gotas de água)",
            Descricao = "Uma rajada de pedras de gelo batem no chão em um cilindro de 6 metros de raio por 12 metros de altura, centrado num ponto dentro do alcance. Cada criatura no cilindro deve realizar um teste de resistência de Destreza. Uma criatura sofre 2d8 de dano de concussão e 4d6 de dano de frio se falhar na resistência ou metade desse dano se obtiver sucesso. O granizo torna a área da tempestade em terreno difícil até o final do seu próximo turno. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 5° nível ou superior, o dano de concussão aumenta em 1d8 para cada nível do espaço acima do 4°. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 341,
            Nome = "Tentáculos Negros de Evard",
            Escola = "Conjuração",
            Alcance = "27 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático, Material (um pedaço de tentáculo de um polvo gigante ou lula gigante)",
            Descricao = "Tentáculos negros retorcidos preenchem um quadrado de 6 metros no chão, que você possa ver dentro do alcance. Pela duração, esses tentáculos transformam o solo na área em terreno difícil. Quando uma criatura adentrar a área afetada pela primeira vez em um turno ou começar o turno dela lá, a criatura deve ser bem sucedida num teste de resistência de Destreza ou sofrerá 3d6 de dano de concussão e estará impedida pelos tentáculos até o fim da magia. Uma criatura que começar seu turno na área e já estiver impedida pelos tentáculos sofre 3d6 de dano de concussão. Uma criatura impedida pelos tentáculos pode usar sua ação para realizar um teste de Força ou Destreza (à escolha dela) contra a CD da sua magia. Se ela obtiver sucesso, ela se libertará. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 342,
            Nome = "Terremoto",
            Escola = "Evocação",
            Alcance = "150 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático, Material (um pouco de poeira, uma pedra e um pedaço de barro)",
            Descricao = "Você cria um distúrbio sísmico num ponto no solo, que você possa ver dentro do alcance. Pela duração, um tremor intenso rompe o solo em um círculo com 30 metros de raio centrado no ponto e sacode criaturas e estruturas em contato com o chão na área. O solo na área torna-se terreno difícil. Cada criatura no solo que estiver se concentrando, deve realizar um teste de resistência de Constituição. Se falha na resistência, a concentração da criatura é interrompida. Quando você conjura essa magia, e ao final de cada turno que você gastar se concentrando nela, cada criatura no solo na área deve realizar um teste de resistência de Destreza. Se falhar na resistência, a criatura será derrubada no chão. Essa magia pode ter efeitos adicionais a depender do terreno na área, como determinado pelo Mestre. Fissuras. Fissuras se abrem por toda área da magia, no começo do seu próximo turno, após você conjurar a magia. Um total de 1d6 dessas fissuras se abrem em locais escolhidos pelo Mestre. Cada um tem 1d10 x 3 metros de profundidade, 3 metros de largura e se estende de uma extremidade até o lado oposto da área da magia. Uma criatura que estiver em um ponto onde uma fissura se abriu deve ser bem sucedido num teste de resistência de Destreza ou cairá dentro dela. Uma criatura que obtenha sucesso na resistência se move com a margem da fissura, à medida que ela se abre. Uma fissura que se abra abaixo de uma estrutura faz com que ela, automaticamente, desmorone (veja abaixo). Estruturas. O tremor causa 50 de dano de concussão a qualquer estrutura em contato com o solo na área, quando você conjurar a magia e, no início de cada turno até a magia terminar. Se a estrutura cair a 0 pontos de vida, ela desmorona e, potencialmente, fere criaturas próximas. Uma criatura a uma distância inferior a metade da altura da estrutura deve realizar um teste de resistência de Destreza. Se falhar na resistência, a criatura sofrerá 5d6 de dano de concussão, cairá no chão e estará soterrada nos escombros, precisando de um teste de Força (Atletismo) com CD 20, usando uma ação, para escapar. O Mestre pode ajustar a CD para cima ou para baixo, dependendo da natureza dos escombros. Se obtiver sucesso na resistência, a criatura sofre metade do dano e não estará caída ou soterrada. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 343,
            Nome = "Terreno Alucinógeno",
            Escola = "Ilusão",
            Alcance = "90 metros",
            TempodeConjuracao = "10 minutos",
            Duracao = "24 horas",
            Componente = "Verbal, Somático, Material (uma pedra, um galho e um pouco de planta verde) ",
            Descricao = "Você faz com que um terreno natural num cubo de 45 metros dentro do alcance, pareça, soe e cheire com outro tipo de terreno natural. Portanto, campos abertos ou uma estrada podem ser modificados para se assemelharem a um pântano, colina, fenda ou algum outro tipo de terreno difícil ou intransponível. Uma lagoa pode ser modificada para se parecer com um prado, um precipício com um declive suave ou um barranco pedregoso com uma estrada larga e lisa. Estruturas manufaturadas, equipamentos e criaturas dentro da área não tem suas aparências modificadas. 288 As características táteis do terreno são inalteradas, portanto, as criaturas que adentrarem na área estão susceptíveis de ver através da ilusão. Se a diferença não for obvia ao toque, uma criatura que examine a ilusão cuidadosamente, pode realizar um teste de Inteligência (Investigação) contra a CD da magia para desacredita-la. Uma criatura que discernir a ilusão do que ela é, a enxerga como uma imagem vaga sobrepondo o terreno. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 344,
            Nome = "Toque Arrepiante",
            Escola = "Necromancia",
            Alcance = "36 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "1 rodada",
            Componente = "Verbal, Somático",
            Descricao = "Você cria uma mão esquelética fantasmagórica no espaço de uma criatura, dentro do alcance. Realize um ataque à distância com magia contra a criatura para afeta-la com o frio sepulcral. Se atingir, a criatura sofre 1d8 de dano necrótico e não poderá recuperar pontos de vida até o início do seu próximo turno. Até lá, a mão ficará presa ao alvo. Se você atingir um alvo morto-vivo, ele terá desvantagem nas jogadas de ataque contra você até o final do seu próximo turno. O dano dessa magia aumenta em 1d8 quando você alcança o 5° nível (2d8), 11° nível (3d8) e 17° nível (4d8). ",
            IdTipoMagia = 1
        },
        new Magia
        {
            IdMagia = 345,
            Nome = "Toque Chocante",
            Escola = "Evocação",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático",
            Descricao = "Eletricidade surge da sua mão para transmitir um choque em uma criatura que você tentar tocar. Faça um ataque corpo-a-corpo com magia contra o alvo. Você tem vantagem na jogada de ataque se o alvo estiver vestindo qualquer armadura de metal. Se atingir, o alvo sofre 1d8 de dano elétrico e não pode usar reações até o início do próximo turno dele. O dano da magia aumenta em 1d8 quando você alcança o 5° nível (2d8), 11° nível (3d8) e 17° nível (4d8). ",
            IdTipoMagia = 1
        },
        new Magia
        {
            IdMagia = 346,
            Nome = "Toque Vampírico",
            Escola = "Necromancia",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático",
            Descricao = "O toque da sua mão coberta de sombras pode drenar a força vital dos outros para curar seus ferimentos. Realize um ataque corpo-a-corpo com magia contra uma criatura ao seu alcance. Se atingir, o alvo sofre 3d6 de dano necrótico e você recupera pontos de vida igual à metade do dano necrótico causado. Até a magia acabar, você pode realizar o ataque novamente, no seu turno, com uma ação. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 4° nível ou superior, o dano aumenta em 1d6 para cada nível do espaço acima do 3°",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 347,
            Nome = "Tranca Arcana",
            Escola = "Abjuração",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação",
            Duracao = "Até ser dissipada",
            Componente = "Verbal, Somático, Material (pó de ouro valendo, no mínimo, 25 po, consumido pela magia)",
            Descricao = "Você toca uma porta, janela, portão, baú ou outra entrada fechada e ela ficará trancada pela duração. Você e as criaturas que você designar, quando você conjurar essa magia, podem abrir o objeto normalmente. Você também pode definir uma senha que, quando falada a 1,5 metro do objeto, suprime a magia por 1 minuto. De outra forma, ele é intransponível até ser quebrado ou a magia seja dissipada ou suprimida. Conjurar arrombar no objeto suprime a tranca arcana por 10 minutos. Enquanto estiver sob efeito dessa magia, o objeto é mais difícil de quebrar ou de forçar para abrir; a CD para quebra-lo ou de arromba-lo aumenta em 10. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 348,
            Nome = "Truque de Corda",
            Escola = "Transmutação",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação",
            Duracao = "1 hora",
            Componente = "Verbal, Somático, Material (pó de extrato de milho e um laço de pergaminho trançado)",
            Descricao = "Você toca um pedaço de corda que tenha até 18 metros de comprimento. Uma ponta da corda então, se ergue no ar até toda a corda estar erguida e perpendicular ao solo. Na ponta de cima da corda, uma entrada invisível se abre para um espaço extradimensional que permanece até a magia acabar. O espaço extradimensional pode ser alcançado escalando a corda até o topo. O espaço pode abrigar até oito criaturas Médias ou menores. A corda pode ser puxada para dentro do buraco, fazendo-a desaparecer para os observadores do lado de fora do espaço. Ataques e magias não podem ultrapassar a entrada, entrando ou saindo do espaço extradimensional, mas quem está dentro pode ver o lado de fora, como se estivesse olhando por uma janela de 0,9 metro por 1,5 metro, centrada na corda. Tudo que estiver dentro do espaço extradimensional cai quando a magia acabar.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 349,
            Nome = "Tsunami",
            Escola = "Conjuração",
            Alcance = "Visão",
            TempodeConjuracao = "1 minuto",
            Duracao = "Concentração, até 6 rodadas",
            Componente = "Verbal, Somático",
            Descricao = "Uma muralha de água aparece do nada num ponto, à sua escolha, dentro do alcance. Você pode fazer a muralha ter até 90 metros de comprimento, 90 metro de altura e 15 metros de espessura. A muralha permanece pela duração. Quando a muralha aparece, cada criatura dentro da área deve realizar um teste de resistência de Força. Se falhar na resistência, uma criatura sofrerá 6d10 de dano de concussão ou metade desse dano se passar na resistência. No início de cada um dos seus turnos, após a muralha aparecer, ela, junto com qualquer criatura nela, se afasta 15 metros de você. Qualquer criatura Enorme ou menor dentro da muralha ou no espaço que a muralha entrar quando ela se mover, deve ser bem sucedida num teste de resistência de Força ou sofrerá 5d6 de dano de concussão. Uma criatura pode sofrer esse dano apenas uma vez por rodada. No final do turno, a altura da muralha é reduzida em 15 metros e o dano que as criaturas sofrem da magia 289 nas rodadas subsequentes é reduzido em 1d10. Quando a muralha chegar a 0 metro de altura, a magia acaba. Uma criatura pega pela muralha, pode se mover nadando. Devido à força da onda, no entanto, a criatura deve realizar um teste de Força (Atletismo) contra a CD da magia para conseguir se mover. Se ela falhar no teste, não conseguirá se mover. Uma criatura que se mova para fora da área, cairá no chão. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 350,
            Nome = "Velocidade",
            Escola = "Transmutação",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático, Verbal  (uma raspa de raiz de alcaçuz)",
            Descricao = "Escolha uma criatura voluntária que você possa ver, dentro do alcance. Até a magia acabar, o deslocamento do alvo é dobrado, ele ganha +2 de bônus na CA, ele tem vantagem em testes de resistência de Destreza e ganha uma ação adicional em cada um dos turnos dele. A ação pode ser usada apenas para realizar as ações de Ataque (um ataque com arma, apenas), Disparada, Desengajar, Esconder ou Usar um Objeto. Quando a magia acabar, o alvo não poderá se mover ou realizar ações até depois do seu próximo turno, à medida que uma onda de letargia toma conta dele. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 351,
            Nome = "Ver o Invisível",
            Escola = "Adivinhação",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 ação",
            Duracao = "1 hora",
            Componente = "Verbal, Somático, Material  (um pouco de talco e um pó de prata polvilhado) ",
            Descricao = "Pela duração, você vê criaturas e objetos invisíveis como se eles fossem visíveis e você pode ver no Plano Etéreo. Criaturas e objetos etéreos parecem espectrais e translúcidos. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 352,
            Nome = "Viagem Planar",
            Escola = "Conjuração",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal, Somático, Material  (uma haste metálica bifurcada valendo, no mínimo, 250 po, sintonizada com um plano de existência em particular)",
            Descricao = "Você e até oito criaturas voluntárias, que estejam de mãos dadas em um círculo, são transportadas para um plano de existência diferente. Você pode especificar o destino alvo em termos gerais, como a Cidade de Bronze do Plano Elemental do Fogo ou o palácio de Dispater na segunda camada dos Nove Infernos e você aparece no ou perto do destino. Se você estiver tentando chegar a Cidade de Bronze, por exemplo, você poderia chegar na Estrada de Aço dela, em frente aos Portões de Cinzas ou contemplando a cidade do outro lado do Mar de Fogo, à critério do Mestre. Alternativamente, se você conhecer a sequência de selos do círculo de teletransporte em outro plano de existência, essa magia pode leva-lo para esse círculo. Se o círculo de teletransporte for muito pequeno para comportar as criaturas que você está transportando, elas aparecerão no espaço desocupado mais próximo do círculo. Você pode usar essa magia para banir uma criatura involuntária para outro plano. Escolha uma criatura ao seu alcance e realize um ataque corpo-a-corpo com magia contra ela. Se atingir, a criatura deve realizar um teste de resistência de Carisma. Se a criatura falhar na resistência, ela é transportada para um local aleatório no plano de existência que você especificou. Uma criatura, uma vez transportada, deve encontrar seu próprio meio de retornar para seu plano de existência atual. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 353,
            Nome = "Vidência",
            Escola = "Adivinhação",
            Alcance = "Pessoal",
            TempodeConjuracao = "10 minutos",
            Duracao = "Concentração, até 10 minutos",
            Componente = "Verbal, Somático, Material   (um foco valendo, no mínimo, 1.000 po, como uma bola de cristal, espelho de prata ou fonte cheia de água benta) ",
            Descricao = "Você pode ver e ouvir uma criatura em particular, à sua escolha, que esteja no mesmo plano de existência que você. O alvo deve realizar um teste de resistência de Sabedoria, que é modificador de acordo com o quão bem você conhece o alvo e o tipo de conexão física que você tem com ele. Se um alvo souber que você está conjurando essa magia, ele pode falhar no teste de resistência voluntariamente, se ele quiser ser observado. Com um sucesso na resistência, o alvo não é afetado e você não pode usar essa magia contra ele novamente por 24 horas. Se falhar na resistência, a magia cria um sensor invisível a até 3 metros do alvo. Você pode ver e ouvir através do sensor, como se você estivesse onde ele está. O sensor se move com o alvo, permanecendo a 3 metros dele pela duração. Uma criatura que puder ver objetos invisíveis verá o sensor como um globo luminoso do tamanho de um punho. Ao invés de focar em uma criatura, você pode escolher um local que você já tenha visto antes como alvo dessa magia. Quando fizer isso, o sensor aparece no local e não se move. Conhecimento Modificador de Resistência Segunda mão (você ouviu falar do alvo) +5 Primeira mão (você foi apresentado ao alvo) +0 Familiar (você conhece bem o alvo) –5 Conexão Modificador de Resistência Descrição ou foto –2 Pertences ou roupas –4 Parte do corpo, mexa de cabelo, recorte de unha ou simular ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 354,
            Nome = "Vínculo Protetor",
            Escola = "Abjuração",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação",
            Duracao = "1 hora",
            Componente = "Verbal, Somático, Material (um par de anéis de platina valendo, no mínimo, 50 po cada, que você e o alvo devem usar pela duração)",
            Descricao = "Essa magia protege uma criatura voluntária que você tocar e cria uma conexão mística entre você e o alvo até a magia acabar. Enquanto o alvo estiver a até 18 metros de você, ele recebe +1 de bônus na CA, nos testes de resistência e terá resistência a todos os danos. No 290 entanto, a cada vez que ele sofrer dano, você sofrerá a mesma quantidade de dano. A magia acaba se você cair a 0 pontos de vida ou se você e o alvo ficarem separados a mais de 18 metros. Ela também termina se a magia for conjurada novamente em quaisquer das criaturas conectadas. Você também pode dissipar a magia com uma ação. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 355,
            Nome = "Vinha Esmagadora",
            Escola = "Conjuração",
            Alcance = "9 metros",
            TempodeConjuracao = "1 ação bônus",
            Duracao = "Concentração, até 1 minuto",
            Componente = "Verbal, Somático",
            Descricao = "Você conjura uma vinha que brota do chão em um espaço desocupado, à sua escolha, que você possa ver dentro do alcance. Quando você conjura essa magia, você pode direcionar a vinha para que ela enlace uma criatura a até 9 metros dela que você possa ver. Essa criatura deve ser bem sucedida num teste de resistência de Destreza ou será arrastada 6 metros na direção da vinha. Até o fim da magia, você pode direcionar a vinha para enlaçar a mesma criatura ou uma diferente, com uma ação bônus, em cada um dos seus turnos. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 356,
            Nome = "Visão da Verdade",
            Escola = "Adivinhação",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação",
            Duracao = "1 hora",
            Componente = "Verbal, Somático, Material  (unguento para os olhos no valor de 25 po; ele é feito de pó de cogumelo, açafrão e gordura; e é consumido pela magia) ",
            Descricao = "Essa magia concede a uma criatura voluntária tocada a habilidade de ver as coisas como elas realmente são. Pela duração, a criatura terá visão verdadeira, percebendo portas secretas escondidas por magia e podendo ver no Plano Etéreo, tudo num alcance de até 36 metros. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 357,
            Nome = "Visão no Escuro",
            Escola = "Transmutação",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação",
            Duracao = "8 horas",
            Componente = "Verbal, Somático, Material   (ou um pedaço de cenoura seca ou uma ágata) ",
            Descricao = "Você toca uma criatura voluntária para conceder a ela a habilidade de ver nas trevas. Pela duração, a criatura terá visão no escuro com alcance de 18 metros",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 358,
            Nome = "Vitalidade Falsa",
            Escola = "Necromancia",
            Alcance = "Pessoal",
            TempodeConjuracao = "1 ação",
            Duracao = "1 hora",
            Componente = "Verbal, Somático, Material   (uma pequena quantidade de álcool ou bebidas destiladas)",
            Descricao = "Reforçando-se com uma vitalidade necromântica ilusória, você ganha 1d4 + 4 pontos de vida temporários pela duração. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 2° nível ou superior, você ganha 5 pontos de vida temporários adicionais para cada nível do espaço de magia acima do 1°.",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 359,
            Nome = "Voo",
            Escola = "Transmutação",
            Alcance = "Toque",
            TempodeConjuracao = "1 ação",
            Duracao = "Concentração, até 10 minutos",
            Componente = "Verbal, Somático, Material (uma pena da asa de qualquer pássaro)",
            Descricao = "Você toca uma criatura voluntária. O alvo ganha deslocamento de voo de 18 metros, pela duração. Quando a magia acabar, o alvo cai se ainda estiver no ar, a não ser que ele possa impedir a queda. Em Níveis Superiores. Quando você conjurar essa magia usando um espaço de magia de 4° nível ou superior, você pode afetar uma criatura adicional para cada nível do espaço acima do 3°. ",
            IdTipoMagia = 2
        },
        new Magia
        {
            IdMagia = 360,
            Nome = "Zombaria Viciosa",
            Escola = "Encantamento",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "Instantânea",
            Componente = "Verbal",
            Descricao = "Você libera uma série de insultos atados com encantamentos sutis numa criatura que você possa ver, dentro do alcance. Se o alvo puder ouvir você (apesar de não precisar compreende-lo), ele deve ser bem sucedido num teste de resistência de Sabedoria ou sofrerá 1d4 de dano psíquico e terá desvantagem na próxima jogada de ataque que ele fizer antes do final do próximo turno dele. O dano dessa magia aumenta em 1d4 quando você alcança o 5° nível (2d4), 11° nível (3d4) e 17° nível (4d4). ",
            IdTipoMagia = 1
        },
        new Magia
        {
            IdMagia = 361,
            Nome = "Zona da Verdade",
            Escola = "Encantamento",
            Alcance = "18 metros",
            TempodeConjuracao = "1 ação",
            Duracao = "10 minutos",
            Componente = "Verbal, Somático",
            Descricao = "Você cria uma zona mágica protegida contra enganação, numa esfera com 4,5 metros de raio, centrada num ponto, à sua escolha, dentro do alcance. Até a magia acabar, uma criatura que entrar na área da magia pela primeira vez num turno ou começar seu turno nela, deve realizar um teste de resistência de Carisma. Se falhar na resistência, a criatura não poderá mentir deliberadamente enquanto estiver no raio. Você saberá cada criatura que passou ou falhou nesse teste de resistência. Uma criatura afetada está ciente da magia e pode, portanto, evitar responder perguntas as quais ela normalmente responderia com uma mentira. Tais criaturas podem ser evasivas em suas respostas, contanto que permaneçam dentro dos limites da verdade. ",
            IdTipoMagia = 2
        }
    );
        modelBuilder.Entity<Raca>().HasData(
        new Raca
        {
            IdRaca = 1,
            Nome = "Anão",
            Tamanho = "1.20m ~ 1.50m",
            Idade = 350,
            Deslocamento = 7.5,
            BonusConstituicao = 2,
            BonusForca = null,
            BonusDestreza = null,
            BonusInteligencia = null,
            BonusSabedoria = null,
            BonusCarisma = null,
            IdIdioma = 1
            // ProfArma = {8, 25, 9, 28}
        },
        new Raca
        {
            IdRaca = 2,
            Nome = "Elfo",
            Tamanho = "1.50m ~ 1.80m",
            Idade = 750,
            Deslocamento = 9.0,
            BonusConstituicao = 2,
            BonusForca = null,
            BonusDestreza = null,
            BonusInteligencia = null,
            BonusSabedoria = null,
            BonusCarisma = null,
            IdIdioma = 3
        },
        new Raca
        {
            IdRaca = 3,
            Nome = "Halfling",
            Tamanho = "0.90m",
            Idade = 150,
            Deslocamento = 7.5,
            BonusConstituicao = 2,
            BonusForca = null,
            BonusDestreza = null,
            BonusInteligencia = null,
            BonusSabedoria = null,
            BonusCarisma = null,
            IdIdioma = 7
        },
        new Raca
        {
            IdRaca = 4,
            Nome = "Humano",
            Tamanho = "1.5m ~ 1.8m",
            Idade = 100,
            Deslocamento = 9.0,
            BonusConstituicao = 1,
            BonusForca = null,
            BonusDestreza = null,
            BonusInteligencia = null,
            BonusSabedoria = null,
            BonusCarisma = null,
            IdIdioma = 2
        },
        new Raca
        {
            IdRaca = 5,
            Nome = "Draconato",
            Tamanho = "1.8m",
            Idade = 80,
            Deslocamento = 9.0,
            BonusConstituicao = 2,
            BonusForca = null,
            BonusDestreza = null,
            BonusInteligencia = null,
            BonusSabedoria = null,
            BonusCarisma = 1,
            IdIdioma = 12
        },
        new Raca
        {
            IdRaca = 6,
            Nome = "Gnomo",
            Tamanho = "0.90m ~ 1.20m",
            Idade = 500,
            Deslocamento = 7.5,
            BonusConstituicao = null,
            BonusForca = null,
            BonusDestreza = null,
            BonusInteligencia = null,
            BonusSabedoria = null,
            BonusCarisma = null,
            IdIdioma = 5
        },
        new Raca
        {
            IdRaca = 7,
            Nome = "Meio-Elfo",
            Tamanho = "1.50m ~ 1.80m",
            Idade = 180,
            Deslocamento = 1,
            BonusConstituicao = null,
            BonusForca = null,
            BonusDestreza = null,
            BonusInteligencia = null,
            BonusSabedoria = null,
            BonusCarisma = 2,
            IdIdioma = 3
        },
        new Raca
        {
            IdRaca = 8,
            Nome = "Meio-Orc",
            Tamanho = "1.80m ~ 2.10m",
            Idade = 75,
            Deslocamento = 9,
            BonusConstituicao = 1,
            BonusForca = 2,
            BonusDestreza = null,
            BonusInteligencia = null,
            BonusSabedoria = null,
            BonusCarisma = null,
            IdIdioma = 8
        },
        new Raca
        {
            IdRaca = 9,
            Nome = "Tiefling",
            Tamanho = "1.50m ~ 1.80m",
            Idade = 120,
            Deslocamento = 9,
            BonusConstituicao = null,
            BonusForca = null,
            BonusDestreza = null,
            BonusInteligencia = 1,
            BonusSabedoria = null,
            BonusCarisma = 2,
            IdIdioma = 13
        }
    );

        modelBuilder.Entity<SubRaca>().HasData(
        new SubRaca
        {
            IdSubRaca = 1,
            Nome = "Anão da Colina",
            BonusConstituicao = null,
            BonusForca = null,
            BonusDestreza = null,
            BonusInteligencia = null,
            BonusSabedoria = 1,
            BonusCarisma = null,
            IdRaca = 1
        },
        new SubRaca
        {
            IdSubRaca = 2,
            Nome = "Anão da Montanha",
            BonusConstituicao = null,
            BonusForca = 2,
            BonusDestreza = null,
            BonusInteligencia = null,
            BonusSabedoria = null,
            BonusCarisma = null,
            IdRaca = 1,
            // ProfArmadura = {1, 2, 3, 4, 5, 6, 7, 8}
        },
        new SubRaca
        {
            IdSubRaca = 3,
            Nome = "Alto Elfo",
            BonusConstituicao = null,
            BonusForca = null,
            BonusDestreza = null,
            BonusInteligencia = 1,
            BonusSabedoria = null,
            BonusCarisma = null,
            IdRaca = 2,
            // ProfArma = {18, 20, 11, 32}
        },
        new SubRaca
        {
            IdSubRaca = 4,
            Nome = "Elfo da Floresta",
            BonusConstituicao = null,
            BonusForca = null,
            BonusDestreza = null,
            BonusInteligencia = null,
            BonusSabedoria = 1,
            BonusCarisma = null,
            IdRaca = 2,
            // ProfArma = {18, 20, 11, 32}
        },
        new SubRaca
        {
            IdSubRaca = 5,
            Nome = "Elfo Negro (Drow)",
            BonusConstituicao = null,
            BonusForca = null,
            BonusDestreza = null,
            BonusInteligencia = null,
            BonusSabedoria = null,
            BonusCarisma = null,
            IdRaca = 2,
            // ProfArma = {30, 18, 33}
        },
        new SubRaca
        {
            IdSubRaca = 6,
            Nome = "Pés Leves",
            BonusConstituicao = null,
            BonusForca = null,
            BonusDestreza = null,
            BonusInteligencia = null,
            BonusSabedoria = null,
            BonusCarisma = 1,
            IdRaca = 3
        },
        new SubRaca
        {
            IdSubRaca = 7,
            Nome = "Robusto",
            BonusConstituicao = 1,
            BonusForca = null,
            BonusDestreza = null,
            BonusInteligencia = null,
            BonusSabedoria = null,
            BonusCarisma = null,
            IdRaca = 3
        },
        new SubRaca
        {
            IdSubRaca = 8,
            Nome = "Gnomo da Floresta",
            BonusConstituicao = null,
            BonusForca = null,
            BonusDestreza = 1,
            BonusInteligencia = null,
            BonusSabedoria = null,
            BonusCarisma = null,
            IdRaca = 6
        },
        new SubRaca
        {
            IdSubRaca = 9,
            Nome = "Gnomo das Rochas",
            BonusConstituicao = 1,
            BonusForca = null,
            BonusDestreza = null,
            BonusInteligencia = null,
            BonusSabedoria = null,
            BonusCarisma = null,
            IdRaca = 6
        }
        );

        modelBuilder.Entity<VeiculoTerrestre>().HasData(
        new VeiculoTerrestre
        {
            IdVeiculoTerrestre = 1,
            Nome = "Burro/mula",
            Preco = "8 Peças de Ouro",
            Deslocamento = "12 metros",
            CapacidadedeCarga = "210 Kg"
        },
        new VeiculoTerrestre
        {
            IdVeiculoTerrestre = 2,
            Nome = "Camelo",
            Preco = "50 Peças de Ouro",
            Deslocamento = "15 metros",
            CapacidadedeCarga = "240 Kg"
        },
        new VeiculoTerrestre
        {
            IdVeiculoTerrestre = 3,
            Nome = "Cavalo de guerra",
            Preco = "400 Peças de Ouro",
            Deslocamento = "18 metros",
            CapacidadedeCarga = "270 Kg"
        },
        new VeiculoTerrestre
        {
            IdVeiculoTerrestre = 4,
            Nome = "Cavalo de montaria",
            Preco = "75 Peças de Ouro",
            Deslocamento = "18 metros",
            CapacidadedeCarga = "220 Kg"
        },
        new VeiculoTerrestre
        {
            IdVeiculoTerrestre = 5,
            Nome = "Cavalo Pesado",
            Preco = "50 Peças de Ouro",
            Deslocamento = "12 metros",
            CapacidadedeCarga = "270 Kg"
        },
        new VeiculoTerrestre
        {
            IdVeiculoTerrestre = 6,
            Nome = "Elefante",
            Preco = "200 Peças de Ouro",
            Deslocamento = "12 metros",
            CapacidadedeCarga = "660 Kg"
        },
        new VeiculoTerrestre
        {
            IdVeiculoTerrestre = 7,
            Nome = "Mastim",
            Preco = "25 Peças de Ouro",
            Deslocamento = "12 metros",
            CapacidadedeCarga = "100 Kg"
        },
        new VeiculoTerrestre
        {
            IdVeiculoTerrestre = 8,
            Nome = "Pônei",
            Preco = "30 Peças de Ouro",
            Deslocamento = "12 metros",
            CapacidadedeCarga = "115 Kg"
        }
        );
        modelBuilder.Entity<VeiculoAquatico>().HasData
        (
            new VeiculoAquatico
            {
                IdVeiculoAquatico = 1,
                Nome = "Barco de quilha",
                Preco = "3000 Peças de Ouro",
                Velocidade = "1.5 km/h"
            },
            new VeiculoAquatico
            {
                IdVeiculoAquatico = 2,
                Nome = "Barco a remo",
                Preco = "50 Peças de Ouro",
                Velocidade = "2 km/h"
            },
            new VeiculoAquatico
            {
                IdVeiculoAquatico = 3,
                Nome = "Dracar",
                Preco = "10000 Peças de Ouro",
                Velocidade = "5 km/h"
            },
            new VeiculoAquatico
            {
                IdVeiculoAquatico = 4,
                Nome = "Galera",
                Preco = "30000 Peças de Ouro",
                Velocidade = "6.5 km/h"
            },
            new VeiculoAquatico
            {
                IdVeiculoAquatico = 5,
                Nome = "Navio de guerra",
                Preco = "25000 Peças de Ouro",
                Velocidade = "4 km/h"
            },
            new VeiculoAquatico
            {
                IdVeiculoAquatico = 6,
                Nome = "Veleiro",
                Preco = "10000 Peças de Ouro",
                Velocidade = "3 km/h"
            }
        );

        modelBuilder.Entity<ASVTracao>().HasData(
            new ASVTracao
            {
                IdASVTracao = 1,
                Nome = "Alforje",
                Preco = "4 Peças de Ouro",
                Peso = "4 Kg"
            },
            new ASVTracao
            {
                IdASVTracao = 2,
                Nome = "Armadura e montaria",
                Preco = "X4",
                Peso = "X2"
            },
            new ASVTracao
            {
                IdASVTracao = 3,
                Nome = "Biga",
                Preco = "250 Peças de Ouro",
                Peso = "50 Kg"
            },
            new ASVTracao
            {
                IdASVTracao = 4,
                Nome = "Carroça",
                Preco = "15 Peças de Ouro",
                Peso = "100 Kg"
            },
            new ASVTracao
            {
                IdASVTracao = 5,
                Nome = "Carruagem",
                Preco = "100 Peças",
                Peso = "300 Kg"
            },
            new ASVTracao
            {
                IdASVTracao = 6,
                Nome = "Estábulo",
                Preco = "5 Peças de Prata",
                Peso = "-"
            },
            new ASVTracao
            {
                IdASVTracao = 7,
                Nome = "Freio e rédea",
                Preco = "2 Peças de Ouro",
                Peso = "0.5 Kg"
            },
            new ASVTracao
            {
                IdASVTracao = 8,
                Nome = "Ração",
                Preco = "5 Kg",
                Peso = "5 Peças de Cobre"
            },
            new ASVTracao
            {
                IdASVTracao = 9,
                Nome = "Sela Compacta",
                Preco = "5 Peças de Ouro",
                Peso = "7.5 Kg"
            },
            new ASVTracao
            {
                IdASVTracao = 10,
                Nome = "Sela Exótica",
                Preco = "60 Peças de Ouro",
                Peso = "20 Kg"
            },
            new ASVTracao
            {
                IdASVTracao = 11,
                Nome = "Sela Militar",
                Preco = "20 Peças de Ouro",
                Peso = "15 Kg"
            },
            new ASVTracao
            {
                IdASVTracao = 12,
                Nome = "Sela p/ Viagem",
                Preco = "10 Peças de Ouro",
                Peso = "12.5 Kg"
            },
            new ASVTracao
            {
                IdASVTracao = 13,
                Nome = "Trenó",
                Preco = "20 Peças de Ouro",
                Peso = "150 Kg"
            }
        );

        modelBuilder.Entity<HabilidadeRacial_Raca>().HasData(
        new HabilidadeRacial_Raca
        {
            IdHabilidadeRacial = 1,
            IdRaca = 1
        },
        new HabilidadeRacial_Raca
        {
            IdHabilidadeRacial = 2,
            IdRaca = 1
        },
        new HabilidadeRacial_Raca
        {
            IdHabilidadeRacial = 3,
            IdRaca = 1
        },
        new HabilidadeRacial_Raca
        {
            IdHabilidadeRacial = 4,
            IdRaca = 1
        },
        new HabilidadeRacial_Raca
        {
            IdHabilidadeRacial = 5,
            IdRaca = 1
        },
        new HabilidadeRacial_Raca
        {
            IdHabilidadeRacial = 1,
            IdRaca = 2
        },
        new HabilidadeRacial_Raca
        {
            IdHabilidadeRacial = 8,
            IdRaca = 2
        },
        new HabilidadeRacial_Raca
        {
            IdHabilidadeRacial = 9,
            IdRaca = 2,
        },
        new HabilidadeRacial_Raca
        {
            IdHabilidadeRacial = 10,
            IdRaca = 2
        },
        new HabilidadeRacial_Raca
        {
            IdHabilidadeRacial = 20,
            IdRaca = 3
        },
        new HabilidadeRacial_Raca
        {
            IdHabilidadeRacial = 21,
            IdRaca = 3
        },
        new HabilidadeRacial_Raca
        {
            IdHabilidadeRacial = 22,
            IdRaca = 3
        },
        new HabilidadeRacial_Raca
        {
            IdHabilidadeRacial = 25,
            IdRaca = 5
        },
        new HabilidadeRacial_Raca
        {
            IdHabilidadeRacial = 26,
            IdRaca = 5
        },
        new HabilidadeRacial_Raca
        {
            IdHabilidadeRacial = 27,
            IdRaca = 5
        },
        new HabilidadeRacial_Raca
        {
            IdHabilidadeRacial = 1,
            IdRaca = 6
        },
        new HabilidadeRacial_Raca
        {
            IdHabilidadeRacial = 28,
            IdRaca = 6
        },
        new HabilidadeRacial_Raca
        {
            IdHabilidadeRacial = 1,
            IdRaca = 7
        },
        new HabilidadeRacial_Raca
        {
            IdHabilidadeRacial = 9,
            IdRaca = 7
        },
        new HabilidadeRacial_Raca
        {
            IdHabilidadeRacial = 33,
            IdRaca = 7
        },
        new HabilidadeRacial_Raca
        {
            IdHabilidadeRacial = 1,
            IdRaca = 8
        },
        new HabilidadeRacial_Raca
        {
            IdHabilidadeRacial = 34,
            IdRaca = 8
        },
        new HabilidadeRacial_Raca
        {
            IdHabilidadeRacial = 35,
            IdRaca = 8
        },
        new HabilidadeRacial_Raca
        {
            IdHabilidadeRacial = 36,
            IdRaca = 8
        },
        new HabilidadeRacial_Raca
        {
            IdHabilidadeRacial = 37,
            IdRaca = 9
        },
        new HabilidadeRacial_Raca
        {
            IdHabilidadeRacial = 38,
            IdRaca = 9
        }
    );
        modelBuilder.Entity<HabilidadeRacial_SubRaca>().HasData(
        new HabilidadeRacial_SubRaca
        {
            IdHabilidadeRacial = 6,
            IdSubRaca = 1
        },
        new HabilidadeRacial_SubRaca
        {
            IdHabilidadeRacial = 7,
            IdSubRaca = 2
        },
        new HabilidadeRacial_SubRaca
        {
            IdHabilidadeRacial = 11,
            IdSubRaca = 3,
        },
        new HabilidadeRacial_SubRaca
        {
            IdHabilidadeRacial = 12,
            IdSubRaca = 3
        },
        new HabilidadeRacial_SubRaca
        {
            IdHabilidadeRacial = 13,
            IdSubRaca = 3
        },
        new HabilidadeRacial_SubRaca
        {
            IdHabilidadeRacial = 11,
            IdSubRaca = 4
        },
        new HabilidadeRacial_SubRaca
        {
            IdHabilidadeRacial = 14,
            IdSubRaca = 4
        },
        new HabilidadeRacial_SubRaca
        {
            IdHabilidadeRacial = 15,
            IdSubRaca = 4
        },
        new HabilidadeRacial_SubRaca
        {
            IdHabilidadeRacial = 16,
            IdSubRaca = 5
        },
        new HabilidadeRacial_SubRaca
        {
            IdHabilidadeRacial = 17,
            IdSubRaca = 5
        },
        new HabilidadeRacial_SubRaca
        {
            IdHabilidadeRacial = 18,
            IdSubRaca = 5
        },
        new HabilidadeRacial_SubRaca
        {
            IdHabilidadeRacial = 19,
            IdSubRaca = 5
        },
        new HabilidadeRacial_SubRaca
        {
            IdHabilidadeRacial = 23,
            IdSubRaca = 6
        },
        new HabilidadeRacial_SubRaca
        {
            IdHabilidadeRacial = 24,
            IdSubRaca = 7
        },
        new HabilidadeRacial_SubRaca
        {
            IdHabilidadeRacial = 29,
            IdSubRaca = 8
        },
        new HabilidadeRacial_SubRaca
        {
            IdHabilidadeRacial = 30,
            IdSubRaca = 8
        },
        new HabilidadeRacial_SubRaca
        {
            IdHabilidadeRacial = 31,
            IdSubRaca = 9
        },
        new HabilidadeRacial_SubRaca
        {
            IdHabilidadeRacial = 32,
            IdSubRaca = 9
        }
    );
        modelBuilder.Entity<TracodeClasse_Arquetipo>().HasData(
            new TracodeClasse_Arquetipo
            {
                IdTracodeClasse = 5,
                IdArquetipo = 1
            },
            new TracodeClasse_Arquetipo
            {
                IdTracodeClasse = 5,
                IdArquetipo = 2
            },
            new TracodeClasse_Arquetipo
            {
                IdTracodeClasse = 19,
                IdArquetipo = 3
            },
            new TracodeClasse_Arquetipo
            {
                IdTracodeClasse = 19,
                IdArquetipo = 4
            },
            new TracodeClasse_Arquetipo
            {
                IdTracodeClasse = 28,
                IdArquetipo = 5
            },
            new TracodeClasse_Arquetipo
            {
                IdTracodeClasse = 28,
                IdArquetipo = 6
            },
            new TracodeClasse_Arquetipo
            {
                IdTracodeClasse = 29,
                IdArquetipo = 7
            },
            new TracodeClasse_Arquetipo
            {
                IdTracodeClasse = 25,
                IdArquetipo = 8
            },
            new TracodeClasse_Arquetipo
            {
                IdTracodeClasse = 25,
                IdArquetipo = 9
            },
            new TracodeClasse_Arquetipo
            {
                IdTracodeClasse = 25,
                IdArquetipo = 10
            },
            new TracodeClasse_Arquetipo
            {
                IdTracodeClasse = 27,
                IdArquetipo = 11
            },
            new TracodeClasse_Arquetipo
            {
                IdTracodeClasse = 32,
                IdArquetipo = 12
            },
            new TracodeClasse_Arquetipo
            {
                IdTracodeClasse = 32,
                IdArquetipo = 13
            },
            new TracodeClasse_Arquetipo
            {
                IdTracodeClasse = 32,
                IdArquetipo = 14
            },
            new TracodeClasse_Arquetipo
            {
                IdTracodeClasse = 32,
                IdArquetipo = 15
            },
            new TracodeClasse_Arquetipo
            {
                IdTracodeClasse = 32,
                IdArquetipo = 16
            },
            new TracodeClasse_Arquetipo
            {
                IdTracodeClasse = 32,
                IdArquetipo = 17
            },
            new TracodeClasse_Arquetipo
            {
                IdTracodeClasse = 32,
                IdArquetipo = 18
            },
            new TracodeClasse_Arquetipo
            {
                IdTracodeClasse = 40,
                IdArquetipo = 19
            },
            new TracodeClasse_Arquetipo
            {
                IdTracodeClasse = 40,
                IdArquetipo = 20
            },
            new TracodeClasse_Arquetipo
            {
                IdTracodeClasse = 47,
                IdArquetipo = 21
            },
            new TracodeClasse_Arquetipo
            {
                IdTracodeClasse = 47,
                IdArquetipo = 22
            },
            new TracodeClasse_Arquetipo
            {
                IdTracodeClasse = 55,
                IdArquetipo = 23
            },
            new TracodeClasse_Arquetipo
            {
                IdTracodeClasse = 55,
                IdArquetipo = 24
            },

            new TracodeClasse_Arquetipo
            {
                IdTracodeClasse = 63,
                IdArquetipo = 26
            },
            new TracodeClasse_Arquetipo
            {
                IdTracodeClasse = 63,
                IdArquetipo = 27
            },
            new TracodeClasse_Arquetipo
            {
                IdTracodeClasse = 63,
                IdArquetipo = 28
            },
            new TracodeClasse_Arquetipo
            {
                IdTracodeClasse = 74,
                IdArquetipo = 29
            },
            new TracodeClasse_Arquetipo
            {
                IdTracodeClasse = 74,
                IdArquetipo = 30
            },
            new TracodeClasse_Arquetipo
            {
                IdTracodeClasse = 74,
                IdArquetipo = 31
            },
            new TracodeClasse_Arquetipo
            {
                IdTracodeClasse = 74,
                IdArquetipo = 32
            },
            new TracodeClasse_Arquetipo
            {
                IdTracodeClasse = 74,
                IdArquetipo = 33
            },
            new TracodeClasse_Arquetipo
            {
                IdTracodeClasse = 74,
                IdArquetipo = 34
            },
            new TracodeClasse_Arquetipo
            {
                IdTracodeClasse = 74,
                IdArquetipo = 35
            },
            new TracodeClasse_Arquetipo
            {
                IdTracodeClasse = 74,
                IdArquetipo = 36
            },
            new TracodeClasse_Arquetipo
            {
                IdTracodeClasse = 82,
                IdArquetipo = 37
            },
            new TracodeClasse_Arquetipo
            {
                IdTracodeClasse = 82,
                IdArquetipo = 38
            },
            new TracodeClasse_Arquetipo
            {
                IdTracodeClasse = 82,
                IdArquetipo = 39
            },
            new TracodeClasse_Arquetipo
            {
                IdTracodeClasse = 103,
                IdArquetipo = 40
            },
            new TracodeClasse_Arquetipo
            {
                IdTracodeClasse = 103,
                IdArquetipo = 41
            },
            new TracodeClasse_Arquetipo
            {
                IdTracodeClasse = 103,
                IdArquetipo = 42
            },
            new TracodeClasse_Arquetipo
            {
                IdTracodeClasse = 114,
                IdArquetipo = 43
            },
            new TracodeClasse_Arquetipo
            {
                IdTracodeClasse = 114,
                IdArquetipo = 44
            },
            new TracodeClasse_Arquetipo
            {
                IdTracodeClasse = 114,
                IdArquetipo = 45
            }
        );
        modelBuilder.Entity<Classe_TracodeClasse>().HasData(
        new Classe_TracodeClasse
        {
            IdClasse = 1,
            IdTracodeClasse = 1,
            Nivel = 1
        },
        new Classe_TracodeClasse
        {
            IdClasse = 1,
            IdTracodeClasse = 2,
            Nivel = 1
        },
        new Classe_TracodeClasse
        {
            IdClasse = 1,
            IdTracodeClasse = 3,
            Nivel = 2
        },
        new Classe_TracodeClasse
        {
            IdClasse = 1,
            IdTracodeClasse = 4,
            Nivel = 2
        },
        new Classe_TracodeClasse
        {
            IdClasse = 1,
            IdTracodeClasse = 5,
            Nivel = 3
        },
        new Classe_TracodeClasse
        {
            IdClasse = 1,
            IdTracodeClasse = 6,
            Nivel = 4
        },
        new Classe_TracodeClasse
        {
            IdClasse = 1,
            IdTracodeClasse = 7,
            Nivel = 5
        },
        new Classe_TracodeClasse
        {
            IdClasse = 1,
            IdTracodeClasse = 8,
            Nivel = 5
        },
        new Classe_TracodeClasse
        {
            IdClasse = 1,
            IdTracodeClasse = 9,
            Nivel = 7
        },
        new Classe_TracodeClasse
        {
            IdClasse = 1,
            IdTracodeClasse = 10,
            Nivel = 9
        },
        new Classe_TracodeClasse
        {
            IdClasse = 1,
            IdTracodeClasse = 11,
            Nivel = 11
        },
        new Classe_TracodeClasse
        {
            IdClasse = 1,
            IdTracodeClasse = 12,
            Nivel = 15
        },
        new Classe_TracodeClasse
        {
            IdClasse = 1,
            IdTracodeClasse = 13,
            Nivel = 18
        },
        new Classe_TracodeClasse
        {
            IdClasse = 1,
            IdTracodeClasse = 14,
            Nivel = 20
        },
        new Classe_TracodeClasse
        {
            IdClasse = 2,
            IdTracodeClasse = 15,
            Nivel = 1
        },
        new Classe_TracodeClasse
        {
            IdClasse = 2,
            IdTracodeClasse = 16,
            Nivel = 1
        },
        new Classe_TracodeClasse
        {
            IdClasse = 2,
            IdTracodeClasse = 17,
            Nivel = 2
        },
        new Classe_TracodeClasse
        {
            IdClasse = 2,
            IdTracodeClasse = 18,
            Nivel = 2
        },
        new Classe_TracodeClasse
        {
            IdClasse = 2,
            IdTracodeClasse = 19,
            Nivel = 3
        },
        new Classe_TracodeClasse
        {
            IdClasse = 2,
            IdTracodeClasse = 20,
            Nivel = 3
        },
        new Classe_TracodeClasse
        {
            IdClasse = 2,
            IdTracodeClasse = 21,
            Nivel = 5
        },
        new Classe_TracodeClasse
        {
            IdClasse = 2,
            IdTracodeClasse = 22,
            Nivel = 6
        },
        new Classe_TracodeClasse
        {
            IdClasse = 2,
            IdTracodeClasse = 23,
            Nivel = 10
        },
        new Classe_TracodeClasse
        {
            IdClasse = 2,
            IdTracodeClasse = 24,
            Nivel = 20
        },
        new Classe_TracodeClasse
        {
            IdClasse = 3,
            IdTracodeClasse = 25,
            Nivel = 1
        },
        new Classe_TracodeClasse
        {
            IdClasse = 3,
            IdTracodeClasse = 26,
            Nivel = 1
        },
        new Classe_TracodeClasse
        {
            IdClasse = 3,
            IdTracodeClasse = 27,
            Nivel = 2
        },
        new Classe_TracodeClasse
        {
            IdClasse = 3,
            IdTracodeClasse = 28,
            Nivel = 3
        },
        new Classe_TracodeClasse
        {
            IdClasse = 3,
            IdTracodeClasse = 29,
            Nivel = 11
        },
        new Classe_TracodeClasse
        {
            IdClasse = 3,
            IdTracodeClasse = 30,
            Nivel = 20
        },
        new Classe_TracodeClasse
        {
            IdClasse = 4,
            IdTracodeClasse = 31,
            Nivel = 1
        },
        new Classe_TracodeClasse
        {
            IdClasse = 4,
            IdTracodeClasse = 32,
            Nivel = 1
        },
        new Classe_TracodeClasse
        {
            IdClasse = 4,
            IdTracodeClasse = 33,
            Nivel = 2
        },
        new Classe_TracodeClasse
        {
            IdClasse = 4,
            IdTracodeClasse = 4,
            Nivel = 4
        },
        new Classe_TracodeClasse
        {
            IdClasse = 4,
            IdTracodeClasse = 36,
            Nivel = 5
        },
        new Classe_TracodeClasse
        {
            IdClasse = 4,
            IdTracodeClasse = 37,
            Nivel = 10
        },
        new Classe_TracodeClasse
        {
            IdClasse = 5,
            IdTracodeClasse = 38,
            Nivel = 1
        },
        new Classe_TracodeClasse
        {
            IdClasse = 5,
            IdTracodeClasse = 39,
            Nivel = 1
        },
        new Classe_TracodeClasse
        {
            IdClasse = 5,
            IdTracodeClasse = 40,
            Nivel = 2
        },
        new Classe_TracodeClasse
        {
            IdClasse = 5,
            IdTracodeClasse = 41,
            Nivel = 2
        },
        new Classe_TracodeClasse
        {
            IdClasse = 5,
            IdTracodeClasse = 4,
            Nivel = 4
        },
        new Classe_TracodeClasse
        {
            IdClasse = 5,
            IdTracodeClasse = 43,
            Nivel = 18
        },
        new Classe_TracodeClasse
        {
            IdClasse = 5,
            IdTracodeClasse = 44,
            Nivel = 18
        },
        new Classe_TracodeClasse
        {
            IdClasse = 5,
            IdTracodeClasse = 45,
            Nivel = 20
        },
        new Classe_TracodeClasse
        {
            IdClasse = 6,
            IdTracodeClasse = 46,
            Nivel = 1
        },
        new Classe_TracodeClasse
        {
            IdClasse = 6,
            IdTracodeClasse = 47,
            Nivel = 1
        },
        new Classe_TracodeClasse
        {
            IdClasse = 6,
            IdTracodeClasse = 48,
            Nivel = 2
        },
        new Classe_TracodeClasse
        {
            IdClasse = 6,
            IdTracodeClasse = 49,
            Nivel = 3
        },
        new Classe_TracodeClasse
        {
            IdClasse = 6,
            IdTracodeClasse = 4,
            Nivel = 4
        },
        new Classe_TracodeClasse
        {
            IdClasse = 6,
            IdTracodeClasse = 51,
            Nivel = 20
        },
        new Classe_TracodeClasse
        {
            IdClasse = 7,
            IdTracodeClasse = 52,
            Nivel = 1
        },
        new Classe_TracodeClasse
        {
            IdClasse = 7,
            IdTracodeClasse = 53,
            Nivel = 1
        },
        new Classe_TracodeClasse
        {
            IdClasse = 7,
            IdTracodeClasse = 54,
            Nivel = 2
        },
        new Classe_TracodeClasse
        {
            IdClasse = 7,
            IdTracodeClasse = 55,
            Nivel = 3
        },
        new Classe_TracodeClasse
        {
            IdClasse = 7,
            IdTracodeClasse = 4,
            Nivel = 4
        },
        new Classe_TracodeClasse
        {
            IdClasse = 7,
            IdTracodeClasse = 7,
            Nivel = 5,
        },
        new Classe_TracodeClasse
        {
            IdClasse = 7,
            IdTracodeClasse = 58,
            Nivel = 9
        },
        new Classe_TracodeClasse
        {
            IdClasse = 8,
            IdTracodeClasse = 59,
            Nivel = 1
        },
        new Classe_TracodeClasse
        {
            IdClasse = 8,
            IdTracodeClasse = 60,
            Nivel = 1
        },
        new Classe_TracodeClasse
        {
            IdClasse = 8,
            IdTracodeClasse = 61,
            Nivel = 1
        },
        new Classe_TracodeClasse
        {
            IdClasse = 8,
            IdTracodeClasse = 62,
            Nivel = 2
        },
        new Classe_TracodeClasse
        {
            IdClasse = 8,
            IdTracodeClasse = 63,
            Nivel = 3
        },
        new Classe_TracodeClasse
        {
            IdClasse = 8,
            IdTracodeClasse = 4,
            Nivel = 4
        },
        new Classe_TracodeClasse
        {
            IdClasse = 8,
            IdTracodeClasse = 65,
            Nivel = 5
        },
        new Classe_TracodeClasse
        {
            IdClasse = 8,
            IdTracodeClasse = 66,
            Nivel = 6
        },
        new Classe_TracodeClasse
        {
            IdClasse = 8,
            IdTracodeClasse = 67,
            Nivel = 11
        },
        new Classe_TracodeClasse
        {
            IdClasse = 8,
            IdTracodeClasse = 68,
            Nivel = 14
        },
        new Classe_TracodeClasse
        {
            IdClasse = 8,
            IdTracodeClasse = 69,
            Nivel = 15
        },
        new Classe_TracodeClasse
        {
            IdClasse = 8,
            IdTracodeClasse = 70,
            Nivel = 18
        },
        new Classe_TracodeClasse
        {
            IdClasse = 8,
            IdTracodeClasse = 71,
            Nivel = 20
        },
        new Classe_TracodeClasse
        {
            IdClasse = 9,
            IdTracodeClasse = 72,
            Nivel = 1
        },
        new Classe_TracodeClasse
        {
            IdClasse = 9,
            IdTracodeClasse = 73,
            Nivel = 1
        },
        new Classe_TracodeClasse
        {
            IdClasse = 9,
            IdTracodeClasse = 74,
            Nivel = 2
        },
        new Classe_TracodeClasse
        {
            IdClasse = 9,
            IdTracodeClasse = 4,
            Nivel = 4
        },
        new Classe_TracodeClasse
        {
            IdClasse = 9,
            IdTracodeClasse = 76,
            Nivel = 18
        },
        new Classe_TracodeClasse
        {
            IdClasse = 9,
            IdTracodeClasse = 77,
            Nivel = 20
        },
        new Classe_TracodeClasse
        {
            IdClasse = 10,
            IdTracodeClasse = 2,
            Nivel = 1
        },
        new Classe_TracodeClasse
        {
            IdClasse = 10,
            IdTracodeClasse = 79,
            Nivel = 1
        },
        new Classe_TracodeClasse
        {
            IdClasse = 10,
            IdTracodeClasse = 80,
            Nivel = 2
        },
        new Classe_TracodeClasse
        {
            IdClasse = 10,
            IdTracodeClasse = 81,
            Nivel = 2
        },
        new Classe_TracodeClasse
        {
            IdClasse = 10,
            IdTracodeClasse = 82,
            Nivel = 3
        },
        new Classe_TracodeClasse
        {
            IdClasse = 10,
            IdTracodeClasse = 83,
            Nivel = 3
        },
        new Classe_TracodeClasse
        {
            IdClasse = 10,
            IdTracodeClasse = 4,
            Nivel = 4
        },
        new Classe_TracodeClasse
        {
            IdClasse = 10,
            IdTracodeClasse = 85,
            Nivel = 4
        },
        new Classe_TracodeClasse
        {
            IdClasse = 10,
            IdTracodeClasse = 7,
            Nivel = 5
        },
        new Classe_TracodeClasse
        {
            IdClasse = 10,
            IdTracodeClasse = 87,
            Nivel = 5
        },
        new Classe_TracodeClasse
        {
            IdClasse = 10,
            IdTracodeClasse = 88,
            Nivel = 6
        },
        new Classe_TracodeClasse
        {
            IdClasse = 10,
            IdTracodeClasse = 66,
            Nivel = 7
        },
        new Classe_TracodeClasse
        {
            IdClasse = 10,
            IdTracodeClasse = 90,
            Nivel = 7
        },
        new Classe_TracodeClasse
        {
            IdClasse = 10,
            IdTracodeClasse = 91,
            Nivel = 10
        },
        new Classe_TracodeClasse
        {
            IdClasse = 10,
            IdTracodeClasse = 92,
            Nivel = 13
        },
        new Classe_TracodeClasse
        {
            IdClasse = 10,
            IdTracodeClasse = 93,
            Nivel = 14
        },
        new Classe_TracodeClasse
        {
            IdClasse = 10,
            IdTracodeClasse = 94,
            Nivel = 15
        },
        new Classe_TracodeClasse
        {
            IdClasse = 10,
            IdTracodeClasse = 95,
            Nivel = 18
        },
        new Classe_TracodeClasse
        {
            IdClasse = 10,
            IdTracodeClasse = 96,
            Nivel = 20
        },
        new Classe_TracodeClasse
        {
            IdClasse = 11,
            IdTracodeClasse = 97,
            Nivel = 1
        },
        new Classe_TracodeClasse
        {
            IdClasse = 11,
            IdTracodeClasse = 98,
            Nivel = 1
        },
        new Classe_TracodeClasse
        {
            IdClasse = 11,
            IdTracodeClasse = 52,
            Nivel = 2
        },
        new Classe_TracodeClasse
        {
            IdClasse = 11,
            IdTracodeClasse = 100,
            Nivel = 2
        },
        new Classe_TracodeClasse
        {
            IdClasse = 11,
            IdTracodeClasse = 101,
            Nivel = 2
        },
        new Classe_TracodeClasse
        {
            IdClasse = 11,
            IdTracodeClasse = 102,
            Nivel = 3
        },
        new Classe_TracodeClasse
        {
            IdClasse = 11,
            IdTracodeClasse = 103,
            Nivel = 3
        },
        new Classe_TracodeClasse
        {
            IdClasse = 11,
            IdTracodeClasse = 4,
            Nivel = 4
        },
        new Classe_TracodeClasse
        {
            IdClasse = 11,
            IdTracodeClasse = 7,
            Nivel = 5
        },
        new Classe_TracodeClasse
        {
            IdClasse = 11,
            IdTracodeClasse = 106,
            Nivel = 6
        },
        new Classe_TracodeClasse
        {
            IdClasse = 11,
            IdTracodeClasse = 107,
            Nivel = 10
        },
        new Classe_TracodeClasse
        {
            IdClasse = 11,
            IdTracodeClasse = 108,
            Nivel = 11
        },
        new Classe_TracodeClasse
        {
            IdClasse = 11,
            IdTracodeClasse = 109,
            Nivel = 14
        },
        new Classe_TracodeClasse
        {
            IdClasse = 12,
            IdTracodeClasse = 110,
            Nivel = 1
        },
        new Classe_TracodeClasse
        {
            IdClasse = 12,
            IdTracodeClasse = 111,
            Nivel = 1
        },
        new Classe_TracodeClasse
        {
            IdClasse = 12,
            IdTracodeClasse = 52,
            Nivel = 2
        },
        new Classe_TracodeClasse
        {
            IdClasse = 12,
            IdTracodeClasse = 100,
            Nivel = 2
        },
        new Classe_TracodeClasse
        {
            IdClasse = 12,
            IdTracodeClasse = 114,
            Nivel = 3
        },
        new Classe_TracodeClasse
        {
            IdClasse = 12,
            IdTracodeClasse = 115,
            Nivel = 3
        },
        new Classe_TracodeClasse
        {
            IdClasse = 12,
            IdTracodeClasse = 4,
            Nivel = 4
        },
        new Classe_TracodeClasse
        {
            IdClasse = 12,
            IdTracodeClasse = 116,
            Nivel = 6
        },
        new Classe_TracodeClasse
        {
            IdClasse = 12,
            IdTracodeClasse = 117,
            Nivel = 8
        },
        new Classe_TracodeClasse
        {
            IdClasse = 12,
            IdTracodeClasse = 118,
            Nivel = 10
        },
        new Classe_TracodeClasse
        {
            IdClasse = 12,
            IdTracodeClasse = 119,
            Nivel = 14
        },
        new Classe_TracodeClasse
        {
            IdClasse = 12,
            IdTracodeClasse = 120,
            Nivel = 18
        },
        new Classe_TracodeClasse
        {
            IdClasse = 12,
            IdTracodeClasse = 121,
            Nivel = 20
        }

    );
    modelBuilder.Entity<Magia_ListaMagia>().HasData(
        new Magia_ListaMagia{
            IdMagia = 1,
            IdListaMagia = 1,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 2,
            IdListaMagia = 1,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 3,
            IdListaMagia = 2,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 4,
            IdListaMagia = 7,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 5,
            IdListaMagia = 3,
            Ciclo = 6
        },
        new Magia_ListaMagia{
            IdMagia = 6,
            IdListaMagia = 7,
            Ciclo = 5
        },
        new Magia_ListaMagia{
            IdMagia = 7,
            IdListaMagia = 8,
            Ciclo = 9
        },
        new Magia_ListaMagia{
            IdMagia = 8,
            IdListaMagia = 8,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 9,
            IdListaMagia = 1,
            Ciclo = 0
        },
        new Magia_ListaMagia{
            IdMagia = 10,
            IdListaMagia = 1,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 11,
            IdListaMagia = 1,
            Ciclo = 3
        },
        new Magia_ListaMagia{
            IdMagia = 12,
            IdListaMagia = 1,
            Ciclo = 5
        },
        new Magia_ListaMagia{
            IdMagia = 13,
            IdListaMagia = 3,
            Ciclo = 3
        },
        new Magia_ListaMagia{
            IdMagia = 14,
            IdListaMagia = 3,
            Ciclo = 3
        },
        new Magia_ListaMagia{
            IdMagia = 15,
            IdListaMagia = 5,
            Ciclo = 5
        },
        new Magia_ListaMagia{
            IdMagia = 16,
            IdListaMagia = 8,
            Ciclo = 8
        },
        new Magia_ListaMagia{
            IdMagia = 17,
            IdListaMagia = 1,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 18,
            IdListaMagia = 2,
            Ciclo = 9
        },
        new Magia_ListaMagia{
            IdMagia = 19,
            IdListaMagia = 8,
            Ciclo = 4
        },
        new Magia_ListaMagia{
            IdMagia = 20,
            IdListaMagia = 8,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 21,
            IdListaMagia = 6,
            Ciclo = 3
        },
        new Magia_ListaMagia{
            IdMagia = 22,
            IdListaMagia = 3,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 23,
            IdListaMagia = 8,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 24,
            IdListaMagia = 5,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 25,
            IdListaMagia = 2,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 26,
            IdListaMagia = 1,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 27,
            IdListaMagia = 8,
            Ciclo = 4
        },
        new Magia_ListaMagia{
            IdMagia = 28,
            IdListaMagia = 2,
            Ciclo = 0
        },
        new Magia_ListaMagia{
            IdMagia = 29,
            IdListaMagia = 6,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 30,
            IdListaMagia = 3,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 31,
            IdListaMagia = 5,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 32,
            IdListaMagia = 6,
            Ciclo = 4
        },
        new Magia_ListaMagia{
            IdMagia = 33,
            IdListaMagia = 6,
            Ciclo = 4
        },
        new Magia_ListaMagia{
            IdMagia = 34,
            IdListaMagia = 6,
            Ciclo = 3
        },
        new Magia_ListaMagia{
            IdMagia = 35,
            IdListaMagia = 8,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 36,
            IdListaMagia = 3,
            Ciclo = 8
        },
        new Magia_ListaMagia{
            IdMagia = 37,
            IdListaMagia = 6,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 38,
            IdListaMagia = 2,
            Ciclo = 4
        },
        new Magia_ListaMagia{
            IdMagia = 39,
            IdListaMagia = 3,
            Ciclo = 6
        },
        new Magia_ListaMagia{
            IdMagia = 40,
            IdListaMagia = 3,
            Ciclo = 6
        },
        new Magia_ListaMagia{
            IdMagia = 41,
            IdListaMagia = 3,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 42,
            IdListaMagia = 8,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 43,
            IdListaMagia = 5,
            Ciclo = 3
        },
        new Magia_ListaMagia{
            IdMagia = 44,
            IdListaMagia = 5,
            Ciclo = 7
        },
        new Magia_ListaMagia{
            IdMagia = 45,
            IdListaMagia = 7,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 46,
            IdListaMagia = 4,
            Ciclo = 0
        },
        new Magia_ListaMagia{
            IdMagia = 47,
            IdListaMagia = 2,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 48,
            IdListaMagia = 2,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 49,
            IdListaMagia = 4,
            Ciclo = 5
        },
        new Magia_ListaMagia{
            IdMagia = 50,
            IdListaMagia = 4,
            Ciclo = 6
        },
        new Magia_ListaMagia{
            IdMagia = 51,
            IdListaMagia = 8,
            Ciclo = 8
        },
        new Magia_ListaMagia{
            IdMagia = 52,
            IdListaMagia = 8,
            Ciclo = 4
        },
        new Magia_ListaMagia{
            IdMagia = 53,
            IdListaMagia = 1,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 54,
            IdListaMagia = 2,
            Ciclo = 6
        },
        new Magia_ListaMagia{
            IdMagia = 55,
            IdListaMagia = 3,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 56,
            IdListaMagia = 3,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 57,
            IdListaMagia = 3,
            Ciclo = 0
        },
        new Magia_ListaMagia{
            IdMagia = 58,
            IdListaMagia = 4,
            Ciclo = 0
        },
        new Magia_ListaMagia{
            IdMagia = 59,
            IdListaMagia = 5,
            Ciclo = 9
        },
        new Magia_ListaMagia{
            IdMagia = 60,
            IdListaMagia = 8,
            Ciclo = 6
        },
        new Magia_ListaMagia{
            IdMagia = 61,
            IdListaMagia = 6,
            Ciclo = 5
        },
        new Magia_ListaMagia{
            IdMagia = 62,
            IdListaMagia = 1,
            Ciclo = 5
        },
        new Magia_ListaMagia{
            IdMagia = 63,
            IdListaMagia = 2,
            Ciclo = 3
        },
        new Magia_ListaMagia{
            IdMagia = 64,
            IdListaMagia = 1,
            Ciclo = 3
        },
        new Magia_ListaMagia{
            IdMagia = 65,
            IdListaMagia = 8,
            Ciclo = 8
        },
        new Magia_ListaMagia{
            IdMagia = 66,
            IdListaMagia = 3,
            Ciclo = 5
        },
        new Magia_ListaMagia{
            IdMagia = 67,
            IdListaMagia = 6,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 68,
            IdListaMagia = 1,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 69,
            IdListaMagia = 1,
            Ciclo = 4
        },
        new Magia_ListaMagia{
            IdMagia = 70,
            IdListaMagia = 3,
            Ciclo = 5
        },
        new Magia_ListaMagia{
            IdMagia = 71,
            IdListaMagia = 4,
            Ciclo = 5
        },
        new Magia_ListaMagia{
            IdMagia = 72,
            IdListaMagia = 5,
            Ciclo = 5
        },
        new Magia_ListaMagia{
            IdMagia = 73,
            IdListaMagia = 8,
            Ciclo = 4
        },
        new Magia_ListaMagia{
            IdMagia = 74,
            IdListaMagia = 1,
            Ciclo = 5
        },
        new Magia_ListaMagia{
            IdMagia = 75,
            IdListaMagia = 4,
            Ciclo = 3
        },
        new Magia_ListaMagia{
            IdMagia = 76,
            IdListaMagia = 3,
            Ciclo = 7
        },
        new Magia_ListaMagia{
            IdMagia = 77,
            IdListaMagia = 4,
            Ciclo = 4
        },
        new Magia_ListaMagia{
            IdMagia = 78,
            IdListaMagia = 4,
            Ciclo = 5
        },
        new Magia_ListaMagia{
            IdMagia = 79,
            IdListaMagia = 2,
            Ciclo = 6
        },
        new Magia_ListaMagia{
            IdMagia = 80,
            IdListaMagia = 7,
            Ciclo = 3
        },
        new Magia_ListaMagia{
            IdMagia = 81,
            IdListaMagia = 7,
            Ciclo = 5
        },
        new Magia_ListaMagia{
            IdMagia = 82,
            IdListaMagia = 4,
            Ciclo = 4
        },
        new Magia_ListaMagia{
            IdMagia = 83,
            IdListaMagia = 3,
            Ciclo = 5
        },
        new Magia_ListaMagia{
            IdMagia = 84,
            IdListaMagia = 4,
            Ciclo = 0
        },
        new Magia_ListaMagia{
            IdMagia = 85,
            IdListaMagia = 4,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 86,
            IdListaMagia = 8,
            Ciclo = 5
        },
        new Magia_ListaMagia{
            IdMagia = 87,
            IdListaMagia = 2,
            Ciclo = 3
        },
        new Magia_ListaMagia{
            IdMagia = 88,
            IdListaMagia = 8,
            Ciclo = 6
        },
        new Magia_ListaMagia{
            IdMagia = 89,
            IdListaMagia = 3,
            Ciclo = 4
        },
        new Magia_ListaMagia{
            IdMagia = 90,
            IdListaMagia = 3,
            Ciclo = 8
        },
        new Magia_ListaMagia{
            IdMagia = 91,
            IdListaMagia = 8,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 92,
            IdListaMagia = 6,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 93,
            IdListaMagia = 4,
            Ciclo = 3
        },
        new Magia_ListaMagia{
            IdMagia = 94,
            IdListaMagia = 5,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 95,
            IdListaMagia = 7,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 96,
            IdListaMagia = 5,
            Ciclo = 6
        },
        new Magia_ListaMagia{
            IdMagia = 97,
            IdListaMagia = 7,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 98,
            IdListaMagia = 5,
            Ciclo = 5
        },
        new Magia_ListaMagia{
            IdMagia = 99,
            IdListaMagia = 6,
            Ciclo = 3
        },
        new Magia_ListaMagia{
            IdMagia = 100,
            IdListaMagia = 4,
            Ciclo = 0
        },
        new Magia_ListaMagia{
            IdMagia = 101,
            IdListaMagia = 2,
            Ciclo = 6
        },
        new Magia_ListaMagia{
            IdMagia = 102,
            IdListaMagia = 3,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 103,
            IdListaMagia = 8,
            Ciclo = 5
        },
        new Magia_ListaMagia{
            IdMagia = 104,
            IdListaMagia = 4,
            Ciclo = 5
        },
        new Magia_ListaMagia{
            IdMagia = 105,
            IdListaMagia = 4,
            Ciclo = 6
        },
        new Magia_ListaMagia{
            IdMagia = 106,
            IdListaMagia = 3,
            Ciclo = 9
        },
        new Magia_ListaMagia{
            IdMagia = 107,
            IdListaMagia = 4,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 108,
            IdListaMagia =  4,
            Ciclo = 5
        },
        new Magia_ListaMagia{
            IdMagia = 109,
            IdListaMagia = 1,
            Ciclo = 6
        },
        new Magia_ListaMagia{
            IdMagia = 110,
            IdListaMagia = 2,
            Ciclo = 7
        },
        new Magia_ListaMagia{
            IdMagia = 111,
            IdListaMagia = 5,
            Ciclo = 9
        },
        new Magia_ListaMagia{
            IdMagia = 112,
            IdListaMagia = 8,
            Ciclo = 6
        },
        new Magia_ListaMagia{
            IdMagia = 113,
            IdListaMagia = 1,
            Ciclo = 2 
        },
        new Magia_ListaMagia{
            IdMagia = 114,
            IdListaMagia = 1,
            Ciclo = 5
        },
        new Magia_ListaMagia{
            IdMagia = 115,
            IdListaMagia = 1,
            Ciclo = 5
        },
        new Magia_ListaMagia{
            IdMagia = 116,
            IdListaMagia = 6,
            Ciclo = 5
        },
        new Magia_ListaMagia{
            IdMagia = 117,
            IdListaMagia = 6,
            Ciclo = 3
        },
        new Magia_ListaMagia{
            IdMagia = 118,
            IdListaMagia = 6,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 119,
            IdListaMagia = 6,
            Ciclo = 4
        },
        new Magia_ListaMagia{
            IdMagia = 120,
            IdListaMagia = 6,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 121,
            IdListaMagia = 6,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 122,
            IdListaMagia = 3,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 123,
            IdListaMagia = 4,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 124,
            IdListaMagia = 5,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 125,
            IdListaMagia = 6,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 126,
            IdListaMagia = 1,
            Ciclo = 3
        },
        new Magia_ListaMagia{
            IdMagia = 127,
            IdListaMagia = 8,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 128,
            IdListaMagia = 8,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 129,
            IdListaMagia = 8,
            Ciclo = 3
        },
        new Magia_ListaMagia{
            IdMagia = 130,
            IdListaMagia = 6,
            Ciclo = 5
        },
        new Magia_ListaMagia{
            IdMagia = 131,
            IdListaMagia = 3,
            Ciclo = 6
        },
        new Magia_ListaMagia{
            IdMagia = 132,
            IdListaMagia = 4,
            Ciclo = 4
        },
        new Magia_ListaMagia{
            IdMagia = 133,
            IdListaMagia = 5,
            Ciclo = 8
        },
        new Magia_ListaMagia{
            IdMagia = 134,
            IdListaMagia = 8,
            Ciclo = 5
        },
        new Magia_ListaMagia{
            IdMagia = 135,
            IdListaMagia = 4,
            Ciclo = 0
        },
        new Magia_ListaMagia{
            IdMagia = 136,
            IdListaMagia = 6,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 137,
            IdListaMagia = 8,
            Ciclo = 9
        },
        new Magia_ListaMagia{
            IdMagia = 138,
            IdListaMagia = 7,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 139,
            IdListaMagia = 1,
            Ciclo = 6
        },
        new Magia_ListaMagia{
            IdMagia = 140,
            IdListaMagia =  1,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 141,
            IdListaMagia = 1,
            Ciclo = 8
        },
        new Magia_ListaMagia{
            IdMagia = 142,
            IdListaMagia = 1,
            Ciclo = 3
        },
        new Magia_ListaMagia{
            IdMagia = 143,
            IdListaMagia = 2,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 144,
            IdListaMagia = 5,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 145,
            IdListaMagia = 6,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 146,
            IdListaMagia = 8,
            Ciclo = 4
        },
        new Magia_ListaMagia{
            IdMagia = 147,
            IdListaMagia = 2,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 148,
            IdListaMagia = 8,
            Ciclo = 6
        },
        new Magia_ListaMagia{
            IdMagia = 149,
            IdListaMagia = 4,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 150,
            IdListaMagia = 8,
            Ciclo = 4
        },
        new Magia_ListaMagia{
            IdMagia = 151,
            IdListaMagia = 8,
            Ciclo = 7
        },
        new Magia_ListaMagia{
            IdMagia = 152,
            IdListaMagia = 3,
            Ciclo = 3
        },
        new Magia_ListaMagia{
            IdMagia = 153,
            IdListaMagia = 5,
            Ciclo = 0
        },
        new Magia_ListaMagia{
            IdMagia = 154,
            IdListaMagia = 1,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 155,
            IdListaMagia = 3,
            Ciclo = 0
        },
        new Magia_ListaMagia{
            IdMagia = 156,
            IdListaMagia = 4,
            Ciclo = 8
        },
        new Magia_ListaMagia{
            IdMagia = 157,
            IdListaMagia = 8,
            Ciclo = 4
        },
        new Magia_ListaMagia{
            IdMagia = 158,
            IdListaMagia = 7,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 159,
            IdListaMagia = 1,
            Ciclo = 3
        },
        new Magia_ListaMagia{
            IdMagia = 160,
            IdListaMagia = 1,
            Ciclo = 3
        },
        new Magia_ListaMagia{
            IdMagia = 161,
            IdListaMagia = 8,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 162,
            IdListaMagia = 7,
            Ciclo = 3
        },
        new Magia_ListaMagia{
            IdMagia = 163,
            IdListaMagia = 1,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 164,
            IdListaMagia = 2,
            Ciclo = 3
        },
        new Magia_ListaMagia{
            IdMagia = 165,
            IdListaMagia = 1,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 166,
            IdListaMagia = 1,
            Ciclo = 3
        },
        new Magia_ListaMagia{
            IdMagia = 167,
            IdListaMagia = 1,
            Ciclo = 7
        },
        new Magia_ListaMagia{
            IdMagia = 168,
            IdListaMagia = 2,
            Ciclo = 3
        },
        new Magia_ListaMagia{
            IdMagia = 169,
            IdListaMagia = 4,
            Ciclo = 8
        },
        new Magia_ListaMagia{
            IdMagia = 170,
            IdListaMagia = 1,
            Ciclo = 3
        },
        new Magia_ListaMagia{
            IdMagia = 171,
            IdListaMagia = 5,
            Ciclo = 6
        },
        new Magia_ListaMagia{
            IdMagia = 172,
            IdListaMagia = 1,
            Ciclo = 0
        },
        new Magia_ListaMagia{
            IdMagia = 173,
            IdListaMagia = 7,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 174,
            IdListaMagia = 3,
            Ciclo = 4
        },
        new Magia_ListaMagia{
            IdMagia = 175,
            IdListaMagia = 1,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 176,
            IdListaMagia = 1,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 177,
            IdListaMagia = 1,
            Ciclo = 3
        },
        new Magia_ListaMagia{
            IdMagia = 178,
            IdListaMagia = 1,
            Ciclo = 0
        },
        new Magia_ListaMagia{
            IdMagia = 179,
            IdListaMagia = 1,
            Ciclo = 6
        },
        new Magia_ListaMagia{
            IdMagia = 180,
            IdListaMagia = 1,
            Ciclo = 3
        },
        new Magia_ListaMagia{
            IdMagia = 181,
            IdListaMagia = 1,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 182,
            IdListaMagia = 1,
            Ciclo = 5
        },
        new Magia_ListaMagia{
            IdMagia = 183,
            IdListaMagia = 2,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 184,
            IdListaMagia = 3,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 185,
            IdListaMagia = 4,
            Ciclo = 4
        },
        new Magia_ListaMagia{
            IdMagia = 186,
            IdListaMagia = 4,
            Ciclo = 7
        },
        new Magia_ListaMagia{
            IdMagia = 187,
            IdListaMagia = 5,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 188,
            IdListaMagia = 5,
            Ciclo = 4
        },
        new Magia_ListaMagia{
            IdMagia = 189,
            IdListaMagia = 8,
            Ciclo = 6
        },
        new Magia_ListaMagia{
            IdMagia = 190,
            IdListaMagia = 8,
            Ciclo = 7
        },
        new Magia_ListaMagia{
            IdMagia = 191,
            IdListaMagia = 8,
            Ciclo = 8
        },
        new Magia_ListaMagia{
            IdMagia = 192,
            IdListaMagia = 4,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 193,
            IdListaMagia = 5,
            Ciclo = 3
        },
        new Magia_ListaMagia{
            IdMagia = 194,
            IdListaMagia = 5,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 195,
            IdListaMagia = 5,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 196,
            IdListaMagia = 8,
            Ciclo = 5
        },
        new Magia_ListaMagia{
            IdMagia = 197,
            IdListaMagia = 8,
            Ciclo = 8
        },
        new Magia_ListaMagia{
            IdMagia = 198,
            IdListaMagia = 7,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 199,
            IdListaMagia = 7,
            Ciclo = 4
        },
        new Magia_ListaMagia{
            IdMagia = 200,
            IdListaMagia = 1,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 201,
            IdListaMagia = 1,
            Ciclo = 8
        },
        new Magia_ListaMagia{
            IdMagia = 202,
            IdListaMagia = 4,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 203,
            IdListaMagia = 1,
            Ciclo = 0
        },
        new Magia_ListaMagia{
            IdMagia = 204,
            IdListaMagia = 3,
            Ciclo = 3
        },
        new Magia_ListaMagia{
            IdMagia = 205,
            IdListaMagia = 4,
            Ciclo = 4
        },
        new Magia_ListaMagia{
            IdMagia = 206,
            IdListaMagia = 8,
            Ciclo = 7
        },
        new Magia_ListaMagia{
            IdMagia = 207,
            IdListaMagia = 6,
            Ciclo = 3
        },
        new Magia_ListaMagia{
            IdMagia = 208,
            IdListaMagia = 8,
            Ciclo = 5
        },
        new Magia_ListaMagia{
            IdMagia = 209,
            IdListaMagia = 5,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 210,
            IdListaMagia = 8,
            Ciclo = 0
        },
        new Magia_ListaMagia{
            IdMagia = 211,
            IdListaMagia = 6,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 212,
            IdListaMagia = 7,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 213,
            IdListaMagia = 1,
            Ciclo = 3
        },
        new Magia_ListaMagia{
            IdMagia = 214,
            IdListaMagia = 4,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 215,
            IdListaMagia = 5,
            Ciclo = 0
        },
        new Magia_ListaMagia{
            IdMagia = 216,
            IdListaMagia = 3,
            Ciclo = 3
        },
        new Magia_ListaMagia{
            IdMagia = 217,
            IdListaMagia = 4,
            Ciclo = 4
        },
        new Magia_ListaMagia{
            IdMagia = 218,
            IdListaMagia = 1,
            Ciclo = 9
        },
        new Magia_ListaMagia{
            IdMagia = 219,
            IdListaMagia = 4,
            Ciclo = 7
        },
        new Magia_ListaMagia{
            IdMagia = 220,
            IdListaMagia = 8,
            Ciclo = 5
        },
        new Magia_ListaMagia{
            IdMagia = 221,
            IdListaMagia = 5,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 222,
            IdListaMagia = 8,
            Ciclo = 5
        },
        new Magia_ListaMagia{
            IdMagia = 223,
            IdListaMagia = 3,
            Ciclo = 4
        },
        new Magia_ListaMagia{
            IdMagia = 224,
            IdListaMagia = 8,
            Ciclo = 3
        },
        new Magia_ListaMagia{
            IdMagia = 225,
            IdListaMagia = 8,
            Ciclo = 6
        },
        new Magia_ListaMagia{
            IdMagia = 226,
            IdListaMagia = 7,
            Ciclo = 4
        },
        new Magia_ListaMagia{
            IdMagia = 227,
            IdListaMagia = 8,
            Ciclo = 5
        },
        new Magia_ListaMagia{
            IdMagia = 228,
            IdListaMagia = 4,
            Ciclo = 6
        },
        new Magia_ListaMagia{
            IdMagia = 229,
            IdListaMagia = 4,
            Ciclo = 4
        },
        new Magia_ListaMagia{
            IdMagia = 230,
            IdListaMagia = 8,
            Ciclo = 6
        },
        new Magia_ListaMagia{
            IdMagia = 231,
            IdListaMagia = 4,
            Ciclo = 5
        },
        new Magia_ListaMagia{
            IdMagia = 232,
            IdListaMagia = 4,
            Ciclo = 3
        },
        new Magia_ListaMagia{
            IdMagia = 233,
            IdListaMagia = 8,
            Ciclo = 9
        },
        new Magia_ListaMagia{
            IdMagia = 234,
            IdListaMagia = 4,
            Ciclo = 3
        },
        new Magia_ListaMagia{
            IdMagia = 235,
            IdListaMagia = 5,
            Ciclo = 3
        },
        new Magia_ListaMagia{
            IdMagia = 236,
            IdListaMagia = 5,
            Ciclo = 5
        },
        new Magia_ListaMagia{
            IdMagia = 237,
            IdListaMagia = 8,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 238,
            IdListaMagia = 8,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 239,
            IdListaMagia = 8,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 240,
            IdListaMagia = 8,
            Ciclo = 8
        },
        new Magia_ListaMagia{
            IdMagia = 241,
            IdListaMagia = 8,
            Ciclo = 4
        },
        new Magia_ListaMagia{
            IdMagia = 242,
            IdListaMagia = 6,
            Ciclo = 5
        },
        new Magia_ListaMagia{
            IdMagia = 243,
            IdListaMagia = 4,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 244,
            IdListaMagia = 3,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 245,
            IdListaMagia = 5,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 246,
            IdListaMagia = 3,
            Ciclo = 0
        },
        new Magia_ListaMagia{
            IdMagia = 247,
            IdListaMagia = 5,
            Ciclo = 4
        },
        new Magia_ListaMagia{
            IdMagia = 248,
            IdListaMagia = 1,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 249,
            IdListaMagia = 3,
            Ciclo = 3
        },
        new Magia_ListaMagia{
            IdMagia = 250,
            IdListaMagia = 5,
            Ciclo = 8
        },
        new Magia_ListaMagia{
            IdMagia = 251,
            IdListaMagia = 1,
            Ciclo = 9
        },
        new Magia_ListaMagia{
            IdMagia = 252,
            IdListaMagia = 1,
            Ciclo = 9
        },
        new Magia_ListaMagia{
            IdMagia = 253,
            IdListaMagia = 3,
            Ciclo = 6
        },
        new Magia_ListaMagia{
            IdMagia = 254,
            IdListaMagia = 3,
            Ciclo = 7
        },
        new Magia_ListaMagia{
            IdMagia = 255,
            IdListaMagia = 5,
            Ciclo = 9
        },
        new Magia_ListaMagia{
            IdMagia = 256,
            IdListaMagia = 2,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 257,
            IdListaMagia = 4,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 258,
            IdListaMagia = 4,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 259,
            IdListaMagia = 5,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 260,
            IdListaMagia = 4,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 261,
            IdListaMagia = 4,
            Ciclo = 4
        },
        new Magia_ListaMagia{
            IdMagia = 262,
            IdListaMagia = 8,
            Ciclo = 3
        },
        new Magia_ListaMagia{
            IdMagia = 263,
            IdListaMagia = 1,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 264,
            IdListaMagia = 5,
            Ciclo = 3
        },
        new Magia_ListaMagia{
            IdMagia = 265,
            IdListaMagia = 5,
            Ciclo = 4
        },
        new Magia_ListaMagia{
            IdMagia = 266,
            IdListaMagia = 3,
            Ciclo = 9
        },
        new Magia_ListaMagia{
            IdMagia = 267,
            IdListaMagia = 5,
            Ciclo = 6
        },
        new Magia_ListaMagia{
            IdMagia = 268,
            IdListaMagia = 3,
            Ciclo = 5
        },
        new Magia_ListaMagia{
            IdMagia = 269,
            IdListaMagia = 3,
            Ciclo = 5
        },
        new Magia_ListaMagia{
            IdMagia = 270,
            IdListaMagia = 5,
            Ciclo = 0
        },
        new Magia_ListaMagia{
            IdMagia = 271,
            IdListaMagia = 8,
            Ciclo = 7
        },
        new Magia_ListaMagia{
            IdMagia = 272,
            IdListaMagia = 3,
            Ciclo = 6
        },
        new Magia_ListaMagia{
            IdMagia = 273,
            IdListaMagia = 3,
            Ciclo = 9
        },
        new Magia_ListaMagia{
            IdMagia = 274,
            IdListaMagia = 8,
            Ciclo = 7
        },
        new Magia_ListaMagia{
            IdMagia = 275,
            IdListaMagia = 6,
            Ciclo = 4
        },
        new Magia_ListaMagia{
            IdMagia = 276,
            IdListaMagia = 7,
            Ciclo = 3
        },
        new Magia_ListaMagia{
            IdMagia = 277,
            IdListaMagia = 1,
            Ciclo = 0
        },
        new Magia_ListaMagia{
            IdMagia = 278,
            IdListaMagia = 2,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 279,
            IdListaMagia = 3,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 280,
            IdListaMagia = 1,
            Ciclo = 6
        },
        new Magia_ListaMagia{
            IdMagia = 281,
            IdListaMagia = 3,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 282,
            IdListaMagia = 5,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 283,
            IdListaMagia = 5,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 284,
            IdListaMagia = 5,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 285,
            IdListaMagia = 2,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 286,
            IdListaMagia = 5,
            Ciclo = 0
        },
        new Magia_ListaMagia{
            IdMagia = 287,
            IdListaMagia = 5,
            Ciclo = 0
        },
        new Magia_ListaMagia{
            IdMagia = 288,
            IdListaMagia = 8,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 289,
            IdListaMagia = 3,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 290,
            IdListaMagia = 4,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 291,
            IdListaMagia = 4,
            Ciclo = 6
        },
        new Magia_ListaMagia{
            IdMagia = 292,
            IdListaMagia = 5,
            Ciclo = 0
        },
        new Magia_ListaMagia{
            IdMagia = 293,
            IdListaMagia = 2,
            Ciclo = 0
        },
        new Magia_ListaMagia{
            IdMagia = 294,
            IdListaMagia = 5,
            Ciclo = 7
        },
        new Magia_ListaMagia{
            IdMagia = 295,
            IdListaMagia = 8,
            Ciclo = 6
        },
        new Magia_ListaMagia{
            IdMagia = 296,
            IdListaMagia = 5,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 297,
            IdListaMagia = 4,
            Ciclo = 5
        },
        new Magia_ListaMagia{
            IdMagia = 298,
            IdListaMagia = 5,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 299,
            IdListaMagia = 1,
            Ciclo = 7
        },
        new Magia_ListaMagia{
            IdMagia = 300,
            IdListaMagia = 8,
            Ciclo = 3
        },
        new Magia_ListaMagia{
            IdMagia = 301,
            IdListaMagia = 8,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 302,
            IdListaMagia = 3,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 303,
            IdListaMagia = 2,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 304,
            IdListaMagia = 3,
            Ciclo = 0
        },
        new Magia_ListaMagia{
            IdMagia = 305,
            IdListaMagia = 4,
            Ciclo = 3
        },
        new Magia_ListaMagia{
            IdMagia = 306,
            IdListaMagia = 1,
            Ciclo = 7
        },
        new Magia_ListaMagia{
            IdMagia = 307,
            IdListaMagia = 3,
            Ciclo = 9
        },
        new Magia_ListaMagia{
            IdMagia = 308,
            IdListaMagia = 4,
            Ciclo = 5
        },
        new Magia_ListaMagia{
            IdMagia = 309,
            IdListaMagia = 6,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 310,
            IdListaMagia = 1,
            Ciclo = 5
        },
        new Magia_ListaMagia{
            IdMagia = 311,
            IdListaMagia = 3,
            Ciclo = 3
        },
        new Magia_ListaMagia{
            IdMagia = 312,
            IdListaMagia = 8,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 313,
            IdListaMagia = 8,
            Ciclo = 3
        },
        new Magia_ListaMagia{
            IdMagia = 314,
            IdListaMagia = 7,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 315,
            IdListaMagia = 3,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 316,
            IdListaMagia = 8,
            Ciclo = 4
        },
        new Magia_ListaMagia{
            IdMagia = 317,
            IdListaMagia = 7,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 318,
            IdListaMagia = 8,
            Ciclo = 8
        },
        new Magia_ListaMagia{
            IdMagia = 319,
            IdListaMagia = 7,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 320,
            IdListaMagia = 1,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 321,
            IdListaMagia = 1,
            Ciclo = 9
        },
        new Magia_ListaMagia{
            IdMagia = 322,
            IdListaMagia = 3,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 323,
            IdListaMagia = 3,
            Ciclo = 7
        },
        new Magia_ListaMagia{
            IdMagia = 324,
            IdListaMagia = 5,
            Ciclo = 5
        },
        new Magia_ListaMagia{
            IdMagia = 325,
            IdListaMagia = 8,
            Ciclo = 7
        },
        new Magia_ListaMagia{
            IdMagia = 326,
            IdListaMagia = 3,
            Ciclo = 3
        },
        new Magia_ListaMagia{
            IdMagia = 327,
            IdListaMagia = 8,
            Ciclo = 5
        },
        new Magia_ListaMagia{
            IdMagia = 328,
            IdListaMagia = 1,
            Ciclo = 5
        },
        new Magia_ListaMagia{
            IdMagia = 329,
            IdListaMagia = 1,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 330,
            IdListaMagia = 1,
            Ciclo = 6
        },
        new Magia_ListaMagia{
            IdMagia = 331,
            IdListaMagia = 1,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 332,
            IdListaMagia = 3,
            Ciclo = 0
        },
        new Magia_ListaMagia{
            IdMagia = 333,
            IdListaMagia = 5,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 334,
            IdListaMagia = 5,
            Ciclo = 5
        },
        new Magia_ListaMagia{
            IdMagia = 335,
            IdListaMagia = 8,
            Ciclo = 8
        },
        new Magia_ListaMagia{
            IdMagia = 336,
            IdListaMagia = 1,
            Ciclo = 7
        },
        new Magia_ListaMagia{
            IdMagia = 337,
            IdListaMagia = 4,
            Ciclo = 6
        },
        new Magia_ListaMagia{
            IdMagia = 338,
            IdListaMagia = 4,
            Ciclo = 9
        },
        new Magia_ListaMagia{
            IdMagia = 339,
            IdListaMagia = 5,
            Ciclo = 7
        },
        new Magia_ListaMagia{
            IdMagia = 340,
            IdListaMagia =  8,
            Ciclo = 4
        },
        new Magia_ListaMagia{
            IdMagia = 341,
            IdListaMagia = 8,
            Ciclo = 4
        },
        new Magia_ListaMagia{
            IdMagia = 342,
            IdListaMagia = 3,
            Ciclo = 8
        },
        new Magia_ListaMagia{
            IdMagia = 343,
            IdListaMagia = 4,
            Ciclo = 4
        },
        new Magia_ListaMagia{
            IdMagia = 344,
            IdListaMagia = 5,
            Ciclo = 0
        },
        new Magia_ListaMagia{
            IdMagia = 345,
            IdListaMagia = 5,
            Ciclo = 0
        },
        new Magia_ListaMagia{
            IdMagia = 346,
            IdListaMagia = 8,
            Ciclo = 5
        },
        new Magia_ListaMagia{
            IdMagia = 347,
            IdListaMagia = 8,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 348,
            IdListaMagia = 8,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 349,
            IdListaMagia = 4,
            Ciclo = 8
        },
        new Magia_ListaMagia{
            IdMagia = 350,
            IdListaMagia = 5,
            Ciclo = 3
        },
        new Magia_ListaMagia{
            IdMagia = 351,
            IdListaMagia = 8,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 352,
            IdListaMagia = 8,
            Ciclo = 7
        },
        new Magia_ListaMagia{
            IdMagia = 353,
            IdListaMagia = 1,
            Ciclo = 5
        },
        new Magia_ListaMagia{
            IdMagia = 354,
            IdListaMagia = 3,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 355,
            IdListaMagia = 4,
            Ciclo = 4
        },
        new Magia_ListaMagia{
            IdMagia = 356,
            IdListaMagia = 5,
            Ciclo = 6
        },
        new Magia_ListaMagia{
            IdMagia = 357,
            IdListaMagia = 8,
            Ciclo = 2
        },
        new Magia_ListaMagia{
            IdMagia = 358,
            IdListaMagia = 5,
            Ciclo = 1
        },
        new Magia_ListaMagia{
            IdMagia = 359,
            IdListaMagia = 5,
            Ciclo = 3
        },
        new Magia_ListaMagia{
            IdMagia = 360,
            IdListaMagia = 1,
            Ciclo = 0
        },
        new Magia_ListaMagia{
            IdMagia = 361,
            IdListaMagia = 1,
            Ciclo = 2
        }
    );
        #endregion
        // }
    }
}