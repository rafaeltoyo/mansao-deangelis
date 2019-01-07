using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuestionNPC : MonoBehaviour {

	public static QuestionNPC intance1;

	public QuestionBase[] pergunta = new QuestionBase[21];

	// Use this for initialization
	void Start () {
		intance1 = this;
		// Banco de perguntas -------------------------------------------------------------------------------------------------------------------
		pergunta [0].SetQuestion (" ''Pagam bem lá?'' Nesta oração o sujeito é:", "oculto", "simples", "indeterminado", "composto", "oração sem sujeito", 2);
		
		pergunta [1].SetQuestion ("Há erro de concordância verbal na opção:", "Comeram-se os doces", "Faz meses que ele chegou", "Existem poucas árvores lá", "Vender-se-iam casas", "Houveram muitos pedidos", 4);
		
		pergunta [2].SetQuestion ("(MACK-SP) Em: “ – Perdi a mala! – um diz de cara acabrunhada”, um tem a função sintática de:", "adjunto adnominal", "sujeito simples", "adjunto adverbial", "aposto", "numeral", 1);
		
		pergunta [3].SetQuestion ("Identifique a alternativa onde todas as palavras seguem a mesma regra de acentuação.", " bocó, dó, sapê, jiló, maré, cajá", "lâmpada, mágico, tóxico, câmera.", "ânsia, júri, país, pó, cômico.", "balaústre, órgão, tórax, saquê.", "mérito, juízes, cafézinho, útil, céu", 1);
		
		pergunta [4].SetQuestion ("Na oração: “Foram chamados às pressas todos os vaqueiros da fazenda vizinha”, o núcleo do sujeito é:", "todos", "fazenda", "vizinha", "vaqueiros", "pressas", 3);
		
		pergunta [5].SetQuestion ("Assinale a alternativa em que o sujeito está incorretamente classificado:", "chegaram, de manhã, o mensageiro e o guia (sujeito composto)", "fala-se muito neste assunto (sujeito indeterminado)", "vai fazer frio à noite (sujeito inexistente)", "haverá oportunidade para todos (sujeito inexistente)", "não existem flores no vaso (sujeito inexistente)", 4);
		
		pergunta [6].SetQuestion ("Marque a oração em que o termo destacado é sujeito:", "houve MUITAS BRIGAS no jogo;", "ia haver MORTES, se a polícia não interviesse", "faz DOIS ANOS que há bons espetáculos", "existem MUITAS PESSOAS desonestas", "há MUITAS PESSOAS desonestas", 3);
		
		pergunta [7].SetQuestion ("Na praça deserta um homem caminhava - o sujeito é:", "indeterminado", "inexistente", "simples", "oculto por elipse", "composto", 2);
		
		pergunta [8].SetQuestion ("(UFPR-2013)Tendo em vista as regras de acentuação gráfica, considere os seguintes grupos de palavras: 1. usuário, sanguínea, distância. 2. ângulo, próximo, médico. 3. deverá, distância, após. 4. razoável, pés, ângulo. As palavras são acentuadas com base na mesma regra ortográfica em:", "1 e 2 apenas", "2 e 3 apenas", "1, 3 e 4 apenas", "1 e 4 apenas", "2, 3 e 4 apenas", 0);
		
		pergunta [9].SetQuestion ("(VUNESP-2014)A Organização Mundial de Saúde (OMS) atesta que o saneamento básico precário consiste____ grave ameaça ______saúde humana. Apesar de disseminada no mundo, a falta de saneamento básico ainda é muito associada_____uma população de baixa renda, mais vulnerável devido_____ condições de subnutrição e, muitas vezes, de higiene inadequada. Assinale a alternativa que completa, correta e respectivamente, as lacunas do texto, segundo a norma-padrão da língua portuguesa.", "em ... a ... à ... a", "em ... à ... a ... a", "de ... à ... a ... as", "em ... à ... à ... às", "de ... a ... a ... às", 1);
		
		pergunta [10].SetQuestion ("(CPOS-2014)“Aproxime-se A FIM DE QUE possamos vê-lo melhor.” O termo destacado é uma conjunção subordinativa adverbial", "causal.", "concessiva.", "final.", "conformativa.", "consecutiva", 2);
		
		pergunta [11].SetQuestion ("(VUNESP-2014)Daqui__________30 anos, quando o Hospital das Clínicas da Faculdade de Medicina da USP completar seu primeiro centenário, o cenário da saúde pública terá certamente__________________ , seguindo o dinamismo inerente ao SUS (Sistema Único de Saúde). O hospital, que completa 70 anos de existência no próximo 19 de abril, é procurado por pacientes de todo o Brasil __________sua qualidade e excelência assisten- cial. Trata-se de uma população que conhece e, principalmente, confia no hospital. Muitas vezes, só nele. (Giovanni Guido Cerri, Um hospital de superlativos. Folha de S.Paulo, 16.04.2014. Adaptado) De acordo com a norma-padrão da língua portuguesa, as lacunas do texto devem ser preenchidas, respectivamente, com:", "há … se transformado … devido a", "há … transformado-se … devido", "há … transformado-se … devido", "a … se transformado … em razão de", "a … transformado-se … por causa de", 3);
		
		pergunta [12].SetQuestion ("Em relação a Lucíola,de José de Alencar,assinale a alternativa incorreta.", "A obra apresenta muito adequadamente o tema da prostituta regenerada, bem ao gosto do Romantismo.", "O narrador tem, além dos leitores da obra,explicitamente  uma interlocutora como personagem-leitora", "A narrativa se constrói em dois tempos muito bem marcados:o da vivência e o da narração da vivência", "A aparição de Maria da Glória resolve todos os problemas da personagem Lúcia, porque aponta o caminho da expiação da culpa, construindo um final feliz para a narrativa", "A presença de muitos paradoxos românticos (virtude x vício, alma x corpo, amor x prazer, ingenuidade x devassidão, família x prostituição) é possível perceber nesse romance", 3);
		
		pergunta [13].SetQuestion ("Assinale a alternativa incorreta a respeito de Lucíola, de José de Alencar.", "É Paulo -como protagonista-simultaneamente agente da narração e objeto da narrativa", "É um romance que apresenta  uma pluralidade de olhares narrativos principalmente na caracterização da personagem Lúcio", "É um romance que traz uma visão alienada na sociedade urbana do RJ, por focalizar unicamente  o drama individual da protagonista", "É através do distanciamento temporal que a narrativa se torna possível, pois a narração é atividade pela memória", "É a protagonista construída em dualidade, uma vez que, dissociando corpo e alma, ela também tem dois nomes, duas casas, dois estilos de vida", 2);
		
		pergunta [14].SetQuestion ("Lucíola, apresenta um perfil de mulher duplicado:um anjo que se contrapõe a uma prostituta;uma imagem de delicada sedução simultânea a outra de lascívia deliberada.O desdobramento da personagem feminina em duas, na obra alencariana, é um típico recurso de:", "maniqueísmo que cinge  a realidade entre o bem e mal, o moral e o imoral", "comparação, que aproxima por semelhança dois seres aparentemente tão opostos.", "duplicação, que possibilita á Lenita superar as barreiras sociais e realizar o seu projeto romântico.", "paralelismo, que permite ao leitor conhecer os lados  opostos da sociedade para melhor julgá-la", "nenhuma das anteriores", 0);
		
		pergunta [15].SetQuestion ("Em relação à peça O ingles maquinista é correto afirmar:", "é um drama em que se discute a impossibilidade de a mulher escolher com quem se casar", "consiste numa peça composta de três atos, com apenas cinco personagens de uma família burguesa do século XIX", "o título da obra se refere à função do personagem principal, grande empresário britânico da área de ferrovias", " consiste numa comédia de costumes envolvendo uma família da burguesia carioca do século XIX", "foi composta no final do século XIX, tendo como tema principal o romance proibido entre um jovem pobre e sua prima rica, prometida, pela familia, em casamento, a um milionário inglês", 3);
		
		pergunta [16].SetQuestion ("A respeito dos personagens centrais da peça “Os dois ou o inglês maquinista”, podemos afirmar:", " presenteando Clemência com um “negrinho meia-cara”, Negreiro, noivo de Mariquinha, traz já em seu nome a profissão que exerce de traficante de escravos", "a mãe de família, Dona Clemência recebe esse nome como uma forma de ironia do autor, porque ela maltrata seus escravos cruelmente, “sem nenhuma clemência”", "o jovem Felício traz em seu nome a principal característica do personagem que, durante toda a peça, extravasa sua felicidade", " o inglês Gainer, desde o início interessado em se casar apenas com D. Clemência, traz no nome sua real intenção de “ganhar”, lucrar alguma coisa de qualquer jeito", "Mariquinha recebe este nome por ser extremamente “maricas”, vaidosa, afetada, mexeriqueira, que só pensa em moda e luxo", 1);
		
		pergunta [17].SetQuestion ("A peça Os dois ou o inglês maquinista, escrita e encenada na década de 1840, põe em cena a permanência do comércio ilegal de escravos e o tratamento dispensado aos negros naquela sociedade. Nessa peça de Martins Pena:", "Mariquinha recebe de presente de seu pretendente um pajem negro. Nessa cena observa-se o esforço desmedido de Negreiro, que é capaz de cometer crimes para agradar a sua amada, postura adequada aos padrões românticos", "Clemência conseguiu comprar um escravo por intermédio de pessoas influentes. Preocupada com sua imagem na sociedade, ela mantém segredo quanto ao novo escravo, ocultando-o dos frequentadores de sua casa", "Felício refere-se a Negreiro como “um negociante de meia-cara”. A expressão, hoje em desuso, serve para julgar a falta de caráter de Negreiro, que usa de máscaras sociais para sustentar uma boa imagem perante a sociedade fluminense", "o inglês Gainer ameaça denunciar o comércio ilegal de escravos. Suas ameaças são movidas pelo desejo de afastar da casa de Mariquinha o traficante de escravos, Negreiro, e não por preocupação com o cumprimento da lei", "personagens negros desempenham papéis secundários, como “o preto dos manuês”, um “preto de ganho” e os escravos da casa. Relegando-os aos bastidores da ação, o autor deixa entrever o aspecto secundário do tema da escravidão para sua comédia.", 3);
		
		pergunta [18].SetQuestion (" Adolfo Carminha, em sua obra, Bom-Crioulo pretendeu incentivar as discussões e reflexões sobre diversos assuntos que até hoje causam polêmica. Dentre os temas apontados nas alternativas indique o que não mereceu a atenção do autor", "relacionamento homossexual", "preconceito racial e social", "trabalho escravo e violência", "união afetiva de mulheres mais velhas com rapazes jovens", "êxodo rural e inchaço urbano", 4);
		
		pergunta [19].SetQuestion ("No decorrer do romance Bom-Crioulo faz-se referência a uma doença que provocou a morte de muitas pessoas no Rio de Janeiro, em 1850, numa epidemia também referida com destaque no romance Lucíola. Essa doença foi:", "a lepra", "o tifo", "a febre amarela", "a dengue", "a leptospirose", 2);
		
		pergunta [20].SetQuestion ("O enredo de Bom-Crioulo se sustenta sobre um triângulo amoroso insólito, estabelecido de maneira diferente do que se tinha visto até então na literatura brasileira. Esse triângulo é composto por:", "dois homens em luta por uma mulher", "duas mulheres que disputam o mesmo homem", "dois homens e uma mulher que é conquistada por um deles", "um homem e uma mulher que são conquistados por outro homem", "uma mulher que atua como homem, pois conquista o parceiro de outro homem em vez de ser conquistada", 4);

		pergunta [21].SetQuestion ("Há predicado verbo-nominal em:", "Ela descansava em casa", "Todos cumpriram o juramento", "Ele vinha preocupado", "Ele está abatido", "Ela marchava alegremente", 2);
		
		pergunta [22].SetQuestion ("Em ''Sacou DA ARMA'', a função sintática do termo destacado é:", "objeto direto preposicionado", "objeto indireto", "adjunto adverbial de meio", "objeto direto", "complemento nominal", 0);
		
		pergunta [23].SetQuestion ("''(...) o guri curioso QUE eu era (...)''. O termo destacado, na passagem acima, apresenta a função sintática de:", "sujeito", "objeto direto", "pronome relativo", "predicativo do sujeito", "adjunto adverbial de intensidade", 3);
		
		pergunta [24].SetQuestion ("Assinale a oração que não possui sujeito:", "A noite caiu repentinamente sobre a cidade", "Nesse mês, vai fazer um ano da sua partida", "Choveram tomates sobre o orador", "O dia amanheceu bastante límpido", "Não havia existido ninguém com tantas qualidades", 1);
		
		pergunta [25].SetQuestion ("A única oração com sujeito simples é:", "Existem algumas dúvidas", "Compraram-se livros e cadernos", "Precisa-se de ajuda", "Faz muito frio", "Há alguns problemas", 0);
		
		pergunta [26].SetQuestion ("O sujeito do período ''Os meninos foram recepcionados pelo padrasto'' é:", "Simples", "Composto", "Derivado", "Indefinido", "Oculto", 0);
		
		pergunta [27].SetQuestion ("Assinale a opção em que o verbo da oração tem dois complementos.", "''Ela é uma gatinha.''", "''Eu fiz um coraçãozão vermelho.''", "''Agora vou botar renda em volta.''", "''Eu te odeio.''", "''Vou mandar um cartão de dia dos namorados para a Susi Derkins.''", 4);
		
		pergunta [28].SetQuestion ("Na frase ''Entrando na faculdade, procurarei emprego.'', a oração subordinada indica idéia de:", "concessão", "oposição", "condição", "lugar", "conseqüência", 2);
		
		pergunta [29].SetQuestion (" ''Ele observou-a e achou aquele gesto FEIO, GROSSEIRO, MASCULINIZADO.'' Os termos destacados são:", "predicativos do objeto", "predicativos do sujeito", "adjuntos adnominais", "objetos diretos", "adjuntos adverbiais de modo", 0);
		
		pergunta [30].SetQuestion ("Neste período ''não bate para cortar'', a oração ''para cortar'' em relação a ''não bate'', é:", "a causa", "o modo", "a conseqüência", "a explicação", "a finalidade", 4);
		
		pergunta [31].SetQuestion ("Na oração ''Esboroou-se o balsâmico indianismo de Alencar ao advento dos Romanos'', a classificação do sujeito é:", "oculto", "inexistente", "simples", "composto", "indeterminado", 2);
		
		pergunta [32].SetQuestion (" ''Nesse momento começaram a feri-lo nas mãos, a pau.'' Nessa frase o sujeito do verbo é:", "nas mãos", "indeterminado", "eles (determinado)", "inexistente ou eles: dependendo do contexto", "n.d.a", 1);
		
		pergunta [33].SetQuestion ("''Ouviram do Ipiranga as margens plácidas / De um povo heróico o brado retumbante...'' O sujeito desta afirmação com que se inicia o Hino Nacional é:", "indeterminado", "um povo heróico", "as margens plácidas do Ipiranga", "do Ipiranga", "o brado retumbante", 2);
		
		pergunta [34].SetQuestion ("Em ''Motoristas, mantenham à direita!'', há um erro de acentuação gráfica, pois o termo direita é:", "objeto direto", "objeto indireto", "adjunto adnominal", "adjunto adverbial de lugar", "aposto do sujeito", 0);


	}
	
	// Update is called once per frame
	void Update () {

	}
	
}

