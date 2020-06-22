import React from 'react';

export default class Counter extends React.Component {
  constructor(props)
  {
    super(props);

    this.state = {
      count: props.initialCount || 0,
    };
  }

  increment = () => {
    this.setState(
      // destructure state parameter
      ({ count }) =>
        ({ count: count + 1 })
    );
  }

  render() {
    const { count } = this.state;

    return (
      <div>
        <h2>Class Based Count: {count}</h2>
        <button onClick={this.increment}>
          Update Counter
        </button>
      </div>
    );
  }
  
  componentDidMount() {
    console.log('componentDidMount');
    document.title = `Class count: ${this.state.count}`;
  }

  componentDidUpdate() {
    console.log('componentDidUpdate');
    document.title = `Class count: ${this.state.count}`;
  }

  componentWillUnmount() {
    console.log('componentWillUnmount');
  }
}