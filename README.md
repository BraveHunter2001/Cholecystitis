# Cholecystit
Это лабораторная работа №1 по предмету **Разработка приложений в распределенной среде**  

**Задание**: Сделать CRUD сервис по предметной области медецина (Холецистит)  
**Описание моделей:**  https://docs.google.com/document/d/12OjY-Nu4fDHk5Q9yg30Ez50sopchGazuBVxQ23PmZq0/edit?usp=sharing  

**Краткая информация:**  
Данный проект можно запустить в докере, чтобы не скачивать postgres себе на компьютер и облегчить запуск этого веб приложения.  
В первом контейнере будет лежать сервис,  
во втором будет лежать базаданны postgres,  
в третьем лежит клиент для просмотра базы данных pgAdmin. 

**Описание api:**  
Контроллер для модели Cholecystit. Более подробнее описание вы можете найти в Swagger
1. [POST] /api/Cholecystitis - создание модели | **Body** - json 
2. [Get] /api/Cholecystitis/{id} - получение модели по id, где id это GUID
3. [PUT] /api/Cholecystitis/{id} - обновление модели по id | **Body** - json
4. [DELETE] /api/Cholecystitis/{id} - удаляет модель по id

**Инструкция по запуску через Docker:**  

0. Скачиваем и устанавливаем себе Docker https://www.docker.com/products/docker-desktop/
1. Клонируем себе этот репоизорий `git clone https://github.com/BraveHunter2001/Cholecystitis.git`.
2. В корне репоизория выполняем команду `docker compose up`, у вас должен собраться три контейнера.
3. Чтобы проветить работоспособность:
   * Сделать запросы через Swagger по `https://localhost:5001/swagger/index.html` или `http://localhost:5000/swagger/index.html`.
   * Можно сделать запросы через Postman. В репозитории лежит файл **Cholecystitis.postman_collection.json**. Импортируете его себе в Postman и выполняете запросы
   * Если чeрез что-то другое, то url api = `https://localhost:5001/api/` или `https://localhost:5001/api/`
   * Также вы можете проверить саму базу данных через pgAdmin. url `http://localhost:5050/browser/`
     креды к базе: Server=postgres;Port=5432;Database=cholecystitis;User ID=pguser;Password=pgadmin;
      
