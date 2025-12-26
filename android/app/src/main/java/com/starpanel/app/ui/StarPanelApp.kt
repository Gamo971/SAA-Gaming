package com.starpanel.app.ui

import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.material3.MaterialTheme
import androidx.compose.material3.Surface
import androidx.compose.runtime.Composable
import androidx.compose.ui.Modifier
import androidx.navigation.compose.NavHost
import androidx.navigation.compose.composable
import androidx.navigation.compose.rememberNavController
import com.starpanel.app.ui.connection.ConnectionScreen
import com.starpanel.app.ui.runtime.RuntimeScreen

@Composable
fun StarPanelApp() {
    val navController = rememberNavController()

    Surface(
        modifier = Modifier.fillMaxSize(),
        color = MaterialTheme.colorScheme.background
    ) {
        NavHost(
            navController = navController,
            startDestination = "connection"
        ) {
            composable("connection") {
                ConnectionScreen(
                    onConnected = {
                        navController.navigate("runtime") {
                            popUpTo("connection") { inclusive = true }
                        }
                    }
                )
            }
            composable("runtime") {
                RuntimeScreen()
            }
        }
    }
}
