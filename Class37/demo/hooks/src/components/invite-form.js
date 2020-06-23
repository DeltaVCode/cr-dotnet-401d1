import React, { useState, useEffect } from 'react';

export default function InviteForm(props) {
  // this.state = { name: '' };
  let [name, setName] = useState('');
  // { value: 'Keith', setter: function }
  // console.log('Rendering HooksCounter', { count, name })

  // Only run when name changes
  useEffect(() => {
    if (name.length > 2)
      console.log('Name changed to ' + name);
  }, [name]);

  const updateName = e => setName(e.target.value);

  const saveInvitation = e => {
    e.preventDefault();

    const newInvite = { name, accepted: false };

    props.createNewInvitation(newInvite);

    e.target.reset();
  };

  return (
    <form onSubmit={saveInvitation}>
      <input onChange={updateName} />
      <div>Name: {name}</div>
    </form>
  );
}