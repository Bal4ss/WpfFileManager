# WpfFileManager

Файл локализации: `[project]\config\text.json`

Пример структуры файла локализации:

```JSON
[
  {
    "Id": "cbbfd588-2b18-4224-93c0-4b869fbd9e48",
    "TextValues": {
      "ru": "Поиск"
    }
  }
]
```

Выбор языка локализации `[project]\[project].exe.config` (конфигурационный файл проекта):

```XAML
<add key="language" value="ru"/>
```

Настройки подключения к базе данных `[project]\[project].exe.config` (конфигурационный файл проекта).
