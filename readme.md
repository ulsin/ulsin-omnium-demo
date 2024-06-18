## Intro and choices

This is my delivery as per the instructions of the email, which I have pasted below.

When testing the API, the order ids will be in the range 1 - 20, customersIds 1 - 10, productIds 1 - 10

I decided to do this as a web api before I saw that you wanted PosOrder as well and to use abstract classes,
so I just made the api polymorphic, as you can do as per .NET 7

Was considering using a minimal API instead of conventional controllers, but I decided that conventional controllers is
the most common one so thought it was the most valuable competency to display

Started with just using AutoFixture to generate the data as per normal testing conventions. I thought about using
SqlLite and EntityFramework, but as the task is fine with mocking and EntityFramework not really showing Data Modeling
nor SQL competency, then I decided not to spend time on that

Decided to make the `CalculateOrderTotal` to be a private method on the abstract class to be called, so that the order
Total is never out of sync

Also added a test project with `WebApplicationFactory` tests to display competency of how to get test coverage even
of the controller whilst having the code being run as unit tests that are getting

I didn't bulletproof the tests as much as I could have, but it was more as a proof of concept, as I've seen not many
know of the `WebApplicationFactory` feature, and I did achieve 100% test coverage (at least per the `dotCover` plugin),
which felt nice.

Also, could have used primary constructors but decided not to, as they can seem strange to some, and hides use of
conventional private readonly fields.

Also, I wrote this readme in english, as when I am coding I often hop into the language gear, but I have no issues
writing and reading code and documentation in both english and norwegian

Ulrik Bakken Singsaas

## Task

- [x] **Order** - Opprett en klasse "Order". Denne skal minst inneholde OrderId, CustomerId, CustomerName, Total og en
  liste
  av varelinjer av type OrderLine. OrderLine skal minst bestå av Quantity, Price, OrderLineId, ProductName, ProductId.

- [x] **GetOrders** - Lag en metode som returnerer en liste av ordreobjekter - du kan enten hardkode objektene, lage en
  metode som genererer tilfeldig ordredata, hente data fra et API eller fra en database.
  For enkelhetens skyld skal oppgave 4 til 8 bruke GetOrders som grunnlag for data. Du kan da godt kalle på GetOrders i
  hver enkelte metode - akkurat dette er ikke så viktig.

- [x] **CalculateOrderTotal** - Lag en metode som kalkulerer order.Total basert på varelinjers pris og antall.

- [x] **GetOrder** - Lag en metode som henter ut en enkelt ordre med en gitt Id.

- [x] **GetOrdersByCustomerId** - Lag en metode som henter ut alle ordre med en gitt kunde

- [x] **GetOrdersByProductId** - Lag en metode som henter ut alle ordre som har en eller flere ordrelinjer med en gitt
  produkt-Id.

- [x] **PosOrder** - Opprett en ny klasse "PosOrder" (Point of sales - kassaapparat/terminal). Denne skal inneholde de
  samme
  egenskapene som Order, men har i tillegg egenskapen "PosId". Skriv om metodene slik at de også kan benytte av typen
  PosOrder.

- [x] **GetTopSellingProducts** - Lag en metode som returnerer de 5 mest solgte produktene, inkludert salgsinntekter per
  produkt. Velg selv om metoden skal returnere en ny klasse du definerer, en dictionary, value tuple eller lignende.