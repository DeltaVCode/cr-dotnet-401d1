import React, { useContext } from 'react';

import { SettingsContext } from '../contexts/settings';
import EditSettings from './edit-settings';

export default function ContextDemo() {
  return (
    <>
      <EditSettings />
      <SettingsFromDirectHook />
      <SettingsFromStaticContext />
      <SettingsFromConsumer />
    </>
  );
}

// Option 1: use hooks, it's easier
function SettingsFromDirectHook() {
  const context = useContext(SettingsContext);

  return(
    <>
      <h2>Static Context</h2>
      <p>Title: {context.title}</p>
    </>
  )
}

// Option 2: static contextType property
class SettingsFromStaticContext extends React.Component {
  static contextType = SettingsContext;

  render() {
    console.log(this.context);
    const { title } = this.context;

    return (
      <>
        <h2>Static Context</h2>
        <p>Title: {title}</p>
      </>
    );
  }
}

// Option 2a: set like this
// SettingsFromStaticContext.contextType = SettingsContext;

// Option 3: Consumer
class SettingsFromConsumer extends React.Component {
  render() {
    return (
      <div>
        <SettingsContext.Consumer>
          {context => (
            <>
              <h2>Settings from Consumer</h2>
              <p>Title: {context.title}</p>
            </>
          )}
        </SettingsContext.Consumer>
      </div>
    )
  }
}
