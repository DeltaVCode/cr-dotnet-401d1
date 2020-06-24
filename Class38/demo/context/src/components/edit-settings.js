import React from 'react';
import useForm from '../hooks/form';
import useSettings from '../contexts/settings';

export default function EditSettings() {
  // using form here is complicated
  // const [handleSubmit, handleChange] = useForm();
  const { twitter, title, setTitle, setTwitter } = useSettings();

  return (
    <>
      <p><label>
        Title: 
        <input onChange={e => setTitle(e.target.value)} value={title} />
        </label></p>
      <p><label>
        Twitter: 
        <input onChange={e => setTwitter(e.target.value)} value={twitter} />
      </label></p>
    </>
  )
}