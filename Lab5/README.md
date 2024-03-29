# Report for Lab 5


<br/>

# Структура проекту

Створюємо бібліотеку класів - це перший проект де будуть файли лаб 1-3

![](./assets/image.png)

Налаштовуємо шлях

![](./assets/init0.jpg)


Далі створюємо `ASP.NET MVC` - це другий проект


![](./assets/create_second_project.jpg)


![](./assets/prepare_second.jpg)


Загальна структура проекту тепер має такий вигляд

![](./assets/general_struct.jpg)


Локально - простий сервер вже працює


![](./assets/local_quick_test.jpg)


<br/>


# Підготовка серверу OpenID & OpenAuth

У якості такого - скористаємось послугами [`Auth0`](https://auth0.com)

![](./assets/auth0.jpg)

Я зробив вхід через GitHub

![](./assets/via_github.jpg)


Далі слідуємо вказівкам туторіалу


![](./assets/tutorial_auth0.jpg)

Обираємо відповідне

![](./assets/app_type.jpg)

Проводимо налаштування форми входу

![](./assets/custom_enter.jpg)


Після створення вашого проекту - він з'явиться тут

![](./assets/auth0_dashboard.jpg)


Додатково ще треба перейти в `Налаштування` та внести зміни для редіректів після логіну та логауту

![](./assets/redirs.jpg)


![](./assets/change_redirs.jpg)

<br/><br/>

# Додавання залежностей

Повертаємось у `Visual Studio` і додаємо залежність

![](./assets/auth0_dependency.jpg)


<br/>

<div align="center">

> **Warning**
> Наступна частина передбачає що ви вже написали MVC і файли лабораторних 1-3

</div>

<br/><br/>

# Запуск додатку

Vagrantfile налаштований на запуск Debian і працює в одну команду. Під капотом - встановлення `.NET` та `Git`, клонування цього репозиторію, перехід в директорію та запуск `dotnet run`.


Таким чином - перейдіть в директорію `VagrantFiles` і запустіть

```shell
vagant up
```

Очікуйте появи такого в консолі

![](./assets/post_launch.jpg)


Тепер можна переходити в браузер

<br/><br/>


# Тест в браузері

Без входу в акаунт маєте побачити таке:

![](./assets/no_auth.jpg)


Без входу в акаунт - ви не зможете перейти на сторінки профілю чи лабораторних. Вас одразу перекине на форму входу. Спробуйте

![](./assets/try_auth.jpg)

Потім - перекине назад

![](./assets/redir_back.jpg)

Тепер ви маєте побачити сторінку з успішним статусом та список лабораторних + шлях до них + короткий опис


![](./assets/after_auth.jpg)


<br/><br/>

# Тестування сторінок


### Lab1


![](./assets/lab1_preview.jpg)

![](./assets/lab1_result.jpg)

### Lab2

![](./assets/lab2_preview.jpg)

![](./assets/lab2_result.jpg)

### Lab3

![](./assets/lab3_preview.jpg)

![](./assets/lab3_result.jpg)


<br/><br/>

# Сторінка профілю

Також, користувач який увійшов може переглянути свій профіль

![](./assets/profile_page.jpg)


# Додатково

Приклади `input.txt` для лабораторних 1-3 знаходяться в диреторії `ExamplesOfInputFilesForTasks`. Всередині своєї машини створіть такі файли, візьміть контент з цих і тоді вказуйте шлях у полях вводу на сторінках виконання лабораторних