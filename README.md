asp.net 6.0 , entityframeworkcore e-commerce backend project

# **Introduction**

In this project, it is aimed to create the rest web service that should be on the basic e-commerce site are written in a simple way. **The project contains only the backend part, the relevant views have not been written**.

The apis were tested via postman.


There are 2 main assets in the project. These are the category and the product. Code first approach is implemented for storing data in db. The relationship between entities are arranged for one-to-many relationship.User and role tables are implemented with IdentityDbContext class. Entities are not used for data transmitting in api. The operations are posted with DTO objects.




![db diagram](https://user-images.githubusercontent.com/72139693/223053186-c6d960d5-a6d3-46c0-99df-9837a5ebbf42.PNG)





## **Authorization/Authentication**

To provide cookie based Authentication, Identity packages are used.
There are 3 different roles in the project. These roles and the competencies are, 

  #### **User**

- User can access only the product controller.

- Shopping cart (COMING SOON)


#### **Operator**

- Operator can access the Operator conroller. That controller includes product managements operations.

#### **Admin** 

- Admin can access Admin controller and other controllers. Admin controller includes user managements operations.


## **Controllers**

#### **ProductController**

- **getproducts() :** gets all the products from database which is active.

- **productdetail(id) :** gets the specified product according to id. 

- **productsbycategory(category_id) :** gets the products according to relevant category by category_id.


#### **AccountController**


- **register(registerDTO) :** gets the registerdto and checks the validations and some rules then sign up.

- **login(loginDTO) :** gets the logindto and check the db to authenticate then sign in.

- **logout() :** removes the cookie and sign out.


#### **OperatorController (authorizated for operator and admin)**

- **AddCategory(category):** add category to db 

- **PostProduct(addproductDTO):** post new product to db.

- **deleteProduct(id) :** delete operations are performed with **softdelete** approach.

- **activeproduct(id) :** to activate the product this operations is performed.


#### **AdminController (authorizated for admin)**

- **getusers() :** gets all the user from db with using UserManager class.

- **deleteuser(deleteUserDTO) :** delete user from database with using UserManager class.

- **getuser(id) :** gets the specified user in database by using the id.

- **assingRole(assignUserDTO)**: admin assigns a role for the the specified user in system and previous role is deleted.
