import { useState, useEffect } from 'react';

// const [isLoading, data] = useFetch(url)

function useFetch(url) {
  const [isLoading, setLoading] = useState(true);
  const [data, setData] = useState(null);

  useEffect(() => {
    async function doFetch() {
      setLoading(true);
      let response = await fetch(url);
      let json = await response.json();
      setData(json);
      setLoading(false);
    }

    doFetch();
  }, [url]);

  return [
    isLoading,
    data,
  ];
}

export default useFetch;
