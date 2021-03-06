import React, { Component } from 'react';
import axios from 'axios';
import { Progress } from 'reactstrap';

export class MontyHall extends Component {
  static displayName = MontyHall.name;

  constructor(props) {
    super(props);
    this.state = { 
      numberOfSim: 10,
      chosenDoor: 0,
      changeDoor: false,
      running: false,
      showResult: false,
      showValidationError: false,
      showError: false,
      goats: 0,
      cars: 0
    };
    this.handleInputChange = this.handleInputChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);

  }

  handleSubmit(event) {
    event.preventDefault();
    if (this.validateForm()) {
      this.setState({
        running: true,
        showError: false,
        showResult: false
      });

      this.runSimulation();
    }
    
  }

  async runSimulation() {
    const simRequest = { 
      numOfSimulations: parseInt(this.state.numberOfSim), 
      chosenDoor: parseInt(this.state.chosenDoor),
      changeDoor: this.state.changeDoor
    };
    const headers = {
      'Content-Type': 'application/json'
    }

    try {
      const response = await axios.post('simulation', simRequest, {headers});
      console.log(response);

      this.setState({
        goats: response.data.goats,
        cars: response.data.cars,
        running: false,
        showResult: true,
      });
    } 
    catch (error) {
      if (error.response) {
        // got a status code
        console.log(error.response.data);
        console.log(error.response.status);
      }
      else {
        console.log('Error', error);
      }

      this.setState({
        showResult: false,
        running: false,
        showError: true
      })
     
    }

  }
  

  handleInputChange(event) {
    const target = event.target;
    const value = target.type === 'checkbox' ? target.checked : target.value;
    const name = target.name;

    this.setState({
      [name]: value
    });
  }

  showError(){
    return (
      <div className="error">
        Something went wrong, please try again!
      </div>
    )
  }

  validateForm(){
    let isValid = true;
    // This should probably be done in a other way?
    if (this.state.numberOfSim <= 0){
      isValid = false;
    }
    this.setState({
      showValidationError: !isValid // TODO: fix, this is ugly...
    });
    return isValid;
  }

  showSimulationForm() {
    return (
        <div id="simulationForm">
          <form onSubmit={this.handleSubmit} className="needs-validation" noValidate>
            <div className="form-group">
              <label htmlFor="numOfSimulations">Number of simulations</label> 
              <input type="number" className="form-control" id="numOfSimulations" name="numberOfSim" defaultValue={this.state.numberOfSim} onChange={this.handleInputChange}/>
              {
                this.state.showValidationError 
                ? <div className="invalid">Please input value above 0</div>  
                : null
              }
                         
            </div>
            <div className="form-check">
              <div className="row">
                <div className="col">
                  <input className="form-check-input" type="radio" name="chosenDoor" id="door1" value="0" defaultChecked="true"  onChange={this.handleInputChange} />
                  <label className="form-check-label" htmlFor="door1">
                    Door 1
                  </label>
                </div>
                <div className="col">
                  <input className="form-check-input" type="radio" name="chosenDoor" id="door2" value="1" onChange={this.handleInputChange} />
                  <label className="form-check-label" htmlFor="door2">
                    Door 2
                  </label>
                </div>
                <div className="col">
                  <input className="form-check-input" type="radio" name="chosenDoor" id="door3" value="2"  onChange={this.handleInputChange} />
                  <label className="form-check-label" htmlFor="door3">
                    Door 3
                  </label>
                </div>
              </div>
            </div>
            
            <div className="form-group form-check">
              <input type="checkbox" className="form-check-input" id="changeDoor" name="changeDoor" onChange={this.handleInputChange}/>
              <label className="form-check-label" htmlFor="changeDoor">Change door</label>
            </div>
            
            <button type="submit" className="btn btn-primary">Run simulation</button>
          </form>
        </div>
    )
  }

  showResult()
  {
    return (        
    <div id="simulationResult">
      <h2>Result</h2>
      <div className="text-left">Won number of cars</div>
      <Progress bar color="success" value={this.state.cars} max={this.state.numberOfSim}>{this.state.cars}</Progress>
      <div className="text-left">Won number of goats</div>
      <Progress bar color="danger" value={this.state.goats} max={this.state.numberOfSim}>{this.state.goats}</Progress>

    </div>)
    // TODO: Known bug, progressbar will change size immediately
  }

  showRunningProgress()
  {
    return (
      <div>
        <Progress animated color="info" value="100">Running Simulations</Progress>
      </div>
    )
  }


  render() {
    return (
      <div>
        <h1>The Monty Hall Problem</h1>

        <p>The Monty Hall problem is a brain teaser, in the form of a probability puzzle, loosely based on the American television game show Let's Make a Deal and named after its original host, Monty Hall.</p>
        <p>Suppose you're on a game show, and you're given the choice of three doors: Behind one door is a car; behind the others, goats. You pick a door, say No. 1, and the host, who knows what's behind the doors, opens another door, say No. 3, which has a goat. He then says to you, "Do you want to pick door No. 2?" Is it to your advantage to switch your choice?</p>
        <p><strong>This is a simulation of the problem so you can test your strategy, change door or not as well as which door to choose in case you have to do it for real one day in the future</strong></p>
      
        { this.showSimulationForm() }
        <br></br>
        {
          this.state.running
          ? this.showRunningProgress()
          : null
        }
        {
          this.state.showResult 
          ? this.showResult()
          : null
        }
        {
          this.state.showError
          ? this.showError()
          : null
        }
      </div>
    );
  }
}