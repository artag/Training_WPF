# Getting Started with Prism


## Intro (Bootstrapper and Shell)

### The Building Blocks

* Shell
* Regions
* Modules
* Views
* Bootstrapper

### Bootstrapper

* Initializes application
* Core services
* Application specific services

#### Core Services

* `IModuleManager`
* `IModuleCatalog`
* `IModuleInitializer`
* `IRegionManager`
* `IEventAggregator`
* `ILoggerFacade`
* `IServiceLocator`

#### Bootstrapper Process

1. LoggerFacade
2. ModuleCatalog
3. Container
4. Region Adapter Mappings
5. Region Behaviors
6. Exception Types
7. Create Shell
8. Initialize Shell
9. Initialize Modules

### What is the Shell?

* Main Window/Page
* "Master Page"
* Contains **Regions**


## Regions

### What are Regions

* "Placeholder" for dynamic content
* No knowledge of views
* Create in code or in XAML
* Implements `IRegion`

### Region Manager

* Maintains collection of regions
* Provides a RegionName attached property
* Maps RegionAdapter to controls
* Provides a RegionContext attached property

### Region Adapters

#### ContentControlRegionAdapter

**ContentControl** - элемент управления с отдельным содержимым любого типа.

Наследование:
```
Object -> DispatcherObject -> DependencyObject -> Visual ->
-> UIElement -> FrameworkElement -> Control -> ContentControl
```

Производные классы (Region может быть установлен в объекты след. классов):
```
System.Activities.Presentation.WorkflowElementDialog
System.Activities.Presentation.WorkflowItemPresenter
System.Activities.Presentation.WorkflowItemsPresenter
System.Activities.Presentation.WorkflowViewElement
System.Activities.Presentation.View.ExpressionTextBox
System.Activities.Presentation.View.TypePresenter
System.Windows.Window
System.Windows.Controls.DataGridCell
System.Windows.Controls.Frame
System.Windows.Controls.GroupItem
System.Windows.Controls.HeaderedContentControl
System.Windows.Controls.Label
System.Windows.Controls.ListBoxItem
System.Windows.Controls.ScrollViewer
System.Windows.Controls.ToolTip
System.Windows.Controls.UserControl
System.Windows.Controls.Primitives.ButtonBase
System.Windows.Controls.Primitives.StatusBarItem
System.Windows.Controls.Ribbon.RibbonControl
System.Windows.Controls.Ribbon.RibbonGalleryItem
System.Windows.Controls.Ribbon.RibbonTabHeader
```

#### ItemsControlRegionAdapter

**ItemsControl** - элемент управления, который может быть использован для представления коллекции элементов.

Наследование:
```
Object -> DispatcherObject -> DependencyObject -> Visual ->
-> UIElement -> FrameworkElement -> Control -> ItemsControl
```

Производные классы (Region может быть установлен в объекты след. классов):
```
System.Windows.Controls.HeaderedItemsControl
System.Windows.Controls.TreeView
System.Windows.Controls.Primitives.DataGridCellsPresenter
System.Windows.Controls.Primitives.DataGridColumnHeadersPresenter
System.Windows.Controls.Primitives.MenuBase
System.Windows.Controls.Primitives.Selector
System.Windows.Controls.Primitives.StatusBar
System.Windows.Controls.Ribbon.RibbonContextualTabGroupItemsControl
System.Windows.Controls.Ribbon.RibbonControlGroup
System.Windows.Controls.Ribbon.RibbonGallery
System.Windows.Controls.Ribbon.RibbonQuickAccessToolBar
System.Windows.Controls.Ribbon.RibbonTabHeaderItemsControl
```

#### SelectorRegionAdapter

**Selector** - элемент управления, позволяющий пользователю выбрать один из его дочерних элементов.

Наследование:
```
Object -> DispatcherObject -> DependencyObject -> Visual ->
-> UIElement -> FrameworkElement -> Control -> ItemsControl -> Selector
```

Производные классы (Region может быть установлен в объекты след. классов):
```

System.Windows.Controls.ComboBox
System.Windows.Controls.ListBox
System.Windows.Controls.TabControl
System.Windows.Controls.Primitives.MultiSelector
System.Windows.Controls.Ribbon.Ribbon
```

#### TabControlRegionAdapter (Silverlight only)

### Custom Region

*Пример см. в `StackPanelRegionAdapter`.*

* Derive from `RegionAdapterBase<T>`
* Implement `CreateRegion` method
  * `SingleActiveRegion` - Region that allows a maximum of one active view at a time.
  * `AllActiveRegion` - Region that keeps all the views in it as active. Deactivation of views is not allowed.
  * `Region` - Implementation of `IRegion` that allows multiple active views.
* Implement `Adapt` method
* Register your adapter


## Modules

### What is Module?

* Building Block
* Class library/XAP
* Class that implements `IModule`

### Module Lifetime

1. Register Modules
2. Discover Modules
3. Load Modules
4. Initialize Modules

#### Register/Discover Modules

*Способы загрузки/поиска модулей.*

* ModuleCatalog
* Code
* XAML
* Configuration File (WPF)
* Disk (WPF)

#### Loading Modules

* From disk (WPF)
* Download from web (Silverlight)
* Control when to load
  * When available
  * On-demand

#### Guidlines for Loading Modules

*Загрузка модуля сразу или по требованию.*

* Required to run?
* Always used?
* Rarely used?

#### Initializing Modules

*Что можно делать при инициализации модуля.*

* `IModule.Initialize()` - здесь происходит инициализация (на момент создания видео) 
* Register types
* Subscribe to services or events
* Register shared services
* Compose views into shell

#### Примеры

Директория 02.Modules_Initialization.

* `LoadModulesInCode` - загрузка модуля из кода (требует reference на модуль).

* `LoadModulesFromDirectory` - загрузка модуля из определенной директории (не требует reference на модуль).
```
Post-build event для ModuleA:
xcopy "$(TargetDir)*.*" "$(SolutionDir)\PrismDemo\bin\$(ConfigurationName)\$(TargetFramework)\Modules\" /Y
```

* `LoadModulesFromXaml` - загрузка модуля из xaml-файла (не требует reference на модуль).

Не получилось загрузить точно таким способом (не нашелся файл ModuleA.dll по указанному неполному пути).
Загрузить удалось только указав полный путь на dll файл.
```
1. xaml-файл это Resource Dictionary (WPF)
2. Build Action на данный xaml-файл устанавливается в Resource (через Properties файла)

Post-build event для ModuleA:
xcopy "$(TargetDir)*.*" "$(SolutionDir)\PrismDemo\bin\$(ConfigurationName)\$(TargetFramework)\" /Y
```

* `LoadModulesFromAppConfigFile` - загрузка модуля из config-файла (не требует reference на модуль).
Все нормально заработало.
```
1. config-файл это Application Configuration File (в примере App.config).

Post-build event для ModuleA:
xcopy "$(TargetDir)*.*" "$(SolutionDir)\PrismDemo\bin\$(ConfigurationName)\$(TargetFramework)\Modules\" /Y
```

## Views

### What is a View?

* Portion of the user interface (в контексте Prism)
* Can be made of multiple views (Composite View)
* UserControl, Page, DataTemplate, etc... (что из себя может представлять)
* Multiple instances (м.б. несколько экземпляров одного View)
* Patterns not required (? т.к. уже некоторые паттерны реализованы в Prism?)

### View Composition

* Constructing of a view
* Made up of many visual elements
* Displayed in Regions
* Два способа создания View:
  * View Discovery
  * View Injection

### View Discovery

* Views added automatically (добавляются в регионы автоматически)
* `RegionManager.RegisterViewWithRegion(name, type)` (name - наименование Region, type - тип View)
* Region looks for view types
* No explicit control (нет явного контроля при создании View)
* View автоматически создается вместе с Region

### View Injection

* Views added programmatically ("ручками")
Два способа добавления:
  * `RegionManager.Region["Name"].Add(view, name)`
  * `IRegion.Add(view, name)`
* Activate/Deactivate (включение/выключение View при отображении в Region)
* More control (больше контроля над View)
* Can't add View to Region that hasn't been created (надо вручную создать View и добавить его в Region)

### Примеры

Директория 03.Views.

`CreatingView` - создание View без MVVM.
```
Особенности:
1. Регистрация модуля ModuleA из кода.
2. Использование StackPanelRegionAdapter (кастомный Region адаптер для StackPanel).
3. Демонстрация View Injection (двумя способами).
```

`CreatingView_MVVM` - создание View с MVVM. Традиционный подход.
```
Особенности:
1. Регистрация модуля ModuleA из кода.
2. `IView` имеет свойство `IViewModel`, `IViewModel` содержит свойство `IView`.
3. Регистрация в контейнере UserControl'а с интерфейсами `I...View` и `I...ViewModel`.
4. Демонстрация View Injection (двумя способами).
5. Для `ContentAView` демонстрируется установка свойства в его ViewModel.
```

`CreatingView_MVVM_ViewFirst` - создание View с MVVM. View ответственен за инициализацию ViewModel.
```
Особенности:
1. Регистрация модуля ModuleA из кода.
2. `IView` имеет свойство `IViewModel`, но `IViewModel` **не** содержит свойство `IView`.
3. Регистрация в контейнере UserControl'ов с интерфейсом `I...ViewModel`.
  Для View интерфейс не регистрируется.
4. Демонстрация View Discovery.
```

`CreatingView_ViewDiscovery` - создание View при помощи View Discovery (автоматическое добавление View в регион).
```
Особенности:
1. Регистрация модуля ModuleA из кода.
2. Использование StackPanelRegionAdapter (кастомный Region адаптер для StackPanel).
3. Используется полный MVVM.
```

`CreatingView_ViewInjection` - создание View при помощи View Injection (ручное добавление View в регион)
двумя способами.
```
Особенности:
1. Регистрация модуля ModuleA из кода.
2. Использование StackPanelRegionAdapter (кастомный Region адаптер для StackPanel).
3. Используется полный MVVM.
4. Демонстрация установки свойств во ViewModel.
5. Для ContentA демонстрация Deactivate старого View и создание и установка нового View (в тот же регион).
```

## Communication

*Изучение способов взаимодействия между модулями*

* Commanding
* Event Aggregation
* Shared Services
* Region Context

### Commanding Overview

*Краткий обзор*

* Binds a UI gesture to action (команда связывает UI и действия)
* Execute (к каждой команде привязан метод, который она выполняет)
* CanExecute (enable/disable command)
* RoutedCommand (команда маршрутизируется по дереву элементов)
* Custom Command (реализует `ICommand`)

### Commanding

*(какие команды есть в PRISM)*

* DelegateCommand (вызов delegate при выполнении команды)
* CompositeCommand (комбинирование нескольких команд)

### DelegateCommand

*Команда, которая использует делегаты.*

* Uses delegates
* Doesn't require a handler (не требует event handler'ов в коде)
* Usually local
  * Locally scoped
  * Обычно создаются во ViewModel
  * Обычно контекст использования ограничен ViewModel
* `DelegateCommand` or `DelegateCommand<T>`
  * T - тип передаваемого параметра в `Execute` и `CanExecute` методы

### CompositeCommand

* Usually global (обычно находится в общем (Common, Infrastructure, ...) классе)
* Multiple child commands (содержит множество дочерних команд)
* Local commands are registered with command
* When invoked, all child commands are invoked
* Supports enablement (если CanExecute какой-либо дочерней команды возвращает false, то CompositeCommand
  также начинает возвращать false).

Пример использования: реализация команды Save All для нескольких страниц.

### Event Aggregation

* Loosely coupled event based communication (основа - слабая связность на основе 
  механизма событий)

* Publisher and Subscribers 

* Manages memory related to eventing (может управлять подписками на события - не надо 
  вручную отписываться от событий).

### EventAggregator

*Основной сервис (резолвится из контейнера)*

* `IEventAggregator` - ответственен за нахождение, создание и хранение event'ов в системе.

* Multicast Pub/Sub (возможно использовать несколько publishers и subscribers).

* Events are typed events derivde from `EventBase`.

* `CompositePresentationEvent<T>` - основной класс.

* `<T>` is the required Payload - где Payload определяет, что посылается subsriber'у,
  когда event is published.

### IEventAggregator

*Возможности, которые обеспечивает этот интерфейс*.

* Publish events

* Subscribe to events

* Subscribe using a strong reference - `keepSubscribeReferenceAlive` (нужно вручную
  отписаться от события, когда уничтожается subscriber)

* Event filtering - возможно отфильтровывать события.

* Unsubscribe from events - "ручная" отписка от событий.

### Примеры

* `04.Commands\DelegateCommand` - пример использования `DelegateCommand` и `DelegateCommand<T>`
  T может быть либо reference, либо Nullable типа.
  ```
  Особенности:
  Используется валидация вводимых параметров (используется `IDataErrorInfo` для валидации
  Entity объекта и RaiseCanExecuteChanged() для обновления статуса команды).
  ```

* `04.Commands\CompositeCommand` - пример использования `CompositeCommand`
  ```
  Особенности:
  1. `CompositeCommand` находится в статическом классе, в "общем" проекте `Demo.Infrastructure`
  2. В `CompositeCommand` регистрируется команда `SaveCommand` (DelegateCommand)
  3. Регистрация производится в `PersonViewModel` (проект `Demo.People`)
  4. Кнопка "Save All" становится активной, когда активны все кнопки "Save" на всех вкладках.
  ```

* `05.EventAggregator\EventAggregator` - пример использования Event Aggregation.
  ```
  Особенности:
  1. Включает DelegateCommand и CompositeCommand, валидацию вводимых параметров.
  2. Создан класс `PersonUpdatedEvent`, наследник от `PubSubEvent`. Для generic T - 
  выбран тип `string`, т.к. будет передаваться имя Person.
  3. В PersonViewModel через `IEventAggregator` выполняется publish события
  `PersonUpdatedEvent` куда передается имя сохраненного Person.
  4. В StatusBarViewModel через выполняется подписка `IEventAggregator` на событие
  `PersonUpdatedEvent` и добавление обработчика данного события.
  ```