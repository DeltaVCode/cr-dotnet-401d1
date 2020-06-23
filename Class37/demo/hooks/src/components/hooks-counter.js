import React, { useState, useEffect } from 'react';
import InviteForm from './invite-form';

export default function Counter(props) {
  // Destructuring allows specifying default value
  // const initialCount = props.initialCount || 0;
  const { initialCount = 0 } = props;

  // let count = initialCount;
  let [count, setCount] = useState(initialCount);

  let [invites, setInvites] = useState([]);

  // Only run once (no dependencies to trigger re-run)
  useEffect(() => {
    console.log('componentDidMount-ish');

    // Function returned from useEffect is called at the end
    // e.g. to cancel a fetch that didn't finish
    return () => {
      console.log('componentWillUnmount-ish');
    };
  }, []);

  // Effect on every render, non-blocking!
  useEffect(() => {
    console.log('componentDidUpdate-ish');
  });

  // Only run when count changes
  useEffect(() => {
    console.log('Count changed')
    setTimeout(() => {
      document.title = 'Count: ' + count;
    }, 500)
  }, [count]);

  const increment = () => {
    // Doesn't work
    // count++;
    // console.log(count);

    // like setState(count => count + 1)
    setCount(count + 1);
  };

  const saveInvite = newInvite => {
    let newInvites = [...invites, newInvite];
    setInvites(newInvites);
  }

  const acceptInvitation = indexToUpdate => {
    let updatedInvites = invites.map((invite, i) => {
      // could match on id instead
      if (i !== indexToUpdate) {
        // Return existing invite unchanged
        return invite;
      }

      // This is the invite to update, let's make a new one
      return { ...invite, accepted: true };
    });
    console.log(updatedInvites);
    setInvites(updatedInvites);
  };

  return (
    <div>
      <h2>Hooks Based Count: {count}</h2>
      <button onClick={increment}>
        Update Counter
      </button>
      <InviteForm createNewInvitation={saveInvite} />
      <ul>
        {invites.map((invite, index) => (
          <li key={index}>
            {invite.name} (Accepted: {invite.accepted.toString()})
            <button onClick={() => acceptInvitation(index)}>Accept</button>
          </li>
        ))}
      </ul>
    </div>
  );
}