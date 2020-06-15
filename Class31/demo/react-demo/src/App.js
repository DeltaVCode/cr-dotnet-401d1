import React from 'react';

// Function Component
function Header() {
  return (
    <header>
      <h1>Welcome to React!</h1>
      <nav>Links go here</nav>
    </header>
  )
}

// Another function component
const Footer = () => (
  <div className="footer">
    &copy; 2020
  </div>
);

// Class components!
class Main extends React.Component {
  constructor(props) {
    // Just do this, don't ask why yet
    super(props);

    // The only time you can assign this.state
    this.state = {
      words: 'Reverse me!',
    };
  }

  // Event handler is a class property
  handleWord = e => {
    let words = e.target.value;

    // Set words in our component state
    this.setState({ words });
    // DO NOT this.state = { words }
    console.log('__STATE__', this.state);
  }

  handleClick = e => {
    e.preventDefault();
    let words = this.state.words
      .split('').reverse().join('');

    this.setState({ words })
  }

  render() {
    // Re-rendering is automatic when state changes
    // console.log('Rendering!', this.state );
    let passwordMessage = this.state.words.length > 10 ? 'Strong!' : 'Weak!';

    return (
      <div className="wrapper">
        <h2>Main!</h2>
        <h3>Words: {this.state.words}</h3>
        <input onChange={this.handleWord}/>
        <button onClick={this.handleClick}>Reverse</button>
        <div>Password strength: {passwordMessage}</div>
      </div>
    )
  }
}

class App extends React.Component{
  render() {
    // <> is a Fragment; can't return multiple things
    return (
      <>
        <Header/>
        <Main />
        <Footer />
      </>
    );
  }
}

export default App;
