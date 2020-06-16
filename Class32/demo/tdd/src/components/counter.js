import React from 'react';

function Header() {
  return (<h1>Hi!</h1>)
}

export default class Counter extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      count: 0
    };
  }

  increment = () => {
    this.setState({ count: this.state.count + 1 })
  }

  render() {
    return (
      <div>
        {this.state.count > 0 && <Header />}
        <span className="count">Clicks: {this.state.count}</span>
        <button onClick={this.increment}>+1</button>
      </div>
    )
  }
}
