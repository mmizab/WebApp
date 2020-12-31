# Setup
### 1 - Craete Database With Docker
docker run --name mariadb -v mariadb:/var/lib/mysql -p 3306:3306 -e MYSQL_ROOT_PASSWORD=1 -d mariadb:latest --restart always 


Also you have to create the database named **webapp**


### 2- Setup the appsettings.json pointing to the docker machine
"WebAppContext":  "Server=192.168.99.100; Port=3306; Database=webapp; Uid=root; Pwd=1;"


### 3- Open Nuget Console and execute the following
Update-database

# Views and Controllers
### Home Controller
The home page it contains the list of the posts that the admin created.
### Admin Controller
Admin section secured with cookie authentication. At this section you can add posts.
### Account Controller
Manages the logic of the cookie authentication.
# Cookie authentication
Implemented to secure some of the endpoints such as admin section, its implmented on Startup.cs and the AccountController, there is the logic for the authentication.
