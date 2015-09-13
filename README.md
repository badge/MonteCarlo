# Monte Carlo European Option Pricing Model

This is a *very* basic Monte Carlo European Option Pricing Model, written in C# with a WinForms front end. The application is split into three parts:

- **Simulator** This is the model for the application proper, described in more detail below
- **View** This is the GUI for the application; a derived type of *Form*. Its code manages basic input validation and exposes the charts to the presenter
- **Presenter** The presenter acts as an interface between the Simulator and the View. It binds the events in the view to methods in the Simulator, and vice versa. When a simulation is complete it is responsible for generating the series for the two charts

## The Simulator

The `Simulator` class exists in the MonteCarlo.Model namespace. All this class does is set up the required number of instances of the `SimulatedPrice` path and runs them in parallel to generate spot price curves. The `SimulatedPrice` class has a number of static variables that reflect the initial state of the model--the spot price and strike price, mu and sigma, and the type of *discretization scheme* that is to be used by the model. It creates a `double` array of the required size and uses the given discretization scheme to calculate subsequent values in the array.

Discretization schemes implement the `IDiscretizationScheme` interface, which defines one property (the name of the scheme) and one method, `Increment`, which takes and returns a `double`. There are two discretization schemes currently defined in the model, Euler and Milstein. Each uses the `GaussianBoxMuller` class to generate a normally-distributed random number. This in turn uses the `RandomProvider` class to generate a threadsafe random number.