# smartphone-clock-application
Documentation for the architecture used for this smartphone clock application.

![Timer](https://github.com/joelnl74/smartphone-clock-application/assets/9337898/ca83257e-26cb-4067-a88a-80e9c1b019bb)
![Clock](https://github.com/joelnl74/smartphone-clock-application/assets/9337898/f2911fef-366d-47f2-880e-5a427b2cd97b)
![Stopwatch](https://github.com/joelnl74/smartphone-clock-application/assets/9337898/9b39a4bb-715d-497a-aa5e-b54da7f130e5)

## Schedule
- Reading assignment: ~15 min
- Documentation: ~30 min
- Tests: ~3 hours
- Implementation: ~4 hours
- Testing on multiple devices: ~30min
- Total 8-9 hours

## Tools
- Unity 2021.3.4f1
- Zenject
- UniRX
- NSubstitute
- Nunit

## Projects
- Project main application
- Edit tests edit time tests
- play tests play mode tests

## Features
- Clock
- Timer
- Stopwatch
- Object pooling
- Tab view
- Audio
- Button styling

## Architecture
- MVVP architecture using dependency injection
- Model -> contains the data shown to the user
- View controller -> Entry point for every page in the application and handles the events used in the view level
- View -> visual representation of the data provided by the presenter
- Presenter -> responsible for loading and changing the data and sending it to the view.
- Mappers are responsible for mapping the initial data or combining data together from multiple data sources (If we would do back-end API calls this would Map to view models)
 
 ### Main pages/Entry points
- MainUIViewcontroller - ClockPresenter - ClockView - ClockModel
- MobileClockViewController - ClockPresenter - ClockView - ClockModel
- MobileStopWatchViewController - StopWatchPresenter - StopWatchView - TimerModel/TimerLapModel
- MobileTimerViewController - TimerPresenter - TimerView - TimerModel
- Installers (Zenject dependencies binding) AudioMonoInstaller, MobileTimerMonoInstaller, MainMonoInstallerTests
### Base classes
- Every presenter inherits from the class Presenter which contains a method to bind a generic view
- Every view controller inherits from the view controller which makes sure contract interfaces are respected and can bind the view to the presenters (the view has no information about the presenter)
- Every view inherits from base view 

### Performance
- The lap view makes use of object pooling so we can reuse the created game objects after a reset

### Main folder structure
- script/test: Core folders contain generic implementations like object pooling, base view, main navigation, base presenter, base view controller
- script/test: MobileClock contains the specific implementation for the different pages: clock, timer. stopwatch
- script/test: Audio is the audio system used
- Textures
- Prefabs
- Audio folder containing audio files
- Scriptable objects used as settings for different elements in the game for example button styles and audio definitions
- Scenes
- Resources

## Tested
- Made use of play mode and edit mode unit testing using the Arrange Act Assert pattern
- Samsung s9
- Ipad pro M1 
- Windows pc
- Macbook M1 generation
Edit time test results
  ![EditTimeTests](https://github.com/joelnl74/smartphone-clock-application/assets/9337898/c2e7bf4a-ba93-4f00-b697-1e5e73258f9e)
Run time test results
![RunTimeTests](https://github.com/joelnl74/smartphone-clock-application/assets/9337898/34a12de1-ffc6-4e08-91dd-8f74ce1a5e56)
## iOS/iPad devices. Do you have any concerns about UI?
- Depending on the requirements landscape vs. portrait mode UI design and implementation need to be taken into account.
- Mobile devices support a vast range of screen resolutions and sizes and can be difficult within Unity to get right, a system to make this more easier or automatically adjustable from code is favorable like a screen wrapper.
- Some mobile devices have safe areas that have to be taken into account when designing applications or UI.
## How would you refactor the code and/or project after release? What would you prioritize as “must happen” versus “nice to have” changes
### Must
- Requirements for different devices it has to support (landscape/portrait/vs/mobile/pc)
- Work on more options for interaction with the UI now it mostly consists of buttons but for some devices, it might be more intuitive to also have other options for interactions with the UI.
- Global navigation structure (navigation controller) Currently all pages are present in the scene but it is more favorable to have one system that can create the pages on startup this would also allow for the creation of different views or settings based on the user's device. The view logic can then be determined based on Zenject injection while the assets can use a unity addressable bundle system for resource and memory management.
- UX research to make a valid UI design for the end user
- Dynamic safe area handling implementation for mobile devices
### Would
- Creating prefabs for mocking view logic for unit testing so we can also test view logic like button stats and so on.
### Nice
- Styling system based on prefab variants and style bootstrapping (desire to quickly switch between styles) 
- The audio system is really simple at the moment and could be made more extendable in the near future.
- The scriptable object collections use linq queries to find specific audio clips or styles for buttons it would be better to map them to a dictionary from o(n) look up to o(1)
- Make the application more visually appealing with animations and art
- Texture/sprite atlassing (currently not used but for a bigger project and more art heavy definitely useful)
- Being able to set multiple alarms
- Being able to show multiple clocks from around the world(timezones)
## This application will be used on VR applications. Share your concern and your opinion on what needs to be taken into account to support it in VR.
- Motion sickness has to be taken into account when developing VR devices
- Ease of use implementation for interaction with the UI and the interaction devices presenter for the VR device.
- Interaction methods for UI with vr input devices.
- Setting up the UI so that it can be used for all platforms (canvas settings world space, event system, vr input system) (mobile, vr, pc)
