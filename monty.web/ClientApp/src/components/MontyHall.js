import React, { Component } from 'react';

export class MontyHall extends Component {
  static displayName = MontyHall.name;

  constructor(props) {
    super(props);
    this.state = { currentCount: 0 }; // TODO: Fix the state
    this.incrementCounter = this.incrementCounter.bind(this);
  }

  incrementCounter() {
    this.setState({
      currentCount: this.state.currentCount + 1
    });
  }

  handleSubmit(event) {
    console.log("submit");
    event.preventDefault();
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
            <input type="number" defaultValue="10" className="form-control" id="numOfSimulations"/>
          </div>
          <div className="form-check">
            <div className="row">
              <div className="col">
                <input className="form-check-input" type="radio" name="doorRadios" id="door1" value="0" />
                <label className="form-check-label" htmlFor="door1">
                  Door 1
                </label>
              </div>
              <div className="col">
                <input className="form-check-input" type="radio" name="doorRadios" id="door2" value="1" />
                <label className="form-check-label" htmlFor="door2">
                  Door 2
                </label>
              </div>
              <div className="col">
                <input className="form-check-input" type="radio" name="doorRadios" id="door3" value="2" />
                <label className="form-check-label" htmlFor="door3">
                  Door 3
                </label>
              </div>
            </div>
          </div>
          
          <div className="form-group form-check">
            <input type="checkbox" className="form-check-input" id="changeDoor"/>
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
