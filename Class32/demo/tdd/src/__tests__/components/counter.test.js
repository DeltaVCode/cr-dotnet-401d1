import React from 'react';
import { shallow, mount } from 'enzyme';

import Counter from '../../components/counter';

describe('<Counter />', () => {

  // This is a [Fact]
  it('initial count is zero', () => {
    // Arrange
    let app = shallow(<Counter />);

    // Assert
    expect(app.find('span.count').text()).toBe('0');
  });

  it('can increment counter', () => {
    // Arrange
    let app = shallow(<Counter />);

    // Act
    let button = app.find('button');
    button.simulate('click');

    // Assert
    expect(app.find('span.count').text()).toBe('1');
  });

  it('has a Header', () => {
    let app = shallow(<Counter />);

    expect(app.find('Header').exists()).toBe(true);
  })

  // mount is more expensive and renders child components
  it('has an h1', () => {
    let app = mount(<Counter />);

    expect(app.find('h1').exists()).toBe(true);
  })
})
