import { useState } from 'react';

// Usage: useForm(saveItem)

export default function useForm(onSubmit) {

  const [values, setValues] = useState({});
  // { name: 'Keith', dinnerPrefs: 'Chicken' }

  const handleSubmit = e => {
    e.preventDefault();
    onSubmit(values);
  }

  const handleChange = e => {
    const { name, value } = e.target;
    setValues(values => ({
      ...values,
      [name]: value,
    }));
  }

  return [
    handleSubmit,
    handleChange,
    values,
  ];
}
