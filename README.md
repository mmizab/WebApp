### 1 - Craete Database With Docker
docker run --name mariadb -v mariadb:/var/lib/mysql -p 3306:3306 -e MYSQL_ROOT_PASSWORD=SpeedStar2020 -d mariadb:latest 


Also you have to create the database named **webapp**


### 2- Setup the appsettings.json pointing to the docker machine
"WebAppContext":  "Server=192.168.99.100; Port=3306; Database=webapp; Uid=root; Pwd=1;"


### 3- Open Nuget Console and execute the following
Update-database
