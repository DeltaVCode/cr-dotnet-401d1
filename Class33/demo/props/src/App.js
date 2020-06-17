import React from 'react';

class App extends React.Component {
  constructor(props)
  {
    super(props);

    this.state = {
      number: 7,
    }
  }

  render(){
    return (
      <div className="App">
        <NumberHeader luckyNumber={this.state.number} />
      </div>
    );
  }
}

function NumberHeader(props) {
  return (
    <h1 style={{color: 'green'}}>Your Lucky Number is {props.luckyNumber}</h1>
  )
}

export default App;
