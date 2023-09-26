# smartphone-clock-application
Documentation for the architecture used for this smartphone clock application.

![Timer](https://github.com/joelnl74/smartphone-clock-application/assets/9337898/ca83257e-26cb-4067-a88a-80e9c1b019bb)
![Clock](https://github.com/joelnl74/smartphone-clock-application/assets/9337898/f2911fef-366d-47f2-880e-5a427b2cd97b)
![Stopwatch](https://github.com/joelnl74/smartphone-clock-application/assets/9337898/9b39a4bb-715d-497a-aa5e-b54da7f130e5)

## Tools
- Unity 2021.3.4f1
- Zenject
- UniRX
- NSubstitute
- NUnit

## Assembly definitions
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
- MVVP architecture using dependency injection and uniRX
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
- Installers (Zenject dependencies binding) AudioMonoInstaller, MobileTimerMonoInstaller, MainMonoInstaller
### Base classes
- Every presenter inherits from the class Presenter which contains a method to bind a generic view
- Every view controller inherits from the view controller which makes sure contract interfaces are respected and can bind the view to the presenters (the view has no information about the presenter)
- Every view inherits from base view 
- Motion sickness has to be taken into account when developing VR devices
- Ease of use implementation for interaction with the UI and the interaction devices presenter for the VR device.
- Interaction methods for UI with VR input devices.
- Setting up the UI so that it can be used for VR platforms (canvas settings world space, event system, VR input systems(gaze, remote controllers, raycasters)
