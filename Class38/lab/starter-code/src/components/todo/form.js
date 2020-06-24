import React from 'react';
import useForm from '../../hooks/form.js';

const TodoForm = props => {

  const { handleChange, handleSubmit } = useForm(onSubmit);

  function onSubmit(formValues) {
    props.handleSubmit({
      ...formValues,
      difficulty: formValues.difficulty ? parseInt(formValues.difficulty) : 5,
    });
  }

  return (
    <>
      <h3>Add Item</h3>
      <form onSubmit={handleSubmit}>
        <label>
          <span>To Do Item</span>
          <input
            name="title"
            placeholder="Add To Do List Item"
            onChange={handleChange}
          />
        </label>
        <label>
          <span>Difficulty Rating</span>
          <input type="range" min="1" max="5" name="difficulty" onChange={handleChange} />
        </label>
        <label>
          <span>Assigned To</span>
          <input type="title" name="assignedTo" placeholder="Assigned To" onChange={handleChange} />
        </label>
        <button>Add Item</button>
      </form>
    </>
  );
};

export default TodoForm;
