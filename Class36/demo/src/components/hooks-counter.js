import React from 'react';

export default function Counter(props) {
  // Destructuring allows specifying default value
  const { initialCount = 0 } = props;

  let count = initialCount;

  const increment = () => {
    // Doesn't work
    count++;
  };

  return (
    <div>
      <h2>Hooks Based Count: {count}</h2>
      <button onClick={increment}>
        Update Counter
      </button>
    </div>
  );
}