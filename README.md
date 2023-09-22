# smartphone-clock-application
Smartphone clock application
## Tools
- Unity 2021.3.4f1
- Zenject
- UniRX
- NSubstitute
- Nunit

## Architecture
- MVVP architecture using dependency injection
- Model -> contains the data shown to the user
- View controller -> Entry point for every page in the application
- View -> visual representation of the data provided by the presenter
- Presenter -> responsible for loading and changing the data and sending it to the view.

### Main folder structure
- script/test: Core folders contain generic implementations like object pooling, base view, base presenter, base view controller
- script/test: MobileClock contains the specific implementation for the different pages: clock, timer. stopwatch
- script/test: Audio is the audio system used
- Textures
- Prefabs
- Audio folder containing audio files
- Scriptable objects used as settings for different elements in the game for example button styles and audio definitions
- Scenes
- Resources

## Tested
- Samsung s9
- Ipad pro M1 
- Windows pc
- Macbook M1 generation

## iOS/iPad devices. Do you have any concerns for UI?
- Depending on the requirements landscape vs portrait mode ui design and implementation needs to be taken into account.
- Mobile devices support a vast range of screen resolution and sizes and can be difficult within unity to get right, a system to make this more easier or automatically adjustable from code is favorable like a screen wrapper.
## How would you refactor the code and/or project after release? What would you prioritize as “must happen” versus “nice to have” changes
### Must
- Requirements for different devices it has to support (landscape/portrait/vs/mobile/pc)
- Global navigation structure (navigation controller) Currently all pages are present in the scene but it is more favorable to have one system that can create the pages on startup this would also allow for the creation of different views or settings based on the user's device. The views can then be determined based on Zenject or with a unity addressable system for resource and memory management.
- UX design for the UI
### Nice
- Styling system based on prefab variants and style boostrapping (desire to qucikly switch between styles) 
- The audio system is really simple at the moment and could be made more extendable in the near future.
- The scriptable object collections use linq queries to find specific audio clips or styles for buttons it would be better to map them to a dictionary from o(n) look up to o(1) 
## This application will be used on VR applications. Share your concern and your opinion on what needs to be taken into account to support it in VR.
### Must
- Motion sickness has to be taken into account when developing VR devices
- Ease of use implementation for interaction with the UI and the interaction devices presenter for the VR device.
- Interaction methods for UI
- Setting up the UI so that it can be used for all platforms (canvas settings, event system, vr input system) (mobile, vr, pc)
### Nice
