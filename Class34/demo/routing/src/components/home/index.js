import React from 'react';
import { Link } from 'react-router-dom';

class Home extends React.Component {
  render() {
    return (
      <>
        <h2>Welcome</h2>
        <p>You might be interested in our <Link to="/users">Users</Link></p>
      </>
    )
  }
}

export default Home;
