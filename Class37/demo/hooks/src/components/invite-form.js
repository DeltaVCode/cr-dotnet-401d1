import React, { useState, useEffect } from 'react';

export default function InviteForm(props) {
  // this.state = { name: '' };
  let [name, setName] = useState('');
  let [dinnerPref, setDinnerPref] = useState('');
  let [guestDinnerPref, setGuestDinnerPref] = useState('');
  // { value: 'Keith', setter: function }
  // console.log('Rendering HooksCounter', { count, name })

  // Only run when name changes
  useEffect(() => {
    if (name.length > 2)
      console.log('Name changed to ' + name);
  }, [name]);

  const updateName = e => setName(e.target.value);
  const updateDinnerPref = e => setDinnerPref(e.target.value);
  const updateGuestDinnerPref = e => setGuestDinnerPref(e.target.value);

  const saveInvitation = e => {
    e.preventDefault();

    const newInvite = {
       name,
       dinnerPref,
       guestDinnerPref,
       accepted: false
       };

    props.createNewInvitation(newInvite);

    e.target.reset();
  };

  return (
    <form onSubmit={saveInvitation}>
      <label>Name: <input onChange={updateName} /></label>
      <label>Dinner Pref:
        <select onChange={updateDinnerPref}>
          <option>Chicken</option>
          <option>Beef</option>
          <option>Veggie</option>
        </select>
      </label>
      <label>Guest Dinner Pref:
        <select onChange={updateGuestDinnerPref}>
          <option></option>
          <option>Chicken</option>
          <option>Beef</option>
          <option>Veggie</option>
        </select>
      </label>
      <button>Add Invite</button>
    </form>
  );
}