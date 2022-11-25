using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsPortal.WebAPI.Migrations
{
    public partial class dataseedArticle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                 table: "Articles",
                 columns: new[] { "Id", "Active", "CategoryId", "Content", "CreateOn", "Likes", "PaidArticleId", "Photo", "PhotoThumb", "Title", "UpdatedOn", "UserId" },
                 values: new object[,]
                 {
                    { 1, true, 1, "Gradska vijećnica Mostara Boška Ćavar, koja nakon izlaska iz Naše stranke djeluje samostalno, mogla bi uskoro osnovati novu političku partiju koja će biti, kako kaže, po mjeri svih građana. Ona tvrdi da je nakon izlaska iz Naše stranke zovu mnogi građani ne samo iz Mostara nego i šire kao i privrednici koji imaju kapital da osnuje novu politiku partiju u kojoj mogu biti slobodni ljudi,i Bošnjaci i Srbi i Hrvati.'Razmišljam sada o osnivanju jedne stranke koja bi bila visoko moralna bez ljudi koji su koruptivni i bez mogućnosti da u ovoj državi prave bilo kave probleme, jer ova država zaista jedan dan mora krenuti naprijed. Ta stranka bi predstavljala baš ono što nedostaje ovakvoj državi, a to su visoko moralni ljudi koji će raditi u korist države, koji će donositi dobre zakone, koji će se provoditi, jer nije dovoljno donijeti zakon, pa ga staviti u ladicu. Zakoni se moraju provoditi da bi nam svima bilo bolje' kazala je Ćavar za Klix.ba. Ističe kako se priča o osnivanju nove političke stranke pokrenula nakon što je doživjela brojne napada kao vijećnica Naše stranke s kojom se u konačnici i razišla,jer su kako kaže mnogi vidjeli tada u njoj osobu koja misli svojom glavom i radi u interesu svih građana te joj bili podrška. 'Poslije silnih napada koje sam preživjela od kolega i svih ostalih u Mostaru i BiH, ja sam ostala najveća građanka u ovome gradu i Hrvatica, zašto to ne reći. Ja se ponosim tim što jesam, ali poštujem i sve druge i zaista želim da svi žive dobro i u miru u ovoj državi',zaključuje Ćavar.", new DateTime(2022, 11, 25, 20, 52, 51, 909, DateTimeKind.Local).AddTicks(9402), 23, null, null, null, "Nakon izlaska iz Naše stranke Boška Ćavar planira osnovati novu političku partiju", null, 1 },
                    { 2, true, 1, "Visoko sudskog i tužilačko vijeće BiH (VSTV) oglasilo se povodom napada na sudiju Suda BiH Branka Perića, ujedno i predsjedavajućeg sudskog vijeća u predmetu “Zijad Mutap i drugi”, koji su uslijedili nakon donošenja prvostepene presude u tom predmetu. Visoko sudsko i tužilačko vijeće Bosne i Hercegovine(VSTV BiH) je uputilo riječi podrške sudiji Periću. 'Perić je, vjerujemo, profesionalno, u smislu i duhu funkcije koju obnaša, zajedno sa još dvoje kolega sudija, donio prvostepenu presudu u navedenom predmetu. U ovom kontekstu, široku javnost podsjećamo da sudije mogu donositi odluke isključivo na temelju dokaza koji su im predočeni, a da svaka pretpostavka na sudu mora biti potkrepljena nedvosmislenim dokazima, jer je to suština prava i pravne države. Ujedno,želimo da istaknemo da smo, na temelju informacija koje smo imali priliku čuti putem medija,uvjereni da su tužioci Tužilaštva Bosne i Hercegovine,u okviru svoje nadležnosti,imali najbolje namjere u navedenom predmetu,zato pozivamo na suzdržanost i prilikom eventualnog kritiziranja njihovog rada', navode iz VSTV-a.", new DateTime(2022, 11, 25, 20, 52, 51, 913, DateTimeKind.Local).AddTicks(3456), 18, null, null, null, "VSTV pozvao sve da se suzdrže od napada na sudiju Branka Perića, a posebno političare", null, 1 },
                    { 3, true, 1, "Mirela Bećirović, supruga člana Predsjedništva BiH Denisa Bećirovića, pojavila se u elegantnom modnom izdanju na sinoćnjem prijemu u Vijećnici povodom Dana državnosti BiH. Ona je za ovu svečanost obukla dugu plavu haljinu i crne štikle, a izgled je upotpunila zlatnim naušnicama i prstenom.Bračni par Bećirović fotografisan je na pozornici sa Žejkom Komšićem i njegovom suprugom Sabinom, koja je obukla crnu haljinu iznad koljena.", new DateTime(2022, 11, 25, 20, 52, 51, 913, DateTimeKind.Local).AddTicks(3488), 68, null, null, null, "Supruga Denisa Bećirovića oduševila stajlingom na prijemu povodom Dana državnosti BiH", null, 1 },
                    { 4, true, 2, "U prvom meču 2. kola Svjetskog prvenstva u Kataru nogometaši Irana došli su do zaslužene pobjede protiv Velsa rezultatom 2:0 i to zahvaljujući golovima koje su postigli u 99. i 101. minuti. Nakon vrlo žustrog početka utakmice, prvu šansu bilježimo u 12.minuti kada je Moore(Vels) šutirao nakon centaršuta s desne strane, no golman Irana mu je odbranio udarac,a pet minuta nakon toga Iran je nakon sjajne akcije postigao gol za vodstvo,no on je poništen zbog nedozvoljene pozicije.", new DateTime(2022, 11, 25, 20, 52, 51, 913, DateTimeKind.Local).AddTicks(3492), 33, null, null, null, "Delirij u Kataru: Iran golovima u 99. i 101. minuti pobijedio Vels!", null, 1 },
                    { 5, true, 2, "Srbijanski teniser Novak Đoković na najbolji mogući način završio je tenisku godinu osvojivši završni Masters u Torinu, a onda je poslao inspirativnu poruku nogometašima uoči nastupa na Svjetskom prvenstvu u Kataru. Nogometaši Srbije s velikim očekivanjima otputovali su u Katar gdje će se sastati sa Brazilom,Švicarskom i Kamerunom u jednoj od najdelikatnijih grupa na Mundijalu koji je jučer otvoren. Javnost u Srbiji vjeruje u dobar rezultat,a Novak Đoković je otišao korak dalje i poručio kroz šalu da njegova reprezentacija mora biti u finalu jer će biti gost na završnoj utakmici Mundijala.", new DateTime(2022, 11, 25, 20, 52, 51, 913, DateTimeKind.Local).AddTicks(3495), 55, null, null, null, "Đoković na kameri napisao poruku za nogometaše: Idem na finale SP-a, Srbija mora biti tamo", null, 1 },
                    { 6, true, 2, "Žao mi je jer smo dosad sa Slovenijom imale skoro 3:0 u međusobnim susretima na velikim takmičenjima.Još mi je više žao kad protivnička ekipa snima treninge, gdje nema kamera, nego se postavlja mobitel i iPAD da nas snime jer se boje hoće li nas pobijediti s četiri beka koja imamo.Šta onda više da se priča o rukometu i o sportu ?. Više detalja nije poznato, osim da je EHF interno riješio ovaj slučaj. Srbija je sa skorom 0 - 3 zauzela posljednje mjesto u grupi,dok Slovenija ima učinak 2 - 1 i ide u drugu fazu šampionata.", new DateTime(2022, 11, 25, 20, 52, 51, 913, DateTimeKind.Local).AddTicks(3497), 63, null, null, null, "Otkriveno kako su Slovenci snimali srbijanske rukometašice, nevjerovatno je čega su se sjetili", null, 1 },
                    { 7, true, 1, "Ženska rukometna reprezentacija Srbije ispala je sa Svjetskog prvenstva nakon poraza od Slovenije rezultatom 27:24, a srbijanska igračica Jelena Lavko optužila je Slovence da su mobilnim telefonima snimali treninge Srbije. Iako je snimanje treninga zabranjeno,Lavko tvrdi da su Slovenke to uradile u tajnosti. 'Žao mi je jer smo dosad sa Slovenijom imale skor 3:0 u međusobnim susretima na velikim takmičenjima. Još mi je više žao kad protivnička ekipa snima treninge, gdje nema kamera, nego se postavlja mobitel i iPAD da nas snime jer se boje hoće li nas pobijediti s četiri beka koja imamo. Šta onda više da se priča o rukometu i o sportu?'. Više detalja nije poznato,osim da je EHF interno riješio ovaj slučaj. Srbija je sa skorom 0 - 3 zauzela posljednje mjesto u grupi,dok Slovenija ima učinak 2 - 1 i ide u drugu fazu šampionata.", new DateTime(2022, 11, 25, 20, 52, 51, 913, DateTimeKind.Local).AddTicks(4403), 12, null, null, null, "Srbijanske rukometašice optužile Slovenke za skandalozan potez: Šta više da se priča o sportu?", null, 1 },
                    { 8, true, 2, "U prvom kolu Svjetskog prvenstva u Kataru nogometaši Irana nisu pjevali nacionalnu himnu pred meč protiv Engleske, no danas su uoči susreta protiv Velsa promijenili tu odluku te su brojni njihovi navijači snimljeni kako plaču na tribinama. Iranski nogometaši su uoči susreta protiv Engleske odbili pjevati himnu kako bi tim činom iskazali protest zbog smrti sunarodnjankinje Mahse Amini(22),koju je privela državna policija za moral zbog navodnog kršenja pravila odijevanja,a nakon čega je preminula u pritvoru. Smrt Amini je za posljedicu imala veliko nezadovoljstvo Iranaca.Ono se prvo izražavalo na društvenim mrežama,a sve je otišlo toliko daleko da su čak i nogometaši u meču protiv Engleske odbili pjevati himnu.Ipak,nakon pritiska tamošnjih vlasti,pred početak utakmice protiv Velsa su promijenili odluku i pjevali himnu,a pojedini navijači na tribinama plakali su u tom trenutku i ubrzo su njihove reakcije objavljene na društvenim mrežama.", new DateTime(2022, 11, 25, 20, 52, 51, 913, DateTimeKind.Local).AddTicks(4412), 12, null, null, null, "Iranci popustili pod pritiskom i pjevali himnu, srceparajuća scena s tribina će obići svijet", null, 1 },
                    { 9, true, 3, "Prema podacima Centralne banke BiH (CBBH) ukupna ulaganja iz Kuvajta u BiH zaključno s 31. decembrom 2021. godine na listi su zemalja najznačajnijih stranih investitora u BiH, sa učešćem od 1,4% u ukupnim investicijama (8,3 milijardi eura ili 16,3 milijardi KM).Zemlje Bliskog istoka uložile su 920,1 milion KM,odnosno 6,1 posto ukupnog ulaganja u BiH.Najveći iznos iz navedene grupe zemalja ima Saudijska Arabija koja se u decembru 2020.nalazila na trinaestoj poziciji,na listi zemalja najznačajnijih investitora po iznosu investicija u BiH.Kuvajt se nalazio na četrnaestoj,Ujedinjeni Arapski Emirati na petnaestoj,a Katar na sedamnaestoj poziciji,na listi zemalja sa najvećim investicijama u Bosni i Hercegovini.Povodom zainteresovanosti kuvajtskih investitora za razvoj poslovanja u Bosni i Hercegovini,za Klix.ba govorio je predsjednik Upravnog odbora Kuvajtskog poslovnog vijeća u BiH Nasser Alshaiji koji se u razgovoru osvrnuo na poslovnu klimu u Bosni i Hercegovini i potencijale koje država ima.", new DateTime(2022, 11, 25, 20, 52, 51, 913, DateTimeKind.Local).AddTicks(4414), 12, null, null, null, "Nasser Alshaiji: Investitori iz Kuvajta žele ulagati u BiH, problem je odnos vlasti prema njima", null, 1 },
                    { 10, true, 3, "U Mostaru je u toku sjednica 340. sjednica Vlade Federacije BiH na kojoj se razmatra o više odluka. Vlada Federacije BiH je, na prijedlog Federalnog ministarstva prometa i komunikacija,donijela dvije odluke o utvrđivanju javnog interesa za izgradnju dvije dionice autoceste na Koridoru 5C.Riječ je o dionicama autoceste Tarčin - Konjic u dužini od 20,2 km,te tunela Prenj dužine 12 km.Također,utvrđeno je da je korisnik eksproprijacije nekretnina potrebnih za izgradnju ovih objekata JP Autoceste FBiH d.o.o.Mostar,te mu je naloženo da pokrene eksproprijacijske postupke.Kako je obrazloženo,nova odluka za dionicu Tarčin - Konjic je potrebna jer je došlo do izmjene projektnog rješenja, kao i izmjene i dopune elaborata eksproprijacije za potrebu izgradnje poddionice Ivan-Ovčari, a kojim su obuhvaćene nove parcele ili pak dijelovi ranije potrebnih parcela u manjim površinama.Utvrđivanje javnog interesa za dionicu tunela Prenj bilo je potrebno radi omogućavanja pokretanja postupka eksproprijacije nekretnina na ovoj dionici, što je ujedno i preduslov za realizaciju projekta izgradnje autoceste na ovoj dionici.Stupanjem na snagu ove dvije odluke, prestaju da važe ranije donosene o utvrđivanju javnog interesa za dionice Tarčin - Konjic i tunel Prenj, a radi propisanih rokova i pokretanja postupka eksproprijacije. Autoceste FBiH će, u skladu sa svojim Trogodišnjim planom poslovanja za period 2022 - 2024.godina, osigurati sredstva za realizaciju ovih odluka.", new DateTime(2022, 11, 25, 20, 52, 51, 913, DateTimeKind.Local).AddTicks(4417), 62, null, null, null, "Vlada FBiH utvrdila javni interes za izgradnju dionica autoceste Tarčin-Konjic i tunel Prenj", null, 1 },
                    { 11, true, 3, "Ukupni obim vanjskotrgovinske razmjene BiH u sektoru tekstila, odjeće, kože i obuće za devet mjeseci ove godine iznosio je 3.133.633.154 KM i veći je za 563.961.322 KM nego u istom periodu 2021. Također,pokrivenost uvoza izvozom iznosila 74,17 posto što je za 1,4 posto manje nego u istom periodu u 2021.godini.Izvoz cjelokupne industrije tekstila,odjeće,kože i obuće u navedenom periodu iznosio je 1.334.495.087 KM i veći je za 228.412.355 KM nego u istom periodu 2021.,te je zabilježen  porast izvoza od 20,65 posto.Uvoz cjelokupnog sektora je pratio povećanje izvoza te je i on srazmjerno povećan.U periodu od januara do septembra 2022.uvoz je realiziran u iznosu 1.799.138.067 KM i veći je za 335.548.968 KM ili 22,93 posto u odnosu na isti period 2021.Podaci su prezentirani na sjednici Odbora Asocijacije tekstila, odjeće, kože i obuće u Bosni i Hercegovini na kojoj je diskutovano o aktuelnoj problematici sektora u svjetlu globalne energetske krize, te o prijedlozima za prevazilaženje izazova s kojima se kompanije iz te branše svakodnevno susreću. Posebno su naglašeni problemi kao što su nedovoljna institucionalna podrška, sve veći deficit i odliv stručne radne snage, neusklađenost obrazovnih programa sa zahtjevima privrede i novih tehnologija, kvote za uvoz radne snage iz inostranstva, porast cijena energenata i repromaterijala, neizvjesnija potražnja za proizvodima na tržištu EU, nearshoring. Istaknuto je da, osim stalnih poskupljenja repromaterijala i energenata, ono na čemu treba također insistirati u narednom peridu je akutni nedostatak radne snage. Na sjednici je usvojen je i okvirni program rada Asocijacije za 2023.godinu.", new DateTime(2022, 11, 25, 20, 52, 51, 913, DateTimeKind.Local).AddTicks(4419), 22, null, null, null, "Izvoz u sektoru tekstila, odjeće, kože i obuće u devet mjeseci u BiH veći za 20,65 posto", null, 1 },
                    { 12, true, 3, "Telemach BH je u fokus svog poslovanja uvijek stavljao ljude i njihov doprinos izgradnji kompanije. Imajući to u vidu, Uprava Telemach BH je donijela odluku da će finansijski podržati sve svoje zaposlenike te im, poštujući Uredbu Vlade FBIH, isplatiti novčanu podršku sa ciljem lakšeg prevazilaženja rasta indexa potrošačkih cijena, uz istovremenu zahvalnost za predan rad tokom ove godine. Telemach BH zapošljava više od 650 zaposlenika. 'Iako je tehnologija izuzetno važna, ona daje samo dobar temelj, dok su ljudi nosioci ideja i inovacija koji svojim radom kreiraju preduslove za uspjeh. Kroz različite aktivnosti koje, kao jedan od najpoželjnijih poslodavaca na bh. tržištu preduzimamo, želimo da se naši zaposlenici ugodno osjećaju u radnom okruženju u kojem rade. Ova novčana podrška jedna je u nizu aktivnosti koje smo preduzeli tokom ove godine', naglasio je Admir Drinić, CEO Telemach BH.", new DateTime(2022, 11, 25, 20, 52, 51, 913, DateTimeKind.Local).AddTicks(4421), 22, null, null, null, "Telemach BH isplaćuje finansijsku podršku svojim radnicima", null, 1 },
                    { 13, true, 3, "Vlada Republike Srpske u sklopu Odluke o gasifikaciji tog bh. entiteta putem Investiciono-razvojne banke i njenih fondova, pokrenula je proceduru preuzimanja vlasništva nad Sarajevo gasom iz Istočnog Sarajeva. Za taj poduhvat, Vlada RS-a će uložiti 10 miliona KM. Takvom strateškom odlukom, namjeravaju kontrolirati gasnu mrežu u smislu kontrole njenog širenja od Šekovića do Istočnog Sarajeva, a dio plana je i da gasna mreža ide do Trebinja. Kompanija 'Sarajevo gas' iz Istočnog Sarajeva u vlasništvu je entitetskih fondova akcijskog, penzijskog i Fonda za restituciju u iznosu od 45 posto . Većinski vlasnici su investicioni fondovi, banke i mali akcionari, a njima je Vlada RS-a ponudila otkupnu cijenu u iznosu manjem od 1 KM za svaku dionicu. Moguće je otkupiti više od 9 miliona dionica. Dogovor je postignut, ali je potrebno da se o dogovoru izjasni još pet posto dioničara 'Sarajevo gasa' a.d. Istočno Sarajevo. 'Ovo je dobra odluka vlade. Preuzeli bi cijelu firmu, a samim tim 40 kilometara gasovoda koji vrijede oko 80 miliona KM, tako da je to zaista jedan dobar potez', kazao je Nedeljko Elek, direktor kompanije. Proces bi trebao biti završen u narednih nekoliko mjeseci, a isplata dioničara bit će obavljena preko fondova koji već upravljaju dijelom vlasništva kompanije. Svaki fond bi preuzeo po trećinu vlasništva ukoliko se svi dioničari jave na poziv za ponudu Vlade RS-a.Na sistem plinovoda bit će priključena i linija od Šekovića do Vlasnice. 'Ovdje u Istočnom Novom Sarajevu radimo gasifikaciju i tu ćemo cijelu općinu prikopčati na gas i treći projekat je gasifikacija općine Pale i Jahorine', najavio je direktor 'Sarajevo gasa' Istočno Sarajevo u razgovoru za RTRS.", new DateTime(2022, 11, 25, 20, 52, 51, 913, DateTimeKind.Local).AddTicks(4424), 22, null, null, null, "Vlada RS-a kupuje Sarajevo gas iz Istočnog Sarajeva za 10 miliona KM", null, 1 },
                    { 14, true, 1, "Mandatar za sastav nove Vlade RS-a Radovan Višković zahvalio je danas predsjedniku Srpske Miloradu Dodiku za povjerenje koje mu je ukazao dodijelivši mu mandat za sastav nove Vlade. 'Hvala predsjedniku na ukazanom povjerenju da mandat za sastav nove Vlade, poslije četiri godine, pripadne ponovo meni. U budućem periodu, to mi je velika čast i privilegija, ali i odgovornost', rekao je Višković. Višković, koji je na čelu Vlade bio protekle četiri godine, istakao je da je Vlada u ovom periodu ispunila data obećanja, trudeći se da očuva ekonomsku stabilnost i nadležnosti RS-a, prenio je RTRS. 'Naš cilj je socijalno pravednije i demografski održivo društvo. Očekujem od novih ministara da savjesno izvršavaju svoje obaveze', rekao je on.", new DateTime(2022, 11, 25, 20, 52, 51, 913, DateTimeKind.Local).AddTicks(4426), 22, null, null, null, "Milorad Dodik dodijelio mandat za sastav nove vlade RS-a Radovanu Viškoviću", null, 1 },
                    { 15, true, 4, "Prilika za najbolji shopping ove godine je tu – Black Friday ponude počinju u svim salonima namještaja Sinmax uz primamljive akcije i top uštede. Kako biste izbjegli velike gužve i borbe za posljednji komad po niskim cijenama, Sinmax saloni namještaja su pripremili nevjerovatna četiri dana fenomenalnih ušteda u novoj Black Friday ponudi. Ukoliko ste u potrazi za novom ugaonom garniturom, udobnim krevetom ili kuhinji po mjeri, samo u Sinmaxu možete pronaći niske cijene za svaku prostoriju Vašeg doma. Iz ponude izdvajamo: ugaone garniture već od šokantnih 499 KM kreveti sa cijenom već od 399 KM lazy bag za samo 39 KM Posjetite naše salone od petka do ponedjeljka(25.11. do 28.11.2022.) i ugrabite dugo priželjkivane proizvode po mrak cijenama. Čekamo Vas sa nevjerovatnim uštedama do 55 % na određeni asortiman.Uz stručnu pomoć našeg prodajnog osoblja, opremite svoj dom prema Vašim željama i pritom značajno uštedite.", new DateTime(2022, 11, 25, 20, 52, 51, 913, DateTimeKind.Local).AddTicks(4428), 22, 1, null, null, "Black Friday u Sinmax salonima namještaja", null, 1 },
                    { 16, true, 4, "Prilika za najbolji shopping ove godine je tu – Black Friday ponude počinju u svim salonima namještaja Sinmax uz primamljive akcije i top uštede. Kako biste izbjegli velike gužve i borbe za posljednji komad po niskim cijenama, Sinmax saloni namještaja su pripremili nevjerovatna četiri dana fenomenalnih ušteda u novoj Black Friday ponudi. Ukoliko ste u potrazi za novom ugaonom garniturom, udobnim krevetom ili kuhinji po mjeri, samo u Sinmaxu možete pronaći niske cijene za svaku prostoriju Vašeg doma. Iz ponude izdvajamo: ugaone garniture već od šokantnih 499 KM kreveti sa cijenom već od 399 KM lazy bag za samo 39 KM Posjetite naše salone od petka do ponedjeljka(25.11. do 28.11.2022.) i ugrabite dugo priželjkivane proizvode po mrak cijenama. Čekamo Vas sa nevjerovatnim uštedama do 55 % na određeni asortiman.Uz stručnu pomoć našeg prodajnog osoblja, opremite svoj dom prema Vašim željama i pritom značajno uštedite.", new DateTime(2022, 11, 25, 20, 52, 51, 913, DateTimeKind.Local).AddTicks(4428), 22, 1, null, null, "Black Friday u Sinmax salonima namještaja", null, 1 }

                 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
              table: "Articles",
              keyColumn: "Id",
              keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 15);
            migrationBuilder.DeleteData(
               table: "Articles",
               keyColumn: "Id",
               keyValue: 16);
        }
    }
}
