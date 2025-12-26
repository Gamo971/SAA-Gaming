package com.starpanel.app.ui.components

import androidx.compose.foundation.layout.*
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.filled.*
import androidx.compose.material3.*
import androidx.compose.runtime.Composable
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.unit.dp

@Composable
fun ConnectionStatus(
    isConnected: Boolean,
    isSearching: Boolean,
    latency: Int?
) {
    Row(
        verticalAlignment = Alignment.CenterVertically,
        horizontalArrangement = Arrangement.spacedBy(8.dp)
    ) {
        Icon(
            imageVector = when {
                isConnected -> Icons.Default.CheckCircle
                isSearching -> Icons.Default.Search
                else -> Icons.Default.Error
            },
            contentDescription = null,
            tint = when {
                isConnected -> MaterialTheme.colorScheme.primary
                isSearching -> MaterialTheme.colorScheme.secondary
                else -> MaterialTheme.colorScheme.error
            }
        )
        
        Text(
            text = when {
                isConnected -> "Connecté"
                isSearching -> "Recherche..."
                else -> "Déconnecté"
            },
            style = MaterialTheme.typography.bodyMedium
        )
        
        if (isConnected && latency != null) {
            Text(
                text = "${latency}ms",
                style = MaterialTheme.typography.bodySmall,
                color = MaterialTheme.colorScheme.secondary
            )
        }
    }
}
