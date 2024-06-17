## TODO

- Add webapplication tests
- Add sqllite with entityframework core

## Intro and choice

This is my delivery as per the instructions of the email, which I have pasted below.

I decided to do this as a web api before I saw that you wanted PosOrdrer as well and to use abstract classes,
so I just made the api polymorphic, as you can do as per .NET 7

Was considering using a minimal API instead of conventional controllers, but i decided that conventional controllers is
the most common one so tought it was the most valuable competency to display

Started with just using autofixture to generate the data as per normal testing conventions, however might decide later
to use sqllite and entityframework

Decided to make the `CalculateOrderTotal` to be a private method on the abstract class to be called, so that the order
Total is never out of sync

When testing the API, the order ids will be in the range 1 - 20, customersIds 1 - 10, productIds 1 - 4

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

- [ ] **GetTopSellingProducts** - Lag en metode som returnerer de 5 mest solgte produktene, inkludert salgsinntekter per
  produkt. Velg selv om metoden skal returnere en ny klasse du definerer, en dictionary, value tuple eller lignende.