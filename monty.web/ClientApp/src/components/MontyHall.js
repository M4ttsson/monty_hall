import React, { Component } from 'react';
import axios from 'axios';

export class MontyHall extends Component {
  static displayName = MontyHall.name;

  constructor(props) {
    super(props);
    this.state = { 
      numberOfSim: 10,
      chosenDoor: 0,
      changeDoor: false,
      running: false,
      goats: 0,
      cars: 0
    };
    this.handleInputChange = this.handleInputChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
    //this.incrementCounter = this.incrementCounter.bind(this);
  }

/*   incrementCounter() {
    this.setState({
      currentCount: this.state.currentCount + 1
    });
  }
 */
  handleSubmit(event) {
    event.preventDefault();
    this.runSimulation();
  }

  async runSimulation() {
    const simRequest = { 
      numOfSimulations: this.state.numberOfSim, 
      chosenDoor: parseInt(this.state.chosenDoor),
      changeDoor: this.state.changeDoor
    };
    const headers = {
      'Content-Type': 'application/json'
    }

    try {
      this.setState({
        running: true
      });
      const response = await axios.post('simulation', simRequest, {headers});
      console.log(response);

      this.setState({
        goats: response.data.goats,
        cars: response.data.cars,
        running: false
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

      // TODO: Show error response for user!
    }


    //this.setState({ forecasts: data, loading: false });

  }
  

  handleInputChange(event) {
    const target = event.target;
    const value = target.type === 'checkbox' ? target.checked : target.value;
    const name = target.name;

    this.setState({
      [name]: value
    });
  }

  render() {
    return (
      <div>
        <h1>The Monty Hall Problem</h1>

        <p>The Monty Hall problem is a brain teaser, in the form of a probability puzzle, loosely based on the American television game show Let's Make a Deal and named after its original host, Monty Hall.</p>
        <p>Suppose you're on a game show, and you're given the choice of three doors: Behind one door is a car; behind the others, goats. You pick a door, say No. 1, and the host, who knows what's behind the doors, opens another door, say No. 3, which has a goat. He then says to you, "Do you want to pick door No. 2?" Is it to your advantage to switch your choice?</p>
        <p><strong>This is a simulation of the problem so you can test your strategy, change door or not as well as which door to choose in case you have to do it for real one day in the future</strong></p>
      

        <form onSubmit={this.handleSubmit}>
          <div className="form-group">
            <label htmlFor="numOfSimulations">Number of simulations</label> 
            <input type="number" className="form-control" id="numOfSimulations" name="numberOfSim" defaultValue={this.state.numberOfSim} onChange={this.handleInputChange}/>
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

          {/* <div className="form-group">
            <label htmlFor="formControlRange">Example Range input</label>
            <input type="range" className="form-control-range" id="formControlRange" max="3" min="1"/>
          </div> */}
          
          <button type="submit" className="btn btn-primary">Run simulation</button>
          
          
        </form>


        {/* <p aria-live="polite">Current count: <strong>{this.state.currentCount}</strong></p>

        <button className="btn btn-primary" onClick={this.incrementCounter}>Increment</button> */}
      </div>
    );
  }
}
