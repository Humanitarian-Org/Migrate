const ModuleFederationPlugin = require('@module-federation/webpack');
const HtmlWebpackPlugin = require('html-webpack-plugin');
const path = require('path');

module.exports = (env, argv) => {
  const isProduction = argv.mode === 'production';
  
  return {
    mode: argv.mode || 'development',
    entry: './src/index.ts',
    target: 'web',
    
    devServer: {
      port: 3001,
      historyApiFallback: true,
      hot: true,
      headers: {
        'Access-Control-Allow-Origin': '*',
        'Access-Control-Allow-Methods': 'GET, POST, PUT, DELETE, PATCH, OPTIONS',
        'Access-Control-Allow-Headers': 'X-Requested-With, content-type, Authorization',
      },
      // Proxy API calls to Platform domain
      proxy: {
        '/api': {
          target: 'http://localhost:7071',
          changeOrigin: true,
        },
        // Proxy beneficiary-specific APIs to Beneficiary domain
        '/api/beneficiary': {
          target: 'http://localhost:7074', 
          changeOrigin: true,
        },
      },
    },
    
    resolve: {
      extensions: ['.tsx', '.ts', '.js', '.jsx'],
    },
    
    module: {
      rules: [
        {
          test: /\.tsx?$/,
          use: 'ts-loader',
          exclude: /node_modules/,
        },
        {
          test: /\.css$/,
          use: ['style-loader', 'css-loader'],
        },
      ],
    },
    
    plugins: [
      // Module Federation Plugin - REMOTE
      new ModuleFederationPlugin({
        name: 'beneficiaryUI',
        filename: 'remoteEntry.js',
        exposes: {
          // Expose the bulk import details page
          './BulkImportDetails': './src/pages/BulkImportDetails',
          // Expose other beneficiary components 
          './BeneficiaryComponents': './src/components/BeneficiaryComponents',
          // Expose routing configuration
          './BeneficiaryRoutes': './src/routes/BeneficiaryRoutes',
        },
        shared: {
          react: { 
            singleton: true, 
            requiredVersion: '^18.2.0',
            eager: true 
          },
          'react-dom': { 
            singleton: true, 
            requiredVersion: '^18.2.0',
            eager: true 
          },
          'react-router-dom': { 
            singleton: true, 
            requiredVersion: '^6.8.0' 
          },
          '@mui/material': { 
            singleton: true, 
            requiredVersion: '^5.11.0' 
          },
          '@mui/icons-material': { 
            singleton: true, 
            requiredVersion: '^5.11.0' 
          },
          '@emotion/react': { 
            singleton: true, 
            requiredVersion: '^11.10.5' 
          },
          '@emotion/styled': { 
            singleton: true, 
            requiredVersion: '^11.10.5' 
          },
        },
      }),
      
      new HtmlWebpackPlugin({
        template: './public/index.html',
        title: 'Humanitarian.org Beneficiary UI',
      }),
    ],
    
    optimization: {
      splitChunks: false,
    },
  };
};