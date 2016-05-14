# webkurs-mai-2016-sogndal
Arjans filer fra kurset


## Oppdatere nodejs
1. Hent og installer den nyeste versjon av nodejs fra https://nodejs.org/en/
2. Finn folderen som node ble installert i. (Antakelig i `C:\Program Files (x86)\nodejs`.) Kopier filstien til clipboarden.
3. I Visual Studio, velg `Tools` / `Options`. Finn frem til `Projects and Solutions` noden, og legg til filstien fra forrige steg 2 __øverst__ i listen.


## Sette opp Imdb-databasen
Prosjektet avhenger av databasen Imdb. Den kan du legge inn i en SQL Server vha. Imdb.dacpac filen som ligger på rot i prosjektet.


### Du trenger SQL Server Data Tools (SSDT)
SSDT er en komponent i Visual Studio. Hvis du ikke har SSDT installert allerede, kan den installeres fra "Programs and Features" i kontrollpanelet slik:

1. Lukk Visual Studio.
2. Dobbeltklikk på `Microsoft Visual Studio Enterprise 2015` (eller hvilken version du har) i listen under `Uninstall or change a program`. Dette skal bringe opp en gra/svart Visual Studio installer.
3. Velg `Modify`, så i trestrukturen under `Windows and Web Development` krysser du av for `Microsoft SQL Server Data Tools`.
4. Klikk `Next` og på neste side klikk `Update`.
5. Hent kaffe mens installasjonen pågår ;)


### Installere database fra .dacpac-filen
1. Åpne Visual Studio igjen.
2. I `Views` menyen, velg `SQL Server Object Explorer`.
3. I selve SQL Server Object Explorer vinduet, naviger til en SQL Server du vil installere på og høyreklikk på `Databases`noden.
4. Velg `Publish Data Tier Application...` fra contaxt menyen.
5. I påfølgende dialog velger du hvilken .dacpac fil fra disk du skal åpne, og hva databasen skal hete. (Og ja: Det er `Imdb.dacpac` i solution folderen, og `Imdb` er et godt navn på databasen...)
6. Når importen er ferdig, refresher du databaselisten i Sql Server Object Explorer vinduet. Da skal den nye databasen ligge der.


### Sette riktig Connectionstring i konfigurasjonsfilen i prosjeketet.
1. Høyreklikk på Imdb-databasen i SQL Server Object Explorer og velg `Properties`. I properties-vinduet finner du Connectionstring, og kopier verdien her inn i konfigurasjonsfilen i prosjektet. (I `src/ImdbWeb/config.json`)


