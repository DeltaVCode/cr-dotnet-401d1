import React, { useState, useEffect } from 'react';

export default function Counter(props) {
  // Destructuring allows specifying default value
  // const initialCount = props.initialCount || 0;
  const { initialCount = 0 } = props;

  // let count = initialCount;
  let [count, setCount] = useState(initialCount);

  // this.state = { name: '' };
  let [name, setName] = useState('');
  // { value: 'Keith', setter: function }
  // console.log('Rendering HooksCounter', { count, name })

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

  // Only run when name changes
  useEffect(() => {
    if (name.length > 2)
      console.log('Name changed to ' + name);
  }, [name]);

  // Only run when count changes
  useEffect(() => {
    console.log('Count changed')
    setTimeout(() => {
      document.title = 'Count: ' + count;
    }, 500)
  }, [count]);

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