import React, { useState, useEffect } from 'react';
import useForm from '../hooks/form';

export default function InviteForm(props) {
  let [handleSubmit, handleChange, values] =
    useForm(saveFromHook);

  function saveFromHook(formValues) {
    props.createNewInvitation({
      ...formValues,
      accepted: false,
    });
  }

  let name = values.name;
  useEffect(() => {
    document.title = `New Invite: ${name}`
  }, [name]);

  return (
    <form onSubmit={handleSubmit}>
      <label>
        Name: 
        <input name='name' onChange={handleChange} /></label>
      <label>Dinner Pref:
        <select name='dinnerPref' onChange={handleChange}>
          <option>Chicken</option>
          <option>Beef</option>
          <option>Veggie</option>
        </select>
      </label>
      <label>Guest Dinner Pref:
        <select name='guestDinnerPref' onChange={handleChange}>
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