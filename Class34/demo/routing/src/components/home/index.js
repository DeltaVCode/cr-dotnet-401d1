import React from 'react';
import { Link } from 'react-router-dom';
import { If } from '../if';
import Modal from '../modal';

class Home extends React.Component {
  constructor() {
    super();

    this.state = {
      showContactUs: false,
    };
  }

  toggleContactUsModal = () => {
    this.setState(oldState => ({ showContactUs: !oldState.showContactUs }));
  }

  render() {
    const { showContactUs } = this.state;

    return (
      <>
        <h2>Welcome</h2>
        <p>You might be interested in our <Link to="/users">Users</Link></p>

        <button onClick={this.toggleContactUsModal}>Contact Us</button>

        <If condition={showContactUs}>
          <Modal title="Contact Us" onClose={this.toggleContactUsModal}>
            Google me, dummy
          </Modal>
        </If>
      </>
    )
  }
}

export default Home;
