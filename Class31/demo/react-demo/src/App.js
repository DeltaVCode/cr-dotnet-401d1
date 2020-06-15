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
  <div class="footer">
    &copy; 2020
  </div>
);

// Class components!
class Main extends React.Component {
  render() {
    return (
      <div class="wrapper">
        <h2>Main!</h2>
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
