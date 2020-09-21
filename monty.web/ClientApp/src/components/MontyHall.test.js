import React from 'react';
import { MontyHall } from './MontyHall';
import { render, fireEvent, screen } from '@testing-library/react'

describe('monty hall tests', () => {

    test('component renders', () => {
      render(<MontyHall></MontyHall>)
      //screen.debug();
      expect(screen.getByText('The Monty Hall Problem')).toBeInTheDocument();;
    })
  
    test('true is truthy', () => {
      expect(true).toBe(true);
    });
   
    test('false is falsy', () => {
      expect(false).toBe(false);
    });
  });