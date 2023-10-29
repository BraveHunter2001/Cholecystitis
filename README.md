# Cholecystit
Это лабораторная работа №1 по предмету **Разработка приложений в распределенной среде**  

**Задание**: Сделать CRUD сервис по предметной области медицина (Холецистит)  
**Описание моделей:**  https://docs.google.com/document/d/12OjY-Nu4fDHk5Q9yg30Ez50sopchGazuBVxQ23PmZq0/edit?usp=sharing  

**Краткая информация:**  
Данный проект можно запустить в докере, чтобы не скачивать postgres себе на компьютер.  
В первом контейнере будет лежать сервис,  
во втором будет лежать база данных postgres,  
в третьем лежит клиент для просмотра базы данных pgAdmin. 

**Описание api:**  
Контроллер для модели Cholecystit. Более подробное описание лежит в Swagger
1. [POST] /api/Cholecystitis - создание модели | **Body** - json 
2. [Get] /api/Cholecystitis/{id} - получение модели по id, где id это GUID
3. [PUT] /api/Cholecystitis/{id} - обновление модели по id | **Body** - json
4. [DELETE] /api/Cholecystitis/{id} - удаление модели по id

**Инструкция по запуску через Docker:**  

0. Скачиваем и устанавливаем себе Docker https://www.docker.com/products/docker-desktop/
1. Клонируем `git clone https://github.com/BraveHunter2001/Cholecystitis.git`.
2. В корне выполняем `docker compose up`.
3. Чтобы проверить работоспособность:
   * Swagger по `https://localhost:5001/swagger/index.html` или `http://localhost:5000/swagger/index.html`.
   * Postman. В репозитории лежит **Cholecystitis.postman_collection.json**. Импортируете его себе в Postman.
   * Что-то другое, то url api = `https://localhost:5001/api/` или `https://localhost:5001/api/`
4. Подключение к БД:
   * pgAdmin. url `http://localhost:5050/browser/` креды к базе через pgAdmin: Server=**postgres**;Port=**5432**;Database=**cholecystitis**;User ID=**pguser**;Password=**pgadmin**;
   * Через внешнее, то замените Server=**postgres** на **localhost**
      
