import React from 'react';

function App() {
  return (
    <div className="App">
      <NumberHeader luckyNumber={42} />
    </div>
  );
}

function NumberHeader(props) {
  return (
    <h1 style={{color: 'green'}}>Your Lucky Number is {props.luckyNumber}</h1>
  )
}

export default App;
