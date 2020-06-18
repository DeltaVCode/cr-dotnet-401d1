import React from 'react';

class Numbers extends React.Component {
  constructor(props)
  {
    super(props);

    this.state = {
      number: 7,
    }
  }

  updateNumber = num => {
    console.log('New Number', num);
    this.setState({ number: num });
    console.log('App State', this.state);
  }

  logAll = whatever => {
    console.log('LOG ALL', whatever);
  }

  render(){
    console.log('Render State', this.state);
    return (
      <div className="App">
        <NumberHeader luckyNumber={this.state.number} />
        <NumberForm defaultNumber={this.state.number}
          saveNumber={this.updateNumber}
          saveAll={this.logAll}
          />
      </div>
    );
  }
}

function NumberHeader(props) {
  return (
    <h1 style={{color: 'green'}}>Your Lucky Number is {props.luckyNumber}</h1>
  )
}

class NumberForm extends React.Component{
  constructor (props){
    super(props);

    this.state = {
      inputNumber: props.defaultNumber || 0,
    };
  }

  numberChange = e => {
    this.setState({ inputNumber: e.target.value })
    console.log(this.state);
  }

  handleSubmit = e => {
    e.preventDefault();
    console.log('SUBMIT!', this.state);
    this.props.saveNumber(this.state.inputNumber);
    this.props.saveAll(this.state);
  }

  render(){
    return (
      <form onSubmit={this.handleSubmit}>
        <input value={this.state.inputNumber}
          onChange={this.numberChange}
          />
        <button type="submit">Save</button>
      </form>
    )
  }
}

export default Numbers;
