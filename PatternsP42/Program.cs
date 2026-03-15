// See https://aka.ms/new-console-template for more information
using PatternsP42.Structural;


Console.WriteLine("Hello, World!");



/*
 * Породжувальні патерни (Creational Patterns) 
 * - це категорія шаблонів проектування, які зосереджені на процесі створення об'єктів.
 * Вони допомагають керувати складністю створення об'єктів, 
 * забезпечуючи гнучкість та повторне використання коду. 
 * Основні порожувальні патерни включають:
 * 
 * - Singleton (Одинак)
 * - Factory Method (Фабричний метод)
 * - Abstract Factory (Абстрактна фабрика)
 * - Builder (Будівельник)
 * - Prototype (Прототип)
 */

//void Method()
//{
//    var singleService2= SingleService.Instance;
//    singleService2.DoSomething();
//}


//Console.WriteLine("Start");

//Console.WriteLine("Press any key to create the first instance of SingleService...");
//Console.ReadKey();


//var singleService1 = SingleService.Instance;
//singleService1.DoSomething();


//Thread.Sleep(2000);
//Method();


// Factory Method (Фабричний метод)

//void SendMessage(string message, SenderCreator creator)
//{
//    var sender = creator.CreateSender();
//    sender.Send(message);
//}

//var emailCreator = new EmailSenderCreator("smtp.example.com", 587);
//var smsCreator = new SmsSenderCreator("api-key", "+1234567890");
//var telegramCreator = new TelegramSenderCreator("bot-token", "chat-id");


//SendMessage("Hello, this is a test email.", emailCreator);
//SendMessage("Hello, this is a test SMS.", smsCreator);
//SendMessage("Hello, this is a test Telegram message.", telegramCreator);


//// Abstract Factory (Абстрактна фабрика)

//Site CreateSite(SiteFactory factory)
//{
//    return new Site()
//    {
//        Button = factory.CreateButton(),
//        TextBox = factory.CreateTextBox(),
//        Label = factory.CreateLabel()
//    };
//}


//Console.WriteLine("Select theme: Light, Dark, Green, DarkGreen");
//var theme = Console.ReadLine();

//SiteFactory factory = theme switch
//{
//    "Light" => new LightSiteFactory(),
//    "Dark" => new DarkSiteFactory(),
//    "Green" => new GreenSiteFactory(),
//    "DarkGreen" => new DarkGreenSiteFactory(),
//    _ => throw new ArgumentException("Invalid theme")
//};

//var site = CreateSite(factory);
//site.Render();


//Car BuildCar(CarBuilder builder)
//{
//    builder.BuildWheel();
//    builder.BuildEngine();
//    builder.BuildExtraOptions();
//    return builder.GetCar();
//}


//// Створити електричний автомобіль з колесами 18R та шкіряними сидіннями та Sunroof.

//var car1 = BuildCar(new ElectricCarBuilder());
//car1.PrintDetails();

//// Створити з звичайним двигуном та колесами 16R .
//var car2 = BuildCar(new StandardCarBuilder());
//car2.PrintDetails();



//// Прототип (Prototype)

//var prototypeCircle = new Circle(5, "Red");


//var clonedCircle = new Circle(prototypeCircle);


//IReadOnlyApiRequest request = new ApiRequestBuilder()
//    .SetBaseUrl("https://api.example.com")
//    .SetMethod("POST")
//    .SetBody("{ \"name\": \"John\", \"age\": 30 }")
//    .Build();

//var writableRequest = request as ApiRequest;
//writableRequest.Url = "https://api.example.com/users";

//Console.WriteLine(request);

//var request2 = new ApiRequestBuilder()
//    .FromRequest(request)
//    .SetMethod("GET")
//    .Build();

//Console.WriteLine(request2);


// Структурні патерни (Structural Patterns)

// Адаптер (Adapter)


//var car = new Car { Engine = new PetrolEngine() };
//car.Use();

//var electricCar = new Car { 
//    Engine = new ElectricEngineAdapter(new ElectricEngine())
//};
//electricCar.Use();

// Міст (Bridge)

//var fileManager = new FileManager(new JsonDataFileReader(), new JsonDataFileWriter());
//var data = new Data { Title = "Sample Title", Content = "Sample Content" };
//fileManager.SaveData("data.json", data);
//var readData = fileManager.LoadData("data.json");

// Композит (Composite)

/*Структура компанія
 *
 * Директор
 * Заступник директора  Заступник директора
 * Бухгалтерія       Відділ продажів Відділ розробки Відділ маркетингу
 *                                                  Відділення 1 Відділення 2 Відділення 3
 * 
 */

//var direktor = new Manager("Директор", 100000);

//var zastrupnik1 = new Manager("Заступник директора 1", 80000);
//direktor.AddChild(zastrupnik1);

//var buchgalteriya = new Department("Бухгалтерія");
//zastrupnik1.AddChild(buchgalteriya);
//var otdelMarketing = new Department("Відділ маркетингу");
//zastrupnik1.AddChild(otdelMarketing);

//var zastrupnik2 = new Manager("Заступник директора 2", 80000);
//direktor.AddChild(zastrupnik2);

//var otdelProdazh = new Department("Відділ продажів");
//zastrupnik2.AddChild(otdelProdazh);
//var otdelRazrabotki = new Department("Відділ розробки");
//zastrupnik2.AddChild(otdelRazrabotki);

//var videlenie1 = new Department("Відділення 1");
//otdelRazrabotki.AddChild(videlenie1);

//var developer1 = new Employee("Розробник 1", 50000);
//videlenie1.AddChild(developer1);
//var developer2 = new Employee("Розробник 2", 50000);
//videlenie1.AddChild(developer2);
//var developer3 = new Employee("Розробник 3", 55000);
//videlenie1.AddChild(developer3);

//var videlenie2 = new Department("Відділення 2");
//otdelRazrabotki.AddChild(videlenie2);
//var developer4 = new Employee("Розробник 4", 45000);
//videlenie2.AddChild(developer4);
//direktor.Display();

// Декоратор (Decorator)


var pizza = new Pizza();

Action <IPizza> printPizzaInfo = p => Console.WriteLine(p.GetDescription() + " costs " + p.GetCost());

//printPizzaInfo(pizza);

//var pizzaWithCheese = new PizzaDecorator(pizza, "with cheese", 2.00m);
//printPizzaInfo(pizzaWithCheese);

//var pizzaWithPepperoni = new PizzaDecorator(pizzaWithCheese, "with pepperoni", 3.00m);

//printPizzaInfo(pizzaWithPepperoni);

//var pizzaWithCheeseAndPepperoni = new PizzaDecorator(pizzaWithPepperoni, "with extra cheese", 1.50m);

//printPizzaInfo(pizzaWithCheeseAndPepperoni);

//var pizzaWithDiscount = new DiscountPizzaDecorator(pizzaWithCheeseAndPepperoni, 10m);
//printPizzaInfo(pizzaWithDiscount);

//var pizzaWithMoreDiscount = new DiscountPizzaDecorator(pizzaWithDiscount, 5m);
//printPizzaInfo(pizzaWithMoreDiscount);


//var basePizza = new Pizza();

//var myPizza = new DiscountPizzaDecorator(
//    new PizzaDecorator(
//        new PizzaDecorator(
//            new PizzaDecorator(
//                basePizza,
//                "with extra cheese", 1.50m),
//            "with cheese", 2.00m), 
//        "with pepperoni", 3.00m), 
//    15m);

//printPizzaInfo(myPizza);


// Фасад (Facade)

var clientCode = new ClientCode(new ComplexLibraryFacade());
clientCode.Execute();

var clientCode2 = new ClientCode(new ComplexLibrary2Facade());
clientCode2.Execute();



// Легковаговик (Flyweight)






// Замісник (Proxy)


