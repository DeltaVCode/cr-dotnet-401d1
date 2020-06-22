import React, { useState } from 'react';

export default function Counter(props) {
  // Destructuring allows specifying default value
  // const initialCount = props.initialCount || 0;
  const { initialCount = 0 } = props;

  // let count = initialCount;
  let [count, setCount] = useState(initialCount);

  // this.state = { name: '' };
  let [name, setName] = useState('');
  // { value: 'Keith', setter: function }
  console.log('Rendering HooksCounter', { count, name })

  const updateName = e => setName(e.target.value);

  const increment = () => {
    // Doesn't work
    // count++;
    // console.log(count);

    // like setState(count => count + 1)
    setCount(count + 1);
  };

  return (
    <div>
      <h2>Hooks Based Count: {count}</h2>
      <button onClick={increment}>
        Update Counter
      </button>
      <fieldset>
        <input onChange={updateName} />
        <div>Name: {name}</div>
      </fieldset>
    </div>
  );
}