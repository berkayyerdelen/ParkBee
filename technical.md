## Technical questions

1. What architectures or patterns are you using currently or have worked on recently?
- I'm using Layered pattern mostly and implementing onion architecture also using CQRS, Mediator, DDD and TDD, CanExecute as a pattern.

2. What do you think of them and would you want to implement it again?

- It helps enforce Single Responsibility Principle and Separation of Concern (Each request is independent of other requests, helping to build ravioli code instead of spaghetti code)
- You can add your cross cutting concerns into the Mediatr pipeline (The mediatr pipeline provides the ability to run cross cutting concerns (eg. logging, performance checks, auth checks, validation) for ALL requests)
- Dependency injection of required services per command/query (This helps to avoid having a controller constructor as a dumping ground for every request)
- Ensures that your controllers aren't doing any business logic - they are just adapters for user requests to application code (application logic should sit in the application project)
- Solving complex problems(DDD)
- TDD is also increasing code quality, good documentation for new commers, reassurance when refactoring, encourages better design, oh yeah and redecue bugs:). at the end of day these methods say "hey your code is okey and I'll be same in the production env" so it reduce fear

3. What version control system do you use or prefer?
- Git. Tbh I havent used SVN, TFS and others but I can cleary say that Git is easy to understand and Visual studio extension is quite reliable.

4. What is your favorite language feature and can you give a short snippet on how you use it?
- LINQ => Probably I wouldnt survive without it:) LINQ is not here for only object manipulation but also provide manipulation of sql, dataset xml and even entity. I also write java and obiviosly Stream Api can't even reach to LINQ level.

5. What future or current technology do you look forward to the most or want to use and why?
- There are so many technologies that I want to work on it but the real question is do we rly need them in our production.
I want to work on project what they really need. If microservice is needed? then fine but I need to understand why we need to implement it then any new technologies fine for me.

6. How would you find a production bug/performance issue? Have you done this before?
I'll try to explain it step by step but before jump in I want say that I did it from developer perspective.
  Developer perspective for finding bug issue
- Need usefull loging system. (meaningful logs) => You can seperate your exceptions to layer spesific and use some usefull words in your log messages.
- Identity and make them uniqe
- Unit tests but it will not be enough so you have also good understanding business logic. Anyway Unit test can pass since they test only smaller units in your app lvl so  next step would be Integration tests. 
- Let say 2+2 = 4  but also 2*2= 4 so result will be same and unit tests will pass but if u identify arithmetic operator here  such as validate operator then you will find the root cause
- Debugging (writing integration test can be so usefull for this case:) instead of debugging entire app)

Developer perspective for finding performance issue
- There has to be maximum response time for any call. Let call it avarage
- Let say in EF you need to retrive some data from table. and u're writing query like this. _context.set<TEntity>().ToList().where(x=>x.propertyname== ""); 
so in sql profiler you will see this query like this "select * from TableName" obiviosly its not ef mistake. 
We could also write like this _context.set<TEntity>().where(x=>x.propertyname== "").ToList(); so query will be "select * from TableName t where  t.propertName ="""
- Another example would be like this. _context.set<TEntity>(); and then using properties. but what if we only need few columns? _context.set<TEntity().Select(x=>x.propertyName);
but actually you only need few columns so query would be like this in sql "select t.propertyX, t.properyY from TableName t;
As a result We need to understand why we're using tools.

7. How would you improve the sample API (bug fixes, security, performance, etc.)?
- I would fallow the 6 again.



